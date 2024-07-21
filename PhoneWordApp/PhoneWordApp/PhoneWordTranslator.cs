﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneWordApp
{
    public static class PhoneWordTranslator
    {
        public static string ToNumber(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
                return null;

            raw = raw.ToUpperInvariant();
            var newString = new StringBuilder();
            foreach (char c in raw)
            {
                if (" -0123456789".Contains(c))
                    newString.Append(c);
                else
                {
                    var result = TranslateToNumber(c);
                    if (result != null)
                    {
                        newString.Append(result);
                    }
                    else
                    {
                        return null;
                    }

                }
            }
            return newString.ToString();    
        }

        static bool Contain(this string keyString, char c)
        {
            return keyString.IndexOf(c) >= 0;
        }
        static readonly string[] digits = {
            "ABC","DEF","GHI","JKL","MNO","PQRS","TUV","WXYZ"
        };

        static int? TranslateToNumber(char c)
        {
            for(int i=0; i<digits.Length; i++)
            {
                if (digits[i].Contain(c))
                    return 2 + i;
            }
            return null;
        }
    }
}
