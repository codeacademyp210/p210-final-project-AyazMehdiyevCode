using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace _56_Xeber.Class
{
    public class LanguageM
    {

        public static List<Language> AvailableLanguages = new List<Language> {

            new Language {
                LanguageCultureName="Ru",
                LanguageFullName= "Russian"
            },
            new Language {
                LanguageCultureName="Az",
                LanguageFullName= "Azərbaycan"
            }
        };


        public static bool IsLanguageAvailable(string lang)
        {
            return AvailableLanguages.Where(l => l.LanguageCultureName.Equals(lang)).FirstOrDefault() != null ? true : false;
        }

        public static string GetDefLanguage()
        {
            return AvailableLanguages[1].LanguageCultureName;
        }

        public void SetLanguage(string lang)
        {
            try
            {
                if (!IsLanguageAvailable(lang))
                {
                    lang = GetDefLanguage();
                }

                CultureInfo culture = new CultureInfo(lang);
                Thread.CurrentThread.CurrentUICulture = culture;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture.Name);
                HttpCookie languageCookie = new HttpCookie("culture", lang);
                languageCookie.Expires = DateTime.Now.AddYears(1);
                HttpContext.Current.Response.Cookies.Add(languageCookie);
            }
            catch (Exception)
            {

            }

        }
    }
    public class Language
    {
        public string LanguageFullName { get; set; }
        public string LanguageCultureName { get; set; }
    }

}