namespace Apress.Recipes.WebApi
{
    public static class StringExtensions
    {
        public static string Between(this string value, string start, string end)
        {
            var startPosition = value.IndexOf(start);
            var endPosition = value.LastIndexOf(end);
            if (startPosition == -1 || endPosition == -1) return string.Empty;

            var adjustedStart = startPosition + start.Length;
            return adjustedStart >= endPosition ? string.Empty : value.Substring(adjustedStart, endPosition - adjustedStart);
        }
    }
}