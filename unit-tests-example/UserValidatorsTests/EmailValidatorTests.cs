using NUnit.Framework;
using UserCreatorTask.UserValidators;

namespace UserValidatorTests;

public class EmailValidatorTests
{
    [TestCase("Qwerty@123")]
    public void ShouldReturnTrue_WhenPasswordIsValid(string password)
    {
        var validator = new PasswordValidator();

        var result = validator.IsValid(password);

        Assert.That(result, Is.True);
    }
}