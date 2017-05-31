using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDiZO_2.Graphs
{
    class GraphHeap
    {
        /*
         * Kopiec bazuje na strukturze jaką stworzyłem w pierwszym projekcie.
         */
        private int popamount = 0;
        public Edge[] Array { get; private set; }

        public GraphHeap()
        {
            Array = new Edge[0];
        }

        // Dodawanie nowej krawędzi do kopca.
        public void Insert(int parent, int child, int weight)
        {
            Edge[] newArray = new Edge[Array.Length + 1];
            for (int i = 0; i < Array.Length; i++)
            {
                newArray[i] = Array[i];
            }

            newArray[newArray.Length - 1] = new Edge(parent, child, weight);
            Array = newArray;

            int index = (Array.Length - 1);
            while (index > 0 && Array[(index - 1) / 2].Weight > Array[index].Weight)
            {
                Edge swap = Array[(index - 1) / 2];
                Array[(index - 1) / 2] = Array[index];
                Array[index] = swap;
                index = (index - 1) / 2;
            }

        }

        // Wyciąganie krawędzi o najmniejszej wadze.
        public Edge Pop()
        {
            popamount++;
            Edge edge = Array[0];
            Array[0] = Array[Array.Length - 1];

            Edge[] newArray = new Edge[Array.Length - 1];
            for (int i = 0; i < Array.Length - 1; i++)
            {
                newArray[i] = Array[i];
            }
            Array = newArray;
            // Sortowanie w celu zachowania warunku kopca.
            int index = 0;
            int lChildIndex = 2 * index + 1;
            int rChildIndex = 2 * index + 2;
            bool done = false;
            Edge swap;
            while (!done)
            {
                if (rChildIndex < Array.Length && lChildIndex < Array.Length)
                {
                    if (Array[rChildIndex].Weight < Array[index].Weight || Array[lChildIndex].Weight < Array[index].Weight)
                    {
                        if (Array[rChildIndex].Weight < Array[lChildIndex].Weight)
                        {
                            swap = Array[index];
                            Array[index] = Array[rChildIndex];
                            Array[rChildIndex] = swap;
                            index = rChildIndex;
                        }
                        else
                        {
                            swap = Array[index];
                            Array[index] = Array[lChildIndex];
                            Array[lChildIndex] = swap;
                            index = lChildIndex;
                        }

                    }
                    else
                    {
                        done = true;
                    }

                }
                else
                {
                    if (lChildIndex < Array.Length)
                    {
                        if (Array[lChildIndex].Weight < Array[index].Weight)
                        {
                            swap = Array[index];
                            Array[index] = Array[lChildIndex];
                            Array[lChildIndex] = swap;
                            index = lChildIndex;
                        }
                        else
                        {
                            done = true;
                        }
                    }
                    else
                    {
                        done = true;
                    }

                }

                lChildIndex = 2 * index + 1;
                rChildIndex = 2 * index + 2;
            }

            return edge;
        }

        // Wielkość kopca.
        public int Size()
        {
            return Array.Length;
        }

        // Czyszczenie kopca.
        public void Clear()
        {
            Array = new Edge[0];
        }
    }

    public class Edge
    {
        public int Start { get; set; }
        public int End { get; set; }
        public int Weight { get; set; }

        public Edge(int start, int end, int weight)
        {
            Start = start;
            End = end;
            Weight = weight;

        }
    }
}
