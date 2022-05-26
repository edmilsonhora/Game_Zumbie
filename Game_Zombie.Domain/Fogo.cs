using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Game_Zombie.Domain
{
    public class Fogo : EntityBase
    {
        Rectangle rect;
        byte[][] fogos = { Media.VesFire_0, Media.VesFire_1, Media.VesFire_2, Media.VesFire_3 };
        int i;
        quandarnte _posicao;
       
        public Fogo(Canvas canvas, Random random, quandarnte posicao, Mago mago) : base(canvas)
        {

            _posicao = posicao;
           
            AnguloX = random.Next(4, 20);
            AnguloY = random.Next(4, 20);


            X = mago.X;
            Y = mago.Y;
            Height = 28;
            Widht = 28;
            rect = Rect;
            rect.Fill = Helper.ObterImagem(fogos[i]);
            rect.Margin = Posicao;

        }
        public int AnguloX { get; set; }
        public int AnguloY { get; set; }
        public override void Desenhar()
        {
            if (!Canvas.Children.Contains(rect))
                Canvas.Children.Add(rect);
        }

        public void Mover()
        {
             var f = _posicao;

            switch ((quandarnte)_posicao)
            {
                case quandarnte.acimaDireita:
                    {
                        base.ParaCima(AnguloY);
                        base.ParaDireita(AnguloX);
                    }
                    break;
                case quandarnte.acimaEsquerda:
                    {
                        base.ParaCima(AnguloY);
                        base.ParaEsquerda(AnguloX);
                    }
                    break;
                case quandarnte.abaixoDireita:
                    {
                        base.ParaBaixo(AnguloY);
                        base.ParaDireita(AnguloX);

                    }
                    break;
                case quandarnte.abaixoEsquerda:
                    {
                        base.ParaBaixo(AnguloY);
                        base.ParaEsquerda(AnguloX);
                    }
                    break;
                case quandarnte.esquerda:
                    {                        
                        base.ParaEsquerda(AnguloX);
                    }
                    break;
                case quandarnte.direita:
                    {                        
                        base.ParaDireita(AnguloX);
                    }
                    break;
                case quandarnte.abaixo:
                    {
                        base.ParaBaixo(AnguloX);
                    }
                    break;
                case quandarnte.acima:
                    {
                        base.ParaCima(AnguloX);
                    }
                    break;
                default:
                    break;
            }      

            rect.Fill = Helper.ObterImagem(fogos[i]);
            rect.Margin = Posicao;
            i++;
            if (i > 3)
                i = 0;

        }
    }
}
