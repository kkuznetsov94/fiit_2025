namespace UserCreatorTask.UserValidators;

public interface IUserValidator
{
    public (bool IsValid, string Reason) Validate(User user);
}