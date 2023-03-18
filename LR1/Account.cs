using System.ComponentModel;

namespace LR1
{
    internal class Account
    {
        [DisplayName("Site")] public string Site { get; set; }
        [DisplayName("Login")] public string Login { get; set; }
        [DisplayName("Password")] public string Password { get; set; }

        public Account(string site, string login, string password) 
        {
            this.Site = site;
            this.Login = login;
            this.Password = password;
        }
    }
}
