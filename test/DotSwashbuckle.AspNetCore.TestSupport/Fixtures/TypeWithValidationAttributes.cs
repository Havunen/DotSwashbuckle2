﻿using System.ComponentModel.DataAnnotations;

namespace DotSwashbuckle.AspNetCore.TestSupport
{
    public class TypeWithValidationAttributes
    {
        [DataType(DataType.CreditCard)]
        public string StringWithDataTypeCreditCard { get; set; }

        [MinLength(1), MaxLength(3)]
        public string StringWithMinMaxLength { get; set; }

        [MinLength(1), MaxLength(3)]
        public string[] ArrayWithMinMaxLength { get; set; }

        [Length(1, 3)]
        public string[] ArrayWithLength { get; set; }

        [Length(1, 3)]
        public string StringWithLength { get; set; }

        [Range(1, 10)]
        public int IntWithRange { get; set; }

        [RegularExpression("^[3-6]?\\d{12,15}$")]
        public string StringWithRegularExpression { get; set; }

        [StringLength(10, MinimumLength = 5)]
        public string StringWithStringLength { get; set; }

        [Required]
        public string StringWithRequired { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string StringWithRequiredAllowEmptyTrue { get; set; }

        public required string StringWithRequiredModifier { get; set; }
    }
}