using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace btlTT
{
    //class Point
    //{
    //    public int X;
    //    public int Y;

    //    public Point(int x, int y)
    //    {
    //        X = x;
    //        Y = y;
    //    }
    //}
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            
        }
        private static readonly int NO_PARENT = -1;

        // Function that implements Dijkstra's  
        // single source shortest path  
        // algorithm for a graph represented  
        // using adjacency matrix  
        // representation  
        private static void dijkstra(int[,] adjacencyMatrix, int startVertex, int end)
        {
            int nVertices = adjacencyMatrix.GetLength(0);

            // shortestDistances[i] will hold the  
            // shortest distance from src to i  
            int[] shortestDistances = new int[nVertices];

            // added[i] will true if vertex i is  
            // included / in shortest path tree  
            // or shortest distance from src to  
            // i is finalized  
            bool[] added = new bool[nVertices];

            // Initialize all distances as  
            // INFINITE and added[] as false  
            for (int vertexIndex = 0; vertexIndex < nVertices; vertexIndex++)
            {
                shortestDistances[vertexIndex] = int.MaxValue;
                added[vertexIndex] = false;
            }

            // Distance of source vertex from  
            // itself is always 0  
            shortestDistances[startVertex] = 0;

            // Parent array to store shortest  
            // path tree  
            int[] parents = new int[nVertices];

            // The starting vertex does not  
            // have a parent  
            parents[startVertex] = NO_PARENT;

            // Find shortest path for all  
            // vertices  
            for (int i = 1; i < nVertices; i++)
            {

                // Pick the minimum distance vertex  
                // from the set of vertices not yet  
                // processed. nearestVertex is  
                // always equal to startNode in  
                // first iteration.  
                int nearestVertex = -1;
                int shortestDistance = int.MaxValue;
                for (int vertexIndex = 0; vertexIndex < nVertices; vertexIndex++)
                {
                    if (!added[vertexIndex] && shortestDistances[vertexIndex] <shortestDistance)
                    {
                        nearestVertex = vertexIndex;
                        shortestDistance = shortestDistances[vertexIndex];
                    }
                }

                // Mark the picked vertex as  
                // processed  


                added[nearestVertex] = true;


                // Update dist value of the  
                // adjacent vertices of the  
                // picked vertex.  
                for (int vertexIndex = 0; vertexIndex < nVertices; vertexIndex++)
                {
                    int edgeDistance = adjacencyMatrix[nearestVertex, vertexIndex];

                    if (edgeDistance > 0
                        && ((shortestDistance + edgeDistance) < shortestDistances[vertexIndex]))
                    {
                        parents[vertexIndex] = nearestVertex;
                        shortestDistances[vertexIndex] = shortestDistance + edgeDistance;
                    }
                }
            }

            printSolution(startVertex, end, shortestDistances, parents);
        }
        static int khoangcach ;
        // A utility function to print  
        // the constructed distances  
        // array and shortest paths  
        private static void printSolution(int startVertex, int n, int[] distances, int[] parents)
        {
            int nVertices = distances.Length;
          //  Console.Write("Vertex\t Distance\tPath");

            for (int vertexIndex = 0; vertexIndex < nVertices; vertexIndex++)
            {
                if (vertexIndex != startVertex && vertexIndex == n)
                {
                    //Console.Write("\n" + startVertex + " -> ");
                    //Console.Write(vertexIndex + " \t\t ");
                   khoangcach= distances[vertexIndex];
                    printPath(vertexIndex, parents);
                }
            }
        }
        static List<int> kq = new List<int>();
        // Function to print shortest path  
        // from source to currentVertex  
        // using parents array  
        private static void printPath(int currentVertex, int[] parents)
        {
            kq.Clear();
            // Base case : Source node has  
            // been processed  
            if (currentVertex == NO_PARENT)
            {
                return;
            }
            printPath(parents[currentVertex], parents);
            //  Console.Write(currentVertex + " ");
            kq.Add(currentVertex);
        }
        Random ran = new Random();
        string path;
        int num_point;
        int start, end;
        List<Point> points = new List<Point>();
        private void Form1_Load(object sender, EventArgs e)
        {
            num_point =ran.Next(0,30);
            start = ran.Next(0, num_point-1);
            end = ran.Next(0, num_point-1);     
            label6.Text = num_point.ToString();
            label7.Text = start.ToString();
            label8.Text = end.ToString();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            //start = int.Parse(textB.ToString());
            //end= int.Parse(textBox1.ToString());
            //  groupBox1_Paint();
        }

        public void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics ve = e.Graphics;
            Brush br = new SolidBrush(Color.Black);
            Font ft = new Font("Courrier new", 9, FontStyle.Bold);
            StringFormat fl = new StringFormat();
            Pen but = new Pen(Color.Gray, 2);
            Pen but1 = new Pen(Color.Blue, 8);
            Pen pen = new Pen(Color.Red, 5);
            Pen pen1 = new Pen(Color.Green, 3);
            for (int i = 0; i < num_point; i++)
            {
                int x = ran.Next(1, 500);
                int y = ran.Next(1, 500);
                points.Add(new Point(x, y));
            }
            for (int i = 0; i < num_point; i++)
            {
                ve.DrawEllipse(pen, points[i].X, points[i].Y, 5, 5);
                ve.DrawString(i.ToString(), ft, br, points[i].X-20, points[i].Y-5 , fl);
            }
            int[,] test = new int[num_point, num_point];
            //for (int i = 0; i < num_point; i++)
            //{
            //    for (int j = 0; j < num_point; j++)
            //    {
            //        var kc = Math.Sqrt((points[j].X - points[i].X) * (points[j].X - points[i].X) + (points[j].Y - points[i].Y) * (points[j].Y - points[i].Y));
            //        if (Math.Round(kc) >200 )
            //        {
            //            test[i, j] = 0;
            //        }
            //        else
            //        {
            //            test[i, j] = (int)Math.Round(kc);
            //          ve.DrawLine(but, points[i].X, points[i].Y, points[j].X, points[j].Y);
            //        }
            //    }
            //}
            for (int k = 0; k < 2; k++)
            {
                for (int i = 0; i < num_point; i++)
                {
                    int j = ran.Next(0, num_point-1);
                    var kc = Math.Sqrt((points[j].X - points[i].X) * (points[j].X - points[i].X) + (points[j].Y - points[i].Y) * (points[j].Y - points[i].Y));
                    test[i, j] = (int)Math.Round(kc);
                    test[j, i] = (int)Math.Round(kc);
                    ve.DrawLine(but, points[i].X, points[i].Y, points[j].X, points[j].Y);
                }
            }
            
                try
                {
                    dijkstra(test, start, end);
                    for (int i = 0; i < kq.Count(); i++)
                    {
                        ve.DrawEllipse(but1, points[kq[i]].X, points[kq[i]].Y, 5, 5);

                    }
                    for (int k = 0; k < kq.Count() - 1; k++)
                    {

                        Thread.Sleep(1000);
                        ve.DrawLine(pen1, points[kq[k]].X, points[kq[k]].Y, points[kq[k + 1]].X, points[kq[k + 1]].Y);
                        path = path + kq[k] + "->";
                    }
                    label2.Text = khoangcach.ToString();

                    path = path + end.ToString();
                    label9.Text = path;
                }
                catch
                {
                    MessageBox.Show("khong tim duoc duong di");
                }
            
        }
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
