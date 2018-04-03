namespace ProyectoDeArqui
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.palabraABuscar = new System.Windows.Forms.ToolStripTextBox();
            this.botonBuscar = new System.Windows.Forms.ToolStripButton();
            this.formaSecuencial = new System.Windows.Forms.CheckBox();
            this.formaParalela = new System.Windows.Forms.CheckBox();
            this.listaResultados = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxContieneTiempoTotal = new System.Windows.Forms.TextBox();
            this.diagramaDinamico = new ZedGraph.ZedGraphControl();
            this.DiagramaEstatico = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label7 = new System.Windows.Forms.Label();
            this.DiagramaDinamicoTiempoReal = new ZedGraph.ZedGraphControl();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiagramaEstatico)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.palabraABuscar,
            this.botonBuscar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1256, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Atras";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "adelante";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 23);
            this.toolStripButton3.Text = "refrescar";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // palabraABuscar
            // 
            this.palabraABuscar.Name = "palabraABuscar";
            this.palabraABuscar.Size = new System.Drawing.Size(200, 25);
            this.palabraABuscar.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            // 
            // botonBuscar
            // 
            this.botonBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.botonBuscar.Image = ((System.Drawing.Image)(resources.GetObject("botonBuscar.Image")));
            this.botonBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(23, 22);
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // formaSecuencial
            // 
            this.formaSecuencial.AutoSize = true;
            this.formaSecuencial.Location = new System.Drawing.Point(44, 45);
            this.formaSecuencial.Name = "formaSecuencial";
            this.formaSecuencial.Size = new System.Drawing.Size(79, 17);
            this.formaSecuencial.TabIndex = 2;
            this.formaSecuencial.Text = "Secuencial";
            this.formaSecuencial.UseVisualStyleBackColor = true;
            // 
            // formaParalela
            // 
            this.formaParalela.AutoSize = true;
            this.formaParalela.Location = new System.Drawing.Point(44, 68);
            this.formaParalela.Name = "formaParalela";
            this.formaParalela.Size = new System.Drawing.Size(64, 17);
            this.formaParalela.TabIndex = 3;
            this.formaParalela.Text = "Paralela";
            this.formaParalela.UseVisualStyleBackColor = true;
            // 
            // listaResultados
            // 
            this.listaResultados.FormattingEnabled = true;
            this.listaResultados.Location = new System.Drawing.Point(22, 134);
            this.listaResultados.Name = "listaResultados";
            this.listaResultados.Size = new System.Drawing.Size(613, 251);
            this.listaResultados.TabIndex = 4;
            this.listaResultados.SelectedIndexChanged += new System.EventHandler(this.listaResultados_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Palabra";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cantidad Resultados";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Pagina Web";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(847, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Abrir Pagina Web";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(544, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tiempo Total Busqueda: ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBoxContieneTiempoTotal
            // 
            this.textBoxContieneTiempoTotal.Location = new System.Drawing.Point(676, 52);
            this.textBoxContieneTiempoTotal.Name = "textBoxContieneTiempoTotal";
            this.textBoxContieneTiempoTotal.Size = new System.Drawing.Size(100, 20);
            this.textBoxContieneTiempoTotal.TabIndex = 10;
            this.textBoxContieneTiempoTotal.TextChanged += new System.EventHandler(this.textBoxContieneTiempoTotal_TextChanged);
            // 
            // diagramaDinamico
            // 
            this.diagramaDinamico.Location = new System.Drawing.Point(658, 370);
            this.diagramaDinamico.Name = "diagramaDinamico";
            this.diagramaDinamico.ScrollGrace = 0D;
            this.diagramaDinamico.ScrollMaxX = 0D;
            this.diagramaDinamico.ScrollMaxY = 0D;
            this.diagramaDinamico.ScrollMaxY2 = 0D;
            this.diagramaDinamico.ScrollMinX = 0D;
            this.diagramaDinamico.ScrollMinY = 0D;
            this.diagramaDinamico.ScrollMinY2 = 0D;
            this.diagramaDinamico.Size = new System.Drawing.Size(586, 226);
            this.diagramaDinamico.TabIndex = 11;
            // 
            // DiagramaEstatico
            // 
            chartArea1.Name = "ChartArea1";
            this.DiagramaEstatico.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.DiagramaEstatico.Legends.Add(legend1);
            this.DiagramaEstatico.Location = new System.Drawing.Point(658, 84);
            this.DiagramaEstatico.Name = "DiagramaEstatico";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.DiagramaEstatico.Series.Add(series1);
            this.DiagramaEstatico.Size = new System.Drawing.Size(586, 280);
            this.DiagramaEstatico.TabIndex = 12;
            this.DiagramaEstatico.Text = "DiagramaEstatico";
            this.DiagramaEstatico.Click += new System.EventHandler(this.chart1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(454, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Tiempo Ejecucion";
            // 
            // DiagramaDinamicoTiempoReal
            // 
            this.DiagramaDinamicoTiempoReal.Location = new System.Drawing.Point(33, 400);
            this.DiagramaDinamicoTiempoReal.Name = "DiagramaDinamicoTiempoReal";
            this.DiagramaDinamicoTiempoReal.ScrollGrace = 0D;
            this.DiagramaDinamicoTiempoReal.ScrollMaxX = 0D;
            this.DiagramaDinamicoTiempoReal.ScrollMaxY = 0D;
            this.DiagramaDinamicoTiempoReal.ScrollMaxY2 = 0D;
            this.DiagramaDinamicoTiempoReal.ScrollMinX = 0D;
            this.DiagramaDinamicoTiempoReal.ScrollMinY = 0D;
            this.DiagramaDinamicoTiempoReal.ScrollMinY2 = 0D;
            this.DiagramaDinamicoTiempoReal.Size = new System.Drawing.Size(590, 196);
            this.DiagramaDinamicoTiempoReal.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 608);
            this.Controls.Add(this.DiagramaDinamicoTiempoReal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DiagramaEstatico);
            this.Controls.Add(this.diagramaDinamico);
            this.Controls.Add(this.textBoxContieneTiempoTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listaResultados);
            this.Controls.Add(this.formaParalela);
            this.Controls.Add(this.formaSecuencial);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Cantidad Resultados";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiagramaEstatico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripTextBox palabraABuscar;
        private System.Windows.Forms.ToolStripButton botonBuscar;
        private System.Windows.Forms.CheckBox formaSecuencial;
        private System.Windows.Forms.CheckBox formaParalela;
        private System.Windows.Forms.ListBox listaResultados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxContieneTiempoTotal;
        private ZedGraph.ZedGraphControl diagramaDinamico;
        private System.Windows.Forms.DataVisualization.Charting.Chart DiagramaEstatico;
        private System.Windows.Forms.Label label7;
        private ZedGraph.ZedGraphControl DiagramaDinamicoTiempoReal;
    }
}

