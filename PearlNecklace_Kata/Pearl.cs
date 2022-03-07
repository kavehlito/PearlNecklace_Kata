using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearlNecklace_Kata
{
    internal class Pearl : IPearl
    {
        public Color Color { get; set; }
        public Shape Shape { get; set; }
        public Type Type { get; set; }
        public int Size { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{Type} pearl, Color: {Color}, Shape: {Shape}. Size: {Size}mm. Price: {Price:C2}";
        }
        public int CompareTo(IPearl other)
        {
            if (this.Size != other.Size)
            {
                return Size.CompareTo(other.Size);
            }
            if (this.Color != other.Color)
            {
                return Color.CompareTo(other.Color);
            }
            if (this.Shape != other.Shape)
            {
                return Shape.CompareTo(other.Shape);
            }
            if (this.Type != other.Type)
            {
                return Type.CompareTo(other.Type);
            }
            return Price.CompareTo(other.Price);
        }

        public override bool Equals(object obj) => Equals(obj as IPearl);
        public bool Equals(IPearl other) => (this.Size,this.Color,this.Shape,this.Type,this.Price)
            == (other.Size,other.Color,other.Shape,other.Type,other.Price);
        public override int GetHashCode() => (this.Size, this.Color, this.Shape, this.Type, this.Price).GetHashCode();
        public void RandomInit()
        {
            var rnd = new Random();
            bool ballsOk= false;
            while (!ballsOk)
            {
                try
                {
                    int[] sizeArray = { 5, 10, 15, 20, 25 };
                    Size = sizeArray[rnd.Next(0, sizeArray.Length)];
                    Color = (Color)rnd.Next((int)Color.Pink, (int)Color.White + 1);
                    Shape = (Shape)rnd.Next((int)Shape.Round, (int)Shape.Teardrop + 1);
                    Type = (Type)rnd.Next((int)Type.Freshwater, (int)Type.Saltwater + 1);
                    if (Type == Type.Freshwater)
                    {
                        Price = (50 * Size);
                    }
                    else Price = (100 * Size);
                    ballsOk = true;
                }
                catch { }
            }
        }
        internal static class Factory
        {
            internal static IPearl CreateRandomNecklace()
            {
                var pearl = new Pearl();
                pearl.RandomInit();
                return pearl;
            }
        }
        public Pearl()
        {
            Size = 15;
            Color = Color.Black;
            Shape = Shape.Round;
            Type = Type.Freshwater;
            Price = (50 * Size);
        }
    }
}
