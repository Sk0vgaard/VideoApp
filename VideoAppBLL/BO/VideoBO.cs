using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VideoAppBLL.BO
{
    public class VideoBO
    {
        public int Id { get; set; }

        [Required] //Video cannot be created without a Title
        [MinLength(2)]
        [MaxLength(40)]
        public string Title { get; set; }

        public int PricePrDay { get; set; }

        public int Year { get; set; }

        public List<GenreBO> Genres { get; set; }

        public int GenreId { get; set; }
    }
}