using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Generators
{
    public class CanonicalDataCase : IValidatableObject
    {
        [Required]
        public string Description { get; set; }
        
        public string Property { get; set; }

        public string[] Comments { get; set; }

        public object Expected { get; set; }

        public CanonicalDataCase[] Cases { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Cases == null && string.IsNullOrWhiteSpace(Property))
                yield return new ValidationResult("This field is required.", new[] { nameof(Property) });
        }
    }
}