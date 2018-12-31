using System.Globalization;
using System.Threading;

namespace Cards_Generator
{
    static class Globals
    {
        public enum ELanguage
        {
            english,
            italian,
            COUNT
        }


        static Globals()
        {
            _Language = ELanguage.english;
        }


        public static ELanguage Language
        {
            get
            {
                return _Language;
            }
            set
            {
                _Language = value;

                switch (_Language)
                {
                    case ELanguage.italian:
                        Thread.CurrentThread.CurrentUICulture = CurrentCultureInfo = CultureInfo.GetCultureInfo("it-IT");
                        break;
                    default:
                        Thread.CurrentThread.CurrentUICulture = CurrentCultureInfo = CultureInfo.GetCultureInfo("en-US");
                        break;
                }

            }
        }

        public static CultureInfo CurrentCultureInfo
        {
            get; private set;
        }




        private static ELanguage _Language;
        

    }
}
