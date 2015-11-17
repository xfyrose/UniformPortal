﻿using System.ComponentModel.DataAnnotations;

namespace WebDemo.Security.Models
{
    public class User
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Password { get; set; }

        public bool RememberMe { get; set; }
    }
}