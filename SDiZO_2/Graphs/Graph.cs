using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SDiZO_2.Utility;

namespace SDiZO_2
{
    public class Graph
    {
        // Rząd grafu (graph order)     - liczba wierzchołków.
        // Rozmiar grafu (graph size)   - liczba krawędzi.
        // Wierzchołek (vertex)
        // Sposób zapisu w pliku:
        /*
         *      Pierwsza linia: [liczba_krawędzi] [liczba_wierzchołków] [wierzchołek_początkowy] [wierzchołek_końcowy]
         *      Kolejne linie - opis krawędzi: [wierzchołek_początkowy] [wierzchołek_końcowy] [waga]
         */
        // Wierzchołki są numerowane od zera.
        // Dla MST wierzchołki są nieskierowane, dla najkrótszej drogi i maksymalnego przepływu - skierowane.

        // ######## ######## ######## ######## Zmienne
        #region
        // Macierz sąsiedztwa - wag.
        // int[wiersz, kolumna]
        // int32.MaxValue = brak krawędzi
        public int[,] Matrix { get; set; }

        // Lista sąsiedztwa.
        // Stworzona z węzłów zawierających docelowy wierzchołek i wartość brzegu.
        // Modyfikacja listy z pierwszego projektu.
        public GList[] List { get; set; }

        // Ilość wierzchołków.
        public int VertexAmount { get; set; }
    
        // Ilość brzegów.
        public int EdgeAmount { get; set; }

        // Skierowany graf?
        // "Czyściej" można zrobić jedną klasę graf a następnie dwie dziedziczące po niej - skierowane i nieskierowane.
        // Jeżeli okaże się to potrzebne/wygodniejsze, pewnie przerobię.
        public bool Directed { get; set; }

        #endregion

        // Konstruktor.
        public Graph(int[] inputArray, bool directed)
        {
            VertexAmount = inputArray[1];
            EdgeAmount = inputArray[0];
            Directed = directed;

            // Tworzenie "pustej" macierzy - bez połączeń między wierzchołkami (maxValue).
            Matrix = new int[VertexAmount,VertexAmount];
            for (int i = 0; i < VertexAmount; i++)
            {
                for (int j = 0; j < VertexAmount; j++)
                {
                    Matrix[i,j] = Int32.MaxValue;
                }
            }

            // Tworzenie listy.
            List = new GList[VertexAmount];
            for (int i = 0; i < VertexAmount; i++)
            {
                List[i] = new GList();
            }

            int[] fillArray = new int[inputArray.Length - 4];
            for (int i = 0; i < fillArray.Length; i++)
            {
                fillArray[i] = inputArray[i + 4];
            }
            Fill(fillArray);
        }

        // Wypełnianie grafu.
        public void Fill(int[] vertexes)
        {
            // Tablica wejściowa zawiera paczki trójek wczytane z pliku:
            /* [i]                      [i+1]                 [i+2]  
             * [wierzchołek_początkowy] [wierzchołek_końcowy] [waga]
             */

            // Wypełnianie.
            for (int i = 0; i < EdgeAmount * 3; i+=3)
            {
                AddList(vertexes[i], vertexes[i+1], vertexes[i+2]);
                AddMatrix(vertexes[i], vertexes[i + 1], vertexes[i + 2]);
            }

        }

        // Wypełnianie listy.
        private void AddList(int vertexStart, int vertexEnd, int edgeValue)
        {
            if (Directed)
            {
                List[vertexStart].Add(vertexEnd, edgeValue);
            }
            else
            {
                List[vertexStart].Add(vertexEnd, edgeValue);
                List[vertexEnd].Add(vertexStart, edgeValue);
            }
        }

        // Wypełnianie macierzy.
        private void AddMatrix(int vertexStart, int vertexEnd, int edgeValue)
        {
            if (Directed)
            {
                Matrix[vertexStart, vertexEnd] = edgeValue;
            }
            else
            {
                Matrix[vertexStart, vertexEnd] = edgeValue;
                Matrix[vertexEnd, vertexStart] = edgeValue;
            }
        }


