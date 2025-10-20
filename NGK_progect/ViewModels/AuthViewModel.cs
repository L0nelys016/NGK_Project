using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using NGK_progect.Models;
using NGK_progect.ViewModels.Base;
using System.Threading.Tasks;

namespace NGK_progect.ViewModels
{
    public partial class AuthViewModel : ViewModelBase
    {
        private const string ERROR_MESSAGE_AUTH = "Неверный логин или пароль";

        private const string EMPTY_FIELDS = "Заполните все поля для регистрации";

        private const string BUSY_EMAIL = "Пользователь с таким email уже существует";

        private const string BUSY_LOGIN = "Пользователь с таким логином уже существует";

        private const string PASSWORD_DONT_MATCH = "Пароли не совпадают";

        private const string REG_ERROR = "Не удалось зарегестрироваться";

        private readonly MainWindowViewModel _mainWindowViewModel;

        private readonly VolkovContext _dbContext = new VolkovContext();

        [ObservableProperty]
        private ViewModelBase? _currentViewModel;

        [ObservableProperty]
        private string? _login;

        [ObservableProperty]
        private string? _email;

        [ObservableProperty]
        private string? _firstName;

        [ObservableProperty]
        private string? _lastName;

        [ObservableProperty]
        private string? _password;

        [ObservableProperty]
        private string? _passwordConfim;

        [ObservableProperty]
        private string? _errorMessageSignIn;

        [ObservableProperty]
        private string? _errorMessageSignUp;

        [ObservableProperty]
        private string? _passwordChar = "*";

        [ObservableProperty]
        private bool _isEnableButtonSignIn = true;

        [ObservableProperty]
        private bool _isEnableButtonSignUp = true;

        [ObservableProperty]
        private bool _isPasVisible = true;

        public AuthViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        [RelayCommand]
        private async Task LoginAndPasswordVerification()
        {
            Login? authUser = await _dbContext.Logins.Include(u => u.User).FirstOrDefaultAsync(login => login.Username == Login && login.Password == Password);
            IsEnableButtonSignIn = false;

            if (authUser != null && authUser.User != null)
            {
                _mainWindowViewModel.CurrentViewModel = new MainViewModel(authUser.User.UserId);
            }
            else
            {
                ErrorMessageSignIn = ERROR_MESSAGE_AUTH;
                IsEnableButtonSignIn = true;
            }
        }

        [RelayCommand]
        private void TogglePasswordVisibility()
        {
            IsPasVisible = !IsPasVisible;
            PasswordChar = IsPasVisible ? "*" : "";
        }

        [RelayCommand]
        private async Task RegisterNewUser()
        {
            try
            {
                IsEnableButtonSignUp = false;

                if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) ||
                    string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Login) ||
                    string.IsNullOrEmpty(Password))
                {
                    ErrorMessageSignUp = EMPTY_FIELDS;
                    IsEnableButtonSignUp = true;
                    return;
                }

                if (await _dbContext.Users.AnyAsync(u => u.Email == Email))
                {
                    ErrorMessageSignUp = BUSY_EMAIL;
                    IsEnableButtonSignUp = true;
                    return;
                }

                if (await _dbContext.Logins.AnyAsync(l => l.Username == Login))
                {
                    ErrorMessageSignUp = BUSY_LOGIN;
                    IsEnableButtonSignUp = true;
                    return;
                }

                if (Password != PasswordConfim)
                {
                    ErrorMessageSignUp = PASSWORD_DONT_MATCH;
                    IsEnableButtonSignUp = true;
                    return;
                }

                Login login = new Login
                {
                    Username = Login,
                    Password = Password
                };

                await _dbContext.Logins.AddAsync(login);
                await _dbContext.SaveChangesAsync();

                User user = new User
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    LoginId = login.LoginId
                };

                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();

                _mainWindowViewModel.CurrentViewModel = new MainViewModel(user.UserId);
            }
            catch
            {
                ErrorMessageSignUp = REG_ERROR;
                IsEnableButtonSignUp = true;
            }
        }

    }
}
