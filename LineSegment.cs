using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Bvx
{
    /// <summary>
    /// Stellt ein lineares Segment zwischen dem Endpunkt des Vorgängersegments und dem angegebenen Zielpunkt dar.
    /// </summary>
    public class LineSegment : Segment
    {
        /// <summary>
        /// Erzeugt ein lineares Segment.
        /// </summary>
        /// <param name="x">Die X-Koordinate des Zielpunktes.</param>
        /// <param name="y">Die Y-Koordinate des Zielpunktes.</param>
        public LineSegment(double x, double y)
        {
            base.X = x;
            base.Y = y;
        }

        /// <summary>
        /// Erzeugt ein lineares Segment.
        /// </summary>
        /// <param name="x">Die X-Koordinate des Zielpunktes.</param>
        /// <param name="y">Die Y-Koordinate des Zielpunktes.</param>
        /// <param name="bevel">Der Gehrungswinkel des Segments.</param>
        public LineSegment(double x, double y, double bevel)
            : this(x, y)
        {
            base.Beavel = bevel;
        }

        /// <summary>
        /// Gibt ein Xml-Element zurück, welches die Daten im BVX-Format enthält.
        /// </summary>
        /// <returns>Ein Xml-Element, welches die Daten im BVX-Format enthält.</returns>
        internal override XElement ToXElement()
        {
            return new XElement("Line",
                new XAttribute("X", Formatter.FormatLength(X)),
                new XAttribute("Y", Formatter.FormatLength(Y)),
                new XAttribute("Bevel", Formatter.FormatAngle(Beavel)));
        }
    }
}
