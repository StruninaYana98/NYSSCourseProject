using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NYSS
{
    public static class Validator
    {
        public static bool FileNameValidator(string s)
        {
            bool result = true;
            string forbiddensymbols = "<>:\"/\\|?*+%!@";
            for (int i = 0; i < s.Length; i++)
            {
                if (forbiddensymbols.Contains(s[i]))
                {
                    result = false;
                }
            }
            if (s[s.Length - 1] == '.' || s[s.Length - 1] == ' ')
            {
                result = false;
            }
            return result;
        }
        public static string PathValidator(string s)
        {
            if (s[s.Length - 1] != '\\')
            {
                s = s + "\\";
                return s;
            }
            return s;

        }
    }
}