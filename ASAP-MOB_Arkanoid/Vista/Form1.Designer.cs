namespace ASAP_MOB_Arkanoid
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.playerPb = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.playerPb)).BeginInit();
            this.SuspendLayout();
            // 
            // playerPb
            // 
            this.playerPb.Location = new System.Drawing.Point(224, 305);
            this.playerPb.Margin = new System.Windows.Forms.Padding(2);
            this.playerPb.Name = "playerPb";
            this.playerPb.Size = new System.Drawing.Size(118, 28);
            this.playerPb.TabIndex = 0;
            this.playerPb.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 25;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(471, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(588, 334);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.playerPb);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.ControlArkanoid_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlArkanoid_KeyDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ControlArkanoid_MouseMove);
            ((System.ComponentModel.ISupportInitialize) (this.playerPb)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox playerPb;
        private System.Windows.Forms.Timer timer1;

        #endregion
    }
}