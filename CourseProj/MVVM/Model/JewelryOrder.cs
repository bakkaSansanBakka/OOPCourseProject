using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CourseProj.MVVM.Model.Base;
using JetBrains.Annotations;

namespace CourseProj.MVVM.Model
{
    public enum OrderStatus
    {
        [Display(Name = "Принят")]
        Accepted = 1,
        [Display(Name = "В процессе")]
        InProgress = 2,
        [Display(Name = "Готов")]
        Ready = 3
    }

    public enum JewelryItemMaterial
    {
        [Display(Name = "Серебро")]
        Silver = 1,
        [Display(Name = "Золото")]
        Gold
    }

    public class JewelryOrder : Item
    {
        public OrderStatus Status { get; set; }
        public string ClientFIO { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public float TotalPrice { get; set; }
        public JewelryItemMaterial Material { get; set; }
        public int CardNum { get; set; }
        public int CardMonth { get; set; }
        public int CardYear { get; set; }

        public int JewelryItemId { get; set; }
        public JewelryItem JewelryItem { get; set; }

        public int DeliveryId { get; set; }
        public Delivery Delivery { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public JewelryOrder() { }

        public JewelryOrder(int id, string clientFIO, string phone, string address, string comment, OrderStatus status,
            JewelryItemMaterial material, int cardNum, int cardMonth, int cardYear) : base(id)
        {
            ClientFIO = clientFIO;
            Phone = phone;
            Address = address;
            Status = status;
            TotalPrice = JewelryItem.Price + Delivery.Price;
            Material = material;
            CardNum = cardNum;
            CardMonth = cardMonth;
            CardYear = cardYear;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
        }
    }
}
