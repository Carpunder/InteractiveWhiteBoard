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
    /// Логика взаимодействия для CreateRoomWindow.xaml
    /// </summary>
    public partial class CreateRoomWindow : Window
    {
        private ApplicationContext db;
        public CreateRoomWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        private void registrationButton_Click(object sender, RoutedEventArgs e)
        {
            int limit;
            if (!int.TryParse(usersField.Text, out limit))
            {
                MessageBox.Show("Ошибка!");
                return;
            }

            if (db.Rooms.FirstOrDefault(i => i.Name == roomNameField.Text) != null)
            {
                MessageBox.Show("Имя комнаты уже занято!");
                return;
            }

            Room room = new Room(User.userId, roomNameField.Text, limit);
            db.Rooms.Add(room);
            db.SaveChangesAsync();
            MessageBox.Show("Комната успешно создана!");
            Close();

        }
    }
}
