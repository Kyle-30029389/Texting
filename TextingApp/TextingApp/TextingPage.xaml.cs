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
    /// Interaction logic for TextingPage.xaml
    /// </summary>
    public partial class TextingPage : Window
    {
        public TextingPage()
        {
            InitializeComponent();
            List<PostStructure> lists = new List<PostStructure>();
            lists = App.db.DisplayPost();
            lists.Reverse();
            lbTodoList.ItemsSource = lists;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            App.db.MakePost(Input.Text);
            Input.Text = "";
            List<PostStructure> lists = new List<PostStructure>();
            lists = App.db.DisplayPost();
            lists.Reverse();
            lbTodoList.ItemsSource = lists;
        }

        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
