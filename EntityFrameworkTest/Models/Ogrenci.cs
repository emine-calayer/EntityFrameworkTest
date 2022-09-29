﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTest.Models
{
    public class Ogrenci
    {
        [Key]
        public int Id { get; set; }
        public string? Adi { get; set; }
        public string? Soyadi { get; set; }
    }
}
