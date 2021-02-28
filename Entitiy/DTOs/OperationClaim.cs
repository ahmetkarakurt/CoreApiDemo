using Core.Entitiy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entitiy.DTOs
{
   public class OperationClaim :IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
