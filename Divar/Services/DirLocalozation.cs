using Divar.Interfaces;
using System.Globalization;

namespace Divar.Services
{
    public class DirLocalozation : IDirLocalozation
    {
        private string localizedDir;
        private string localizedBootstrapLink;
        public DirLocalozation()
        {
            if (CultureInfo.CurrentCulture.ToString() == "fa-IR")
            {
                this.localizedDir = "rtl";
                this.localizedBootstrapLink = "./lib/bootstrap/dist/css/bootstrap.rtl.min.css";
            }
            else
            {
                this.localizedDir = "ltr";
                this.localizedBootstrapLink = "./lib/bootstrap/dist/css/bootstrap.min.css";
            }
        }
        public string ReadLocalizedDir()
        {
            return this.localizedDir;
        }
        public string ReadlocalizedBootstrapLink()
        {
            return this.localizedBootstrapLink;
        }
    }
}
