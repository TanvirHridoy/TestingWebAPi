using System;
using System.Collections.Generic;

#nullable disable

namespace TestingWebAPi.Models
{
    public partial class EmployeeDb
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Degination { get; set; }
        public long? Phone { get; set; }
        public int Id { get; set; }
    }
}
