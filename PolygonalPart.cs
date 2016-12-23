using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Bvx
{
    /// <summary>
    /// Stellt ein Bauteil mit polygonaler Außenkontur dar.
    /// </summary>
    public class PolygonalPart : Part
    {
        /// <summary>
        /// Erzeugt ein neues Bauteil.
        /// </summary>
        /// <param name="name">Der Name des Bauteils.</param>
        /// <param name="outline">Die Außenkontur des Bauteils.</param>
        /// <param name="thickness">Die Dicke des Bauteils.</param>
        /// <param name="inlines">Die Innenkontouren des Bauteils.</param>
        public PolygonalPart(string name, Contour outline, double thickness, params Contour[] inlines)
        {
            base.Name = name;
            this.Outline = outline;
            base.Thickness = thickness;
            this.Inlines.AddRange(inlines);
            base.RequiredQuantity = 1;
        }


        /// <summary>
        /// Gibt die Außenkontur zurück, oder legt diese fest.
        /// </summary>
        public Contour Outline { get; set; }

        private List<Contour> inlines = new List<Contour>();

        /// <summary>
        /// Gibt die Liste der Innenkonturen zurück.
        /// </summary>
        public List<Contour> Inlines 
        {
            get 
            {
                return inlines; 
            } 
        }


        /// <summary>
        /// Gibt ein Xml-Element zurück, welches die Daten im BVX-Format enthält.
        /// </summary>
        /// <returns>Ein Xml-Element, welches die Daten im BVX-Format enthält.</returns>
        internal override XElement ToXElement(int id)
        {
            //var name = string.IsNullOrEmpty(Name) ? "" : Name;
            //name.Replace("%ID%", id.ToString());

            return new XElement("PolygonalPart",
               new XAttribute("PartId", id),
               new XAttribute("Name", string.IsNullOrEmpty(Name) ? id.ToString() : Name),
               new XAttribute("Thickness", Thickness),
               new XAttribute("ReqQuantity", RequiredQuantity),
               new XAttribute("Material", string.IsNullOrEmpty(Material) ?  "" : Material),
               Outline.ToXElement("Outline"),
               new XElement("Inlines", inlines.Select(o => o.ToXElement("Inline"))),
               new XElement("Operations", Operations.Select(o => o.ToXElement())),
               new XElement("FrameBox",
                    new XAttribute("DimensionX", Formatter.FormatLength(FrameboxX)),
                    new XAttribute("DimensionY", Formatter.FormatLength(FrameboxY)),
                    new XAttribute("DimensionZ", Formatter.FormatLength(FrameboxZ))),
               new XElement("CADPositionList",
                    new XElement("Transformation",
                        new XAttribute("X", Formatter.FormatLength(OriginX)),
                        new XAttribute("Y", Formatter.FormatLength(OriginY)),
                        new XAttribute("Z", Formatter.FormatLength(OriginZ))),
                        new XAttribute("RotationX", Formatter.FormatAngle(RotationX)),
                        new XAttribute("RotationY", Formatter.FormatAngle(RotationY)),
                        new XAttribute("RotationZ", Formatter.FormatAngle(RotationZ)))
               );
        }
    }
}
