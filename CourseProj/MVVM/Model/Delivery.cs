using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProj.MVVM.Model.Base;

namespace CourseProj.MVVM.Model
{
    public enum DeliveryType
    {
        [Display(Name = "Самовывоз")]
        Pickup = 1,
        [Display(Name = "Почта")]
        Mail
    }

    public class Delivery : Item
    {
        public DeliveryType DeliveryType { get; set; }
        public int Price { get; set; }
        public IList<JewelryOrder> JewelryOrders { get; set; }

        public Delivery() { }

        public Delivery(int id, int price, DeliveryType deliveryType) : base(id)
        {
            Price = price;
            DeliveryType = deliveryType;
        }
    }
}
