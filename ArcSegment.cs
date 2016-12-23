using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Bvx
{
    /// <summary>
    /// Stellt ein kreisbogenförmiges Segment zwischen dem Endpunkt des Vorgängersegments und dem angegebenen Zielpunkt dar.
    /// </summary>
    public class ArcSegment : Segment
    {
        /// <summary>
        /// Erzeugt ein kreisbogenförmiges Segment.
        /// </summary>
        /// <param name="x">Die X-Koordinate des Zielpunktes.</param>
        /// <param name="y">Die Y-Koordinate des Zielpunktes.</param>
        /// <param name="direction">Die Drehrichtung des Kreisbogens.</param>
        /// <param name="largeArc">Bestimmt, ob das längere Bogensegment gewählt werden soll.</param>
        /// <param name="radius">Der Radius des Kreisbogens.</param>
        public ArcSegment(double x, double y, Directions direction, bool largeArc, double radius)
        {
            base.X = x;
            base.Y = y;
            this.Direction = direction;
            this.LargeArc = largeArc;
            this.Radius = radius;
        }

        /// <summary>
        /// Ruft die Drehrichtung des Kreisbogens ab, oder legt diese fest.
        /// </summary>
        public Directions Direction { get; set; }

        /// <summary>
        /// Ruft einen Wert ab, des angibt ob das längere Bogensegment gewählt werden soll, oder legt diesen fest.
        /// </summary>
        public bool LargeArc { get; set; }

        /// <summary>
        /// Ruft den Radius des Bogens ab, oder legt diesen fest.
        /// </summary>
        public Double Radius { get; set; }

        /// <summary>
        /// Gibt Konstanten an, mit welchen die Drehrichtung eines Kreisbogens definiert wird
        /// </summary>
        public enum Directions
	    {
            /// <summary>
            /// Drehung im Uhrzeigersinn
            /// </summary>
            Clockwise = 0,
            /// <summary>
            /// Drehung gegen den Uhrzeigersinn
            /// </summary>
            Counterclockwise = 1
	    }

        /// <summary>
        /// Gibt ein Xml-Element zurück, welches die Daten im BVX-Format enthält.
        /// </summary>
        /// <returns>Ein Xml-Element, welches die Daten im BVX-Format enthält.</returns>
        internal override XElement ToXElement()
        {
            return new XElement("Arc",
                new XAttribute("X", Formatter.FormatLength(X)),
                new XAttribute("Y", Formatter.FormatLength(Y)),
                new XAttribute("Bevel", Formatter.FormatAngle(Beavel)),
                new XAttribute("Direction", Direction == 0 ? "CW" : "CCW"),
                new XAttribute("LargeArc", LargeArc),
                new XAttribute("Radius", Radius));
        }
    }
}
