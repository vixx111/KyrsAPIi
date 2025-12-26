using KyrsClient.Utills;
using KyrsClient.Models;
using KyrsClient.Services;
using KyrsClient.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;
using System.Threading.Tasks;
using KyrsProjectISP31.Utills;

namespace KyrsClient.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        private ProductService productService;
        private ObservableCollection<Product> productList;
        public ObservableCollection<Product> ProductList
        {
            get { return productList; }
            set
            {
                if (productList != value)
                {
                    productList = value;
                    OnPropertyChanged(nameof(ProductList));
                }
            }
        }

        private Product selected;
        public Product Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged(nameof(Selected));
            }
        }

        public ProductViewModel()
        {
            productService = new ProductService();
            Load();
        }

        private void Load()
        {
            try
            {
                ProductList = null!;
                Task<List<Product>> task = Task.Run(() => productService.GetAll());
                ProductList = new ObservableCollection<Product>(task.Result);
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
                          AddEditProduct window = new AddEditProduct(new Product());
                          if (window.ShowDialog() == true)
                          {
                              await productService.Add(window.Product);
                              Load();
                          }
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show($"Ошибка при добавлении: {ex.Message}");
                      }
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
                      try
                      {
                          Product product = (obj as Product)!;
                          AddEditProduct window = new AddEditProduct(product);
                          if (window.ShowDialog() == true)
                          {
                              await productService.Update(window.Product);
                          }
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show($"Ошибка при редактировании: {ex.Message}");
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
                      Product product = (obj as Product)!;
                      MessageBoxResult result = MessageBox.Show(
                          $"Вы действительно хотите удалить товар \"{product.Name}\"?",
                          "Удаление товара",
                          MessageBoxButton.YesNo,
                          MessageBoxImage.Warning);

                      if (result == MessageBoxResult.Yes)
                      {
                          try
                          {
                              await productService.Delete(product);
                              Load();
                          }
                          catch (Exception ex)
                          {
                              MessageBox.Show($"Ошибка при удалении: {ex.Message}");
                          }
                      }
                  }));
            }
        }

        private RelayCommand refreshCommand;
        public RelayCommand RefreshCommand
        {
            get
            {
                return refreshCommand ??
                  (refreshCommand = new RelayCommand(obj =>
                  {
                      Load();
                  }));
            }
        }
    }
}