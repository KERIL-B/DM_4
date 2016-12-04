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
    class Node
    {
        Ellipse el;
        TextBlock tb;
        Color nodeColor;
        bool isVisited;

        public double x;
        public double y;
        public int n;
        public List<Node> edges = new List<Node>();

        public Node(int n, double x, double y, Canvas canvas)
        {
            this.n = n;
            this.x = x;
            this.y = y;
            el = new Ellipse();
            tb = new TextBlock();
            canvas.Children.Add(el);
            canvas.Children.Add(tb);
            IsVisited = false;
            Draw(canvas);
        }

        public bool IsVisited
        {
            get { return isVisited; }
            set
            {
                isVisited = value;
                if (isVisited)
                    nodeColor = Colors.DarkBlue;
                else nodeColor = Colors.LightSkyBlue;

                el.Fill = new SolidColorBrush(nodeColor);
            }
        }

        public void Draw(Canvas canvas)
        {            
            el.Fill = new SolidColorBrush(nodeColor);
            el.Width = 30;
            el.Height = 30;
            el.Stroke = Brushes.Black;
            el.StrokeThickness = 1;
            el.Margin = new Thickness(x - el.Width / 2, y - el.Height / 2, 0, 0);

            tb.Foreground = Brushes.White;
            tb.Width = 15;
            tb.Height = 15;
            tb.FontSize = 14;
            tb.Text = this.n + "";
            if (this.n<10)
            tb.Margin = new Thickness(x-4, y - 10, 0, 0);
            else
                tb.Margin = new Thickness(x - 7, y - 10, 0, 0);

            canvas.Children.Remove(el);
            canvas.Children.Remove(tb);
            canvas.Children.Add(el);
            canvas.Children.Add(tb);
        }

        public bool IsConnected(Node node)
        {
            bool tmp=false;
            int i = 0;
            
            while (i < edges.Count && !tmp)
            {
                if (edges[i] == node)
                    tmp = true;
                i++;
            }

            return tmp;
        }
    }
}
