using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Enums;

namespace YouLearn.Domain.Entities
{
    public class PlayList
    {
        public Guid Id { get; set; }
        public Usuario Usuario { get; set; }
        public EnumStatus Status { get; set; }
    }
}
