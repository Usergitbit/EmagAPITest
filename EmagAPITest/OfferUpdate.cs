using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CommonData.Emag.Models
{
    public class OfferUpdate
    {
        public int id { get; set; }
        public List<Stock> stock { get; set; } = new List<Stock>
        {
            new Stock { warehouse_id = 1, value = 1}
        };
        public List<HandlingTime> handling_time { get; set; } = new List<HandlingTime>
        {
            new HandlingTime { warehouse_id = 1, value = 0}
        };
        public int status { get; set; }
        public decimal sale_price { get; set; }
        public int vat_id { get; set; }

        public OfferUpdate()
        {
            id = 2;
            status = 1;
            sale_price = 63;
            vat_id = 1;
        }

    }

    public class HandlingTime
    {
        public int warehouse_id { get; set; }
        public int value { get; set; }

    }

    public class Stock
    {
        public int warehouse_id { get; set; }
        public int value { get; set; }
    }


}
