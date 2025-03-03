using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using UserCreatorTask;
using UserCreatorTask.UserValidators;

namespace IntegrationTests;

public class UserValidatorIntegrationTests
{
    #region FirstStep

    private EmailValidator _emailValidator;
    private PasswordValidator _passwordValidator;
    private NameValidator _nameValidator;
    private UserValidator _userValidatorFirstStep;

    [OneTimeSetUp]
    public void Setup()
    {
        _emailValidator = new EmailValidator();
        _passwordValidator = new PasswordValidator();
        _nameValidator = new NameValidator();
        _userValidatorFirstStep = new UserValidator(_nameValidator, _passwordValidator, _emailValidator);
    }

    #endregion

    #region StringConstants

    private const string InvalidName = "J";
    private const string ValidName = "John Smith";
    private const string InvalidPassword = "123";
    private const string ValidPassword = "123456@Das";
    private const string InvalidEmail = "testtest.te";
    private const string ValidEmail = "test@test.com";
    private const int ValidAge = 1;
    private const int InvalidAge = -1;

    #endregion

    [Test]
    public void IsValid_ReturnTrue_IfAllFieldsValid()
    {
        var userValidator = new UserValidator(new NameValidator(), new PasswordValidator(), new EmailValidator());
        var user = new User("Ivan Ivan", "123456@Qwerty", "asdfdad@dfasdas.asd", ValidAge);

        var result = userValidator.Validate(user);

        Assert.That(result.IsValid, Is.True);
    }

    [Test]
    public void IsValid_ReturnFalse_IfNameInvalid()
    {
        var userValidator = new UserValidator(new NameValidator(), new PasswordValidator(), new EmailValidator());
        var user = new User("Ivan", "123456@Qwerty", "asdfdad@dfasdas.asd", ValidAge);

        var result = userValidator.Validate(user);

        Assert.That(result, Is.EqualTo((false, "InvalidName")));
    }

    #region SecondStep

    private IUserValidator _userValidator = AssemblySetupFixture.ContainerCache.GetRequiredService<IUserValidator>();

    [Test]
    public void IsValid_ReturnTrue_IfAllFieldsValid2()
    {
        var user = new User("Ivan Ivan", "123456@Qwerty", "asdfdad@dfasdas.asd", ValidAge);

        var result = _userValidator.Validate(user);

        Assert.That(result.IsValid, Is.True);
    }

    [Test]
    public void IsValid_ReturnFalse_IfNameInvalid2()
    {
        var user = new User("Ivan", string.Empty, "asdfdad@dfasdas.asd", ValidAge);

        var result = _userValidator.Validate(user);

        Assert.That(result, Is.EqualTo((false, "InvalidName")));
    }

    #endregion

    #region ThirdStep

    public static IEnumerable<TestCaseData> UserValidatorCases()
    {
        yield return
            new TestCaseData(new User(InvalidName, ValidPassword, ValidEmail, ValidAge), "InvalidName")
                .SetName("name not valid");
        yield return
            new TestCaseData(new User(ValidName, ValidPassword, InvalidEmail, ValidAge), "InvalidEmail")
                .SetName("email not valid");
        yield return
            new TestCaseData(new User(ValidName, InvalidPassword, ValidEmail, ValidAge), "InvalidPassword")
                .SetName("password  not valid");
        yield return
            new TestCaseData(new User(ValidName, InvalidPassword, ValidEmail, InvalidAge), "AgeMustNotBeNegative")
                .SetName("Age  not valid");
    }

    [TestCaseSource(nameof(UserValidatorCases))]
    public void IsValid_ReturnFalse_When(User user, string? errorMessage)
    {
        var result = _userValidator.Validate(user);

        result.Should().Be((false, errorMessage)!);
    }

    #endregion
}