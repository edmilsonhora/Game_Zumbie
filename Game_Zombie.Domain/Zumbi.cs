using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Game_Zombie.Domain
{
    public class Zumbi : EntityBase
    {
        Rectangle rect;
        byte[][] walkers = null;

        int i;
        Mago _mago;
        public Zumbi(Canvas canvas, Mago mago, Random random) : base(canvas)
        {
            walkers = ObterWalkers(random.Next(1, 5));
            _mago = mago;
            X = -60;
            Y = random.Next(-300, (int)canvas.Height + 300);
            Height = 100;
            Widht = 60;
            rect = Rect;

        }

        public override void Desenhar()
        {
            if (!Canvas.Children.Contains(rect))
                Canvas.Children.Add(rect);
        }

        public void Mover()
        {

            if (this.Y > _mago.Y)
                this.Y -= 2;
            if (this.X < _mago.X)
                this.X += 4;
            if (this.Y < _mago.Y)
                this.Y += 2;
            if (this.X > _mago.X)
                this.X -= 4;

            rect.Fill = Helper.ObterImagem(walkers[i]);
            rect.Margin = Posicao;
            i++;
            if (i > 3)
                i = 0;

        }

        private byte[][] ObterWalkers(int tipo)
        {
            byte[][] walkers = new byte[4][];

            switch (tipo)
            {
                case 1:
                    {
                        walkers[0] = Media.Zum1_0;
                        walkers[1] = Media.Zum1_1;
                        walkers[2] = Media.Zum1_2;
                        walkers[3] = Media.Zum1_3;

                    }
                    break;
                case 2:
                    {
                        walkers[0] = Media.Zum2_0;
                        walkers[1] = Media.Zum2_1;
                        walkers[2] = Media.Zum2_2;
                        walkers[3] = Media.Zum2_3;

                    }
                    break;
                case 3:
                    {
                        walkers[0] = Media.Zum3_0;
                        walkers[1] = Media.Zum3_1;
                        walkers[2] = Media.Zum3_2;
                        walkers[3] = Media.Zum3_3;

                    }
                    break;
                case 4:
                    {
                        walkers[0] = Media.Zum4_0;
                        walkers[1] = Media.Zum4_1;
                        walkers[2] = Media.Zum4_2;
                        walkers[3] = Media.Zum4_3;

                    }
                    break;
                case 5:
                    {
                        walkers[0] = Media.Zum4_0;
                        walkers[1] = Media.Zum4_1;
                        walkers[2] = Media.Zum4_2;
                        walkers[3] = Media.Zum4_3;

                    }
                    break;
                default:
                    break;
            }

            return walkers;
        }
    }
}
