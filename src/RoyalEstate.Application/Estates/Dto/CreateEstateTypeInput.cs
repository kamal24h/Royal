﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RoyalEstate.Estates.Dto
{    
    public class CreateEstateTypeInput
    {
        [Required]
        public string Name { get; set; }

        public DateTime CreationTime { get; set; }

        public bool IsActive { get; set; }

        public CreateEstateTypeInput()
        {
            CreationTime = DateTime.Now;
        }
    }
}