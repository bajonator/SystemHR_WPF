using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SystemHR_WPF.Commands;
using SystemHR_WPF.Models;

namespace SystemHR_WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private UserSettings _userSettings;

        public LoginViewModel()
        {
            ConfirmCommand = new RelayCommand(Confirm);
            ExitCommand = new RelayCommand(Exit);
            _userSettings = new UserSettings();
        }


        public ICommand ConfirmCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        public UserSettings UserSettings
        {
            get
            {
                return _userSettings;
            }
            set
            {
                _userSettings = value;
                OnPropertyChanged();
            }
        }

        private void Confirm(object obj)
        {
            var loginParams = obj as LoginParams;
            UserSettings.Password = loginParams.PasswordBox.Password;

            if (Login())
            {
                CloseWindow(loginParams.Window);
            }
        }

        private bool Login()
        {
            if (UserSettings.Password == "1" && UserSettings.Login == "a")
                return true;
            return false;

        }

        private void Exit(object obj)
        {
            Application.Current.Shutdown();
        }

        private void CloseWindow(Window window)
        {
            window.Close();
        }
    }
}
