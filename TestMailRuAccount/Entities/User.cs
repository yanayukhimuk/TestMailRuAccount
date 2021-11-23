namespace TestMailRuAccount.Entities
{
    public class User
    {
        private readonly string Login;
        private readonly string Email;
        private readonly string Password;

        public string[] DataUser { get; private set; }

        public User (string log, string email, string password)
        {
            log = Login;
            email = Email;
            password = Password;
            DataUser = new[] { this.Login, this.Email, this.Password };
        }

        public User()
        {
        }
    }
}
