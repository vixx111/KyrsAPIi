using KyrsClient.Utills;
using KyrsProjectISP31.Utills;
using KyrsClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KyrsClient.ViewModels
{
    public class NavigationViewModel:ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        public ICommand HomeCommand { get; set; }
        public ICommand ClientCommand { get; set; }
        private void HomeView(object obj) => CurrentView = new HomeViewModel();
        private void ClientView(object obj) => CurrentView = new ClientViewModel();
        public NavigationViewModel()
        {
            HomeCommand = new RelayCommand(HomeView);
            ClientCommand = new RelayCommand(ClientView);
            CurrentView = new HomeViewModel();
        }
    }
}
