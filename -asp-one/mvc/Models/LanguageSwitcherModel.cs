using System.Collections.Generic;
using System.Globalization;

namespace mvc.Models
{
    public class LanguageSwitcherModel
    {
        public CultureInfo CurrentUICulture { get; set; }
        public List<CultureInfo> SupportedCultures { get; set; }
        public string CurrentSitecoreRoute { get; set; }
    }
}
