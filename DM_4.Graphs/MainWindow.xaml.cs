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

namespace DM_4.Graphs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Class1 go;
        public MainWindow()
        {
            InitializeComponent();
            go = new Class1(DiscriptionTb);
        }

        private void canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            go.AddNode(e.GetPosition(null).X, e.GetPosition(null).Y,canvas);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool check = true;
            int n1=0;
            int n2=0;
            try
            {
                 n1 = Convert.ToInt32(tb1.Text);
                 n2 = Convert.ToInt32(tb2.Text);
                 if (n1 == n2)
                     check = false;
            }
            catch (Exception) { check = false; }
            if (check)
                go.Connect(n1,n2,canvas);
            tb1.Text = "";
            tb2.Text = "";
        }

        private void DeepBtn_Click(object sender, RoutedEventArgs e)
        {
            go.Refresh();
            DiscriptionTb.Text += "Начали обход вглубину с 0:\n";
            go.Deep(0);
        }

        private void LvlBtn_Click(object sender, RoutedEventArgs e)
        {
            go.Refresh();
            DiscriptionTb.Text += "Начали обход по уровням с 0:\n";
            go.Lvl(0);
        }
    }
}
