using System;
using System.Collections.Generic;
using System.Text;

namespace VideoAppBLL.BO
{
    public class RentalBO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public VideoBO Video { get; set; }
    }
}
