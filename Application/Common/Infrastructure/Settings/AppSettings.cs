using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Infrastructure.Settings
{
    public class AppSettings
    {
        public string AllowedHosts { get; set; } = string.Empty;
        public string TokenDurationDays { get; set; } = string.Empty;
        public string Secret { get; set; } = string.Empty;
        public string ImagesFolder { get; set; } = string.Empty;
    }
}