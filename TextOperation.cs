using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Bvx
{
    /// <summary>
    /// Stellt eine Beschriftung dar.
    /// </summary>
    public class TextOperation : Operation
    {
        /// <summary>
        /// Erstellt eine neue Beschriftung.
        /// </summary>
        /// <param name="text">Der Text der Beschriftung.</param>
        /// <param name="x">Die X-Koordinate der Beschriftung bezüglich der Bodenebene.</param>
        /// <param name="y">Die Y-Koordinate der Beschriftung bezüglich der Bodenebene.</param>
        /// <param name="angle">Der Drehwinkel der Beschriftung bezüglich der Bodenebene.</param>
        public TextOperation(string text, double x, double y, double angle)
            : base(3)
        {
            this.Text = text;
            this.X = x;
            this.Y = y;
            this.Angle = angle;
        }

        /// <summary>
        /// Ruft die X-Koordinate der Beschriftung ab, oder legt diese fest.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Ruft die Y-Koordinate der Beschriftung ab, oder legt diese fest.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Gibt die Drehung der Beschriftung um die Z-Achse in Radiant zurück, oder legt diese fest.
        /// </summary>
        public double Angle { get; set; }

        /// <summary>
        /// Gibt den Inhalt der Beschriftung zurück, oder legt diesen fest.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gibt ein Xml-Element zurück, welches die Daten im BVX-Format enthält.
        /// </summary>
        /// <returns></returns>
        internal override XElement ToXElement()
        {
            return new XElement("TextOutput",
                new XAttribute("FrameId", FrameId),
                new XAttribute("Text", Text),
                new XAttribute("X", Formatter.FormatLength(X)),
                new XAttribute("Y", Formatter.FormatLength(Y)),
                new XAttribute("Z", Formatter.FormatLength(.1)),
                new XAttribute("Angle", Formatter.FormatAngle(Angle)),
                new XAttribute("TextDirection", "Normal"),
                new XAttribute("HAlign", "Center"),
                new XAttribute("VAlign", "Center"));
        }
    }
}
