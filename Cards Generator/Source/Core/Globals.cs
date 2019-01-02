using System;
using System.Globalization;
using System.Threading;

namespace Cards_Generator
{
    static class Globals
    {

        public delegate void LanguageChangedDel(ELanguage newLanguage);

        public static LanguageChangedDel OnLanguageChanged;


        public enum ELanguage
        {
            english,
            italian,
            COUNT
        }


        static Globals()
        {
            RandomNumberGenerator = new Random();
            _Language = ELanguage.english;
        }

        /// <summary>
        /// Generates "count" unique random numbers from min to max (Lower extreme included, Upper extreme exluded)
        /// </summary>
        /// <param name="count"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int[] GenerateUniqueRandomNumbers(uint count, int min, int max)
        {
            int[] generatedNumbers = null;

            if (max > min && count <= max - min)
            {
                generatedNumbers = new int[count];

                for (var i = 0; i < count; ++i)
                {
                    generatedNumbers[i] = RandomNumberGenerator.Next(min, max);

                    for (var j = 0; j < i; ++j)
                    {
                        // Check if number has been already generated
                        if (generatedNumbers[i] == generatedNumbers[j])
                        {
                            --i;
                            break;
                        }
                    }
                }
            }

            return generatedNumbers;
        }


        public static ELanguage Language
        {
            get
            {
                return _Language;
            }
            set
            {
                if(_Language != value)
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

                    OnLanguageChanged.Invoke(_Language);
                }

            }
        }

        public static CultureInfo CurrentCultureInfo
        {
            get; private set;
        }

        public static Random RandomNumberGenerator;



        private static ELanguage _Language;
        

    }
}
