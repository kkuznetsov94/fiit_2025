using NSubstitute;
using NUnit.Framework;
using UserCreatorTask;
using UserCreatorTask.UserValidators;

namespace UserValidatorTests;

[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class UserValidatorTests
{
    IStringValidator nameValidator = Substitute.For<IStringValidator>();
    IStringValidator emailValidator = Substitute.For<IStringValidator>();
    IStringValidator passwordValidator = Substitute.For<IStringValidator>();

    private const string validName = "Ivanov Ivan";
    private const string validPassword = "Qverty123@45";
    private const string validEmail = "test@test.ru";
    private const int validAge = 12;
    private const string invalidName = "a";
    private const string invalidPassword = "Qvert";
    private const string invalidEmail = "tes";
    private const int invalidAge = -1;

    [OneTimeSetUp]
    public void SetMocks()
    {
        nameValidator.IsValid(validName).Returns(true);
        emailValidator.IsValid(validEmail).Returns(true);
        passwordValidator.IsValid(validPassword).Returns(true);
        nameValidator.IsValid(invalidName).Returns(false);
        emailValidator.IsValid(invalidEmail).Returns(false);
        passwordValidator.IsValid(invalidPassword).Returns(false);

        nameValidator.When(nv => nv.IsValid(null)).Throw(new ArgumentNullException());
    }

    [TearDown]
    public void ClearCalls()
    {
        nameValidator.ClearReceivedCalls();
        emailValidator.ClearReceivedCalls();
        passwordValidator.ClearReceivedCalls();
    }


    [Test]
    public void UserValidator_ReturnTrue_WhenUserValid()
    {
        var validator = new UserValidator(nameValidator, passwordValidator, emailValidator);
        var user = new User(validName, validPassword, validEmail, validAge);
        var actual = validator.Validate(user);


        Assert.That(actual, Is.EqualTo((true, "")));
    }

    [Test]
    public void UserValidator_ReturnFalseWithError_WhenUserNameIsInvalid()
    {
        var validator = new UserValidator(nameValidator, passwordValidator, emailValidator);
        var user = new User(invalidName, validPassword, validEmail, validAge);

        var actual = validator.Validate(user);

        passwordValidator.DidNotReceive().IsValid(validPassword);
        emailValidator.DidNotReceive().IsValid(validEmail);
        Assert.That(actual, Is.EqualTo((false, "InvalidName")));
    }


    //посмотреть вывод Nunit.
    [Test]
    public void UserValidator_ShouldReturnFalse_WhenSomeOfValidatorsThrowEx()
    {
        var validator = new UserValidator(nameValidator, passwordValidator, emailValidator);
        var user = new User(null, validPassword, validEmail, validAge);

        var actual = validator.Validate(user);

        passwordValidator.DidNotReceive().IsValid(validPassword);
        emailValidator.DidNotReceive().IsValid(validEmail);


        Assert.That(actual, Is.EqualTo((false, "validationError")));
    }

    public class ValidatorStub : IStringValidator
    {
        public ValidatorStub(bool expected)
        {
            _expected = expected;
        }

        private readonly bool _expected;

        public int GetValue() => _count;

        private int _count = 0;

        public bool IsValid(string value)
        {
            _count++;
            return _expected;
        }
    }
}