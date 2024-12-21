using System.Text.RegularExpressions;

namespace RestaurantChain.Presentation.Classes.Helpers;

internal static class TextHelpers
{
    private static readonly Regex OnlyNumbers = new Regex("[^0-9.-]+"); //regex that matches disallowed text

    public static bool IsTextAllowed(string text)
    {
        return !OnlyNumbers.IsMatch(text);
    }

    private static readonly Regex OnlyDecimalNumbers = new Regex(@"^[0-9]*(\.[0-9]{1,2})?$"); //regex that matches disallowed text

    public static bool IsDecimalAllowed(string text)
    {
        return !OnlyDecimalNumbers.IsMatch(text);
    }
}