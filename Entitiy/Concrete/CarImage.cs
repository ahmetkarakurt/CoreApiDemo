using Core.Entitiy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entitiy.Concrete
{
    public class CarImage:IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
