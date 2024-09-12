using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passwordManager
{
    internal class EncryptionUtilities
    {
        private static readonly string original = GenerateOriginal();
        private static readonly string alt = GenerateAlt(original);

        private static string GenerateOriginal()
        {
            return "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        }
// random order to make encryption
        private static string GenerateAlt(string original)
        {
            var random = new Random();
            var chars = original.ToCharArray();
            var shuffledChars = chars.OrderBy(c => random.Next()).ToArray();
            return new string(shuffledChars);
        }
        public static string encrypt(string pass)
        {
            var sb = new StringBuilder();
            foreach (var item in pass)
            {
                //get the original index and replace it by alt index
                var i = original.IndexOf(item);
                sb.Append(alt[i]);
            }
            return sb.ToString();
        }

        public static string decrypt(string pass)
        {
            var sb = new StringBuilder();
            foreach (var item in pass)
            {

                var i = alt.IndexOf(item);
                sb.Append(original[i]);
            }
            return sb.ToString();
        }
    }
}
