using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDiZO_2.Algorithms
{
    /*
     * Najkrótsza ścieżka to ścieżka łącząca wszystkie wierzchołki z wierzchołkiem startowym przy jak najmniejszej sumie wag krawędzi.
     * 
     * Algorytm Bellmana-Forda działa wolniej od Dijkstry ale radzi sobie z krawędziami o wartościach ujemnych. 
     * Nie jest w stanie przetworzyć jednak grafu który posiada cykl ujemny;
     *
     */
    class ShortestPathBellmanFord : AlgorithmCommon
    {
        // Przechowuje wierzchołki i koszty dojścia.
        // int[wiersz, kolumna]
        // n - wierzchołek
        // int[0,n] - koszt dojścia z wierzchołka startowego.
        // int[1,n] - indeks wierzchołka-poprzednika.
        // -1/Int32.MaxValue -> brak poprzednika/kosztu dojścia
        private int[,] array;

        // Pobierać dane z listy? False -> pobieraj z macierzy.
        public bool ListMode { get; set; }

        // Wierzchołek startowy.
        private int startVertex;

        // Obecnie przetwarzany wierzchołek.
        private int currentVertex;

        // Czy jest cykl ujemny?
        private bool negativeCycle = false;

        private Graph graph;

        public ShortestPathBellmanFord(Graph graph, bool mode, int startVertex = 0)
        {
            array = new int[2, graph.VertexAmount];

            for (int i = 0; i < graph.VertexAmount; i++)
            {
                array[0, i] = Int32.MaxValue;
                array[1, i] = -1;
            }

            this.startVertex = startVertex;
            this.graph = graph;
            ListMode = mode;
        }

        // Relaksacja - znajdywanie coraz lepszych rozwiązań (tutaj mniejszych wag) aż do znalezienia optimum.
        private void Relaxation()
        {
            /*
             * Przeglądamy wszystkie krawędzie.
             * Jeżeli trafimy na krawędź A - B (o wadze W) gdzie:
             * 
             * array[0, B] > array[0, A] + W 
             * (koszt dojścia przez A jest mniejszy niż obecny koszt dojścia)
             * 
             * to zmieniamy koszt dojścia i poprzednika B na
             * 
             * array[0, B] = array[0, A] + W
             * array[1, B] = A
             * 
             * po wykonaniu wszystkich przebiegów mamy w tablicy array[n, m] optymalne rozwiązanie problemu.
             * Należy jeszcze sprawdzić czy nie ma nigdzie cyklu ujemnego - jeżeli jest, algorytm musi zwrócić błąd.
             * Aby wykryć cykl ujemny przeglądamy tablice. Jeżeli natrafimy na krawędź A - B (o wadze W) gdzie 
             * 
             * array[0, B] > array[0, A] + W
             * i array[1, B] = A
             * 
             * cykl ujemny występuje w grafie.
             *
             */
            for (int j = 0; j < graph.VertexAmount; j++)
            {
                if (ListMode)
                {

                    // Pobierz głowę listy sąsiadów dla danego wierzchołka.
                    GListNode node = graph.List[j].Head;
                    node = node.Next;
                    // Idź do następnego wierzchołka tak długo aż nie dojdziesz do ogona.
                    while (node != graph.List[j].Tail)
                    {
                        // Sprawdź obecny koszt dojścia do i.
                        // Jeżeli nowy koszt dojścia jest mniejszy, zamień koszt i wierzchołek poprzedzający.
                        // Dodatkowe warunki:
                        //      Nie wolno szukać dojścia do wierzchołka startowego
                        //      Nie wolno używać wierzchołka który nie ma poprzednika
                        //      Bez drugiego warunku następowało przepełnienie (Int32.MaxValue + cokolwiek = bardzo mała liczba ujemna)
                        if (array[0, node.TargetVertex] > node.Value + array[0, j] && node.TargetVertex != startVertex && array[1, j] != -1)
                        {
                            array[0, node.TargetVertex] = node.Value + array[0, j];
                            array[1, node.TargetVertex] = j;
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
                        // Dodatkowe warunki:
                        //      Nie wolno szukać dojścia do wierzchołka startowego
                        //      Nie wolno używać wierzchołka który nie ma poprzednika
                        //      Bez drugiego warunku następowało przepełnienie (Int32.MaxValue + cokolwiek = bardzo mała liczba ujemna)
                        if (graph.Matrix[j, i] != int.MaxValue && i != startVertex && array[1, j] != -1)
                        {
                            if (array[0, i] > graph.Matrix[j, i] + array[0, j])
                            {
                                array[0, i] = graph.Matrix[j, i] + array[0, j];
                                array[1, i] = j;
                            }
                        }
                    }
                }
            }
               
        }

        // Szukanie ujemnego cyklu.
        private void FindNegativeCycle()
        {
            /*
            *Aby wykryć cykl ujemny przeglądamy tablice. Jeżeli natrafimy na krawędź A - B(o wadze W) gdzie
            *
            * array[0, B] > array[0, A] + W
            * i array[1, B] = A
            * 
            * to istnieje cykl ujemny.
            */
            for (int i = 0; i < graph.VertexAmount; i++)
            {
                if (i != startVertex)
                {
                    int parent = array[1, i];
                    if (ListMode)
                    {
                        if (array[0, i] > array[0, parent] + graph.List[parent].FindByTargetVertex(i).Value)
                        {
                            negativeCycle = true;
                            return;
                        }
                    }
                    else
                    {
                        if (array[0, i] > array[0, parent] + graph.Matrix[parent, i])
                        {
                            negativeCycle = true;
                            return;
                        }
                    }
                }
            }
            negativeCycle = false;
            return;
        }

        // Praca.
        public void Work()
        {
            // Zerowy koszt dojścia do wierzchołka startowego.
            array[0, startVertex] = 0;
            // "specjalna" wartość tak by odróżnić wierzchołek startowy od innych (które mają -1).
            array[1, startVertex] = -2; 

            for (int i = 0; i < graph.VertexAmount; i++)
            {
                Relaxation();
            }
            FindNegativeCycle();
        }

        // Zwracanie nazwy pliku.
        public string Filename()
        {
            return "path_bellmanford";
        }

        // Zwracanie typu algorytmu jako string.
        public string Type()
        {
            return "Najkrótsza ścieżka Bellmana-Forda";
        }

        // Wypisywanie zawartości.
        public override string ToString()
        {
            StringBuilder total = new StringBuilder("Najkrótsza ścieżka algorytmem Bellmana-Forda:" + Environment.NewLine + "Start:" + startVertex + Environment.NewLine + "(Wierzchołek){Koszt}(Droga)" + Environment.NewLine);
            StringBuilder path = new StringBuilder();
            int sum = 0;
            int j;
            if (negativeCycle)
            {
                return total + "Cykl ujemny!";
            }
            for (int i = 0; i < graph.VertexAmount; i++)
            {
                total.Append("( " + i + " ) { " + array[0, i] + " } ");
                sum += array[0, i];
                j = array[1, i];
                while (j != -2)
                {
                    path.Append(" " + j);
                    j = array[1, j];
                }
                char[] pathArray = path.ToString().ToCharArray();
                Array.Reverse(pathArray);
                total.Append("( " + new string(pathArray) + " )" + Environment.NewLine);
                path.Clear();
            }
            total.Append(Environment.NewLine + "Tryb listowy: " + ListMode + Environment.NewLine + "Suma wag: " + sum);
            return total.ToString();
        }
    }
}
