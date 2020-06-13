﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace ASAP_MOB_Arkanoid
{
    public partial class Form1 : Form
    {
        public int yspeed,xspeed;
        public const int row = 5;
        public const int col = 13;
        public PictureBox[,] blocks;
        
        public Form1()
        {
            yspeed = 4;
            xspeed = 4;
            setblocks();
            InitializeComponent();
        }
        private int point = 0;
        private int vidas = 3;
        private void setblocks()
        {
            int blockHeight = 25;
            int blockwidth = 50;
            blocks= new PictureBox[row,col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    blocks[i,j]=new PictureBox();
                    blocks[i, j].Width = blockwidth;
                    blocks[i, j].Height = blockHeight;
                    blocks[i, j].Top = (blockHeight*i)+30;
                    blocks[i, j].Left = (blockwidth*j);
                    blocks[i, j].BackColor = Color.Green;
                    blocks[i, j].BorderStyle = BorderStyle.Fixed3D;

                    this.Controls.Add(blocks[i,j]);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = Program.usuario;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Ballpicbox.Top += yspeed;
            Ballpicbox.Left += xspeed;
            label2.Text = point.ToString();
            label3.Text = "Vidas: x" + vidas;
            //if para movimiento vertical
           if (Ballpicbox.Bottom > this.ClientSize.Height)
           {
               yspeed = -yspeed;
               vidas -= 1;
               label3.Text = "Vidas: x" + vidas;
           }
           if (Ballpicbox.Top-30 < 0)
           {
               yspeed = -yspeed;
           }
           //if para movimiento horizontal
           if (Ballpicbox.Right > this.ClientSize.Width)
           {
               xspeed = -xspeed;
           }
           if (Ballpicbox.Left < 0)
           {
               xspeed = -xspeed;
           }

           if (vidas <= 0)
           {
               timer1.Stop();
               MessageBox.Show("Juego terminado");
               AgregarDatos();
               this.Close();
           }
           //interaccion bola tabla
           if (Ballpicbox.Bounds.IntersectsWith(TabPicbox.Bounds) == true)
           {
               yspeed = -yspeed;
           }
           //perdida
           
           //colison bloques
           for (int i = 0; i < row; i++)
           {
               for (int j = 0; j < col; j++)
               {
                   if (Ballpicbox.Bounds.IntersectsWith(blocks[i, j].Bounds) && blocks[i,j].Visible)
                   {
                       blocks[i, j].Visible = false;
                       yspeed = -yspeed;
                       point += 10;
                       label2.Text = point.ToString();


                   }
               }
           }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            TabPicbox.Left = e.X - (TabPicbox.Width/2);
        }

        private void AgregarDatos()
        {
            try
            {
                BaseDatos.ExecuteNonQuery($"INSERT INTO Jugadores(nombres, puntaje) " +
                                          $"VALUES('{label1.Text}','{label2.Text}'); " );
            }
            catch (Exception exp)
            {
                MessageBox.Show("Ha ocurrido un error insert player");
            }
        }
    }
}