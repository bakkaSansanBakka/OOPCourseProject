using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProj.MVVM.Model.Base
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public int GetId() => Id;

        public Item() { }

        public Item(int id)
        {
            Id = id;
        }
    }
}
