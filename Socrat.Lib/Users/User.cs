using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socrat.Lib.Users
{
    public class User
    {
        public string DisplayName { get; set; }
        public string Login { get; set; }
        public string Mail { get; set; }
        public string Mobile { get; set; }
        public string DepartmentName { get; set; }
        public string Position { get; set; }
        public string Domain { get; set; }
        public string Surname
        {
            get { return GetSurname(); }
        }

        public string Name
        {
            get { return GetName(); }
        }

        public string Patronimyc
        {
            get { return GetPatronimyc(); }
        }

        private string GetPatronimyc()
        {
            string _patr = string.Empty;
            string[] _parts = DisplayName.Split(' ');
            if (_parts.Length > 2)
                _patr = _parts[2];
            return _patr;
        }

        private string GetName()
        {
            string _name = string.Empty;
            string[] _parts = DisplayName.Split(' ');
            if (_parts.Length > 1)
                _name = _parts[1];
            return _name;
        }

        private string GetSurname()
        {
            string _surname = string.Empty;
            string[] _parts = DisplayName.Split(' ');
            if (_parts.Length>0)
            {
                _surname = _parts[0];
            }

            return _surname;
        }
    }
}
