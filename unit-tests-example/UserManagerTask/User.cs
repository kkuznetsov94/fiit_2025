namespace UserCreatorTask
{
    public class User
    {
        public User(string name, string password, string email, int age)
        {
            Name = name;
            Password = password;
            Email = email;
            Age = age;
        }

        public string Name;
        public string Email;
        public string Password;
        public int Age;
    }
}