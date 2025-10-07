using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore.Query.Internal;
using NGK_progect.Models;

namespace NGK_progect.ViewModels.Base
{
    public partial class MainWindowViewModel : ViewModelBase
    {

        [ObservableProperty]
        ViewModelBase _currentViewModel;

        public MainWindowViewModel()
        {
            CurrentViewModel = new AuthViewModel(this);
        }
       
    }
}
