﻿using TabletopStore.Models.Games;

namespace TabletopStore.Models.Orders
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
