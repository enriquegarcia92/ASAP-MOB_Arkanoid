using System;
using System.Drawing;
using System.Windows.Forms;
using testarkanoid;

namespace ASAP_MOB_Arkanoid
{
    public partial class Form1 : Form
    {
           private CustomPictureBox[,] cpb;
        private Panel scorePanel;
        private Label remainingLifes, score;
        private PictureBox ball;

        private int remainingPb = 0;

        // Para trabajar con pic + label
        private PictureBox heart;

        // Para trabajar con n pic
        private PictureBox[] hearts;

        private delegate void BallActions();    
        private readonly BallActions BallMovements;
        public Form1()
        {
            InitializeComponent();

            BallMovements = BounceBall;
            BallMovements += MoveBall;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }

        // Metodos que coinciden con el delegate de Event
        private void ControlArkanoid_Load(object sender, EventArgs e)
        {
            label1.Text = Program.usuario;

            ScoresPanel();
            
            // Seteando los atributos para picBox jugador
            playerPb.BackgroundImage = Image.FromFile("../../Imagenes/Player.png");
            playerPb.BackgroundImageLayout = ImageLayout.Stretch;
            playerPb.BackColor=Color.Transparent;

            playerPb.Top = Height - playerPb.Height - 80;
            playerPb.Left = (Width / 2) - (playerPb.Width / 2);

            // Seteando los atributos para picBox pelota
             ball= new PictureBox();
            ball.Width = ball.Height = 20;

            ball.BackgroundImage = Image.FromFile("../../Imagenes/Ball.png");
            ball.BackgroundImageLayout = ImageLayout.Stretch;
            ball.BackColor=Color.Transparent;

            ball.Top = playerPb.Top - ball.Height;
            ball.Left = playerPb.Left + (playerPb.Width / 2) - (ball.Width / 2);

            Controls.Add(ball);

            LoadTiles();
        }

        private void LoadTiles()
        {
            int xAxis = 10, yAxis = 5;
            remainingPb = xAxis * yAxis;
            int pbWidth = (Width - (xAxis - 5)) / xAxis;
            int pbHeight = (int)(Height * 0.3) / yAxis;

            cpb = new CustomPictureBox[yAxis, xAxis];

            for (int i = 0; i < yAxis; i++)
            {
                for (int j = 0; j < xAxis; j++)
                {
                    cpb[i, j] = new CustomPictureBox();

                    if (i == 4)
                        cpb[i, j].Golpes = 2;
                    else
                        cpb[i, j].Golpes = 1;

                    // Seteando el tamano
                    cpb[i, j].Height = pbHeight;
                    cpb[i, j].Width = pbWidth;

                    // Posicion de left, y posicion de top
                    cpb[i, j].Left = j * pbWidth;
                    cpb[i, j].Top = i * pbHeight + scorePanel.Height + 1;

                    int imageBack = 0;

                    if (i % 2 == 0 && j % 2 == 0)
                        imageBack = 1;
                    else if (i % 2 == 0 && j % 2 != 0)
                        imageBack = 1;
                    else if (i % 2 != 0 && j % 2 == 0)
                        imageBack = 4;
                    else
                        imageBack = 4;

                    if (i == 4)
                    {
                        cpb[i, j].BackgroundImage = Image.FromFile("../../Imagenes/tb1.png");
                        cpb[i, j].Tag = "blinded";
                    }
                    else
                    {
                        cpb[i, j].BackgroundImage = Image.FromFile("../../Imagenes/" + imageBack + ".png");
                        cpb[i, j].Tag = "tileTag";
                    }

                    cpb[i, j].BackgroundImageLayout = ImageLayout.Stretch;

                    Controls.Add(cpb[i, j]);
                }
            }
        }

        private void ControlArkanoid_MouseMove(object sender, MouseEventArgs e)
        {
            if (!DatosJuego.gameStarted)
            {
                if (e.X < (Width - playerPb.Width))
                {
                    playerPb.Left = e.X;
                    ball.Left = playerPb.Left + (playerPb.Width / 2) - (ball.Width / 2);
                }
            }
            else
            {
                if (e.X < (Width - playerPb.Width))
                    playerPb.Left = e.X;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (!DatosJuego.gameStarted)
                return;

            DatosJuego.ticksCount += 0.01;
            BallMovements?.Invoke();
        }

        private void ControlArkanoid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                DatosJuego.gameStarted = true;
                timer1.Start();
            }
        }

