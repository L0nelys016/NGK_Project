using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using NGK_progect.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

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