        // Funckje zwracają listę stringów gdzie każdy z nich to wiersz "tablicy" wyświetlającej zawartość.
        public string GraphAsList()
        {
            string total = "Graf w formie listy." + Environment.NewLine + "{ wierzchołek } [ docelowy wierzchołek / waga krawędzi ]" + Environment.NewLine 
                + "Ilość wierzchołków: " + VertexAmount + " Ilość krawędzi: " + EdgeAmount + Environment.NewLine;
            for (int i = 0; i < VertexAmount; i++)
            {
                // "\r\n" zamiast samego "\n"!
                // Windows potrzebuje CRLF jako terminatora linii, a nie samego LF.
                // Upd.: lepsze rozwiązanie - Environment.NewLine.
                total += "{" + i + "} - " + List[i] + Environment.NewLine;
            }

            return total;
        }

        public string GraphAsMatrix()
        {
            string total = "Graf w formie macierzy." + Environment.NewLine + "{ wierzchołek } [ waga krawędzi ]" + Environment.NewLine
                           + "Ilość wierzchołków: " + VertexAmount + " Ilość krawędzi: " + EdgeAmount + Environment.NewLine;
            string line;
            for (int i = 0; i < VertexAmount; i++)
            {
                line = "{" + i + "} - ";
                for (int j = 0; j < VertexAmount; j++)
                {
                    if (Matrix[i, j] == Int32.MaxValue)
                    {
                        line += "[_]  ";
                    }
                    else
                    {
                        line += "[" + Matrix[i, j] + "]  ";
                    }
                }
                total += line + Environment.NewLine;
            }

            return total;
        }
        

        // Zwraca zawartość grafu w formie tabeli DataTable.
        // Work in progress - chyba też nie będzie już przydatne.
        public DataTable GraphMatrixToDataTable()
        {
            DataTable table = new DataTable("Macierz sąsiedztwa");
            for (int i = 0; i < VertexAmount; i++)
            {
                table.Columns.Add("[" + i + "]", typeof(string));
            }
            for (int i = 0; i < VertexAmount; i++)
            {
                DataRow newRow = table.NewRow();
                for (int j = 0; j < VertexAmount; j++)
                {
                    if (Matrix[i, j] != Int32.MaxValue)
                    {
                        newRow["[" + j + "]"] = Matrix[i,j];
                    }
                }
                table.Rows.Add(newRow);
            }

            return table;
        }
    }

    // ######## ######## ######## ######## Lista
    #region
    public class GList
    {
        // Property i zmienne.
        public int Size { get; set; }
        public GListNode Head { get; set; } = new GListNode();
        public GListNode Tail { get; set; }= new GListNode();

        public GList()
        {
            Tail.Previous = Head;
            Head.Next = Tail;
        }
        
        // Dodawanie węzła na koniec.
        public void Add(int targetVertex, int value)
        {

            GListNode newListNode = new GListNode(targetVertex, value);

            // Łączenie z poprzednim węzłem
            (Tail.Previous).Next = newListNode;
            newListNode.Previous = (Tail.Previous);

            // Łączenie z ogonem
            Tail.Previous = newListNode;
            newListNode.Next = Tail;

            Size++;
        }

        // Funkcja znajdująca węzeł wybranego wierzchołka.
        // Funkcja nie jest bezpieczna ale jest używana tylko w przypadku gdy mam pewność
        // znalezienia zadanego wierzchołka.
        public GListNode FindByTargetVertex(int vertex)
        {
            GListNode targetListNode;
            targetListNode = Head.Next;
            while (targetListNode.TargetVertex != vertex)
            {
                targetListNode = targetListNode.Next;
            }
            return targetListNode;
        }

        // Zwraca zawartość listy jako string.
        public override string ToString()
        {
            if (this.Size == 0)
            {
                return "Brak";
            }

            string contents = "";
            GListNode currentNode = Head.Next;
            while (currentNode != Tail)
            {
                //contents += "\t[" + currentNode.TargetVertex + " / " + currentNode.Value + "] ";
                contents += currentNode + " ";
                currentNode = currentNode.Next;
            }

            return contents;
        }
    }

    // Węzeł listy.
    public class GListNode
    {
        // Wierzchołek docelowy
        public int TargetVertex { get; set; }

        // Waga krawędzi
        public int Value { get; set; }

        // Następny węzeł
        public GListNode Next { get; set; }

        // Poprzedni węzeł
        public GListNode Previous { get; set; }

        // Konstruktory
        public GListNode(int targetVertex, int value)
        {
            TargetVertex = targetVertex;
            Value = value;
        }
        public GListNode()
        {

        }

        public override string ToString()
        {
            return "[" + TargetVertex + " / " + Value + "]";
        }
    }
    #endregion

}
