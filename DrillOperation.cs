using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Bvx
{
    /// <summary>
    /// Stellt eine Bohrung dar.
    /// </summary>
    public class DrillOperation : Operation
    {
        /// <summary>
        /// Erzeugt eine neue Bohrung.
        /// </summary>
        /// <param name="x">Die X-Koordinate der Bohrung.</param>
        /// <param name="y">Die Y-Koordinate der Bohrung.</param>
        /// <param name="z">Die Z-Koordinate der Bohrung.</param>
        /// <param name="diameter">Der Durchmesser der Bohrung.</param>
        /// <param name="depth">Die Tiefe der Bohrung (<= 0 unendlich).</param>
        public DrillOperation(double x, double y, double z, double diameter, double depth)
            : base(3)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.Diameter = diameter;
            
            if (depth > 0)
                this.Depth = depth;
            else
                this.Infinite = true;
        }

        /// <summary>
        /// Erzeugt eine neue Bohrung.
        /// </summary>
        /// <param name="x">Die X-Koordinate der Bohrung.</param>
        /// <param name="y">Die Y-Koordinate der Bohrung.</param>
        /// <param name="z">Die Z-Koordinate der Bohrung.</param>
        /// <param name="rotationX">Die Rotation der Bohrung um die X-Achse.</param>
        /// <param name="rotationY">Die Rotation der Bohrung um die Y-Achse.</param>
        /// <param name="rotationZ">Die Rotation der Bohrung um die Z-Achse.</param>
        /// <param name="diameter">Der Durchmesser der Bohrung.</param>
        /// <param name="depth">Die Tiefe der Bohrung (<= 0 unendlich).</param>
        public DrillOperation(double x, double y, double z, double rotationX, double rotationY, double rotationZ, double diameter, double depth)
            : this(x, y, z, diameter, depth)
        {
            this.RotationX = rotationX;
            this.RotationY = rotationY;
            this.RotationZ = rotationZ;
        }

        /// <summary>
        /// Ruft die X-Koordinate der Bohrung ab, oder legt diese fest.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Ruft die Y-Koordinate der Bohrung ab, oder legt diese fest.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Ruft die Z-Koordinate der Bohrung ab, oder legt diese fest.
        /// </summary>
        public double Z { get; set; }

        /// <summary>
        /// Gibt die Drehung der Bohrung um die X-Achse in Radiant zurück, oder legt diese fest.
        /// </summary>
        public double RotationX { get; set; }

        /// <summary>
        /// Gibt die Drehung der Bohrung um die Y-Achse in Radiant zurück, oder legt diese fest.
        /// </summary>
        public double RotationY { get; set; }

        /// <summary>
        /// Gibt die Drehung der Bohrung um die Z-Achse in Radiant zurück, oder legt diese fest.
        /// </summary>
        public double RotationZ { get; set; }

        /// <summary>
        /// Ruft den Durchmesser der Bohrung ab, oder legt diesen fest.
        /// </summary>
        public double Diameter { get; set; }

        /// <summary>
        /// Ruft die Tiefe der Bohrung ab, oder legt diese fest.
        /// </summary>
        public double Depth { get; set; }

        /// <summary>
        /// Gibt einen Wert zurück, der festlegt ob die Bohrung durch das gesamte Bauteil verlaufen soll, oder legt diesen fest.
        /// </summary>
        public bool Infinite { get; set; }

        /// <summary>
        /// Gibt ein Xml-Element zurück, welches die Daten im BVX-Format enthält.
        /// </summary>
        /// <returns>Ein Xml-Element, welches die Daten im BVX-Format enthält.</returns>
        internal override XElement ToXElement()
        {
            return new XElement("Drilling",
                new XAttribute("FrameId", 3),
                new XAttribute("X", Formatter.FormatLength(X)),
                new XAttribute("Y", Formatter.FormatLength(Y)),
                new XAttribute("Z", Formatter.FormatLength(Z)),
                new XAttribute("Rotation", Formatter.FormatAngle(RotationX)),
                new XAttribute("Bevel", Formatter.FormatAngle(RotationY)),
                new XAttribute("Angle", Formatter.FormatAngle(RotationZ)),
                new XAttribute("DrillDiam", Formatter.FormatLength(Diameter)),
                new XAttribute("Depth", Formatter.FormatLength(Depth)),
                new XAttribute("DepthUsing", Infinite ? "Infinite" : "Value"));
        }
    }
}
