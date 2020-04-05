using System;
using System.Collections.Generic;
using Socrat.Common.Enums;
using Socrat.Core.Added;

namespace Socrat.Data.Model
{
    public class EMail : Entity
    {
        public EMail()
        {
            EMailFiles = new HashSet<EMailFile>();
        }


        public string From { get; set; }


        public string To { get; set; }


        public string Subject { get; set; }


        public DateTime? DateSend { get; set; }


        public EmailStatusEnum EmailStatusEnum { get; set; }


        public string Body { get; set; }

        public virtual ICollection<EMailFile> EMailFiles { get; set; }
    }
}