using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using NGK_progect.Models;
using NGK_progect.ViewModels.Base;

namespace NGK_progect.ViewModels
{
    public partial class AuthViewModel : ViewModelBase
    {
        private const string ERROR_MESSAGE = "Неверный логин или пароль";

        private readonly MainWindowViewModel _mainWindowViewModel;

        private readonly VolkovContext _dbContext = new VolkovContext();

        [ObservableProperty]
        private ViewModelBase? _currentViewModel;

        [ObservableProperty]
        private string? _login;

        [ObservableProperty]
        private string? _password;

        [ObservableProperty]
        private string? _errorMessage;

        [ObservableProperty]
        private string? _passwordChar = "*";

        [ObservableProperty]
        private bool _isEnableButtonSignIn = true;

        [ObservableProperty]
        private bool _isPasSignInVisible = true;

        public AuthViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        [RelayCommand]
        private async Task LoginAndPasswordVerification()
        {
            Login? authUser = await _dbContext.Logins.FirstOrDefaultAsync(login => login.Username == Login && login.Password == Password);
            IsEnableButtonSignIn = false;

            if (authUser != null)
            {
                _mainWindowViewModel.CurrentViewModel = new MainViewModel();
            }
            else
            {
                ErrorMessage = ERROR_MESSAGE;
                IsEnableButtonSignIn = true;
            }
        }

        [RelayCommand]
        private void TogglePasswordVisibility()
        {
            IsPasSignInVisible = !IsPasSignInVisible;
            PasswordChar = IsPasSignInVisible ? "*" : "";
        }



    }
}
