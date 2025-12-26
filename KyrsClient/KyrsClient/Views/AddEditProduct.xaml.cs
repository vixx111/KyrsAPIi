using System;
using KyrsClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KyrsClient.Views
{
    public partial class AddEditProduct : Window
    {
        public Product Product { get; private set; }

        public AddEditProduct(Product product)
        {
            InitializeComponent();
            Product = product;
            DataContext = Product;
        }
    }
}
