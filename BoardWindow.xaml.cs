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
using System.Windows.Shapes;
using DotNetBrowser.Browser;
using DotNetBrowser.Engine;
using KursRSPO.Classes;

namespace KursRSPO
{
    /// <summary>
    /// Логика взаимодействия для BoardWindow.xaml
    /// </summary>
    public partial class BoardWindow : Window
    {
        private readonly IEngine engine;
        private readonly IBrowser browser;
        private ApplicationContext db;
        public BoardWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
            engine = EngineFactory.Create(new EngineOptions.Builder
                {
                    LicenseKey = "6P91WMFPXCB1IL3TCOG1Y1SNRXZM2VKFHJEBO6IWS5ILSEQ7YR3QSTQY0YPG89JAZDWI"
            }
                .Build());
            browser = engine.CreateBrowser();
            browser.Navigation.LoadUrl("C:\\Users\\Flarl\\source\\repos\\Whiteboard\\whiteboard-main\\docs\\index.html");
            BrowserView.InitializeFrom(browser);

        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //if (e.ChangedButton == MouseButton.Left)
                //this.DragMove();
        }


        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            engine.Dispose();
            browser.Dispose();
        }
    }
}
