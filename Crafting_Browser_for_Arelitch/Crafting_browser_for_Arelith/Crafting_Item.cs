using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Crafting_browser_for_Arelith
{
    class Crafting_Item
    {
        #region Fields
        private string name;
        private string category="Basic";
        private string subCategory;
        private string graphics;
        private int craftingID;
        private int dc;
        private int reqired_crafting_Points;
        private int total_Value;
        private Dictionary<string,int> material_Requirements=new Dictionary<string, int>();
        private string end_Products;
        private string properties;
        #endregion

        #region Properties
        public string Name { get => name; set => name = value; }
        public string Category { get => category; set => category = value; }
        public string SubCategory { get => subCategory; set => subCategory = value; }
        public string Graphics { get => graphics; set => graphics = value; }
        public int CraftingID { get => craftingID; set => craftingID = value; }
        public int Dc { get => dc; set => dc = value; }
        public int Reqired_crafting_Points { get => reqired_crafting_Points; set => reqired_crafting_Points = value; }
        public int Total_Value { get => total_Value; set => total_Value = value; }
        internal Dictionary<string, int> Material_Requirements { get => material_Requirements; set => material_Requirements = value; }
        public string End_Products { get => end_Products; set => end_Products = value; }
        public string Properties { get => properties; set => properties = value; }


        #endregion

        #region Constructors
        public Crafting_Item()
        {
        }

        public Crafting_Item(string name, int craftingID, int total_Value)
        {
            Name = name;
            CraftingID = craftingID;
            Total_Value = total_Value;
        }
        #endregion
        
        #region Methods
        public void CreateXml()
        {
            var xmlPath = Path.Combine("Crafting_Items");
            if (!Directory.Exists(xmlPath))
            {
                Directory.CreateDirectory(xmlPath);
            }
            xmlPath = Path.Combine(xmlPath, category);
            if (!Directory.Exists(xmlPath))
            {
                Directory.CreateDirectory(xmlPath);
            }
            if (subCategory!=null)
            {
                xmlPath = Path.Combine(xmlPath, subCategory);
                if (!Directory.Exists(xmlPath))
                {
                    Directory.CreateDirectory(xmlPath);
                } 
            }

            xmlPath = Path.Combine(xmlPath, name+".xml");
            var xmlSetings=new XmlWriterSettings();
            xmlSetings.Indent = true;
            xmlSetings.NewLineOnAttributes = true;
            XmlWriter xmlWriter = XmlWriter.Create(xmlPath, xmlSetings);

            xmlWriter.WriteStartDocument();

            xmlWriter.WriteStartElement("craftingItem");
            xmlWriter.WriteAttributeString("name", name);
            xmlWriter.WriteAttributeString("category", category);
            xmlWriter.WriteAttributeString("subCategory", subCategory);
            xmlWriter.WriteAttributeString("graphics", graphics);
            xmlWriter.WriteAttributeString("craftingID", craftingID.ToString());
            xmlWriter.WriteAttributeString("dc", dc.ToString());
            xmlWriter.WriteAttributeString("requiredCraftingPoints", reqired_crafting_Points.ToString());
            xmlWriter.WriteAttributeString("totalValue", total_Value.ToString());
            xmlWriter.WriteAttributeString("endProduct", end_Products);
            xmlWriter.WriteAttributeString("properties", properties);
                       xmlWriter.WriteStartElement("materialReqirements");
            foreach (var material in material_Requirements)
            {
                xmlWriter.WriteStartElement("material");
                xmlWriter.WriteAttributeString("name", material.Key);
                xmlWriter.WriteAttributeString("quantity", material.Value.ToString());
                xmlWriter.WriteEndElement();
            } 

            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }
        #endregion

    }
}
