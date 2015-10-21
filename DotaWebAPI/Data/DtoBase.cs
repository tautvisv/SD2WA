using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataInterfaces;

namespace Data
{
    public abstract class DtoBase :IValidatableObject, IDto, IValidate
    {
        [Required(ErrorMessage = "RefreshData is Required")]
        public bool? RefreshData { get; set; }

        public bool IsValid()
        {
            return RefreshData != null;
        }

        public bool IsValidThrowable()
        {
            if (!IsValid()) throw new ArgumentNullException("RefreshData");
            return true;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (RefreshData == null)
                yield return new ValidationResult("Model2 is required", new []{ "Model2" });
        }
    }
}
