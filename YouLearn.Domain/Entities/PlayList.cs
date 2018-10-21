using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entities.Base;
using YouLearn.Domain.Enums;

namespace YouLearn.Domain.Entities
{
    public class PlayList : EntityBase
    {
        public Usuario Usuario { get; set; }
        public EnumStatus Status { get; set; }
    }
}
