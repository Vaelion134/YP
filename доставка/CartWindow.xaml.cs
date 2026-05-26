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

namespace доставка
{
    /// <summary>
    /// Логика взаимодействия для CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        public CartWindow()
        {
            InitializeComponent();
            LoadCart();
        }
        private void LoadCart()
        {
            CartList.Items.Clear();

            foreach (var item in MainWindow.Cart)
            {
                CartList.Items.Add($"{item.Name} x{item.Quantity}");
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Cart.Clear();
            LoadCart();
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.Cart.Count == 0)
            {
                MessageBox.Show("Корзина пуста");
                return;
            }

            string summary = string.Join("\n",
                MainWindow.Cart.Select(x => $"{x.Name} x{x.Quantity}"));

            MessageBox.Show("Заказ оформлен!\n\n" + summary);

            MainWindow.Cart.Clear();
            LoadCart();
        }
    }
    }


