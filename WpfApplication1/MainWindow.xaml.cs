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
using System.Windows.Threading;

namespace WpfApplication1
{
    public partial class MainWindow : Window
    {
        bool blink = false;
        string ucapan = "";
        string nama = System.Environment.UserName;
        public MainWindow()
        {
            InitializeComponent();
            var layar = SystemParameters.WorkArea;
            this.Left = layar.Width - this.Width;
            this.Top = layar.Height - this.Height;
            this.Topmost = true;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0,0,1);
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e) {
            jam.Content = DateTime.Now.Hour;
            menit.Content = DateTime.Now.Minute;
            if (blink)
            {
                menit.Visibility = Visibility.Visible;
                blink = false;
            }
            else {
                menit.Visibility = Visibility.Hidden;
                blink = true;
            }
            if (DateTime.Now.Hour >= 00 && DateTime.Now.Hour < 11)
            {
                ucapan = "Selamat Pagi,";
            }
            else if (DateTime.Now.Hour >= 11 && DateTime.Now.Hour < 15)
            {
                ucapan = "Selamat Siang,";
            }
            else if (DateTime.Now.Hour >= 15 && DateTime.Now.Hour < 18)
            {
                ucapan = "Selamat Sore,";
            }
            else {
                ucapan = "Selamat Malam";
            }
            Ucapan.Content = ucapan + "\n" + nama;
        }


        private void tutupform(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void minimize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
