using System.ComponentModel;

namespace ASAP_MOB_Arkanoid
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.jugar = new System.Windows.Forms.Button();
            this.puntajes = new System.Windows.Forms.Button();
            this.salir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::ASAP_MOB_Arkanoid.Properties.Resources.arkanoid_logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(57, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(453, 137);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // jugar
            // 
            this.jugar.BackColor = System.Drawing.Color.Transparent;
            this.jugar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.jugar.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.jugar.ForeColor = System.Drawing.Color.White;
            this.jugar.Location = new System.Drawing.Point(141, 252);
            this.jugar.Name = "jugar";
            this.jugar.Size = new System.Drawing.Size(268, 88);
            this.jugar.TabIndex = 1;
            this.jugar.Text = "Jugar";
            this.jugar.UseVisualStyleBackColor = false;
            this.jugar.Click += new System.EventHandler(this.jugar_Click);
            // 
            // puntajes
            // 
            this.puntajes.BackColor = System.Drawing.Color.Transparent;
            this.puntajes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.puntajes.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.puntajes.ForeColor = System.Drawing.Color.White;
            this.puntajes.Location = new System.Drawing.Point(141, 376);
            this.puntajes.Name = "puntajes";
            this.puntajes.Size = new System.Drawing.Size(268, 88);
            this.puntajes.TabIndex = 2;
            this.puntajes.Text = "Puntajes";
            this.puntajes.UseVisualStyleBackColor = false;
            this.puntajes.Click += new System.EventHandler(this.puntajes_Click);
            // 
            // salir
            // 
            this.salir.BackColor = System.Drawing.Color.Transparent;
            this.salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salir.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.salir.ForeColor = System.Drawing.Color.White;
            this.salir.Location = new System.Drawing.Point(141, 496);
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(268, 88);
            this.salir.TabIndex = 3;
            this.salir.Text = "Salir";
            this.salir.UseVisualStyleBackColor = false;
            this.salir.Click += new System.EventHandler(this.salir_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ASAP_MOB_Arkanoid.Properties.Resources.menu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(569, 625);
            this.ControlBox = false;
            this.Controls.Add(this.salir);
            this.Controls.Add(this.puntajes);
            this.Controls.Add(this.jugar);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu - Arkanoid pre Alpha";
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button jugar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button puntajes;
        private System.Windows.Forms.Button salir;

        #endregion
    }
}