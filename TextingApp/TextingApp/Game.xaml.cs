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
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        int Cash;
        int Wheel1Spin;
        int Wheel2Spin;
        int Wheel3Spin;
        public Game()
        {
            InitializeComponent();
            CashAmount.Text = $"You have ${Cash}";
        }

        private void AddCash_Click(object sender, RoutedEventArgs e)
        {
            Cash = Cash + 100;
            CashAmount.Text = $"You have ${Cash}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Cash - 10 > 0)
            {
                Cash = Cash - 10;
                CashAmount.Text = $"You have ${Cash}";
                Random rand = new Random();
                Wheel1Spin = rand.Next(1, 7);
                Wheel2Spin = rand.Next(1, 7);
                Wheel3Spin = rand.Next(1, 7);

                if (Wheel1Spin == 1) Wheel1.Source = new BitmapImage(new Uri("Images/lose.png",
                                                          UriKind.RelativeOrAbsolute));
                else if (Wheel1Spin == 2) Wheel1.Source = new BitmapImage(new Uri("Images/spade.png",
                                                                           UriKind.RelativeOrAbsolute));
                else if (Wheel1Spin == 3) Wheel1.Source = new BitmapImage(new Uri("Images/club.png",
                                                                           UriKind.RelativeOrAbsolute));
                else if (Wheel1Spin == 4) Wheel1.Source = new BitmapImage(new Uri("Images/heart.png",
                                                                           UriKind.RelativeOrAbsolute));
                else if (Wheel1Spin == 5) Wheel1.Source = new BitmapImage(new Uri("Images/diamond.png",
                                                                           UriKind.RelativeOrAbsolute));
                else Wheel1.Source = new BitmapImage(new Uri("Images/win.png", UriKind.RelativeOrAbsolute));



                if (Wheel2Spin == 1) Wheel2.Source = new BitmapImage(new Uri("Images/lose.png",
                                                          UriKind.RelativeOrAbsolute));
                else if (Wheel2Spin == 2) Wheel2.Source = new BitmapImage(new Uri("Images/spade.png",
                                                                           UriKind.RelativeOrAbsolute));
                else if (Wheel2Spin == 3) Wheel2.Source = new BitmapImage(new Uri("Images/club.png",
                                                                           UriKind.RelativeOrAbsolute));
                else if (Wheel2Spin == 4) Wheel2.Source = new BitmapImage(new Uri("Images/heart.png",
                                                                           UriKind.RelativeOrAbsolute));
                else if (Wheel2Spin == 5) Wheel2.Source = new BitmapImage(new Uri("Images/diamond.png",
                                                                           UriKind.RelativeOrAbsolute));
                else Wheel2.Source = new BitmapImage(new Uri("Images/win.png", UriKind.RelativeOrAbsolute));



                if (Wheel3Spin == 1) Wheel3.Source = new BitmapImage(new Uri("Images/lose.png",
                                                          UriKind.RelativeOrAbsolute));
                else if (Wheel3Spin == 2) Wheel3.Source = new BitmapImage(new Uri("Images/spade.png",
                                                                           UriKind.RelativeOrAbsolute));
                else if (Wheel3Spin == 3) Wheel3.Source = new BitmapImage(new Uri("Images/club.png",
                                                                           UriKind.RelativeOrAbsolute));
                else if (Wheel3Spin == 4) Wheel3.Source = new BitmapImage(new Uri("Images/heart.png",
                                                                           UriKind.RelativeOrAbsolute));
                else if (Wheel3Spin == 5) Wheel3.Source = new BitmapImage(new Uri("Images/diamond.png",
                                                                           UriKind.RelativeOrAbsolute));
                else Wheel3.Source = new BitmapImage(new Uri("Images/win.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                CashAmount.Text = $"You dont have enough money";
            }
        }
    }
}
