using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDiZO_2.Algorithms;

namespace SDiZO_2.Utility
{
    class Clock
    {
        // Pomiar czasu + wypisywanie do pliku.
        // Ulepszona wersja z pierwszego projektu.
        public string Filename { get; set; }
        private Stopwatch sw;
        private List<double> timeList;
        private double ticks;

        public Clock(Graph graph, AlgorithmCommon algorithm)
        {
            sw = new Stopwatch();
            timeList = new List<double>();

            Filename = algorithm.Filename();
            double density = graph.EdgeAmount / graph.VertexAmount * (graph.VertexAmount - 1);

            string firstLine = "Directed: " + graph.Directed + " Vertexes: " + graph.VertexAmount + " Edges: " +
                            graph.EdgeAmount + " Density: " + density;
            SaveToFile(firstLine);

            string secondLine = "Algorithm: " + algorithm.Type() + " Mode: ";
            if (algorithm.ListMode)
            {
                secondLine += "List";
            }
            else
            {
                secondLine += "Matrix";
            }
            SaveToFile(secondLine);
        }

        #region
        // Start od nowa.
        public void Start()
        {
            sw.Reset();
            sw.Start();
        }

        // Kontynuacja.
        public void Continue()
        {
            sw.Start();
        }

        // Pauza.
        public void Pause()
        {
            sw.Stop();
        }

        // Koniec pojedynczego pomiaru.
        public void Stop()
        {
            sw.Stop();
            timeList.Add(sw.Elapsed.TotalMilliseconds);
        }

        // Koniec serii pomiarów.
        public void End()
        {
            SaveToFile("Average time: " + Average() + " Time count: " + timeList.Count);
            SaveToFile("*** *** *** ***");
        }
        #endregion

        // Średnia z obecnej serii pomiarów.
        public double Average()
        {
            double average;
            average = timeList.Sum();
            average = (average / timeList.Count);

            return average;
        }

        // Zapis pojedynczej linii do pliku.
        public void SaveToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(@"./" + Filename + ".txt", true))
            {
                sw.WriteLine(text + Environment.NewLine);
            }
        }
    }
}
