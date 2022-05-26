using Game_Zombie.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Game_Zombie.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Canvas canvas;
        PanoDeFundo panoDeFundo;
        Plataforma plataforma;
        Mago mago;
        List<Fogo> fogos;
        List<Zumbi> zumbis;
        DispatcherTimer gameTimer;
        DispatcherTimer fogoTimer;
        Random random;
        int tempoGeraZumbi = 10;
        public MainWindow()
        {
            InitializeComponent();
            random = new Random();
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            canvas = new Canvas();
            canvas.Height = this.Height;
            canvas.Width = this.Width;
            canvas.Background = Brushes.Gray;
            this.AddChild(canvas);
            panoDeFundo = new PanoDeFundo(canvas);
            mago = new Mago(canvas, random);
            plataforma = new Plataforma(canvas);
            fogos = new List<Fogo>();
            zumbis = new List<Zumbi>();// (canvas, mago, random);
            //panoDeFundo.Desenhar();
            plataforma.Desenhar();
            mago.Desenhar();



            gameTimer = new DispatcherTimer();
            gameTimer.Interval = TimeSpan.FromMilliseconds(80);
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();

            fogoTimer = new DispatcherTimer();
            fogoTimer.Interval = TimeSpan.FromMilliseconds(20);
            fogoTimer.Tick += FogoTimer_Tick;
            fogoTimer.Start();

        }

        private void FogoTimer_Tick(object sender, EventArgs e)
        {
            fogos.ForEach(p => p.Mover());
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {

            if (tempoGeraZumbi <= 0)
            {
                var z = new Zumbi(canvas, mago, random);
                z.Desenhar();
                zumbis.Add(z);
                tempoGeraZumbi = random.Next(10, 40);
            }
            tempoGeraZumbi--;


            mago.Mover();
            plataforma.Mover();
            mago.Atirando();
            zumbis.ForEach(p => p.Mover());

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();


            if (Keyboard.IsKeyDown(Key.Up) && Keyboard.IsKeyDown(Key.Left))
            {
                
                fogos.AddRange(mago.Atirar(quandarnte.acimaEsquerda));
                fogos.AddRange(mago.Atirar(quandarnte.abaixoEsquerda));
                fogos.AddRange(mago.Atirar(quandarnte.esquerda));
                fogos.AddRange(mago.Atirar(quandarnte.acima));
                //fogos.AddRange(mago.Atirar(quandarnte.abaixo));
            }



            if (Keyboard.IsKeyDown(Key.Up) && Keyboard.IsKeyDown(Key.Right))
            {
                fogos.AddRange(mago.Atirar(quandarnte.acimaDireita));
                fogos.AddRange(mago.Atirar(quandarnte.abaixoDireita));
                fogos.AddRange(mago.Atirar(quandarnte.direita));
                //fogos.AddRange(mago.Atirar(quandarnte.acima));
                fogos.AddRange(mago.Atirar(quandarnte.abaixo));

            }
                
                    


            //if (Keyboard.IsKeyDown(Key.Down) && Keyboard.IsKeyDown(Key.Left))
            //   if (e.Key == Key.Space)
            //        fogos.AddRange(mago.Atirar(quandarnte.abaixoEsquerda));

            //if (Keyboard.IsKeyDown(Key.Down) && Keyboard.IsKeyDown(Key.Right))
            //    if (e.Key == Key.Space)
            //        fogos.AddRange(mago.Atirar(quandarnte.abaixoDireita));


            //if (Keyboard.IsKeyDown(Key.Left) && Keyboard.IsKeyDown(Key.Space))
            //    fogos.AddRange(mago.Atirar(quandarnte.esquerda));


            //if (Keyboard.IsKeyDown(Key.Right) && Keyboard.IsKeyDown(Key.Space))
            //    fogos.AddRange(mago.Atirar(quandarnte.direita));


            //if (Keyboard.IsKeyDown(Key.Up) && Keyboard.IsKeyDown(Key.Space))
            //    fogos.AddRange(mago.Atirar(quandarnte.acima));


            //if (Keyboard.IsKeyDown(Key.Down) && Keyboard.IsKeyDown(Key.Space))
            //    fogos.AddRange(mago.Atirar(quandarnte.abaixo));



        }
    }
}
