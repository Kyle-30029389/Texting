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
    /// Interaction logic for Array.xaml
    /// </summary>
    public partial class Array : Window
    {
        public Array()
        {
            InitializeComponent();
        }

        string[] timeArray = { "thirty minutes", "an hour", "eight hours", "twelve hours", "a day", "a week", "a month", "a year", "a decade" };
        string[] aspectArray = { "finances", "love life", "career prospects", "travel plans", "relationships" };
        string[] effectArray = { "fall apart", "exceed your expectation", "become awkward in an unexpected way", "become manageable", "become spectacular", "come to a positive outcome" };
        string[] personaArray = { "man", "boy", "woman", "girl", "dog", "bird", "hedgehog", "singer", "relative" };
        string[] featureArray = { "pink hair", "a broken golden chain", "scary eyes", "long blond nose hair", "very red lips", "silver feet" };
        string[] consequenceArray = { "avoid looking at directly", "sing a sad song with", "stop and talk to", "dance with", "tell a secret", "buy a coffee" };

        private void Predict_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            Predict_Text.Text = $"Over a period of {timeArray[rand.Next(0, timeArray.Length)]} your {aspectArray[rand.Next(0, aspectArray.Length)]} will {effectArray[rand.Next(0, effectArray.Length)]}.This will come to pass after you meet a {personaArray[rand.Next(0, personaArray.Length)]} with {featureArray[rand.Next(0, featureArray.Length)]} who for some reason you find yourself obliged to {consequenceArray[rand.Next(0, consequenceArray.Length)]}.";
        }
    }
}
