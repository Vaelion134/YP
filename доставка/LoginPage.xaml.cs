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
    public partial class LoginPage : Page
    {
        public static List<User> Users = new List<User>();

        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var user = Users.FirstOrDefault(x =>
                x.Username == UsernameBox.Text &&
                x.Password == PasswordBox.Password);

            if (user != null)
            {
                MainWindow.CurrentUser = user;
                MessageBox.Show("Вход выполнен");
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Users.Add(new User
            {
                Username = UsernameBox.Text,
                Password = PasswordBox.Password
            });

            MessageBox.Show("Регистрация успешна");
        }
    }
}