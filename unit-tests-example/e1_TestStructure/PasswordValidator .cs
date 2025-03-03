using System.Text.RegularExpressions;
using NUnit.Framework;

namespace e4_TestStructure;

public class PasswordValidator
{
    public bool IsValid(string value)
    {
        var regex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{9,}$");
        return regex.Match(value).Success;
    }
}

public class PasswordValidatorTests
{

    public void Test()
    {
        
    }
    #region good variants

    [Test]
    public void IsValid_ReturnTrue_IfPasswordValid()
    {
        //arrange
        var validator = new PasswordValidator();
        var validPassword = "Ab#123445";
        
        //act
        var result = validator.IsValid(validPassword);

        //assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void IsValid_ReturnFalse_IfPasswordNotContainsSpecialChar()
    {
        //arrange
        var validator = new PasswordValidator();
        var invalidPassword = "Ab#1231";
        
        //act
        var result = validator.IsValid(invalidPassword);

        //assert
        Assert.That(result, Is.False);
    }
    #endregion
}