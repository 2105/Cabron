using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Bvx
{
    /// <summary>
    /// Stellt eine Basisklasse für Operationen dar.
    /// </summary>
    public abstract class Operation
    {
        /// <summary>
        /// Erstellt eine neue Operation.
        /// </summary>
        /// <param name="frameId">Die Basisebene der Operation.</param>
        protected Operation(int frameId)
        {
            FrameId = frameId;
        }

        /// <summary>
        /// Gibt Ausrichtungsmöglichkeiten an.
        /// </summary>
        public enum Alignment
        {
            /// <summary>
            /// Ausrichtung mittig bezüglich Achse
            /// </summary>
            Center,
            /// <summary>
            /// Ausrichtung links bezüglich Achse
            /// </summary>
            Left,
            /// <summary>
            /// Ausrichtung rechts bezüglich Achse
            /// </summary>
            Right
        }

        /// <summary>
        /// Gibt die Bezugsebene für die Operation an, oder legt diese fest.
        /// </summary>
        public int FrameId { get; set; }

        /// <summary>
        /// Gibt ein Xml-Element zurück, welches die Daten im BVX-Format enthält.
        /// </summary>
        /// <returns>Ein Xml-Element, welches die Daten im BVX-Format enthält.</returns>
        internal abstract XElement ToXElement();
    }
}
