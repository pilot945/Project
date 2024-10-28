using App.Command;
using App.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModels
{
    public class AutorizationViewModel : ViewModelBase
    {
        public AutorizationViewModel()
        {
            LoginCommand = new RelayCommand(o =>
            {
                var user = UserSrvice.Find(login, password);
                if (user != null)
                {
                    new MainView().ShowDialog();
                }
            });

            RegisterCommand = new RelayCommand(o =>
            {
                UserService.AddUser(lastname, firstname, middlename, login, password);
            });

        }

        private string firstname;
        private string lastname;
        private string middlename;
        private string login;
        private string password;

        public string Firstname { get => firstname; set => Set(ref firstname, value, nameof(Firstname)); }
        public string Lastname { get => lastname; set => Set(ref lastname, value, nameof(Lastname)); }
        public string Middlename { get => middlename; set => Set(ref middlename, value, nameof(Middlename)); }
        public string Login { get => login; set => Set(ref login, value, nameof(Login)); }
        public string Password { get => password; set => Set(ref password, value, nameof(Password)); }

        public RelayCommand LoginCommand { get; } 
        
        public RelayCommand RegisterCommand { get; } 
    }
}
