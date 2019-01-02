using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cards_Generator
{
    public static class UIUtils
    {

        public static readonly string LocalizableTextPrefix = "#";


        public static string ResolveTextKey(string textKey)
        {
            if (textKey.StartsWith(LocalizableTextPrefix))
            {
     
                PropertyInfo propertyInfo = typeof(Properties.Strings).GetProperty(
                    textKey.Substring(LocalizableTextPrefix.Length), BindingFlags.Static | BindingFlags.NonPublic);

                if (propertyInfo != null)
                {
                    MethodInfo getterInfo = propertyInfo.GetGetMethod(true);
                    if (getterInfo != null)
                    {
                        string localizedText = getterInfo.Invoke(null, null) as string;
                        if (localizedText != null)
                        {
                            return localizedText;
                        }
                    }
                }

            }
            return textKey;
        }

    }
}
