using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDiZO_2.Graphs;

namespace SDiZO_2.Algorithms
{
    /*
     * Najkrótsza ścieżka to ścieżka łącząca wszystkie wierzchołki z wierzchołkiem startowym przy jak najmniejszej sumie wag krawędzi.
     *
     */
    class ShortestPathDijkstra : AlgorithmCommon
    { 

        // Przechowuje wierzchołki i koszty dojścia.
        // int[wiersz, kolumna]
        // n - wierzchołek
        // int[0,n] - koszt dojścia z wierzchołka startowego.
        // int[1,n] - indeks wierzchołka-poprzednika.
        // -1/Int32.MaxValue -> brak poprzednika/kosztu dojścia
        private int[,] array;

        // Przechowuje informacje o wierzchołkach które mamy.
        // S - zbiór wierzchołków o policzonych najkrótszych ścieżkach.
        // Q - zbiór wierzchołków bez najkrótszych ścieżek.
        // False -> Q; True -> S;
        private bool[] includedVertexes;

        // Pobierać dane z listy? False -> pobieraj z macierzy.
        public bool ListMode { get; set; }

        // Wierzchołek startowy.
        private int startVertex;

        // Obecnie przetwarzany wierzchołek.
        private int currentVertex;

        private Graph graph;

        public ShortestPathDijkstra(Graph graph, bool mode, int startVertex = 0)
        {
            array = new int[2,graph.VertexAmount];
            includedVertexes = new bool[graph.VertexAmount];

            for (int i = 0; i < graph.VertexAmount; i++)
            {
                array[0, i] = Int32.MaxValue;
                array[1, i] = -1;
            }

            this.startVertex = startVertex;
            this.graph = graph;
            ListMode = mode;
        }

        // Przetwarzanie nowego wierzchołka i jego sąsiadów.
        private void FillNeighbours()
        {
            includedVertexes[currentVertex] = true;
            if (ListMode)
            {
                // Pobierz głowę listy sąsiadów dla danego wierzchołka.
                GListNode node = graph.List[currentVertex].Head;
                node = node.Next;
                // Idź do następnego wierzchołka tak długo aż nie dojdziesz do ogona.
                while (node != graph.List[currentVertex].Tail)
                {
                    // Sprawdź obecny koszt dojścia do i.
                    // Jeżeli nowy koszt dojścia jest mniejszy, zamień koszt i wierzchołek poprzedzający.
                    if (array[0, node.TargetVertex] >= node.Value + array[0, currentVertex])
                    {
                        array[0, node.TargetVertex] = node.Value + array[0, currentVertex];
                        array[1, node.TargetVertex] = currentVertex;
                    }
                    node = node.Next;
                }
            }
            else
            {
                // Przejdź cały rząd dla danego wierzchołka w macierzy.
                // Jeżeli wartość != Int32.MaxValue, dodaj go do tablicy.
                for (int i = 0; i < graph.VertexAmount; i++)
                {
                    // Jeżeli istnieje taka krawędź czyli miejsce w macierzy != Int32.MaxValue.
                    if (graph.Matrix[currentVertex, i] != Int32.MaxValue)
                    {
                        // Sprawdź obecny koszt dojścia do i.
                        // Jeżeli nowy koszt dojścia jest mniejszy, zamień koszt i wierzchołek poprzedzający.
                        if (array[0, i] >= graph.Matrix[currentVertex, i] + array[0, currentVertex])
                        {
                            array[0, i] = graph.Matrix[currentVertex, i] + array[0, currentVertex];
                            array[1, i] = currentVertex;
                        }
                    }
                }
            }
        }

        // Znajdowanie najbliższego wierzchołka.
        private void FindClosestVertex()
        {
            int minValue = Int32.MaxValue;
            // Przeszukiwanie tablicy liniowo.
            for (int i = 0; i < graph.VertexAmount; i++)
            {
                // Jeżeli waga jest mniejsza od obecnej wagi (minValue) i wierzchołek nie znajduje się w S (includedVertexes[n] = false).
                // Wierzchołek staje się nowym najbliższym.
                if (array[0, i] < minValue && includedVertexes[i] == false)
                {
                    currentVertex = i;
                    minValue = array[0, i];
                }

            }

        }

        // Praca.
        public void Work()
        {
            // Zerowy koszt dojścia do wierzchołka startowego.
            array[0, startVertex] = 0;
            
            for (int i = 0; i < graph.VertexAmount; i++)
            {
                // Znajdź najbliższy wierzchołek.
                FindClosestVertex();
                // Przetwórz go.
                FillNeighbours();
            }
        }

        // Zwracanie nazwy pliku.
        public string Filename()
        {
            return "path_dijkstra";
        }
        // Zwracanie typu algorytmu jako string.
        public string Type()
        {
            return "Najkrótsza ścieżka Dijkstry";
        }

        // Wypisywanie zawartości.
        public override string ToString()
        {
            StringBuilder total = new StringBuilder("Najkrótsza ścieżka algorytmem Dijkstry:" + Environment.NewLine + "Start:" + startVertex + Environment.NewLine +"(Wierzchołek){Koszt}(Droga)" + Environment.NewLine);
            StringBuilder path = new StringBuilder();
            int sum = 0;
            int j;
            for (int i = 0; i < includedVertexes.Length; i++)
            {
                total.Append("( " + i + " ) { " + array[0, i] + " } ");
                sum += array[0, i];
                j = array[1, i];
                while (j != -1)
                {
                    path.Append(" " + j);
                    j = array[1, j];
                }
                char[] pathArray = path.ToString().ToCharArray();
                Array.Reverse(pathArray);
                total.Append("( " + new string (pathArray)+ " )" + Environment.NewLine);
                path.Clear();
            }
            total.Append(Environment.NewLine + "Tryb listowy: " + ListMode + Environment.NewLine + "Suma wag: " + sum);
            return total.ToString();
        }
    }
}
