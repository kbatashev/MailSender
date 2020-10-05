using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MailSender.Services
{
    public static class PasswordHelper
    {
        private static readonly List<char> Chars = (
     "1234567890-=!@#$%^&*()_+" +
     "qQwWeErRtTyYuUiIoOpP[{]}\\|" +
     "aAsSdDfFgGhHjJkKlL;:'\"" +
     "zZxXcCvVbBnNmM,<.>/?").ToList();

        private static char EncodeChar(char ch, int key)
        {

            if (!Chars.Contains(ch))
                return ch;

            if (Math.Abs(key) >= Chars.Count)
                key %= Chars.Count;

            var index = Chars.IndexOf(ch) + key;

            if (index >= Chars.Count)
                index -= Chars.Count;
            else if (index < 0)
                index += Chars.Count;

            Debug.WriteLine($"PasswordHelper.EncodeChar({ch}, {key}) => '{Chars[index]}' (0x{(int)Chars[index]:X})");

            return Chars[index];
        }

        public static string Encode(this string text, int key) => new string(text.Select(ch => EncodeChar(ch, key)).ToArray());

        public static string Decode(this string text, int key) => Encode(text, -key);
    }
}
