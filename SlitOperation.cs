using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Bvx
{
    /// <summary>
    /// Stellt einen Schlitz dar.
    /// </summary>
    public class SlitOperation : Operation
    {
        /// <summary>
        /// Erzeugt einen neue Schlitz.
        /// </summary>
        /// <param name="x">Die X-Koordinate des Schlitzes.</param>
        /// <param name="y">Die Y-Koordinate des Schlitzes.</param>
        /// <param name="z">Die Z-Koordinate des Schlitzes.</param>
        /// <param name="sizeX">Die Größe des Schlitzes in X-Richtung.</param>
        /// <param name="sizeY">Die Größe des Schlitzes in Y-Richtung.</param>
        /// <param name="infinite">Bestimmt, ob der Schlitz durch das gesamte Bauteil verlaufen soll.</param>
        public SlitOperation(double x, double y, double z, double sizeX, double sizeY, bool infinite)
            : base(3)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.SizeX = sizeX;
            this.SizeY = sizeY;
        }

        /// <summary>
        /// Erzeugt eine neue Schlitz.
        /// </summary>
        /// <param name="x">Die X-Koordinate des Schlitzes.</param>
        /// <param name="y">Die Y-Koordinate des Schlitzes.</param>
        /// <param name="z">Die Z-Koordinate der Tasche.</param>
        /// <param name="rotationX">Die Rotation des Schlitzes um die X-Achse.</param>
        /// <param name="rotationY">Die Rotation des Schlitzes um die Y-Achse.</param>
        /// <param name="rotationZ">Die Rotation des Schlitzes um die Z-Achse.</param>
        /// <param name="sizeX">Die Größe des Schlitzes in X-Richtung.</param>
        /// <param name="sizeY">Die Größe des Schlitzes in Y-Richtung.</param>
        /// <param name="infinite">Bestimmt, ob der Schlitz durch das gesamte Bauteil verlaufen soll.</param>
        public SlitOperation(double x, double y, double z, double rotationX, double rotationY, double rotationZ, double sizeX, double sizeY, bool infinite)
            : this(x, y, z, sizeX, sizeY, infinite)
        {
            this.RotationX = rotationX;
            this.RotationY = rotationY;
            this.RotationZ = rotationZ;
        }

        /// <summary>
        /// Ruft die X-Koordinate des Schlitzes ab, oder legt diese fest.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Ruft die Y-Koordinate des Schlitzes ab, oder legt diese fest.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Ruft die Z-Koordinate des Schlitzes ab, oder legt diese fest.
        /// </summary>
        public double Z { get; set; }

        /// <summary>
        /// Gibt die Drehung des Schlitzes um die X-Achse in Radiant zurück, oder legt diese fest.
        /// </summary>
        public double RotationX { get; set; }

        /// <summary>
        /// Gibt die Drehung des Schlitzes um die Y-Achse in Radiant zurück, oder legt diese fest.
        /// </summary>
        public double RotationY { get; set; }

        /// <summary>
        /// Gibt die Drehung des Schlitzes um die Z-Achse in Radiant zurück, oder legt diese fest.
        /// </summary>
        public double RotationZ { get; set; }

        /// <summary>
        /// Ruft die Größe des Schlitzes in X-Richtung ab, oder legt diese fest.
        /// </summary>
        public double SizeX { get; set; }

        /// <summary>
        /// Ruft die Größe des Schlitzes in Y-Richtung ab, oder legt diese fest.
        /// </summary>
        public double SizeY { get; set; }

        /// <summary>
        /// Gibt einen Wert zurück, der festlegt ob der Schlitz durch das gesamte Bauteil verlaufen soll, oder legt diesen fest.
        /// </summary>
        public bool Infinite { get; set; }

        /// <summary>
        /// Gibt die Ausrichtung des Schlitzes in X-Richtung an, oder legt diese fest.
        /// </summary>
        public Alignment AlignmentX { get; set; }

        /// <summary>
        /// Gibt die Ausrichtung des Schlitzes in Y-Richtung an, oder legt diese fest.
        /// </summary>
        public Alignment AlignmentY { get; set; }

        /// <summary>
        /// Gibt die Tiefe des Schlitzes an, oder legt diese fest.
        /// </summary>
        public double Depth { get; set; }

        /// <summary>
        /// Gibt ein Xml-Element zurück, welches die Daten im BVX-Format enthält.
        /// </summary>
        /// <returns></returns>
        internal override XElement ToXElement()
        {
            return new XElement("Slit",
                new XAttribute("FrameId", 3),
                new XAttribute("X", Formatter.FormatLength(X)),
                new XAttribute("Y", Formatter.FormatLength(Y)),
                new XAttribute("Z", Formatter.FormatLength(Z)),
                new XAttribute("RotationX", Formatter.FormatAngle(RotationX)),
                new XAttribute("RotationY", Formatter.FormatAngle(RotationY)),
                new XAttribute("RotationZ", Formatter.FormatAngle(RotationZ)),
                new XAttribute("Infinite", Infinite),
                new XAttribute("DimensionX", Formatter.FormatLength(SizeX)),
                new XAttribute("DimensionY", Formatter.FormatLength(SizeY)),
                new XAttribute("AlignX", Formatter.FormatAlignment(AlignmentX)),
                new XAttribute("AlignY", Formatter.FormatAlignment(AlignmentY)),
                new XAttribute("Depth", Formatter.FormatLength(Depth)));
        }
    }
}
