using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Bvx
{
    /// <summary>
    /// Stellt eine Basisklasse für Bauteile dar.
    /// </summary>
    public abstract class Part
    {
        private List<Operation> operations = new List<Operation>();

        /// <summary>
        /// Gibt die Liste der Operationen zurück.
        /// </summary>
        public List<Operation> Operations 
        { 
            get 
            { 
                return operations; 
            } 
        }

        /// <summary>
        /// Gibt die Dicke des Bauteil zurück, oder legt diese fest.
        /// </summary>
        public double Thickness { get; set; }

        /// <summary>
        /// Gibt den Namen des Bauteil zurück, oder legt diesen fest.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gibt die Größe der Framebox in X-Richtung zurück, oder legt diese fest.
        /// </summary>
        public double FrameboxX { get; set; }

        /// <summary>
        /// Gibt die Größe der Framebox in Y-Richtung zurück, oder legt diese fest.
        /// </summary>
        public double FrameboxY { get; set; }

        /// <summary>
        /// Gibt die Größe der Framebox in Z-Richtung zurück, oder legt diese fest.
        /// </summary>
        public double FrameboxZ { get; set; }

        /// <summary>
        /// Gibt die Sollstückzahl des Bauteils zurück, oder legt diese fest.
        /// </summary>
        public int RequiredQuantity { get; set; }

        /// <summary>
        /// Gibt die X-Koordinate des Bauteils in der Zeichnung zurück, oder legt diese fest.
        /// </summary>
        public double OriginX { get; set; }

        /// <summary>
        /// Gibt die Y-Koordinate des Bauteils in der Zeichnung zurück, oder legt diese fest.
        /// </summary>
        public double OriginY { get; set; }

        /// <summary>
        /// Gibt die Z-Koordinate des Bauteils in der Zeichnung zurück, oder legt diese fest.
        /// </summary>
        public double OriginZ { get; set; }

        /// <summary>
        /// Gibt die Drehung des Bauteils um die X-Achse in Radiant zurück, oder legt diese fest.
        /// </summary>
        public double RotationX { get; set; }

        /// <summary>
        /// Gibt die Drehung des Bauteils um die Y-Achse in Radiant zurück, oder legt diese fest.
        /// </summary>
        public double RotationY { get; set; }

        /// <summary>
        /// Gibt die Drehung des Bauteils um die Z-Achse in Radiant zurück, oder legt diese fest.
        /// </summary>
        public double RotationZ { get; set; }

        /// <summary>
        /// Gibt das Material des Bauteils zurück, oder legt dieses fest.
        /// </summary>
        public string Material { get; set; }


        internal abstract XElement ToXElement(int id);
    }
}
