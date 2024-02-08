using System.Security.Cryptography;
using System.Text;

namespace IOTSystem.Helpers
{
    internal static class HashingHelper
    {
        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        public static bool VerifyHash(byte[] bytes, string inputString)
        {
            var hashed = GetHash(inputString);

            for (int i = 0; i < bytes.Length; i++)
            {
                if (hashed[i] != bytes[i])
                    return false;
            }

            return true;
        }

        public static bool VerifyHash(byte[] bytes, byte[] input)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                if (input[i] != bytes[i])
                    return false;
            }

            return true;
        }
    }
}
