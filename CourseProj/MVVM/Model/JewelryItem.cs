using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProj.MVVM.Model.Base;

namespace CourseProj.MVVM.Model
{
    public class JewelryItem : Item
    {
        public string JewelryName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public IList<JewelryOrder> JewelryOrders { get; set; }

        public JewelryItem() { }

        public JewelryItem(int id, string jewelryName, string description, string image, int price) : base(id)
        {
            JewelryName = jewelryName;
            Description = description;
            Image = image;
            Price = price;
        }
    }
}
