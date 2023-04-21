using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Infrastructure.Settings
{
    public class AppSettings
    {
        public string AllowedHosts { get; set; }
        public string AllowedMethods { get; set; }
        public string Secret { get; set; }
        public string WebAppTokenDurationDays { get; set; }
        public string ServiceUserTokenDurationDays { get; set; }
        public string APIUsername { get; set; }
        public string APIPassword { get; set; }
        public string DocumentPath { get; set; }

        public string NewDatasetDocumentPath { get; set; }
        public string NewDataSetEmailSender { get; set; }
        public string NewDataSetEmailResiver { get; set; }
        public string SmtpClientUserName { get; set; }
        public string SmtpClientPassword { get; set; }
        public int SmtpClientPort { get; set; }
        public string SmtpClientHost { get; set; }
        public string SmtpClientDomainName { get; set; }
        public string MsgFromDisplayName { get; set; }

    }
}