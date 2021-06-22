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
using KursRSPO.Classes;

namespace KursRSPO
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private ApplicationContext db;
        public RegistrationWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void RegistrationRoot_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private async void registrationButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = new User(loginField.Text, passwordField.Password);

                db.Users.Add(user);
                await db.SaveChangesAsync();
                MessageBox.Show("Успешно зарегестрирован");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                MessageBox.Show("Ошибка регистрации!");
            }

        }
    }
}
