namespace Wumpus
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
            this.tlp_Juego = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblxy = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFlechas = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tablero = new System.Windows.Forms.FlowLayoutPanel();
            this.pbVista = new System.Windows.Forms.PictureBox();
            this.pbAventurero = new System.Windows.Forms.PictureBox();
            this.tlp_Juego.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAventurero)).BeginInit();
            this.SuspendLayout();
            // 
            // tlp_Juego
            // 
            this.tlp_Juego.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tlp_Juego.ColumnCount = 2;
            this.tlp_Juego.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.71468F));
            this.tlp_Juego.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.28532F));
            this.tlp_Juego.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tlp_Juego.Controls.Add(this.tablero, 1, 0);
            this.tlp_Juego.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Juego.Location = new System.Drawing.Point(0, 0);
            this.tlp_Juego.Name = "tlp_Juego";
            this.tlp_Juego.RowCount = 1;
            this.tlp_Juego.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Juego.Size = new System.Drawing.Size(889, 499);
            this.tlp_Juego.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.pbVista);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.lblxy);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.lblFlechas);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.pbAventurero);
            this.flowLayoutPanel1.Controls.Add(this.textBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(193, 487);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Vista";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Intentos";
            // 
            // lblxy
            // 
            this.lblxy.AutoSize = true;
            this.lblxy.Location = new System.Drawing.Point(3, 157);
            this.lblxy.Name = "lblxy";
            this.lblxy.Size = new System.Drawing.Size(63, 19);
            this.lblxy.TabIndex = 1;
            this.lblxy.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Flechas";
            // 
            // lblFlechas
            // 
            this.lblFlechas.AutoSize = true;
            this.lblFlechas.Location = new System.Drawing.Point(3, 195);
            this.lblFlechas.Name = "lblFlechas";
            this.lblFlechas.Size = new System.Drawing.Size(0, 19);
            this.lblFlechas.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 424);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(191, 26);
            this.textBox1.TabIndex = 4;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // tablero
            // 
            this.tablero.Location = new System.Drawing.Point(208, 6);
            this.tablero.Name = "tablero";
            this.tablero.Size = new System.Drawing.Size(675, 487);
            this.tablero.TabIndex = 1;
            // 
            // pbVista
            // 
            this.pbVista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbVista.Image = global::Wumpus.Properties.Resources.me_gusta;
            this.pbVista.Location = new System.Drawing.Point(3, 26);
            this.pbVista.Name = "pbVista";
            this.pbVista.Size = new System.Drawing.Size(191, 105);
            this.pbVista.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbVista.TabIndex = 2;
            this.pbVista.TabStop = false;
            // 
            // pbAventurero
            // 
            this.pbAventurero.Image = global::Wumpus.Properties.Resources.ezgif_3_5365f0d974;
            this.pbAventurero.Location = new System.Drawing.Point(3, 258);
            this.pbAventurero.Name = "pbAventurero";
            this.pbAventurero.Size = new System.Drawing.Size(188, 160);
            this.pbAventurero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAventurero.TabIndex = 0;
            this.pbAventurero.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(889, 499);
            this.Controls.Add(this.tlp_Juego);
            this.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tlp_Juego.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAventurero)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_Juego;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblxy;
        private System.Windows.Forms.PictureBox pbVista;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pbAventurero;
        private System.Windows.Forms.FlowLayoutPanel tablero;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFlechas;
    }
}

