using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Task10_1.Models;

namespace Task10_1.ViewModels
{
    internal class MainWindowViewModels : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string username;
        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        private string statusMessage="Введите учетные данные";
        public string StatusMessage
        {
            get => statusMessage;
            set
            {
                statusMessage = value;
                OnPropertyChanged();
            }
        }

        private bool isSuccess;
        public bool IsSuccess
        {
            get => isSuccess;
            set
            {
                isSuccess = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; } /*= new RelayCommand(OnLoginCommand, CanLoginCommandExecuted);*/

        private void OnLoginCommand(object? parameter)
        {            
            IsSuccess = AuthModel.Authenticate(Username, Password);

            if (IsSuccess)
            {
                StatusMessage = "Успешный вход! Добро пожаловать!";
            }
        }

        private bool CanLoginCommandExecuted(object? parameter)
        {
            return Username != null && Password != null;
        }

        public MainWindowViewModels()
        {
            LoginCommand = new RelayCommand(OnLoginCommand, CanLoginCommandExecuted);
        }
    }
}
