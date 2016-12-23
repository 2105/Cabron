using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Bvx
{
    /// <summary>
    /// Stellt eine Tasche dar.
    /// </summary>
    public class PocketOperation : Operation
    {
        /// <summary>
        /// Erzeugt eine neue Tasche.
        /// </summary>
        /// <param name="x">Die X-Koordinate der Tasche.</param>
        /// <param name="y">Die Y-Koordinate der Tasche.</param>
        /// <param name="z">Die Z-Koordinate der Tasche.</param>
        /// <param name="sizeX">Die Größe der Tasche in X-Richtung.</param>
        /// <param name="sizeY">Die Größe der Tasche in Y-Richtung.</param>
        /// <param name="infinite">Bestimmt, ob die Tasche durch das gesamte Bauteil verlaufen soll.</param>
        public PocketOperation(double x, double y, double z, double sizeX, double sizeY, bool infinite)
            : base(3)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.SizeX = sizeX;
            this.SizeY = sizeY;
        }

        /// <summary>
        /// Erzeugt eine neue Tasche.
        /// </summary>
        /// <param name="x">Die X-Koordinate der Tasche.</param>
        /// <param name="y">Die Y-Koordinate der Tasche.</param>
        /// <param name="z">Die Z-Koordinate der Tasche.</param>
        /// <param name="rotationX">Die Rotation der Tasche um die X-Achse.</param>
        /// <param name="rotationY">Die Rotation der Tasche um die Y-Achse.</param>
        /// <param name="rotationZ">Die Rotation der Tasche um die Z-Achse.</param>
        /// <param name="sizeX">Die Größe der Tasche in X-Richtung.</param>
        /// <param name="sizeY">Die Größe der Tasche in Y-Richtung.</param>
        /// <param name="infinite">Bestimmt, ob die Tasche durch das gesamte Bauteil verlaufen soll.</param>
        public PocketOperation(double x, double y, double z, double rotationX, double rotationY, double rotationZ, double sizeX, double sizeY, bool infinite)
            : this(x, y, z, sizeX, sizeY, infinite)
        {
            this.RotationX = rotationX;
            this.RotationY = rotationY;
            this.RotationZ = rotationZ;
        }

        /// <summary>
        /// Ruft die Ebene der Tasche ab, oder legt diese fest.
        /// </summary>
        public BVXPlane BasePlane { get; set; }

        /// <summary>
        /// Ruft die X-Koordinate der Tasche ab, oder legt diese fest.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Ruft die Y-Koordinate der Tasche ab, oder legt diese fest.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Ruft die Z-Koordinate der Tasche ab, oder legt diese fest.
        /// </summary>
        public double Z { get; set; }

        /// <summary>
        /// Gibt die Drehung der Tasche um die X-Achse in Radiant zurück, oder legt diese fest.
        /// </summary>
        public double RotationX { get; set; }

        /// <summary>
        /// Gibt die Drehung der Tasche um die Y-Achse in Radiant zurück, oder legt diese fest.
        /// </summary>
        public double RotationY { get; set; }

        /// <summary>
        /// Gibt die Drehung der Tasche um die Z-Achse in Radiant zurück, oder legt diese fest.
        /// </summary>
        public double RotationZ { get; set; }

        /// <summary>
        /// Ruft die Größe der Tasche in X-Richtung ab, oder legt diese fest.
        /// </summary>
        public double SizeX { get; set; }

        /// <summary>
        /// Ruft die Größe der Tasche in Y-Richtung ab, oder legt diese fest.
        /// </summary>
        public double SizeY { get; set; }

        /// <summary>
        /// Gibt einen Wert zurück, der festlegt ob die Tasche durch das gesamte Bauteil verlaufen soll, oder legt diesen fest.
        /// </summary>
        public bool Infinite { get; set; }

        /// <summary>
        /// Gibt die Ausrichtung der Tasche in X-Richtung an, oder legt diese fest.
        /// </summary>
        public Alignment AlignmentX { get; set; }

        /// <summary>
        /// Gibt die Ausrichtung der Tasche in Y-Richtung an, oder legt diese fest.
        /// </summary>
        public Alignment AlignmentY { get; set; }

        /// <summary>
        /// Gibt die Tiefe der Tasche an, oder legt diese fest.
        /// </summary>
        public double Depth { get; set; }

        /// <summary>
        /// Gibt ein Xml-Element zurück, welches die Daten im BVX-Format enthält.
        /// </summary>
        /// <returns></returns>
        internal override XElement ToXElement()
        {
            return new XElement("Pocket",
                new XAttribute("FrameId", 3),
                new XAttribute("X", Formatter.FormatLength(X)),
                new XAttribute("Y", Formatter.FormatLength(Y)),
                new XAttribute("Z", Formatter.FormatLength(Z)),
                new XAttribute("Rotation", Formatter.FormatAngle(RotationX)),
                new XAttribute("Bevel", Formatter.FormatAngle(RotationY)),
                new XAttribute("Angle", Formatter.FormatAngle(RotationZ)),
                new XAttribute("Infinite", Infinite),
                new XAttribute("DimensionX", Formatter.FormatLength(SizeX)),
                new XAttribute("DimensionY", Formatter.FormatLength(SizeY)),
                new XAttribute("AlignX", Formatter.FormatAlignment(AlignmentX)),
                new XAttribute("AlignY", Formatter.FormatAlignment(AlignmentY)),
                new XAttribute("Depth", Formatter.FormatLength(Depth)));
        }
    }
}
