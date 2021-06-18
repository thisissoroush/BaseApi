using Ganss.XSS;

namespace FrameWork.Security.Data
{
    public static class Strings
    {
        public static string Safe(this string BadString)
        {
            var sanitizer = new HtmlSanitizer();
            return sanitizer.Sanitize(BadString);
        }
    }
}
