using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDiZO_2.Utility
{
    public static class GraphGenerator
    {
        /* Dla grafu nieskierowanego:
         * d = 2m / n(n - 1)
         * Dla grafu skierowanego:
         * d = m / n(n - 1)
         * Gdzie m - liczba krawędzi; n - liczba wierzchołków; d - gęstość
         * Badane gęstości - 25%, 50%, 75% i 99%
         * 
         *      Format pliku:
         *      Pierwsza linia: [liczba_krawędzi] [liczba_wierzchołków] [wierzchołek_początkowy] [wierzchołek_końcowy]
         *      Kolejne linie - opis krawędzi: [wierzchołek_początkowy] [wierzchołek_końcowy] [waga]
         */


        public static int[] NewGraphArray(int vertexAmount, double density, int start, int finish, bool directed)
        {
            int maxEdgeAmount;
            int edgeAmount = 0;

            if (directed)
            {
                maxEdgeAmount = Convert.ToInt32(density * vertexAmount * (vertexAmount - 1));
            }
            else
            {
                 maxEdgeAmount = Convert.ToInt32(density * vertexAmount * (vertexAmount - 1) / 2);
            }
            
            int[,] matrix = new int[vertexAmount, vertexAmount];
            
            List<int[]> notDone = new List<int[]>();
            Random rng = new Random();


            // Wypełnianie wartościami "zerowymi"
            for (int i = 0; i < vertexAmount; i++)
            {
                for (int j = 0; j < vertexAmount; j++)
                {
                    matrix[i, j] = Int32.MaxValue;
                }
            }

            // Przejście między każdym wierzchołkiem, duże liczby.
            for (int i = 0; i < vertexAmount - 1;)
            {
                matrix[i, i + 1] = rng.Next(0, vertexAmount);
                edgeAmount++;
                i++;
            }

            // Dla 25% w tym miejscu już wszystkie będą skończone.
            if (edgeAmount < maxEdgeAmount)
            {
                // Przejście z końca na początek.
                matrix[vertexAmount - 1, 0] = rng.Next(0, vertexAmount);
                edgeAmount++;


                // Dodanie krawędzi do listy.
                if (directed)
                {
                    for (int i = 0; i < vertexAmount; i++)
                    {
                        for (int j = 0; j < vertexAmount; j++)
                        {
                            if (matrix[i, j] == Int32.MaxValue && i != j)
                            {
                                notDone.Add(new int[2] { i, j });
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < vertexAmount; i++)
                    {
                        for (int j = i + 1; j < vertexAmount; j++)
                        {
                            if (matrix[i, j] == Int32.MaxValue && i != j)
                            {
                                notDone.Add(new int[2] { i, j });
                            }
                        }
                    }
                }
                

                int[][] notDoneArray = notDone.OrderBy(a => rng.Next()).ToArray();

                int fillMatrixIndex = 0;
                int[] currentEdge;
                while (edgeAmount < maxEdgeAmount)
                {
                    currentEdge = notDoneArray[fillMatrixIndex];
                    matrix[currentEdge[0], currentEdge[1]] = rng.Next(0, vertexAmount);
                    edgeAmount++;
                    fillMatrixIndex++;
                }
            }

            int[] array = new int[4 + edgeAmount * 3];
            // Pierwsza linijka
            array[0] = edgeAmount;
            array[1] = vertexAmount;
            array[2] = start;
            array[3] = finish;

            // Przerabianie macierzy na tablice.
            int matrixToArrayIndex = 4;
            for (int i = 0; i < vertexAmount; i++)
            {
                for (int j = 0; j < vertexAmount; j++)
                {
                    if (matrix[i, j] != Int32.MaxValue)
                    {
                        array[matrixToArrayIndex] = i;
                        matrixToArrayIndex++;

                        array[matrixToArrayIndex] = j;
                        matrixToArrayIndex++;

                        array[matrixToArrayIndex] = matrix[i, j];
                        matrixToArrayIndex++;
                    }
                }
            }

           // Zwracana jest tablica taka jakby została wczytana z pliku.
            return array;
        }

    }
}
