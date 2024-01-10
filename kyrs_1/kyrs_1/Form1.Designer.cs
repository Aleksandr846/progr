namespace kyrs_1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lstSchedule = new System.Windows.Forms.ListBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSupp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSaveToFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRead = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLoadFromFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSort = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemGenerateChart = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstSchedule
            // 
            this.lstSchedule.FormattingEnabled = true;
            this.lstSchedule.Location = new System.Drawing.Point(396, 111);
            this.lstSchedule.Name = "lstSchedule";
            this.lstSchedule.Size = new System.Drawing.Size(421, 134);
            this.lstSchedule.TabIndex = 11;
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(842, 111);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(207, 145);
            this.chart.TabIndex = 12;
            this.chart.Text = "chart1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAdd,
            this.menuItemSupp,
            this.menuItemDelete,
            this.menuItemSaveToFile,
            this.menuItemRead,
            this.menuItemLoadFromFile,
            this.menuItemSearch,
            this.menuItemSort,
            this.menuItemGenerateChart,
            this.menuItemExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1064, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip";
            // 
            // menuItemAdd
            // 
            this.menuItemAdd.Name = "menuItemAdd";
            this.menuItemAdd.Size = new System.Drawing.Size(91, 20);
            this.menuItemAdd.Text = "Добавить(F1)";
            this.menuItemAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // menuItemSupp
            // 
            this.menuItemSupp.Name = "menuItemSupp";
            this.menuItemSupp.Size = new System.Drawing.Size(100, 20);
            this.menuItemSupp.Text = "Дополнить(F2)";
            this.menuItemSupp.Click += new System.EventHandler(this.menuItemSupp_Click);
            // 
            // menuItemDelete
            // 
            this.menuItemDelete.Name = "menuItemDelete";
            this.menuItemDelete.Size = new System.Drawing.Size(83, 20);
            this.menuItemDelete.Text = "Удалить(F3)";
            this.menuItemDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // menuItemSaveToFile
            // 
            this.menuItemSaveToFile.Name = "menuItemSaveToFile";
            this.menuItemSaveToFile.Size = new System.Drawing.Size(139, 20);
            this.menuItemSaveToFile.Text = "Сохранить в файл(F4)";
            this.menuItemSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
            // 
            // menuItemRead
            // 
            this.menuItemRead.Name = "menuItemRead";
            this.menuItemRead.Size = new System.Drawing.Size(129, 20);
            this.menuItemRead.Text = "Читать из файла(F5)";
            this.menuItemRead.Click += new System.EventHandler(this.menuItemRead_Click);
            // 
            // menuItemLoadFromFile
            // 
            this.menuItemLoadFromFile.Name = "menuItemLoadFromFile";
            this.menuItemLoadFromFile.Size = new System.Drawing.Size(146, 20);
            this.menuItemLoadFromFile.Text = "Загрузить из файла(F6)";
            this.menuItemLoadFromFile.Click += new System.EventHandler(this.btnLoadFromFile_Click);
            // 
            // menuItemSearch
            // 
            this.menuItemSearch.Name = "menuItemSearch";
            this.menuItemSearch.Size = new System.Drawing.Size(74, 20);
            this.menuItemSearch.Text = "Поиск(F7)";
            this.menuItemSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // menuItemSort
            // 
            this.menuItemSort.Name = "menuItemSort";
            this.menuItemSort.Size = new System.Drawing.Size(110, 20);
            this.menuItemSort.Text = "Сортировать(F8)";
            this.menuItemSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // menuItemGenerateChart
            // 
            this.menuItemGenerateChart.Name = "menuItemGenerateChart";
            this.menuItemGenerateChart.Size = new System.Drawing.Size(102, 20);
            this.menuItemGenerateChart.Text = "Диаграмма(F9)";
            this.menuItemGenerateChart.Click += new System.EventHandler(this.btnGenerateChart_Click);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(80, 20);
            this.menuItemExit.Text = "Выход(F10)";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(564, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Расписание игр";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(911, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Диаграмма";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Сведения о назначении программы";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Добавить(F1) - ввод данных";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Дополнить(F2) - дополнение данных";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Удалить(F3) - удаление данных";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(239, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Сохранить в файл(F4) - запись данных в файл";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 206);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(244, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Читать из файла(F5) - чтение данных из файла";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 232);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(256, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Загрузить из файла(F6) - вывод данных на экран";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 260);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(283, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Поиск(F7) - поиск информации по заданному атрибуту";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 287);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(198, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Сортировать(F8) - сортировка данных";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 314);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(215, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Диаграмма(F9) - построение диаграммы";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 340);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(186, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "Выход(F10) - завершить программу";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 395);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.lstSchedule);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Расписание игр";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lstSchedule;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem menuItemDelete;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveToFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemLoadFromFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemSearch;
        private System.Windows.Forms.ToolStripMenuItem menuItemSort;
        private System.Windows.Forms.ToolStripMenuItem menuItemGenerateChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem menuItemSupp;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuItemRead;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}

