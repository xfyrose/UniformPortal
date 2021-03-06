﻿using System.Collections.Generic;

namespace CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter03
{
    public class Destination
    {
        public int DestinationId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }

        //[ForeignKey("LocationId")]
        public List<Lodging> Lodgings { get; set; }
    }
}