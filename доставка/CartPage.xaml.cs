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
    public partial class CartPage : Page
    {
        public CartPage()
        {
            InitializeComponent();
            LoadCart();
        }

        private void LoadCart()
        {
            CartList.Items.Clear();

            decimal total = 0;

            foreach (var item in MainWindow.Cart)
            {
                CartList.Items.Add($"{item.Name} x{item.Quantity} — {item.Price * item.Quantity} руб");
                total += item.Price * item.Quantity;
            }

            TotalText.Text = $"Итого: {total:0} руб";
        }

        private void RemoveSelected_Click(object sender, RoutedEventArgs e)
        {
            if (CartList.SelectedIndex == -1) return;

            MainWindow.Cart.RemoveAt(CartList.SelectedIndex);

            LoadCart();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Cart.Clear();
            LoadCart();
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.CurrentUser == null)
            {
                MessageBox.Show("Сначала войдите");
                return;
            }

            if (string.IsNullOrWhiteSpace(AddressBox.Text))
            {
                MessageBox.Show("Введите адрес доставки");
                return;
            }

            if (MainWindow.Cart.Count == 0)
            {
                MessageBox.Show("Корзина пуста");
                return;
            }

            MessageBox.Show($"Заказ оформлен!\nАдрес: {AddressBox.Text}");

            MainWindow.Cart.Clear();
            LoadCart();
        }
    }
}