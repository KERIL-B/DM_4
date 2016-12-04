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
    class Class1
    {

        List<Node> nodes = new List<Node>();
        TextBox tb;

        public Class1(TextBox tb)
        {
            this.tb = tb;

        }

        public void AddNode(double x, double y, Canvas canvas)
        {
            Refresh();
            nodes.Add(new Node(nodes.Count, x, y, canvas));
            tb.Text += "Добавили узел №"+nodes.Count+";\n";
        }

        public void Connect(int n1, int n2, Canvas canvas)
        {
            if (n1 < nodes.Count && n2 < nodes.Count)
            {
                if (!nodes[n1].IsConnected(nodes[n2]))
                {
                    Refresh(); 

                    nodes[n1].edges.Add(nodes[n2]);
                    nodes[n2].edges.Add(nodes[n1]);

                    Line l = new Line();
                    l.X1 = nodes[n1].x;
                    l.X2 = nodes[n2].x;
                    l.Y1 = nodes[n1].y;
                    l.Y2 = nodes[n2].y;
                    l.StrokeThickness = 1;
                    l.Stroke = Brushes.Black;
                    canvas.Children.Add(l);
                    nodes[n1].Draw(canvas);
                    nodes[n2].Draw(canvas);

                    tb.Text += "Связали узел " + n1 +" с узлом "+ n2 + ";\n";
                }
            }
        }

        public void Refresh()
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].IsVisited = false;
            }
        }

        public void Deep(int n)
        {
            if (!nodes[n].IsVisited)
            {
                nodes[n].IsVisited = true;
                tb.Text += "Поситили узел "+n+";\n";
                for (int i = 0; i < nodes[n].edges.Count; i++)
                {
                    Deep(nodes[n].edges[i].n);
                }

            }
        }

        public void Lvl(int n)
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(n);
            nodes[n].IsVisited = true;
            tb.Text += "Посетли узел " + n + ";\n";
            while (q.Count > 0)
            {
                int v = q.Dequeue();
                for (int i=0;i<nodes[v].edges.Count;i++)
                {
                    if (!nodes[v].edges[i].IsVisited)
                    {
                        q.Enqueue(nodes[v].edges[i].n);
                        nodes[v].edges[i].IsVisited = true;
                        tb.Text += "Посетли узел " + nodes[v].edges[i].n + ";\n";
                    }
                }
            }

        }
    }
}
