using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace VideoAppBLL.BO
{
    public class UserBO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }   
        public int RentalId { get; set; }
    }
}
