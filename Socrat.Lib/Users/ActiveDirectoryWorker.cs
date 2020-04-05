using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Socrat.Log;

namespace Socrat.Lib.Users
{
    public class ActiveDirectoryWorker
    {
        private List<AdDomain> _domains = null;
        public List<AdDomain> Domains
        {
            get { return GetDomains(); }
            set { _domains = value; }
        }


        public AdDomain CurrentDomain
        {
            get
            {
                return Domains.FirstOrDefault(itm => itm.ShortName.ToLower() == Environment.UserDomainName.ToLower());
            }
        }

        private List<AdDomain> GetDomains()
        {
            if (_domains == null)
                _domains = new List<AdDomain>();

            if (_domains.Count < 1)
            {
                string _domain = Environment.UserDomainName;
                _domains.Add(new AdDomain() { FullName = _domain + ".rglass.loc", ShortName = _domain });

                DirectoryEntry _entry = new DirectoryEntry(@"LDAP://" + _domain);
                DirectorySearcher _searcher = new DirectorySearcher(_entry);
                _searcher.Filter = "(&(objectClass=trustedDomain))";
                SearchResultCollection _results = _searcher.FindAll();
                foreach (SearchResult _res in _results)
                {
                    _domains.Add(new AdDomain
                    {
                        FullName = _res.Properties["name"][0].ToString(),
                        ShortName = _res.Properties["flatName"][0].ToString()
                    });
                }
            }

            return _domains;
        }

        public List<User> GetDomainUsers(string domainName)
        {
            List<User> _users = new List<User>();

            try
            {
                string str = string.Format(@"LDAP://{0}.rglass.loc/OU={1},DC={0},DC=rglass,DC=loc", 
                    domainName.ToLower(), domainName.ToUpper());
                DirectoryEntry _entry = new DirectoryEntry(str);
                DirectorySearcher _searcher = new DirectorySearcher(_entry);
                _searcher.Filter = "(&(objectClass=user))";
                SearchResultCollection _results = _searcher.FindAll();
                foreach (SearchResult _res in _results)
                {
                    _users.Add(new User
                    {
                        DisplayName = GetProperty(_res.Properties["cn"]),
                        DepartmentName = GetProperty(_res.Properties["department"]),
                        Mail = GetProperty(_res.Properties["mail"]),
                        Login = GetProperty(_res.Properties["samaccountname"]),
                        Mobile = GetProperty(_res.Properties["mobile"]),
                        Position = GetProperty(_res.Properties["title"]),
                        Domain = domainName
                    });
                }
            }
            catch (Exception ex)
            {
                Logger.AddErrorEx("GetDomainUsers", ex);
            }

            _users.Sort(Comparison);

            return _users;
        }

        private int Comparison(User x, User y)
        {
            return x.DisplayName.CompareTo(y.DisplayName);
        }

        private string GetProperty(ResultPropertyValueCollection resProperty)
        {
            if (resProperty.Count > 0)
                return resProperty[0].ToString();
            return string.Empty;
        }


        public void Test()
        {
            List<User> _users = GetDomainUsers("spo");
            
        }
    }
}
