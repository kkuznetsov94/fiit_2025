using System.Text.RegularExpressions;

namespace UserCreatorTask.UserValidators;

public class PasswordValidator : IStringValidator
{
    public bool IsValid(string value)
    {
        if (value == null)
        {
            throw new ArgumentNullException(message: "password value can't be null", null);
        }
        var regex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{100,}$");
        return regex.Match(value).Success;
    }
}

