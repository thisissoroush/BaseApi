using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class TblContactServersInfo
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string From { get; set; }
        public long ProviderId { get; set; }
        public string ProviderCustomUrl { get; set; }
        public bool UseProxy { get; set; }
        public string ProxyUserName { get; set; }
        public string ProxyPassord { get; set; }
        public string ProxyServer { get; set; }
        public string ProxyPort { get; set; }
        public bool UseSsl { get; set; }
        public string Sslport { get; set; }
        public long OrganizationId { get; set; }
        public short Type { get; set; }

        public virtual TblOrganization Organization { get; set; }
        public virtual TblContactInfoType TypeNavigation { get; set; }
    }
}
