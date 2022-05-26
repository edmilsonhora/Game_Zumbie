using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Game_Zombie.Domain
{
    public class PanoDeFundo : EntityBase
    {
        Rectangle rect;
        public PanoDeFundo(Canvas canvas) : base(canvas)
        {
            X = 0;
            Y = 0;
            Widht = (int)canvas.Width;
            Height = (int)canvas.Height;
            rect = Rect;
            rect.Fill = Helper.ObterImagem(Media.BackG);
            rect.Margin = Posicao;
        }

        public override void Desenhar()
        {
            Canvas.Children.Add(rect);
        }
    }
}
