using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace доставка
{
    public partial class HomePage : Page
    {
        public static List<MenuItem> Menu = new List<MenuItem>()
        {

            new MenuItem { Name="Маргарита", Category="Пицца", Price=650m, ImagePath="Images/pizza1.jpg" },
            new MenuItem { Name="Пепперони", Category="Пицца", Price=750m, ImagePath="Images/pizza2.jpg" },
            new MenuItem { Name="4 сыра", Category="Пицца", Price=820m, ImagePath="Images/pizza3.jpg" },
            new MenuItem { Name="Гавайская", Category="Пицца", Price=780m, ImagePath="Images/pizza4.jpg" },
            new MenuItem { Name="Мясная", Category="Пицца", Price=900m, ImagePath="Images/pizza5.jpg" },

            new MenuItem { Name="Чизбургер", Category="Бургер", Price=320m, ImagePath="Images/burger1.jpg" },
            new MenuItem { Name="Двойной бургер", Category="Бургер", Price=450m, ImagePath="Images/burger2.jpg" },
            new MenuItem { Name="Куриный бургер", Category="Бургер", Price=390m, ImagePath="Images/burger3.jpg" },
            new MenuItem { Name="Биг бургер", Category="Бургер", Price=520m, ImagePath="Images/burger4.jpg" },
            new MenuItem { Name="BBQ бургер", Category="Бургер", Price=410m, ImagePath="Images/burger5.jpg" },

            new MenuItem { Name="Филадельфия", Category="Суши", Price=690m, ImagePath="Images/sushi1.jpg" },
            new MenuItem { Name="Калифорния", Category="Суши", Price=620m, ImagePath="Images/sushi2.jpg" },
            new MenuItem { Name="С лососем", Category="Суши", Price=710m, ImagePath="Images/sushi3.jpg" },
            new MenuItem { Name="С тунцом", Category="Суши", Price=680m, ImagePath="Images/sushi4.jpg" },
            new MenuItem { Name="Сет", Category="Суши", Price=1200m, ImagePath="Images/sushi5.jpg" }
        };

        public HomePage()
        {
            InitializeComponent();
            MenuItemsControl.ItemsSource = Menu;
        }

        private void AddToCart(object sender, RoutedEventArgs e)
        {
            if (MainWindow.CurrentUser == null)
            {
                MessageBox.Show("Сначала войдите");
                return;
            }

            var item = (sender as FrameworkElement)?.DataContext as MenuItem;

            if (item == null) return;

            var existing = MainWindow.Cart.FirstOrDefault(x => x.Name == item.Name);

            if (existing != null)
                existing.Quantity++;
            else
                MainWindow.Cart.Add(new CartItem
                {
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = 1
                });

            MessageBox.Show("Добавлено");
        }

        private void Filter(string category)
        {
            if (category == "Все")
                MenuItemsControl.ItemsSource = Menu;
            else
                MenuItemsControl.ItemsSource =
                    Menu.Where(x => x.Category == category).ToList();
        }

        private void All_Click(object sender, RoutedEventArgs e)
        {
            Filter("Все");
        }

        private void Pizza_Click(object sender, RoutedEventArgs e)
        {
            Filter("Пицца");
        }

        private void Burger_Click(object sender, RoutedEventArgs e)
        {
            Filter("Бургер");
        }

        private void Sushi_Click(object sender, RoutedEventArgs e)
        {
            Filter("Суши");
        }
    }
}