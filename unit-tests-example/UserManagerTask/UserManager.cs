using UserCreatorTask.UserValidators;

namespace UserCreatorTask
{
    public class UserManager
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IEmailService _emailService;
        private readonly IUserValidator _userValidator;

        public UserManager(IUsersRepository userRepository, IEmailService emailService, IUserValidator userValidator)
        {
            _usersRepository = userRepository;
            _emailService = emailService;
            _userValidator = userValidator;
        }

        public void CreateNewUser(User newUser)
        {
            var validationResult = _userValidator.Validate(newUser);
            if (!validationResult.IsValid)
            {
                throw new InvalidUserException(validationResult.Reason);
            }
            
            if (_usersRepository.GetUser(newUser.Email) != null)
                throw new InvalidUserException("UserAlreadyExists");
            
            _usersRepository.SaveUser(newUser);

            _emailService.SendEmail(newUser.Name, "Welcome", "Thank you for registering!");
        }
        
        public void DeleteUser(string email)
        {
            var user = _usersRepository.GetUser(email);
            if (user == null)
                throw new InvalidOperationException("User not found");

            _usersRepository.DeleteUser(email);
            _emailService.SendEmail(user.Name, "Goodbye", "Your account has been deleted.");
        }
        
        public List<User> GetAdultUsers()
        {
            var allUsers = _usersRepository.GetAllUsers();
            return allUsers.Where(u => u.Age >= 18).ToList();
        }
    }
}