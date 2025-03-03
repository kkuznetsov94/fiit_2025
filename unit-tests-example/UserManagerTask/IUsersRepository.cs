namespace UserCreatorTask;

public interface IUsersRepository
{
    User GetUser(string email);
    void SaveUser(User user);
    void DeleteUser(string email);
    List<User> GetAllUsers();
}