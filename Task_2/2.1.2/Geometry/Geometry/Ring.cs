namespace Geometry
{
    class Ring : Circle
    {
        /// <summary>
        /// кольцо
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="internalRadius"></param>
        /// <param name="p"></param>
        public Ring(int radius, int internalRadius, Point p) : base(radius, p)
        {
            InternalRadius = internalRadius;
        }

        public int InternalRadius { get; set; }
        public override double Perimeter => base.Perimeter - 2 * 3.14 * InternalRadius;
        public double Square => 3.14 * Radius * Radius - 3.14 * InternalRadius * InternalRadius;

        public override string ToString()
        {
            return $"Кольцо: Периметр - {Perimeter} --- Площадь - {Square}";
        }
    }
}