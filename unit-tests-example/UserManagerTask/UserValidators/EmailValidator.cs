using System.Text.RegularExpressions;

namespace UserCreatorTask.UserValidators;

public class EmailValidator: IStringValidator
{
    public bool IsValid(string value)
    {
        if (value == null)
        {
            throw new ArgumentNullException(message: "email value can't be null", null);
        }
        var regex =  new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        return regex.Match(value).Success;
    }
}