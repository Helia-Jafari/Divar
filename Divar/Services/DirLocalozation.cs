using Divar.Interfaces;
using System.Globalization;

namespace Divar.Services
{
    public class DirLocalozation : IDirLocalozation
    {
        private string localizedDir;
        public DirLocalozation()
        {
            if (CultureInfo.CurrentCulture.ToString() == "fa-IR")
            {
                this.localizedDir = "rtl";
            }
            else
            {
                this.localizedDir = "ltr";
            }
        }
        public string ReadLocalizedDir()
        {
            return this.localizedDir;
        }
    }
}
