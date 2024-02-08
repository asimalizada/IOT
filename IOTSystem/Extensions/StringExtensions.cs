namespace IOTSystem.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveSpaces(this string str)
        {
            return str.Replace(" ", "");
        }

        public static string RemoveWhiteSpaces(this string str)
        {
            string result = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsWhiteSpace(str[i]))
                    result += str[i];
            }
            return result;
        }
    }
}
