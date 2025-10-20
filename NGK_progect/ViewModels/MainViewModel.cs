using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NGK_progect.Models;
using NGK_progect.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace NGK_progect.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {

        private readonly MainWindowViewModel? _mainWindowViewModel;

        private readonly VolkovContext _dbContext = new VolkovContext();

        [ObservableProperty]
        private ObservableCollection<Tasks>? _tasks;

        [ObservableProperty]
        private ViewModelBase? _currentViewModel;

        public MainViewModel(int UserId)
        {
            GetTask(UserId);
        }

        private void GetTask(int userId)
        {
            if (userId != 0)
            {
                List<Tasks> userTask = _dbContext.Tasks
                    .Where(t => t.UserId == userId)
                    .ToList();

                Tasks = new ObservableCollection<Tasks>(userTask);
            }
            else
            {
                Tasks = new ObservableCollection<Tasks>(); 
            }
        }

    }
}