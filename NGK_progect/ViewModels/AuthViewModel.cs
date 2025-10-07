using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NGK_progect.Models;
using NGK_progect.ViewModels.Base;
using System.Linq;
using Avalonia;
using Xceed.Wpf.Toolkit;
using System;

namespace NGK_progect.ViewModels
{
    public partial class AuthViewModel : ViewModelBase
    {
        private readonly MainWindowViewModel _mainWindowViewModel;

        private readonly VolkovContext _dbContext = new VolkovContext();

        [ObservableProperty]
        private ViewModelBase? _currentViewModel;

        [ObservableProperty]
        private string? _login;

        [ObservableProperty]
        private string? _password;

        public AuthViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        [RelayCommand]
        private void LoginAndPasswordVerification()
        {
            Login? authUser = _dbContext.Logins.FirstOrDefault(login => login.Username == Login && login.Password == Password);

            if (authUser != null)
            {
                _mainWindowViewModel.CurrentViewModel = new MainViewModel();
            }
            else
            {
            }
        }
    }
}
