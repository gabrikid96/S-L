namespace MusicListSearcher
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.excelFileButton = new System.Windows.Forms.Button();
            this.musicFolderInput = new System.Windows.Forms.TextBox();
            this.folderButton = new System.Windows.Forms.Button();
            this.labelFileInput = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.folderOutputButton = new System.Windows.Forms.Button();
            this.outputFolderInput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.excelFileInput = new System.Windows.Forms.TextBox();
            this.numBailes = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.resultsLabel = new System.Windows.Forms.Label();
            this.resultBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numBailes)).BeginInit();
            this.SuspendLayout();
            // 
            // excelFileButton
            // 
            this.excelFileButton.Location = new System.Drawing.Point(571, 66);
            this.excelFileButton.Name = "excelFileButton";
            this.excelFileButton.Size = new System.Drawing.Size(29, 20);
            this.excelFileButton.TabIndex = 0;
            this.excelFileButton.Text = "...";
            this.excelFileButton.UseVisualStyleBackColor = true;
            this.excelFileButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // musicFolderInput
            // 
            this.musicFolderInput.Location = new System.Drawing.Point(65, 127);
            this.musicFolderInput.Name = "musicFolderInput";
            this.musicFolderInput.Size = new System.Drawing.Size(583, 20);
            this.musicFolderInput.TabIndex = 3;
            // 
            // folderButton
            // 
            this.folderButton.Location = new System.Drawing.Point(654, 126);
            this.folderButton.Name = "folderButton";
            this.folderButton.Size = new System.Drawing.Size(29, 20);
            this.folderButton.TabIndex = 4;
            this.folderButton.Text = "...";
            this.folderButton.UseVisualStyleBackColor = true;
            this.folderButton.Click += new System.EventHandler(this.folderButton_Click);
            // 
            // labelFileInput
            // 
            this.labelFileInput.AutoSize = true;
            this.labelFileInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFileInput.Location = new System.Drawing.Point(66, 38);
            this.labelFileInput.Name = "labelFileInput";
            this.labelFileInput.Size = new System.Drawing.Size(237, 25);
            this.labelFileInput.TabIndex = 5;
            this.labelFileInput.Text = "Archivo con lista de bailes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Carpeta con toda la música";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(264, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Carpeta destino de la música";
            // 
            // folderOutputButton
            // 
            this.folderOutputButton.Location = new System.Drawing.Point(654, 194);
            this.folderOutputButton.Name = "folderOutputButton";
            this.folderOutputButton.Size = new System.Drawing.Size(29, 20);
            this.folderOutputButton.TabIndex = 8;
            this.folderOutputButton.Text = "...";
            this.folderOutputButton.UseVisualStyleBackColor = true;
            this.folderOutputButton.Click += new System.EventHandler(this.folderOutputButton_Click);
            // 
            // outputFolderInput
            // 
            this.outputFolderInput.Location = new System.Drawing.Point(65, 195);
            this.outputFolderInput.Name = "outputFolderInput";
            this.outputFolderInput.Size = new System.Drawing.Size(583, 20);
            this.outputFolderInput.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Purple;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(68, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 53);
            this.button1.TabIndex = 10;
            this.button1.Text = "COPIAR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // excelFileInput
            // 
            this.excelFileInput.Location = new System.Drawing.Point(68, 66);
            this.excelFileInput.Name = "excelFileInput";
            this.excelFileInput.Size = new System.Drawing.Size(497, 20);
            this.excelFileInput.TabIndex = 2;
            // 
            // numBailes
            // 
            this.numBailes.Location = new System.Drawing.Point(616, 66);
            this.numBailes.Name = "numBailes";
            this.numBailes.Size = new System.Drawing.Size(67, 20);
            this.numBailes.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(612, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 22);
            this.label3.TabIndex = 13;
            this.label3.Text = "# bailes";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(188, 279);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(495, 23);
            this.progressBar1.TabIndex = 15;
            // 
            // resultsLabel
            // 
            this.resultsLabel.AutoSize = true;
            this.resultsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultsLabel.Location = new System.Drawing.Point(66, 326);
            this.resultsLabel.Name = "resultsLabel";
            this.resultsLabel.Size = new System.Drawing.Size(109, 25);
            this.resultsLabel.TabIndex = 17;
            this.resultsLabel.Text = "Resultados";
            // 
            // resultBox
            // 
            this.resultBox.Location = new System.Drawing.Point(68, 354);
            this.resultBox.Name = "resultBox";
            this.resultBox.ReadOnly = true;
            this.resultBox.Size = new System.Drawing.Size(616, 107);
            this.resultBox.TabIndex = 18;
            this.resultBox.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(795, 534);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.resultsLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numBailes);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.folderOutputButton);
            this.Controls.Add(this.outputFolderInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelFileInput);
            this.Controls.Add(this.folderButton);
            this.Controls.Add(this.musicFolderInput);
            this.Controls.Add(this.excelFileInput);
            this.Controls.Add(this.excelFileButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "SWEET";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numBailes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button excelFileButton;
        private System.Windows.Forms.TextBox musicFolderInput;
        private System.Windows.Forms.Button folderButton;
        private System.Windows.Forms.Label labelFileInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button folderOutputButton;
        private System.Windows.Forms.TextBox outputFolderInput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox excelFileInput;
        private System.Windows.Forms.NumericUpDown numBailes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label resultsLabel;
        private System.Windows.Forms.RichTextBox resultBox;
    }
}

