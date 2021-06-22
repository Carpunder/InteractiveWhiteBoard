using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApplicationContext db;
        public static User user;
        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            user = db.Users.FirstOrDefault(i => i.id == User.userId);
            titleLabel.Content = user?.Login;
            var rooms = db.Rooms.Where(i => i.user_id == user.id).Select(values => new
            {
                values.id,
                values.Name,
                values.UsersLimit,
            }).ToList();
            roomsTable.ItemsSource = rooms;
        }

        private void updateTableButton_Click(object sender, RoutedEventArgs e)
        {
            var rooms = db.Rooms.Where(i => i.user_id == user.id).Select(values => new
            {
                values.id,
                values.Name,
                values.UsersLimit,
            }).ToList();
            roomsTable.ItemsSource = rooms;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void mainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }


        private void enterButton_Click(object sender, RoutedEventArgs e)
        {
            int roomIdFromText;
            if (!Int32.TryParse(roomIdField.Text, out roomIdFromText))
            {
                MessageBox.Show("Ошибка");
                return;
            }
            var room = db.Rooms.FirstOrDefault(i => i.id == roomIdFromText);
            if (room != null)
            {
                Room.roomId = room.id;
                BoardWindow board = new BoardWindow();
                board.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
