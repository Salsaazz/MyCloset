namespace MyCloset.Backend.Application.Extensions
{
    public static class UserInput
    {
        public static string FormatString(this string value) =>
            char.ToUpper(value[0]) + value.Substring(1).Trim();

    }
}
