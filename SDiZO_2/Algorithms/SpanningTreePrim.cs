using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDiZO_2.Graphs;

namespace SDiZO_2.Algorithms 
{
    /*
     * Drzewo rozpinające - zawiera wszystkie wierzchołki grafu, nie zawiera jednak wszystkich jego krawędzi tylko minimalną ich ilość.
     * Graf może mieć kilka różnych drzew 
     * Graf jest nieskierowany i połączony - wtedy zawiera drzewo.
     * 
     * Algorytm Prima - znajduje drzewo rozpinające o minimalnej sumie wag krawędzi
     *      1 - wybierz wierzchołek do którego jest najkrótsza droga (a nie jest jeszcze w tablicy)
     *      2 - idź do niego
     *      3 - zaktualizuj kolejkę priorytetową (dodaj jego sąsiadów)
     */

    public class SpanningTreePrim : AlgorithmCommon
    {
        // Przechowuje wierzchołki znajdujące się w drzewie.
        private int[] childVertexes;

        // Przechowuje wierzchołki z których doszliśmy, potrzebne do wyświetlania.
        // Przykładowo: childVertexes[n] = X; parentVertexes[n] = Y -> do X doszliśmy z Y, między nimi jest krawędź.
        private int[] parentVertexes;

        // Przechowuje informacje o wierzchołkach które mamy.
        // Przykładowo: includedVertexes[0] = true -> wierzchołek 0 jest w drzewie.
        private bool[] includedVertexes;

        // Pobierać dane z listy? False -> pobieraj z macierzy.
        public bool ListMode { get; set; }

        private Graph graph;
        private GraphHeap heap;
        
        public SpanningTreePrim(Graph graph, bool mode, int startingVertex = 0)
        {
            includedVertexes = new bool[graph.VertexAmount];
            includedVertexes[startingVertex] = true;

            childVertexes = new int[graph.VertexAmount - 1 ];
            parentVertexes = new int[graph.VertexAmount - 1];

            ListMode = mode;
            this.graph = graph;
            heap = new GraphHeap();

            AddNeighboursToHeap(startingVertex);
        }

        // Dodaj sąsiadów wierzchołka do kopca.
        private void AddNeighboursToHeap(int vertex)
        {
            if (ListMode)
            {
                // Pobierz głowę listy sąsiadów dla danego wierzchołka.
                GListNode node = graph.List[vertex].Head;
                node = node.Next;
                // Idź do następnego wierzchołka tak długo aż nie dojdziesz do ogona.
                while (node != graph.List[vertex].Tail)
                {
                    // Dodaj do kolejki.
                    if (includedVertexes[node.TargetVertex] == false)
                    {
                        heap.Insert(vertex, node.TargetVertex, node.Value);
                    }
                    node = node.Next;
                }
            }
            else
            {
                // Jeżeli wartość != Int32.MaxValue, dodaj do kolejki.
                for (int i = 0; i < graph.VertexAmount; i++)
                {
                    if (graph.Matrix[vertex, i] != Int32.MaxValue && includedVertexes[i] == false)
                    {
                        heap.Insert(vertex, i, graph.Matrix[vertex, i]);
                    }
                }
            }
            
        }

        // Praca.
        public void Work()
        {
            int[] currentEdge;
            // currentEdge - minitablica którymi posługuje się kopiec.
            // [0] - początkowy wierzchołek.
            // [1] - końcowy wierzchołek.
            // Tak długo aż nie wypełnisz całej tablicy:
            for(int i = 0; i < parentVertexes.Length;)
            {
                currentEdge = heap.Pop();
                // Pobierz wartość z początku kolejki.
                // Jeżeli nie mamy tej wartości, jej wartość w tablicy bool jest false -> dodaj ją.
                if (includedVertexes[currentEdge[1]] == false)
                {
                    includedVertexes[currentEdge[1]] = true;
                    parentVertexes[i] = currentEdge[0];
                    childVertexes[i] = currentEdge[1];
                    AddNeighboursToHeap(currentEdge[1]);
                    i++;
                }
            }

        }

        // Zwracanie nazwy pliku.
        public string Filename()
        {
            return "mst_prim";
        }

        // Zwracanie typu algorytmu jako string.
        public string Type()
        {
            return "Drzewo rozpinające Prima";
        }

        // Wypisywanie zawartości.
        public override string ToString()
        {
            string total = "Drzewo rozpinające algorytmem Prima:" + Environment.NewLine + "(Wierzchołki){Waga}" + Environment.NewLine;
            int sum = 0;
            for (int i = 0; i < parentVertexes.Length; i++)
            {
                total += "( " + parentVertexes[i] + ", " + childVertexes[i] + " ) { " + graph.Matrix[parentVertexes[i],childVertexes[i]] + " }" + Environment.NewLine;
                sum += graph.Matrix[parentVertexes[i], childVertexes[i]];
            }
            total += Environment.NewLine + "Tryb listowy: " + ListMode + Environment.NewLine + "Suma wag: " + sum + Environment.NewLine;
            return total;
        }
    }

}
