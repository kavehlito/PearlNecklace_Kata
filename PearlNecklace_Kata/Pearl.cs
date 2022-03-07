using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearlNecklace_Kata
{
    internal class Pearl : IPearl
    {
        public Color Color { get; private set; }
        public Shape Shape { get; private set; }
        public Type Type { get; private set; }
        public int Size { get; private set; }
        public decimal Price { get; private set; }

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

        public static bool operator == (Pearl p1, Pearl p2) => Equals(p1, p2);
        public static bool operator != (Pearl p1, Pearl p2) => !Equals(p1, p2);
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
        public Pearl(Pearl pearl)
        {
            Color = pearl.Color;
            Shape = pearl.Shape;
            Type = pearl.Type;
            Size = pearl.Size;
            Price = pearl.Price;
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
