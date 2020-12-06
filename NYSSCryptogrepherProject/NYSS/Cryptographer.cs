using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace NYSS
{
    public class Cryptographer
    {

        static Dictionary<char, int> charKey = new Dictionary<char, int> { { 'а', 1 }, { 'б', 2 }, { 'в', 3 }, { 'г', 4 }, { 'д', 5 }, { 'е', 6 }, { 'ё', 7 }, { 'ж', 8 }, { 'з', 9 }, { 'и', 10 }, { 'й', 11 }, { 'к', 12 }, { 'л', 13 }, { 'м', 14 }, { 'н', 15 }, { 'о', 16 }, { 'п', 17 }, { 'р', 18 }, { 'с', 19 }, { 'т', 20 }, { 'у', 21 }, { 'ф', 22 }, { 'х', 23 }, { 'ц', 24 }, { 'ч', 25 }, { 'ш', 26 }, { 'щ', 27 }, { 'ъ', 28 }, { 'ы', 29 }, { 'ь', 30 }, { 'э', 31 }, { 'ю', 32 }, { 'я', 33 } };
        static Dictionary<int, char> intKey = new Dictionary<int, char> { { 1, 'а' }, { 2, 'б' }, { 3, 'в' }, { 4, 'г' }, { 5, 'д' }, { 6, 'е' }, { 7, 'ё' }, { 8, 'ж' }, { 9, 'з' }, { 10, 'и' }, { 11, 'й' }, { 12, 'к' }, { 13, 'л' }, { 14, 'м' }, { 15, 'н' }, { 16, 'о' }, { 17, 'п' }, { 18, 'р' }, { 19, 'с' }, { 20, 'т' }, { 21, 'у' }, { 22, 'ф' }, { 23, 'х' }, { 24, 'ц' }, { 25, 'ч' }, { 26, 'ш' }, { 27, 'щ' }, { 28, 'ъ' }, { 29, 'ы' }, { 30, 'ь' }, { 31, 'э' }, { 32, 'ю' }, { 33, 'я' } };
        public static bool KeyValidator(string key)
        {
            bool isvalid = true;
            for (int i = 0; i < key.Length; i++)
            {
                if (!charKey.ContainsKey(Char.ToLower(key[i])))
                {
                    isvalid = false;
                }
            }
            return isvalid;
        }
        public static string EncryptText(string text, string key)
        {
            int[] textnumbers = StringToInts(text);
            int[] keynumbers = StringToInts(key);
            int[] shift = ShiftSequence(keynumbers);

            textnumbers = Encrypt(textnumbers, shift);
            return IntsToString(textnumbers, text);
        }
        public static string DecryptText(string text, string key)
        {
            int[] textnumbers = StringToInts(text);
            int[] keynumbers = StringToInts(key);
            int[] shift = ShiftSequence(keynumbers);

            textnumbers = Decrypt(textnumbers, shift);
            return IntsToString(textnumbers, text);
        }
        static int[] StringToInts(string s)
        {
            int[] charnumbers = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                if (charKey.ContainsKey(Char.ToLower(s[i])))
                {
                    charnumbers[i] = charKey[Char.ToLower(s[i])];
                }
                else
                {
                    charnumbers[i] = -1;
                }
            }
            return charnumbers;
        }
        static int[] ShiftSequence(int[] keywordnumbers)
        {
            for (int i = 0; i < keywordnumbers.Length; i++)
            {
                keywordnumbers[i] = keywordnumbers[i] - 1;
                if (keywordnumbers[i] < 0)
                {
                    keywordnumbers[i] = 33 + keywordnumbers[i];
                }

            }
            return keywordnumbers;
        }
        static int[] Encrypt(int[] textnumbers, int[] shift)
        {
            int k = 0;
            int[] encryptedtextnumbers = new int[textnumbers.Length];
            for (int i = 0; i < textnumbers.Length; i++)
            {
                if (textnumbers[i] != -1)
                {
                    encryptedtextnumbers[i] = (textnumbers[i] + shift[k]) % 33;
                    if (encryptedtextnumbers[i] == 0)
                    {
                        encryptedtextnumbers[i] = 33;
                    }
                    k++;
                    if (k > shift.Length - 1)
                    {
                        k = 0;
                    }
                }
                else
                {
                    encryptedtextnumbers[i] = textnumbers[i];
                }
            }
            return encryptedtextnumbers;
        }
        static int[] Decrypt(int[] textnumbers, int[] shift)
        {

            int k = 0;
            int[] decryptedtextnumbers = new int[textnumbers.Length];
            for (int i = 0; i < textnumbers.Length; i++)
            {
                if (textnumbers[i] != -1)
                {
                    decryptedtextnumbers[i] = textnumbers[i] - shift[k];
                    if (decryptedtextnumbers[i] <= 0)
                    {
                        decryptedtextnumbers[i] = 33 + decryptedtextnumbers[i];
                    }
                    k++;
                    if (k > shift.Length - 1)
                    {
                        k = 0;
                    }
                }
                else
                {
                    decryptedtextnumbers[i] = textnumbers[i];
                }
            }
            return decryptedtextnumbers;

        }
        static string IntsToString(int[] textnumbers, string oldstring)
        {
            string newstring = "";
            for (int i = 0; i < textnumbers.Length; i++)
            {
                if (textnumbers[i] == -1)
                {
                    newstring += oldstring[i];
                }
                else
                {
                    if (Char.IsUpper(oldstring[i]))
                    {
                        newstring += char.ToUpper(intKey[textnumbers[i]]);
                    }
                    else
                    {
                        newstring += intKey[textnumbers[i]];
                    }
                }
            }
            return newstring;
        }

    }
}
