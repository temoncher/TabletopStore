﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabletopStore.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int GameId { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public virtual Game Game { get; set; }
        public virtual Order Order { get; set; }
    }
}
