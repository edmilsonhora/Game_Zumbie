using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Game_Zombie.Domain
{
    public class Plataforma : EntityBase
    {
        Rectangle rect;
        public Plataforma(Canvas canvas) : base(canvas)
        {
            X = (int)(canvas.Width / 2) - 100;
            Y = (int)(canvas.Height / 2) + 30;
            Height = 110;
            Widht = 160;
            rect = Rect;
            rect.Fill = Helper.ObterImagem(Media.Plataforma);
            rect.Margin = Posicao;
        }

        public override void Desenhar()
        {
            Canvas.Children.Add(rect);
        }

        public void Mover()
        {
            Y += 2;
            X += 2;
            rect.Margin = Posicao;
        }
    }
}
