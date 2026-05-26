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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace доставка
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }
        private void AddToCart(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            string name = btn.Tag.ToString();

            decimal price = 0;

            if (name == "Pizza") price = 8.5m;
            if (name == "Burger") price = 6.0m;
            if (name == "Sushi") price = 10.0m;

            MainWindow.Cart.Add(new CartItem
            {
                Name = name,
                Price = price,
                Quantity = 1
            });

            MessageBox.Show("Добавлено в корзину");
        }

        private void ShowCategory(string category)
        {
            foreach (var item in ItemsPanel.Children)
            {
                Border card = item as Border;

                if (category == "All")
                {
                    card.Visibility = Visibility.Visible;
                }
                else
                {
                    card.Visibility =
                        (card.Tag?.ToString() == category)
                        ? Visibility.Visible
                        : Visibility.Collapsed;
                }
            }
        }

        private void All_Click(object sender, RoutedEventArgs e)
        {
            ShowCategory("All");
        }

        private void Pizza_Click(object sender, RoutedEventArgs e)
        {
            ShowCategory("Pizza");
        }

        private void Burger_Click(object sender, RoutedEventArgs e)
        {
            ShowCategory("Burger");
        }

        private void Sushi_Click(object sender, RoutedEventArgs e)
        {
            ShowCategory("Sushi");
        }
    }
}
