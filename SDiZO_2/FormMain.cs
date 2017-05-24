using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using SDiZO_2.Algorithms;
using SDiZO_2.Utility;

namespace SDiZO_2
{
    public partial class FormMain : Form
    {
        private int[] inputArray;
        private int repeat;
        private bool negative;
        private List<String> listBoxSource;
        private Graph graph;
        private SpanningTreePrim spanningTreePrim;
        private Clock spanningTreePrimClock;
        private SpanningTreeKruskal spanningTreeKruskal;
        private Clock spanningTreeKruskalClock;
        private ShortestPathBellmanFord shortestPathBellmanFord;
        private Clock shortestPathBellmanFordClock;
        private ShortestPathDijkstra shortestPathDijkstra;
        private Clock shortestPathDijkstraClock;

        public FormMain()
        {
            InitializeComponent();
            textBoxFilename.Text = "input";
            //textBoxCreateGraphFilename.Text = "input";
            radioButtonSpanningTreePrim.Checked = true;
            radioButtonShortestPathDijkstra.Checked = true;
            radioButtonModeMatrix.Checked = true;
            checkBoxLoadDirected.Checked = true;

            repeat = 1;
            textBoxRepeatCurrent.Text = repeat.ToString();

            listBoxSource = new List<String>();
            listBoxSource.Add("0,25");
            listBoxSource.Add("0,50");
            listBoxSource.Add("0,75");
            listBoxSource.Add("0,99");
            listBoxCreateGraphDensity.DataSource = listBoxSource;
        }

        // ######## ######## ######## ######## Przyciski
        #region

