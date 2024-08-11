using System.Text.RegularExpressions;

namespace WebApi.Core.ExtensionMethods.String;

static class String
{
    public static bool ContainLowerCaseCharacter(this string password)
    { return password != null && Regex.IsMatch(password, @"[a-z]"); }

    public static bool ContainNumber(this string password)
    { return password != null && Regex.IsMatch(password, @"\d"); }

    public static bool ContainCapitalizedCharacter(this string password)
    { return password != null && Regex.IsMatch(password, @"[A-Z]"); }

    public static bool IsEmail(this string email)
    { return email != null && Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"); }

    public static bool IsName(this string name)
    { return name != null && Regex.IsMatch(name, @"^[a-zA-Z]*$"); }

    public static bool IsSurname(this string surname)
    { return surname != null && Regex.IsMatch(surname, @"^[a-zA-Z -]*$"); }
}