using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Bvx
{
    /// <summary>
    /// Stellt eine Kontur dar.
    /// </summary>
    public class Contour
    {
        /// <summary>
        /// Erzeugt eine Kontur.
        /// <param name="startX">Die X-Koordinate des Startpunktes.</param>
        /// <param name="startY">Die Y-Koordinate des Startpunktes.</param>
        /// <param name="segments">Die Segmente der Kontur.</param>
        /// </summary>
        public Contour(double startX, double startY, params Segment[] segments)
        {
            this.StartX = startX;
            this.StartY = startY;
            this.Segments.AddRange(segments);
        }

        /// <summary>
        /// Ruft die X-Koordinate des Startpunktes ab, oder legt diese fest.
        /// </summary>
        public double StartX { get; set; }

        /// <summary>
        /// Ruft die Y-Koordinate des Startpunktes ab, oder legt diese fest.
        /// </summary>
        public double StartY { get; set; }

        private List<Segment> segments = new List<Segment>();
        /// <summary>
        /// Gibt die Liste der Kurvensegmente zurück.
        /// </summary>
        public List<Segment> Segments { get { return segments; } }

        /// <summary>
        /// Gibt ein Xml-Element zurück, welches die Daten im BVX-Format enthält.
        /// </summary>
        /// <returns>Ein Xml-Element, welches die Daten im BVX-Format enthält.</returns>
        internal XElement ToXElement(string name)
        {
            return new XElement(name,
                new XElement("Point", new XAttribute("X", Formatter.FormatLength(StartX)), new XAttribute("Y", Formatter.FormatLength(StartY))),
                segments.Select(o => o.ToXElement()));
        }
    }
}
