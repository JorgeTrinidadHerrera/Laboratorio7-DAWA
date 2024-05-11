using Business;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laboratorio7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            ProductBusiness business = new ProductBusiness();
            dgProducts.ItemsSource = business.Get();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ProductBusiness business = new ProductBusiness();

            business.Insert(new Entity.Product { Name = txtName.Text, Price = Convert.ToDecimal( txtPrice.Text), Stock =  Convert.ToInt32( txtStock.Text)});
            
        }
    }
}