        private void BounceBall()
        {
            try
            {
                if (ball.Top < 0)
                    DatosJuego.dirY = -DatosJuego.dirY;

                if (ball.Bottom > Height)
                {
                    DatosJuego.lifes--;
                    DatosJuego.gameStarted = false;
                    timer1.Stop();
                    DatosJuego.dirY = -DatosJuego.dirY;

                    RepositionElements();
                    UpdateElements();

                    if (DatosJuego.lifes <= 0)
                    {
                        timer1.Stop();
                        throw new NotRemaininglifesException("Juego terminado");

                    }
                }

                if (ball.Left < 0 || ball.Right > Width)
                {
                    DatosJuego.dirX = -DatosJuego.dirX;
                    return;
                }

                if (ball.Bounds.IntersectsWith(playerPb.Bounds))
                {
                    DatosJuego.dirY = -DatosJuego.dirY;
                }

                for (int i = 4; i >= 0; i--)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (cpb[i, j] != null && ball.Bounds.IntersectsWith(cpb[i, j].Bounds))
                        {
                            DatosJuego.score += (int) (cpb[i, j].Golpes * DatosJuego.ticksCount);
                            cpb[i, j].Golpes--;

                            if (cpb[i, j].Golpes == 0)
                            {
                                Controls.Remove(cpb[i, j]);
                                cpb[i, j] = null;
                                remainingPb--;

                            }
                            else if (cpb[i, j].Tag.Equals("blinded"))
                                cpb[i, j].BackgroundImage = Image.FromFile("../../Imagenes/tb2.png");

                            DatosJuego.dirY = -DatosJuego.dirY;

                            score.Text = DatosJuego.score.ToString();
                            if (remainingPb == 0)
                            {
                                timer1.Stop();
                                throw new OutofTilesException("Victoria!");
                            }

                            return;
                        }
                    }
                }
            }
            catch (NotRemaininglifesException ex)
            {
                MessageBox.Show(ex.Message);
                AgregarDatos();
                DatosJuego.lifes = 3;
                DatosJuego.score = 0;
                DatosJuego.ticksCount = 0;
                ScoresPanel();
                this.Close();
            }
            catch (OutofTilesException ex)
            {
                MessageBox.Show(ex.Message);
                AgregarDatos();
                DatosJuego.lifes = 3;
                DatosJuego.score = 0;
                DatosJuego.ticksCount = 0;
                ScoresPanel();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }

        private void MoveBall()
        {
            ball.Left += DatosJuego.dirX;
            ball.Top += DatosJuego.dirY;
        }

        // Se encarga de inicializar todos los elementos del panel de puntajes + vidas
        private void ScoresPanel()
        {
            // Instanciar panel
            scorePanel = new Panel();

            // Setear elementos del panel
            scorePanel.Width = Width;
            scorePanel.Height = (int)(Height * 0.07);

            scorePanel.Top = scorePanel.Left = 0;

            scorePanel.BackColor = Color.Black;

            #region Label + PictureBox
            // Instanciar pb
            heart = new PictureBox();

            heart.Height = heart.Width = scorePanel.Height;

            heart.Top = 0;
            heart.Left = 20;

            heart.BackgroundImage = Image.FromFile("../../Imagenes/Heart.png");
            heart.BackgroundImageLayout = ImageLayout.Stretch;
            #endregion

            #region N cantidad de PictureBox
            hearts = new PictureBox[DatosJuego.lifes];

            for(int i = 0; i < DatosJuego.lifes; i++)
            {
                // Instanciacion de pb
                hearts[i] = new PictureBox();

                hearts[i].Height = hearts[i].Width = scorePanel.Height;

                hearts[i].BackgroundImage = Image.FromFile("../../Imagenes/Heart.png");
                hearts[i].BackgroundImageLayout = ImageLayout.Stretch;

                hearts[i].Top = 0;

                if (i == 0)
                    // corazones[i].Left = 20;
                    hearts[i].Left = scorePanel.Width / 2;
                else
                {
                    hearts[i].Left = hearts[i - 1].Right + 5;
                }
            }
            #endregion

            // Instanciar labels
            remainingLifes = new Label();
            score = new Label();

            // Setear elementos de los labels
            remainingLifes.ForeColor = score.ForeColor = Color.White;

            remainingLifes.Text = "x " + DatosJuego.lifes.ToString();
            score.Text = DatosJuego.score.ToString();

            remainingLifes.Font = score.Font = new Font("Microsoft YaHei", 18F);
            remainingLifes.TextAlign = score.TextAlign = ContentAlignment.MiddleCenter;

            remainingLifes.Left = heart.Right + 5;
            score.Left = Width - 100;

            remainingLifes.Height = score.Height = scorePanel.Height;

            scorePanel.Controls.Add(heart);
            scorePanel.Controls.Add(remainingLifes);
            scorePanel.Controls.Add(score);

            foreach(var pb in hearts)
            {
                scorePanel.Controls.Add(pb);
            }

            Controls.Add(scorePanel);
        }

        private void RepositionElements()
        {
            playerPb.Left = (Width / 2) - (playerPb.Width / 2);
            ball.Top = playerPb.Top - ball.Height;
            ball.Left = playerPb.Left + (playerPb.Width / 2) - (ball.Width / 2);
        }

        private void UpdateElements()
        {
            remainingLifes.Text = "x " + DatosJuego.lifes.ToString();

            scorePanel.Controls.Remove(hearts[DatosJuego.lifes]);
            hearts[DatosJuego.lifes] = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }
        private void AgregarDatos()
        {
            Menu menu= new Menu();
            menu.Show();
            try
            {
                var dt = BaseDatos.ExecuteQuery("select puntaje from jugadores where nombres = '" + label1.Text + "'");

                if (dt.Rows.Count > 0)
                {
                    var dr = dt.Rows[0];
                    var savedscore = Convert.ToInt32(dr[0].ToString());
                    int newscore = Convert.ToInt32(score.Text);
                    if (newscore >= savedscore)
                    {
                        BaseDatos.ExecuteNonQuery($"update jugadores set puntaje = '" + score.Text +
                                                  "' where nombres = '" + label1.Text + "'");
                        MessageBox.Show("Nuevo record");
                    }
                }
                else
                {
                    throw new EmptyUserNameException("Puntaje Registrado");
                }



            }
            catch (EmptyUserNameException ex)
            {
                BaseDatos.ExecuteNonQuery($"insert into jugadores(nombres, puntaje) " + 
                                          $"VALUES('{label1.Text}','{score.Text}'); " );
                MessageBox.Show(ex.Message);
               
            }
            catch (Exception exp)
            {
              
                MessageBox.Show(exp.Message);
                                                
            }  
       
        }
    }
}