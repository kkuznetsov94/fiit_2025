using System.Text.RegularExpressions;

namespace UserCreatorTask.UserValidators;

public class NameValidator : IStringValidator
{
    public bool IsValid(string value)
    {
        if (value == null)
        {
            throw new ArgumentNullException(message: "name value can't be null", null);
        }

        var regex = new Regex(@"^[a-zA-Z]+ [a-zA-Z]+$");
        return regex.Match(value).Success;
    }
}