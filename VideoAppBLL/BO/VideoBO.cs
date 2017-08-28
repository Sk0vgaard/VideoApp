using System;
using System.Collections.Generic;
using System.Text;

namespace VideoAppBLL.BO
{
    public class VideoBO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public string TitleAndYear { get { return $"{Title} {Genre}"; } }

        public int Year { get; set; }
    }
}