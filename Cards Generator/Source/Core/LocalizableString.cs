using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards_Generator
{
    public class LocalizableString
    {

        public LocalizableString(string stringKey)
        {
            _stringKey = stringKey;
            UpdateStringLocalization();
            Globals.OnLanguageChanged += LanguageChanged;
        }

        public static implicit operator LocalizableString(string stringkey)
        {
            return new LocalizableString(stringkey);
        }

        public string GetKey()
        {
            return _stringKey;
        }

        public string GetLocalized()
        { 
            return _stringLocalized;
        }

        private void LanguageChanged(Globals.ELanguage newLanguage)
        {
            UpdateStringLocalization();
        }

        private void UpdateStringLocalization()
        {
            _stringLocalized = UIUtils.ResolveTextKey(_stringKey);
        }


        private string _stringKey;

        private string _stringLocalized;
    }
}
