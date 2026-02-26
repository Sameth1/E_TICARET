namespace UI_MVC.Extensions
{
    public static class StringExtensions
    {
        public static string ToUrl(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

           
            return value.Replace(" ", "-").ToLower();
        }
    }
}