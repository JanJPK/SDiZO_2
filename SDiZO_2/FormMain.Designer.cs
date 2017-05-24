namespace SDiZO_2
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxDisplay = new System.Windows.Forms.GroupBox();
            this.labelList = new System.Windows.Forms.Label();
            this.labelMatrix = new System.Windows.Forms.Label();
            this.buttonDisplayList = new System.Windows.Forms.Button();
            this.buttonDisplayMatrix = new System.Windows.Forms.Button();
            this.groupBoxLoad = new System.Windows.Forms.GroupBox();
            this.checkBoxLoadDirected = new System.Windows.Forms.CheckBox();
            this.buttonLoadGraph = new System.Windows.Forms.Button();
            this.labelFilename = new System.Windows.Forms.Label();
            this.textBoxFilename = new System.Windows.Forms.TextBox();
            this.groupBoxShortestPath = new System.Windows.Forms.GroupBox();
            this.textBoxShortestPathTime = new System.Windows.Forms.TextBox();
            this.buttonShortestPathDisplay = new System.Windows.Forms.Button();
            this.radioButtonShortestPathDijkstra = new System.Windows.Forms.RadioButton();
            this.radioButtonShortestPathFordBellman = new System.Windows.Forms.RadioButton();
            this.buttonShortestPathRun = new System.Windows.Forms.Button();
            this.groupBoxSpanningTree = new System.Windows.Forms.GroupBox();
            this.textBoxSpanningTreeTime = new System.Windows.Forms.TextBox();
            this.buttonSpanningTreeDisplay = new System.Windows.Forms.Button();
            this.radioButtonSpanningTreePrim = new System.Windows.Forms.RadioButton();
            this.radioButtonSpanningTreeKruskal = new System.Windows.Forms.RadioButton();
            this.buttonSpanningTreeRun = new System.Windows.Forms.Button();
            this.groupBoxMode = new System.Windows.Forms.GroupBox();
            this.radioButtonModeMatrix = new System.Windows.Forms.RadioButton();
            this.radioButtonModeList = new System.Windows.Forms.RadioButton();
            this.groupBoxCreate = new System.Windows.Forms.GroupBox();
            this.listBoxCreateGraphDensity = new System.Windows.Forms.ListBox();
            this.textBoxCreateGraphSize = new System.Windows.Forms.TextBox();
            this.buttonCreateNewGraph = new System.Windows.Forms.Button();
            this.groupBoxRepeat = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxRepeatCurrent = new System.Windows.Forms.TextBox();
            this.buttonRepeatChange = new System.Windows.Forms.Button();
            this.textBoxRepeatNew = new System.Windows.Forms.TextBox();
            this.checkBoxCreateGraphDirected = new System.Windows.Forms.CheckBox();
            this.groupBoxDisplay.SuspendLayout();
            this.groupBoxLoad.SuspendLayout();
            this.groupBoxShortestPath.SuspendLayout();
            this.groupBoxSpanningTree.SuspendLayout();
            this.groupBoxMode.SuspendLayout();
            this.groupBoxCreate.SuspendLayout();
            this.groupBoxRepeat.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDisplay
            // 
            this.groupBoxDisplay.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBoxDisplay.Controls.Add(this.labelList);
            this.groupBoxDisplay.Controls.Add(this.labelMatrix);
            this.groupBoxDisplay.Controls.Add(this.buttonDisplayList);
            this.groupBoxDisplay.Controls.Add(this.buttonDisplayMatrix);
            this.groupBoxDisplay.Location = new System.Drawing.Point(188, 12);
            this.groupBoxDisplay.Name = "groupBoxDisplay";
            this.groupBoxDisplay.Size = new System.Drawing.Size(140, 82);
            this.groupBoxDisplay.TabIndex = 1;
            this.groupBoxDisplay.TabStop = false;
            this.groupBoxDisplay.Text = "Wypisywanie zawartości";
            // 
            // labelList
            // 
            this.labelList.AutoSize = true;
            this.labelList.Location = new System.Drawing.Point(87, 53);
            this.labelList.Name = "labelList";
            this.labelList.Size = new System.Drawing.Size(29, 13);
            this.labelList.TabIndex = 3;
            this.labelList.Text = "Lista";
            // 
            // labelMatrix
            // 
            this.labelMatrix.AutoSize = true;
            this.labelMatrix.Location = new System.Drawing.Point(87, 24);
            this.labelMatrix.Name = "labelMatrix";
            this.labelMatrix.Size = new System.Drawing.Size(44, 13);
            this.labelMatrix.TabIndex = 2;
            this.labelMatrix.Text = "Macierz";
            // 
            // buttonDisplayList
            // 
            this.buttonDisplayList.Location = new System.Drawing.Point(6, 48);
            this.buttonDisplayList.Name = "buttonDisplayList";
            this.buttonDisplayList.Size = new System.Drawing.Size(75, 23);
            this.buttonDisplayList.TabIndex = 1;
            this.buttonDisplayList.Text = "Wypisz";
            this.buttonDisplayList.UseVisualStyleBackColor = true;
            this.buttonDisplayList.Click += new System.EventHandler(this.buttonDisplayList_Click);
            // 
            // buttonDisplayMatrix
            // 
            this.buttonDisplayMatrix.Location = new System.Drawing.Point(6, 19);
            this.buttonDisplayMatrix.Name = "buttonDisplayMatrix";
            this.buttonDisplayMatrix.Size = new System.Drawing.Size(75, 23);
            this.buttonDisplayMatrix.TabIndex = 0;
            this.buttonDisplayMatrix.Text = "Wypisz";
            this.buttonDisplayMatrix.UseVisualStyleBackColor = true;
            this.buttonDisplayMatrix.Click += new System.EventHandler(this.buttonDisplayMatrix_Click);
            // 
            // groupBoxLoad
            // 
            this.groupBoxLoad.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBoxLoad.Controls.Add(this.checkBoxLoadDirected);
            this.groupBoxLoad.Controls.Add(this.buttonLoadGraph);
            this.groupBoxLoad.Controls.Add(this.labelFilename);
            this.groupBoxLoad.Controls.Add(this.textBoxFilename);
            this.groupBoxLoad.Location = new System.Drawing.Point(12, 12);
            this.groupBoxLoad.Name = "groupBoxLoad";
            this.groupBoxLoad.Size = new System.Drawing.Size(170, 82);
            this.groupBoxLoad.TabIndex = 4;
            this.groupBoxLoad.TabStop = false;
            this.groupBoxLoad.Text = "Wczytywanie grafu";
            // 
            // checkBoxLoadDirected
            // 
            this.checkBoxLoadDirected.AutoSize = true;
            this.checkBoxLoadDirected.Location = new System.Drawing.Point(8, 52);
            this.checkBoxLoadDirected.Name = "checkBoxLoadDirected";
            this.checkBoxLoadDirected.Size = new System.Drawing.Size(81, 17);
            this.checkBoxLoadDirected.TabIndex = 5;
            this.checkBoxLoadDirected.Text = "Skierowany";
            this.checkBoxLoadDirected.UseVisualStyleBackColor = true;
            // 
            // buttonLoadGraph
            // 
            this.buttonLoadGraph.Location = new System.Drawing.Point(94, 48);
            this.buttonLoadGraph.Name = "buttonLoadGraph";
            this.buttonLoadGraph.Size = new System.Drawing.Size(70, 23);
            this.buttonLoadGraph.TabIndex = 4;
            this.buttonLoadGraph.Text = "Wczytaj";
            this.buttonLoadGraph.UseVisualStyleBackColor = true;
            this.buttonLoadGraph.Click += new System.EventHandler(this.buttonCreateGraph_Click);
            // 
            // labelFilename
            // 
            this.labelFilename.AutoSize = true;
            this.labelFilename.Location = new System.Drawing.Point(101, 24);
            this.labelFilename.Name = "labelFilename";
            this.labelFilename.Size = new System.Drawing.Size(65, 13);
            this.labelFilename.TabIndex = 4;
            this.labelFilename.Text = "Nazwa pliku";
            // 
            // textBoxFilename
            // 
            this.textBoxFilename.Location = new System.Drawing.Point(6, 21);
            this.textBoxFilename.Name = "textBoxFilename";
            this.textBoxFilename.Size = new System.Drawing.Size(89, 20);
            this.textBoxFilename.TabIndex = 0;
            // 
            // groupBoxShortestPath
            // 
            this.groupBoxShortestPath.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBoxShortestPath.Controls.Add(this.textBoxShortestPathTime);
            this.groupBoxShortestPath.Controls.Add(this.buttonShortestPathDisplay);
            this.groupBoxShortestPath.Controls.Add(this.radioButtonShortestPathDijkstra);
            this.groupBoxShortestPath.Controls.Add(this.radioButtonShortestPathFordBellman);
            this.groupBoxShortestPath.Controls.Add(this.buttonShortestPathRun);
            this.groupBoxShortestPath.Location = new System.Drawing.Point(12, 100);
            this.groupBoxShortestPath.Name = "groupBoxShortestPath";
            this.groupBoxShortestPath.Size = new System.Drawing.Size(205, 99);
            this.groupBoxShortestPath.TabIndex = 6;
            this.groupBoxShortestPath.TabStop = false;
            this.groupBoxShortestPath.Text = "Najkrótsza ścieżka";
            // 
            // textBoxShortestPathTime
            // 
            this.textBoxShortestPathTime.Location = new System.Drawing.Point(109, 72);
            this.textBoxShortestPathTime.Name = "textBoxShortestPathTime";
            this.textBoxShortestPathTime.Size = new System.Drawing.Size(90, 20);
            this.textBoxShortestPathTime.TabIndex = 10;
            // 
            // buttonShortestPathDisplay
            // 
            this.buttonShortestPathDisplay.Location = new System.Drawing.Point(129, 39);
            this.buttonShortestPathDisplay.Name = "buttonShortestPathDisplay";
            this.buttonShortestPathDisplay.Size = new System.Drawing.Size(70, 23);
            this.buttonShortestPathDisplay.TabIndex = 6;
            this.buttonShortestPathDisplay.Text = "Wypisz";
            this.buttonShortestPathDisplay.UseVisualStyleBackColor = true;
            this.buttonShortestPathDisplay.Click += new System.EventHandler(this.buttonShortestPathDisplay_Click);
            // 
            // radioButtonShortestPathDijkstra
            // 
            this.radioButtonShortestPathDijkstra.AutoSize = true;
            this.radioButtonShortestPathDijkstra.Location = new System.Drawing.Point(6, 19);
            this.radioButtonShortestPathDijkstra.Name = "radioButtonShortestPathDijkstra";
            this.radioButtonShortestPathDijkstra.Size = new System.Drawing.Size(60, 17);
            this.radioButtonShortestPathDijkstra.TabIndex = 5;
            this.radioButtonShortestPathDijkstra.TabStop = true;
            this.radioButtonShortestPathDijkstra.Text = "Dijkstra";
            this.radioButtonShortestPathDijkstra.UseVisualStyleBackColor = true;
            // 
            // radioButtonShortestPathFordBellman
            // 
            this.radioButtonShortestPathFordBellman.AutoSize = true;
            this.radioButtonShortestPathFordBellman.Location = new System.Drawing.Point(6, 42);
            this.radioButtonShortestPathFordBellman.Name = "radioButtonShortestPathFordBellman";
            this.radioButtonShortestPathFordBellman.Size = new System.Drawing.Size(86, 17);
            this.radioButtonShortestPathFordBellman.TabIndex = 2;
            this.radioButtonShortestPathFordBellman.TabStop = true;
            this.radioButtonShortestPathFordBellman.Text = "Ford-Bellman";
            this.radioButtonShortestPathFordBellman.UseVisualStyleBackColor = true;
            // 
            // buttonShortestPathRun
            // 
            this.buttonShortestPathRun.Location = new System.Drawing.Point(6, 70);
            this.buttonShortestPathRun.Name = "buttonShortestPathRun";
            this.buttonShortestPathRun.Size = new System.Drawing.Size(70, 23);
            this.buttonShortestPathRun.TabIndex = 4;
            this.buttonShortestPathRun.Text = "Start";
            this.buttonShortestPathRun.UseVisualStyleBackColor = true;
            this.buttonShortestPathRun.Click += new System.EventHandler(this.buttonShortestPathRun_Click);
            // 
            // groupBoxSpanningTree
            // 
            this.groupBoxSpanningTree.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBoxSpanningTree.Controls.Add(this.textBoxSpanningTreeTime);
            this.groupBoxSpanningTree.Controls.Add(this.buttonSpanningTreeDisplay);
            this.groupBoxSpanningTree.Controls.Add(this.radioButtonSpanningTreePrim);
            this.groupBoxSpanningTree.Controls.Add(this.radioButtonSpanningTreeKruskal);
            this.groupBoxSpanningTree.Controls.Add(this.buttonSpanningTreeRun);
            this.groupBoxSpanningTree.Location = new System.Drawing.Point(223, 100);
            this.groupBoxSpanningTree.Name = "groupBoxSpanningTree";
            this.groupBoxSpanningTree.Size = new System.Drawing.Size(205, 99);
            this.groupBoxSpanningTree.TabIndex = 7;
            this.groupBoxSpanningTree.TabStop = false;
            this.groupBoxSpanningTree.Text = "Drzewo rozpinające";
            // 
            // textBoxSpanningTreeTime
            // 
            this.textBoxSpanningTreeTime.Location = new System.Drawing.Point(109, 72);
            this.textBoxSpanningTreeTime.Name = "textBoxSpanningTreeTime";
            this.textBoxSpanningTreeTime.Size = new System.Drawing.Size(90, 20);
            this.textBoxSpanningTreeTime.TabIndex = 9;
            // 
            // buttonSpanningTreeDisplay
            // 
            this.buttonSpanningTreeDisplay.Location = new System.Drawing.Point(129, 39);
            this.buttonSpanningTreeDisplay.Name = "buttonSpanningTreeDisplay";
            this.buttonSpanningTreeDisplay.Size = new System.Drawing.Size(70, 23);
            this.buttonSpanningTreeDisplay.TabIndex = 8;
            this.buttonSpanningTreeDisplay.Text = "Wypisz";
            this.buttonSpanningTreeDisplay.UseVisualStyleBackColor = true;
            this.buttonSpanningTreeDisplay.Click += new System.EventHandler(this.buttonSpanningTreeDisplay_Click);
            // 
            // radioButtonSpanningTreePrim
            // 
            this.radioButtonSpanningTreePrim.AutoSize = true;
            this.radioButtonSpanningTreePrim.Location = new System.Drawing.Point(6, 19);
            this.radioButtonSpanningTreePrim.Name = "radioButtonSpanningTreePrim";
            this.radioButtonSpanningTreePrim.Size = new System.Drawing.Size(45, 17);
            this.radioButtonSpanningTreePrim.TabIndex = 7;
            this.radioButtonSpanningTreePrim.TabStop = true;
            this.radioButtonSpanningTreePrim.Text = "Prim";
            this.radioButtonSpanningTreePrim.UseVisualStyleBackColor = true;
            // 
            // radioButtonSpanningTreeKruskal
            // 
            this.radioButtonSpanningTreeKruskal.AutoSize = true;
            this.radioButtonSpanningTreeKruskal.Location = new System.Drawing.Point(6, 42);
            this.radioButtonSpanningTreeKruskal.Name = "radioButtonSpanningTreeKruskal";
            this.radioButtonSpanningTreeKruskal.Size = new System.Drawing.Size(60, 17);
            this.radioButtonSpanningTreeKruskal.TabIndex = 6;
            this.radioButtonSpanningTreeKruskal.TabStop = true;
            this.radioButtonSpanningTreeKruskal.Text = "Kruskal";
            this.radioButtonSpanningTreeKruskal.UseVisualStyleBackColor = true;
            // 
            // buttonSpanningTreeRun
            // 
            this.buttonSpanningTreeRun.Location = new System.Drawing.Point(6, 70);
            this.buttonSpanningTreeRun.Name = "buttonSpanningTreeRun";
            this.buttonSpanningTreeRun.Size = new System.Drawing.Size(70, 23);
            this.buttonSpanningTreeRun.TabIndex = 4;
            this.buttonSpanningTreeRun.Text = "Start";
            this.buttonSpanningTreeRun.UseVisualStyleBackColor = true;
            this.buttonSpanningTreeRun.Click += new System.EventHandler(this.buttonSpanningTreeRun_Click);
            // 
            // groupBoxMode
            // 
            this.groupBoxMode.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBoxMode.Controls.Add(this.radioButtonModeMatrix);
            this.groupBoxMode.Controls.Add(this.radioButtonModeList);
            this.groupBoxMode.Location = new System.Drawing.Point(334, 12);
            this.groupBoxMode.Name = "groupBoxMode";
            this.groupBoxMode.Size = new System.Drawing.Size(94, 82);
            this.groupBoxMode.TabIndex = 8;
            this.groupBoxMode.TabStop = false;
            this.groupBoxMode.Text = "Tryb pracy";
            // 
            // radioButtonModeMatrix
            // 
            this.radioButtonModeMatrix.AutoSize = true;
            this.radioButtonModeMatrix.Location = new System.Drawing.Point(9, 42);
            this.radioButtonModeMatrix.Name = "radioButtonModeMatrix";
            this.radioButtonModeMatrix.Size = new System.Drawing.Size(81, 17);
            this.radioButtonModeMatrix.TabIndex = 1;
            this.radioButtonModeMatrix.TabStop = true;
            this.radioButtonModeMatrix.Text = "Macierzowy";
            this.radioButtonModeMatrix.UseVisualStyleBackColor = true;
            // 
            // radioButtonModeList
            // 
            this.radioButtonModeList.AutoSize = true;
            this.radioButtonModeList.Location = new System.Drawing.Point(9, 19);
            this.radioButtonModeList.Name = "radioButtonModeList";
            this.radioButtonModeList.Size = new System.Drawing.Size(60, 17);
            this.radioButtonModeList.TabIndex = 0;
            this.radioButtonModeList.TabStop = true;
            this.radioButtonModeList.Text = "Listowy";
            this.radioButtonModeList.UseVisualStyleBackColor = true;
            // 
            // groupBoxCreate
            // 
            this.groupBoxCreate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBoxCreate.Controls.Add(this.checkBoxCreateGraphDirected);
            this.groupBoxCreate.Controls.Add(this.listBoxCreateGraphDensity);
            this.groupBoxCreate.Controls.Add(this.textBoxCreateGraphSize);
            this.groupBoxCreate.Controls.Add(this.buttonCreateNewGraph);
            this.groupBoxCreate.Location = new System.Drawing.Point(12, 205);
            this.groupBoxCreate.Name = "groupBoxCreate";
            this.groupBoxCreate.Size = new System.Drawing.Size(205, 82);
            this.groupBoxCreate.TabIndex = 6;
            this.groupBoxCreate.TabStop = false;
            this.groupBoxCreate.Text = "Tworzenie grafu";
            // 
            // listBoxCreateGraphDensity
            // 
            this.listBoxCreateGraphDensity.FormattingEnabled = true;
            this.listBoxCreateGraphDensity.Location = new System.Drawing.Point(6, 43);
            this.listBoxCreateGraphDensity.Name = "listBoxCreateGraphDensity";
            this.listBoxCreateGraphDensity.Size = new System.Drawing.Size(92, 30);
            this.listBoxCreateGraphDensity.TabIndex = 7;
            // 
            // textBoxCreateGraphSize
            // 
            this.textBoxCreateGraphSize.Location = new System.Drawing.Point(6, 22);
            this.textBoxCreateGraphSize.Name = "textBoxCreateGraphSize";
            this.textBoxCreateGraphSize.Size = new System.Drawing.Size(92, 20);
            this.textBoxCreateGraphSize.TabIndex = 6;
            this.textBoxCreateGraphSize.TextChanged += new System.EventHandler(this.textBoxCreateGraphSize_TextChanged);
            // 
            // buttonCreateNewGraph
            // 
            this.buttonCreateNewGraph.Location = new System.Drawing.Point(123, 50);
            this.buttonCreateNewGraph.Name = "buttonCreateNewGraph";
            this.buttonCreateNewGraph.Size = new System.Drawing.Size(70, 23);
            this.buttonCreateNewGraph.TabIndex = 4;
            this.buttonCreateNewGraph.Text = "Twórz";
            this.buttonCreateNewGraph.UseVisualStyleBackColor = true;
            this.buttonCreateNewGraph.Click += new System.EventHandler(this.buttonCreateNewGraph_Click);
            // 
            // groupBoxRepeat
            // 
            this.groupBoxRepeat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBoxRepeat.Controls.Add(this.label3);
            this.groupBoxRepeat.Controls.Add(this.label2);
            this.groupBoxRepeat.Controls.Add(this.textBoxRepeatCurrent);
            this.groupBoxRepeat.Controls.Add(this.buttonRepeatChange);
            this.groupBoxRepeat.Controls.Add(this.textBoxRepeatNew);
            this.groupBoxRepeat.Location = new System.Drawing.Point(223, 205);
            this.groupBoxRepeat.Name = "groupBoxRepeat";
            this.groupBoxRepeat.Size = new System.Drawing.Size(205, 82);
            this.groupBoxRepeat.TabIndex = 7;
            this.groupBoxRepeat.TabStop = false;
            this.groupBoxRepeat.Text = "Powtórzenia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nowy mnożnik";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Obecny mnożnik";
            // 
            // textBoxRepeatCurrent
            // 
            this.textBoxRepeatCurrent.Location = new System.Drawing.Point(98, 21);
            this.textBoxRepeatCurrent.Name = "textBoxRepeatCurrent";
            this.textBoxRepeatCurrent.ReadOnly = true;
            this.textBoxRepeatCurrent.Size = new System.Drawing.Size(48, 20);
            this.textBoxRepeatCurrent.TabIndex = 5;
            // 
            // buttonRepeatChange
            // 
            this.buttonRepeatChange.Location = new System.Drawing.Point(149, 42);
            this.buttonRepeatChange.Name = "buttonRepeatChange";
            this.buttonRepeatChange.Size = new System.Drawing.Size(52, 23);
            this.buttonRepeatChange.TabIndex = 4;
            this.buttonRepeatChange.Text = "Zmień";
            this.buttonRepeatChange.UseVisualStyleBackColor = true;
            this.buttonRepeatChange.Click += new System.EventHandler(this.buttonRepeatChange_Click);
            // 
            // textBoxRepeatNew
            // 
            this.textBoxRepeatNew.Location = new System.Drawing.Point(98, 44);
            this.textBoxRepeatNew.Name = "textBoxRepeatNew";
            this.textBoxRepeatNew.Size = new System.Drawing.Size(48, 20);
            this.textBoxRepeatNew.TabIndex = 0;
            // 
            // checkBoxCreateGraphDirected
            // 
            this.checkBoxCreateGraphDirected.AutoSize = true;
            this.checkBoxCreateGraphDirected.Location = new System.Drawing.Point(104, 24);
            this.checkBoxCreateGraphDirected.Name = "checkBoxCreateGraphDirected";
            this.checkBoxCreateGraphDirected.Size = new System.Drawing.Size(81, 17);
            this.checkBoxCreateGraphDirected.TabIndex = 6;
            this.checkBoxCreateGraphDirected.Text = "Skierowany";
            this.checkBoxCreateGraphDirected.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 292);
            this.Controls.Add(this.groupBoxRepeat);
            this.Controls.Add(this.groupBoxCreate);
            this.Controls.Add(this.groupBoxMode);
            this.Controls.Add(this.groupBoxSpanningTree);
            this.Controls.Add(this.groupBoxShortestPath);
            this.Controls.Add(this.groupBoxLoad);
            this.Controls.Add(this.groupBoxDisplay);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.groupBoxDisplay.ResumeLayout(false);
            this.groupBoxDisplay.PerformLayout();
            this.groupBoxLoad.ResumeLayout(false);
            this.groupBoxLoad.PerformLayout();
            this.groupBoxShortestPath.ResumeLayout(false);
            this.groupBoxShortestPath.PerformLayout();
            this.groupBoxSpanningTree.ResumeLayout(false);
            this.groupBoxSpanningTree.PerformLayout();
            this.groupBoxMode.ResumeLayout(false);
            this.groupBoxMode.PerformLayout();
            this.groupBoxCreate.ResumeLayout(false);
            this.groupBoxCreate.PerformLayout();
            this.groupBoxRepeat.ResumeLayout(false);
            this.groupBoxRepeat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDisplay;
        private System.Windows.Forms.Label labelList;
        private System.Windows.Forms.Label labelMatrix;
        private System.Windows.Forms.Button buttonDisplayList;
        private System.Windows.Forms.Button buttonDisplayMatrix;
        private System.Windows.Forms.GroupBox groupBoxLoad;
        private System.Windows.Forms.CheckBox checkBoxLoadDirected;
        private System.Windows.Forms.Button buttonLoadGraph;
        private System.Windows.Forms.Label labelFilename;
        private System.Windows.Forms.TextBox textBoxFilename;
        private System.Windows.Forms.GroupBox groupBoxShortestPath;
        private System.Windows.Forms.Button buttonShortestPathRun;
        private System.Windows.Forms.GroupBox groupBoxSpanningTree;
        private System.Windows.Forms.Button buttonSpanningTreeRun;
        private System.Windows.Forms.GroupBox groupBoxMode;
        private System.Windows.Forms.RadioButton radioButtonShortestPathDijkstra;
        private System.Windows.Forms.RadioButton radioButtonShortestPathFordBellman;
        private System.Windows.Forms.RadioButton radioButtonSpanningTreePrim;
        private System.Windows.Forms.RadioButton radioButtonSpanningTreeKruskal;
        private System.Windows.Forms.RadioButton radioButtonModeMatrix;
        private System.Windows.Forms.RadioButton radioButtonModeList;
        private System.Windows.Forms.Button buttonShortestPathDisplay;
        private System.Windows.Forms.Button buttonSpanningTreeDisplay;
        private System.Windows.Forms.TextBox textBoxShortestPathTime;
        private System.Windows.Forms.TextBox textBoxSpanningTreeTime;
        private System.Windows.Forms.GroupBox groupBoxCreate;
        private System.Windows.Forms.Button buttonCreateNewGraph;
        private System.Windows.Forms.GroupBox groupBoxRepeat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxRepeatCurrent;
        private System.Windows.Forms.Button buttonRepeatChange;
        private System.Windows.Forms.TextBox textBoxRepeatNew;
        private System.Windows.Forms.ListBox listBoxCreateGraphDensity;
        private System.Windows.Forms.TextBox textBoxCreateGraphSize;
        private System.Windows.Forms.CheckBox checkBoxCreateGraphDirected;
    }
}

