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

namespace TextingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Login WinLogin = new Login();
            WinLogin.Show();
            this.Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Register WinRegister = new Register();
            WinRegister.Show();
            this.Close();
        }

        private void Prediction_Button_Click(object sender, RoutedEventArgs e)
        {
            Array WinArray = new Array();
            WinArray.Show();
            this.Close();
        }

        private void Game_Button_Click(object sender, RoutedEventArgs e)
        {
            Game WinGame = new Game();
            WinGame.Show();
            this.Close();
        }
    }
}
