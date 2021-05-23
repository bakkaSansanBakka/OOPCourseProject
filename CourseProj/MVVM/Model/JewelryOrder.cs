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

    public enum DeliveryType
    {
        [Display(Name = "Самовывоз")]
        Pickup = 1,
        [Display(Name = "Почта")]
        Mail
    }

    public class JewelryOrder : Item
    {
        public OrderStatus Status { get; set; }
        public string ClientFIO { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public float TotalPrice { get; set; }
        public JewelryItemMaterial Material { get; set; }
        public DeliveryType Delivery { get; set; }
        public long CardNum { get; set; }
        public string CardMonth { get; set; }
        public string CardYear { get; set; }

        public int JewelryItemId { get; set; }
        public JewelryItem JewelryItem { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public JewelryOrder() { }

        public JewelryOrder(int id, string clientFIO, string phone, string address, OrderStatus status,
            JewelryItemMaterial material, int cardNum, string cardMonth, string cardYear) : base(id)
        {
            ClientFIO = clientFIO;
            Phone = phone;
            Address = address;
            Status = status;
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
