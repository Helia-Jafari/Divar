﻿using System.Globalization;

namespace Divar.Interfaces
{
    public interface ILocalizationService
    {
        string GetLocalizedDir();
        string GetlocalizedBootstrapLink();
        string ChangeCultureInfo(string culture);
    }
}
