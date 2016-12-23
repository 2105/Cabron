using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Bvx
{
  
    public class Document
    {
      
        public Document(string application, params Part[] parts)
        {
            this.Application = application;
            this.parts.AddRange(parts);
        }


        private List<Part> parts = new List<Part>();
      
        public List<Part> Parts 
        {
            get
            { 
                return parts; 
            } 
        }

      
        public DateTime? DeliveryDate { get; set; }

     
        public string Application { get; set; }


        public XDocument ToXDocument()
        {
            var id = 1;

            var parts = Parts.Select(o => o.ToXElement(id++)).ToList();

            return new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Job",
                    new XAttribute("BvxVersion", "2.0"),
                    new XAttribute("ProgVersion", Application),
                    new XElement("Parts", parts)));
        }
    }
}
