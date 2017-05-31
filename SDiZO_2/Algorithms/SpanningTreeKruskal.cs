using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDiZO_2.Graphs;

namespace SDiZO_2.Algorithms
{
    /*
     * Drzewo rozpinające - zawiera wszystkie wierzchołki grafu, nie zawiera jednak wszystkich jego krawędzi tylko minimalną ich ilość.
     * Graf może mieć kilka różnych drzew 
     * Graf jest nieskierowany i połączony - wtedy zawiera drzewo.
     * 
     * Algorytm Kruskala - znajduje drzewo rozpinające o minimalnej sumie wag krawędzi
     *      1 - utwórz tablicę wszystkich połączeń
     *      2 - posortuj połączenia w sposób niemalejący
     *      3 - pobierz najtańszą krawędź
     *      4 - jeżeli nie tworzy ona cyklu -> dodaj ją do drzewa
     */
    class SpanningTreeKruskal : AlgorithmCommon
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
        private KruskalSet kruskalSet;

        public SpanningTreeKruskal(Graph graph, bool mode)
        {
            childVertexes = new int[graph.VertexAmount - 1];
            parentVertexes = new int[graph.VertexAmount - 1];
            includedVertexes = new bool[graph.VertexAmount];

            this.graph = graph;
            ListMode = mode;

            heap = new GraphHeap();
            kruskalSet = new KruskalSet(graph.VertexAmount);
            
            for (int i = 0; i < graph.VertexAmount; i++)
            {
                // Każdy wierzchołek posiada swój zbiór.
                kruskalSet.MakeSet(i);   
            }
            FillHeap();
        }

        // Dodaj sąsiadów wierzchołka do kopca.
        private void FillHeap()
        {
            if (ListMode)
            {
                // Pobierz głowę listy sąsiadów dla danego wierzchołka.
                for (int i = 0; i < graph.VertexAmount; i++)
                {
                    GListNode node = graph.List[i].Head;
                    node = node.Next;
                    // Idź do następnego wierzchołka tak długo aż nie dojdziesz do ogona.
                    while (node != graph.List[i].Tail)
                    {
                        // Dodaj do kolejki.
                        if (node.TargetVertex > i)
                        {
                            heap.Insert(i, node.TargetVertex, node.Value);
                        }
                        node = node.Next;
                    }
                }
            }
            else
            {
                // Przejdź macierz w sposób "trójkątny" - tyle wystarczy dla grafu nieskierowanego.
                // Jeżeli wartość != Int32.MaxValue, dodaj do kolejki.
                for (int i = 1; i < graph.VertexAmount; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (graph.Matrix[i, j] != Int32.MaxValue)
                        {
                            heap.Insert(i, j, graph.Matrix[i,j]);
                        }
                    }
                }
            }

        }

        // Praca.
        public void Work()
        {
            Edge currentEdge;
            // Tak długo aż nie wypełnisz całej tablicy:
            for (int i = 0; i < parentVertexes.Length;)
            {

                currentEdge = heap.Pop();
                // Pobierz wartość z początku kolejki.

                while (kruskalSet.FindSet(currentEdge.Start) == kruskalSet.FindSet(currentEdge.End))
                {
                    currentEdge = heap.Pop();
                }

                includedVertexes[currentEdge.End] = true;
                includedVertexes[currentEdge.Start] = true;
                parentVertexes[i] = currentEdge.Start;
                childVertexes[i] = currentEdge.End;
                kruskalSet.UnionSets(currentEdge);
                i++;

            }

        }

        // Zwracanie nazwy pliku.
        public string Filename()
        {
            return "mst_kruskal";
        }

        // Zwracanie typu algorytmu jako string.
        public string Type()
        {
            return "Drzewo rozpinające Kruskala";
        }

        // Wypisywanie zawartości.
        public override string ToString()
        {
            string total = "Drzewo rozpinające algorytmem Kruskala:" + Environment.NewLine + "(Wierzchołki){Waga}" + Environment.NewLine;
            int sum = 0;
            for (int i = 0; i < parentVertexes.Length; i++)
            {
                total += "( " + parentVertexes[i] + ", " + childVertexes[i] + " ) { " + graph.Matrix[parentVertexes[i], childVertexes[i]] + " }" + Environment.NewLine;
                sum += graph.Matrix[parentVertexes[i], childVertexes[i]];
            }
            total += Environment.NewLine + "Tryb listowy: " + ListMode + Environment.NewLine + "Suma wag: " + sum + Environment.NewLine;
            return total;
        }
    }

    // Zbiór rozłączny który zapewnia łączność grafu tj. podczas tworzenia krawędzi między dwoma wierzchołkami
    // obecnie zawartymi w drzewie wykrywa czy krawędź "połączy" dwa osobne drzewa czy też stworzy cykl.
    public class KruskalSet
    {
        private KruskalSetNode[] nodes;

        public KruskalSet(int vertexAmount)
        {
            // Tworzenie zbioru dla każdego wierzchołka.
            nodes = new KruskalSetNode[vertexAmount];
            for (int i = 0; i < vertexAmount; i++)
            {
                nodes[i] = new KruskalSetNode();
            }
        }

        // Utwórz zbiór.
        public void MakeSet(int vertex)
        {
            nodes[vertex].Up = vertex;
            nodes[vertex].Amount = 0;
        }

        // Znajdź zbiór.
        public int FindSet(int vertex)
        {
            
            if (nodes[vertex].Up != vertex)
            {
                nodes[vertex].Up = FindSet(nodes[vertex].Up);
            }

            return nodes[vertex].Up;
        }

        // Połącz dwa zbiory.
        public void UnionSets(Edge edge)
        {
            int set1, set2;

            // Znajdujemy zbiory danych wierzchołków.
            set1 = FindSet(edge.Start); 
            set2 = FindSet(edge.End);

            if (set1 != set2)
            {
                // Łączymy je jeżeli są różne.
                // Zbiór mniejszy wchodzi do zbioru większego.
                if (nodes[set1].Amount > nodes[set2].Amount)
                {
                    nodes[set2].Up = set1;
                }
                else
                {
                    nodes[set1].Up = set2;
                    if (nodes[set1].Amount == nodes[set2].Amount)
                    {
                        nodes[set2].Amount++;
                    }
                }
            }
        }
    }

    // Obiekty na których operuje zbiór.
    public class KruskalSetNode
    {
        public int Up { get; set; }
        public int Amount { get; set; }

        public KruskalSetNode()
        {
            Up = 0;
            Amount = 0;
        }
        
    }
    
}
