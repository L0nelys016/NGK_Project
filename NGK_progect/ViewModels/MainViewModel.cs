using CommunityToolkit.Mvvm.ComponentModel;
using NGK_progect.ViewModels.Base;

namespace NGK_progect.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {

        [ObservableProperty]
        private int _currentId;

        [ObservableProperty]
        private string _surname = "Фамилия";

        [ObservableProperty]
        private string _name = "Имя";

        [ObservableProperty]
        private int? _stipend = 0;

        public MainViewModel()
        {
        }


    }
}