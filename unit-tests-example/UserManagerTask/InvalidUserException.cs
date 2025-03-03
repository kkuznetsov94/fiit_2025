namespace UserCreatorTask
{
    public class InvalidUserException : Exception
    {
        public InvalidUserException(string message) : base(message)
        {
        }
    }
}