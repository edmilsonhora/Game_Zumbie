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
    public abstract class EntityBase
    {
        
        public EntityBase(Canvas canvas)
        {
            this.Canvas = canvas;
            this.Velocidade = 4;
            this.EstaVivo = true;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Widht { get; set; }
        public int Height { get; set; }
        public int Velocidade { get; set; }
        public Canvas Canvas { get; set; }
        public bool EstaVivo { get; set; }
        public Rectangle Rect { get { return ObterRetangulo(); } }
        public Thickness Posicao { get { return ObterPosicao(); } }
        public Rect Area { get { return ObterArea(); } }
        public abstract void Desenhar();

        public virtual void ParaCima(int angulo=4)
        {
            Y -= angulo;
        }

        public virtual void ParaBaixo(int angulo=4)
        {
            Y += angulo;
        }

        public virtual void ParaDireita(int angulo = 4)
        {
            X += angulo;
        }

        public virtual void ParaEsquerda(int angulo = 4)
        {
            X -= angulo;
        }

        private Rectangle ObterRetangulo()
        {
            return new Rectangle() { Height = this.Height, Width = this.Widht };
        }

        private Thickness ObterPosicao()
        {
            return new Thickness(this.X, this.Y, this.X + this.Widht, this.Y + this.Height);
        }

        private Rect ObterArea()
        {
            return new Rect(new Point(X, Y), new Size(Widht, Height));
        }

    }
}
