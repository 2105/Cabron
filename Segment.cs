using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Bvx
{
    /// <summary>
    /// Stellt ein Kurvensegment dar.
    /// </summary>
    public abstract class Segment
    {
        /// <summary>
        /// Ruft die X-Koordinate des Zielpunktes ab, oder legt diese fest.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Ruft die Y-Koordinate des Zielpunktes ab, oder legt diese fest.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Ruft den Gehrungswinkel des Segments in Radiant ab, oder legt diesen fest.
        /// </summary>
        public double Beavel { get; set; }

        /// <summary>
        /// Gibt ein Xml-Element zurück, welches die Daten im BVX-Format enthält.
        /// </summary>
        /// <returns>Ein Xml-Element, welches die Daten im BVX-Format enthält.</returns>
        internal abstract XElement ToXElement();
    }
}
