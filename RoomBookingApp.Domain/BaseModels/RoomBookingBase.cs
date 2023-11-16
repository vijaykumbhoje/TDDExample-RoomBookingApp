﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingApp.Domain.BaseModels
{
    public abstract class RoomBookingBase : IValidatableObject
    {
        [Required]
        [StringLength(80)]
        public string FullName { get; set; }

        [Required]
        [StringLength(80)]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Date < DateTime.Now.Date)
            {
                yield return new ValidationResult("Date must be in the future", new[] { nameof(Date)});
            }
        }
    }
}
