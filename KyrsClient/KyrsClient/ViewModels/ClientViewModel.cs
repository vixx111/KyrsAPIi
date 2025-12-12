using KyrsClient.Utills;
using KyrsProjectISP31.Utills;
using KyrsClient.Models;
using KyrsClient.Services;
using KyrsClient.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KyrsClient.ViewModels
{
    public class ClientViewModel : ViewModelBase
    {
        private ClientService clientService;
        private ObservableCollection<Client> clientList;
        public ObservableCollection<Client> ClientList
        {
            get { return clientList; }
            set
            {
                if (clientList != value)
                {
                    clientList = value;
                    OnPropertyChanged(nameof(ClientList));
                }
            }
        }

        private Client selected;
        public Client Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged(nameof(Selected));
            }
        }

        public ClientViewModel()
        {
            clientService = new ClientService();
            Load();
        }

        private void Load()
        {
            try
            {
                ClientList = null!;
                Task<List<Client>> task = Task.Run(() => clientService.GetAll());
                ClientList = new ObservableCollection<Client>(task.Result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(async obj =>
                  {
                      try
                      {
                          AddEditClient window = new AddEditClient(new Client());
                          if (window.ShowDialog() == true)
                          {
                              await clientService.Add(window.Client);
                              Load();
                          }
                      }
                      catch { }
                  }));
            }
        }

        private RelayCommand editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand(async obj =>
                  {
                      Client client = (obj as Client)!;
                      AddEditClient window = new AddEditClient(client);
                      if (window.ShowDialog() == true)
                      {
                          await clientService.Update(window.Client);
                      }
                  }));
            }
        }

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand(async obj =>
                  {
                      Client client = (obj as Client)!;
                      MessageBoxResult result = MessageBox.Show(
                          $"Вы действительно хотите удалить объект {client!.FirstName} {client.LastName}",
                          "Удаление объекта",
                          MessageBoxButton.YesNo,
                          MessageBoxImage.Warning);

                      if (result == MessageBoxResult.Yes)
                      {
                          await clientService.Delete(client);
                          Load();
                      }
                  }));
            }
        }
    }
}