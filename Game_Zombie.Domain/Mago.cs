using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Game_Zombie.Domain
{
    public class Mago : EntityBase
    {
        byte[][] mag = { Media.Mago_0, Media.Mago_1, Media.Mago_2, Media.Mago_3, Media.Mago_4, Media.Mago_5, Media.Mago_6, Media.Mago_7 };
        Rectangle rect;
        int i, j=3;
        Random _r;
        public Mago(Canvas canvas, Random random) : base(canvas)
        {
            _r = random;
            X = (int)(canvas.Width / 2) - 70;
            Y = (int)(canvas.Height /2) - 40;
            Height = 90;
            Widht = 70;
            rect = Rect;
            rect.Fill = Helper.ObterImagem(mag[i]);
            rect.Margin = Posicao;

        }

        public bool EstaAtirando { get; set; }
        public override void Desenhar()
        {
            Canvas.Children.Add(rect);
        }

        public void Mover()
        {
            Y += 2;
            X += 2;
            rect.Fill = Helper.ObterImagem(mag[i]);
            rect.Margin = Posicao;
            i++;
            if (i > 2)
                i = 0;
        }

        public void Atirando()
        {
            if (!EstaAtirando) return;
            rect.Fill = Helper.ObterImagem(mag[j]);
            rect.Margin = Posicao;
            j++;
            if (j > 7)
            {
                EstaAtirando = false;
                j = 3;
            }
        }

        public List<Fogo> Atirar(quandarnte quadrante) 
        {
            quandarnte[] linhaParaUmTiro = { quandarnte.direita, quandarnte.esquerda, quandarnte.acima, quandarnte.abaixo };
            EstaAtirando = true;
            List<Fogo> fogos = new List<Fogo>();
            int qtdChamas = 2;
            if (linhaParaUmTiro.Contains(quadrante))
                qtdChamas = 1;


            for (int i = 0; i < qtdChamas; i++)
            {
                fogos.Add(new Fogo(Canvas, _r, quadrante, this));
            }

            fogos.ForEach(p => p.Desenhar());
           
            return fogos;
                
        }
    }
}
