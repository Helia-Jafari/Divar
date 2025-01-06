using System.Globalization;
using Divar.Interfaces;
using Microsoft.Extensions.Localization;

namespace Divar.Extra
{
    public class DirLocalozation: IDirLocalozation
    {
        private string localizedDir;
        DirLocalozation()
        {
            if (CultureInfo.CurrentCulture.ToString() == "fa-IR")
            {
                this.localizedDir = "rlt";
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
