using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Map
{
    class Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    class Prog
    {
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
                    if (!added[vertexIndex] &&
                        shortestDistances[vertexIndex] <
                        shortestDistance)
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

        // A utility function to print  
        // the constructed distances  
        // array and shortest paths  
        private static void printSolution(int startVertex, int n, int[] distances, int[] parents)
        {
            int nVertices = distances.Length;
            Console.Write("Vertex\t Distance\tPath");

            for (int vertexIndex = 0; vertexIndex < nVertices; vertexIndex++)
            {
                if (vertexIndex != startVertex && vertexIndex == n)
                {
                    //Console.Write("\n" + startVertex + " -> ");
                    //Console.Write(vertexIndex + " \t\t ");
                    //Console.Write(distances[vertexIndex] + "\t\t");
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

        // Driver Code  



    //    static void Main(string[] args)
    //    {
    //        Random ran = new Random();
    //        int num_point = 10;
    //        List<Point> points = new List<Point>();
    //        for (int i = 0; i < num_point; i++)
    //        {
    //            int x = ran.Next(1, 500);
    //            int y = ran.Next(1, 500);
    //            points.Add(new Point(x, y));
    //        }
    //        for (int i = 0; i < num_point; i++)
    //        {
    //            Console.WriteLine(i + " : " + points[i].X + " - " + points[i].Y);
    //        }
    //        int[,] test = new int[num_point, num_point];
    //        for (int i = 0; i < num_point; i++)
    //        {
    //            for (int j = 0; j < num_point; j++)
    //            {
    //                var kc = Math.Sqrt((points[j].X - points[i].X) * (points[j].X - points[i].X) + (points[j].Y - points[i].Y) * (points[j].Y - points[i].Y));
    //                if (Math.Round(kc) > 200)
    //                {
    //                    test[i, j] = 0;
    //                }
    //                else
    //                {
    //                    test[i, j] = (int)Math.Round(kc);
    //                }
    //            }
    //        }
    //        for (int i = 0; i < num_point; i++)
    //        {
    //            Console.Write(i + " : ");
    //            for (int j = 0; j < num_point; j++)
    //            {
    //                Console.Write(test[i, j] + ", ");
    //            }
    //            Console.WriteLine();
    //        }
    //        dijkstra(test, 0, 4);
    //    }

    } 
}

