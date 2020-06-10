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

namespace TextingApp
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();



            // Textthing.Text = userdata[0].ElementAt(3);


        }
        private void submit_Click(object sender, RoutedEventArgs e)
        {
            
            RegisterClass reg = new RegisterClass
            {
                Name = NameInput.Text,
                Username = UsernameInput.Text,
                Email = EmailInput.Text,
                Age = Convert.ToInt32(AgeInput.Text),
                Password = PasswordInput.Password
            };
            App.db.InsertUserData(reg);

            Login WinLogin = new Login();
            WinLogin.Show();
            this.Close();

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Main = new MainWindow();
            Main.Show();
            this.Close();
        }
    }
}
