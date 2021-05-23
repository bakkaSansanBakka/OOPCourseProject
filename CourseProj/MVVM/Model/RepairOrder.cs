using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CourseProj.MVVM.Model.Base;
using JetBrains.Annotations;

namespace CourseProj.MVVM.Model
{
    public class RepairOrder : Item
    {
        public OrderStatus Status { get; set; }
        public string ClientFIO { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public RepairOrder() { }

        public RepairOrder(int id, string clientFIO, OrderStatus status, string image, string description) : base(id)
        {
            Status = status;
            ClientFIO = clientFIO;
            Image = image;
            Description = description;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
        }
    }
}