        // Zmiana mnożnika.
        private void buttonRepeatChange_Click(object sender, EventArgs e)
        {
            int newRepeat;
            if (!int.TryParse(textBoxRepeatNew.Text, out newRepeat))
            {
                MessageBox.Show("Nieprawidłowa liczba", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                repeat = newRepeat;
                if (repeat < 0)
                {
                    repeat = 1;
                }
                textBoxRepeatCurrent.Text = repeat.ToString();
            }

        }

        // Wyświetlanie w formie macierzy.
        private void buttonDisplayMatrix_Click(object sender, EventArgs e)
        {
            if (graph != null)
            {
                FormDisplay fD = new FormDisplay(graph.GraphAsMatrix());
                fD.Show();
            }
            else
            {
                MessageBox.Show("Graf nie został stworzony!", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Wyświetlanie w formie listy.
        private void buttonDisplayList_Click(object sender, EventArgs e)
        {
            if (graph != null)
            {
                FormDisplay fD = new FormDisplay(graph.GraphAsList());
                fD.Show();
            }
            else
            {
                MessageBox.Show("Graf nie został stworzony!", "Błąd",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Wyświetlanie drzewa rozpinającego.
        private void buttonSpanningTreeDisplay_Click(object sender, EventArgs e)
        {
            if (graph != null && (spanningTreeKruskal != null || spanningTreePrim != null))
            {
                if (radioButtonSpanningTreeKruskal.Checked)
                {
                    FormDisplay fD = new FormDisplay(spanningTreeKruskal.ToString());
                    fD.Show();
                }
                else
                {
                    FormDisplay fD = new FormDisplay(spanningTreePrim.ToString());
                    fD.Show();
                }
                
            }
            else
            {
                MessageBox.Show("Graf nie został stworzony lub jest skierowany!", "Błąd",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Wyświetlanie najkrótszej ścieżki.
        private void buttonShortestPathDisplay_Click(object sender, EventArgs e)
        {
            if (graph != null && (shortestPathDijkstra != null || shortestPathBellmanFord != null))
            {
                if (radioButtonShortestPathDijkstra.Checked)
                {
                    FormDisplay fD = new FormDisplay(shortestPathDijkstra.ToString());
                    fD.Show();
                }
                else
                {
                    FormDisplay fD = new FormDisplay(shortestPathBellmanFord.ToString());
                    fD.Show();
                }
            }
            else
            {
                MessageBox.Show("Graf nie został stworzony!", "Błąd",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Start algorytmu drzewa rozpinającego.
        private void buttonSpanningTreeRun_Click(object sender, EventArgs e)
        {
            if (graph != null)
            {


                if (radioButtonSpanningTreeKruskal.Checked)
                {
                    spanningTreeKruskal = new SpanningTreeKruskal(graph, radioButtonModeList.Checked);
                    spanningTreeKruskalClock = new Clock(graph, spanningTreeKruskal);
                    for (int i = 0; i < repeat; i++)
                    {
                        spanningTreeKruskalClock.Start();
                        spanningTreeKruskal = new SpanningTreeKruskal(graph, radioButtonModeList.Checked);
                        spanningTreeKruskal.Work();
                        spanningTreeKruskalClock.Stop();
                    }
                    spanningTreeKruskalClock.End();
                    textBoxSpanningTreeTime.Text = spanningTreeKruskalClock.Average().ToString();
                }
                else
                {
                    spanningTreePrim = new SpanningTreePrim(graph, radioButtonModeList.Checked, 0);
                    spanningTreePrimClock = new Clock(graph, spanningTreePrim);
                    for (int i = 0; i < repeat; i++)
                    {
                        spanningTreePrimClock.Start();
                        spanningTreePrim = new SpanningTreePrim(graph, radioButtonModeList.Checked, 0);
                        spanningTreePrim.Work();
                        spanningTreePrimClock.Stop();
                    }
                    spanningTreePrimClock.End();
                    textBoxSpanningTreeTime.Text = spanningTreePrimClock.Average().ToString();
                }
            }
            else
            {
                MessageBox.Show("Graf nie został stworzony!", "Błąd",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Start algorytmu najkrótszej ścieżki.
        private void buttonShortestPathRun_Click(object sender, EventArgs e)
        {
            if (graph != null)
            {
                if (radioButtonShortestPathDijkstra.Checked)
                {
                    if (!negative)
                    {
                        shortestPathDijkstra = new ShortestPathDijkstra(graph, radioButtonModeList.Checked, inputArray[2]);
                        shortestPathDijkstraClock = new Clock(graph, shortestPathDijkstra);
                        for (int i = 0; i < repeat; i++)
                        {
                            shortestPathDijkstraClock.Start();
                            shortestPathDijkstra = new ShortestPathDijkstra(graph, radioButtonModeList.Checked, inputArray[2]);
                            shortestPathDijkstra.Work();
                            shortestPathDijkstraClock.Stop();
                        }
                        shortestPathDijkstraClock.End();
                        textBoxShortestPathTime.Text = shortestPathDijkstraClock.Average().ToString();
                    }
                    else
                    {
                        MessageBox.Show("Krawędź ujemna! Dijkstra nie może wystartować!", "Błąd",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   
                }
                else
                {
                    shortestPathBellmanFord = new ShortestPathBellmanFord(graph, radioButtonModeList.Checked, inputArray[2]);
                    shortestPathBellmanFordClock = new Clock(graph, shortestPathBellmanFord);
                    for (int i = 0; i < repeat; i++)
                    {
                        shortestPathBellmanFordClock.Start();
                        shortestPathBellmanFord = new ShortestPathBellmanFord(graph, radioButtonModeList.Checked, inputArray[2]);
                        shortestPathBellmanFord.Work();
                        shortestPathBellmanFordClock.Stop();
                    }
                    shortestPathBellmanFordClock.End();
                    textBoxShortestPathTime.Text = shortestPathBellmanFordClock.Average().ToString();
                }
            }
            else
            {
                MessageBox.Show("Graf nie został stworzony!", "Błąd",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Tworzenie grafu (wczytanie z pliku).
        private void buttonCreateGraph_Click(object sender, EventArgs e)
        {
            ReadFile(textBoxFilename.Text);
            if (inputArray == null)
            {
                graph = null;
                MessageBox.Show("Coś poszło nie tak. Graf nie został stworzony.", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                graph = new Graph(inputArray, checkBoxLoadDirected.Checked);
            }
            

        }

        #endregion

        // ######## ######## ######## ######## Funkcje
        #region
        // Funkcja wczytująca z pliku.
        private void ReadFile(string filename)
        {
            try
            {
                using (StreamReader sr = new StreamReader(@".\" + filename + ".txt"))
                {
                    //  ASCII   symbol
                    //  48      0
                    //  57      9
                    List<int> inputList = new List<int>();
                    int amount = 0;
                    int symbol;
                    int intNumber;
                    string number;
                    negative = false;
                    while (!sr.EndOfStream)
                    {
                        number = "";
                        symbol = sr.Read();
                        while (symbol >= 48 && symbol <= 57 || symbol == 45)
                        {
                            if (symbol == 45)
                            {
                                negative = true;
                            }
                            number += (char) symbol;
                            symbol = sr.Read();

                        }
                        if (number != "")
                        {
                            if (!int.TryParse(number, out intNumber))
                            {
                                MessageBox.Show("Nieprawidłowa liczba", "Błąd",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                inputArray = null;
                                return;
                            }
                            inputList.Add(intNumber);
                        }

                    }
                    // Plik załadowany -> zielony kolor.
                    textBoxFilename.BackColor = Color.MediumAquamarine;
                    inputArray = inputList.ToArray();

                    // Tablica wejściowa zawiera ogólne informacje oraz paczki trójek wczytane z pliku:
                    /* [n]                      [n+1]                 [n+2]  
                     * [wierzchołek_początkowy] [wierzchołek_końcowy] [waga]
                     */
                    // Nieprawidłowa tablica - nie składa się z trójek lub jest ich za mało.
                    if ((inputArray.Length - 4) % 3 != 0 || (inputArray.Length - 4) != inputArray[0] * 3)
                    {
                        MessageBox.Show("Nieprawidłowy plik wejściowy.", "Błąd",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        inputArray = null;
                        return;
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.ToString(), "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Plik załadowany -> czerwony kolor.
                this.BackColor = Color.MediumVioletRed;
                throw;
            }

        }

        // Funkcja tworząca graf.
        private void CreateGraph()
        {
            inputArray = GraphGenerator.NewGraphArray(Convert.ToInt32(textBoxCreateGraphSize.Text), Convert.ToDouble(listBoxSource[listBoxCreateGraphDensity.SelectedIndex]), 0, 0, 
                checkBoxCreateGraphDirected.Checked);
            graph = new Graph(inputArray, checkBoxCreateGraphDirected.Checked);
            textBoxCreateGraphSize.BackColor = Color.MediumAquamarine;
        }
        #endregion

        // Po załadowaniu pliku textBox jest zielony.
        // Ta funkcja zmienia kolor textBox gdy zmieniamy nazwę pliku.
        private void textBoxFilename_TextChanged(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.Window;
            
        }

        private void buttonCreateNewGraph_Click(object sender, EventArgs e)
        {
            CreateGraph();
        }

        private void textBoxCreateGraphSize_TextChanged(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.Window;
        }
    }
}