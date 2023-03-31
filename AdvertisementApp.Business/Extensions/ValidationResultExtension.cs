﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvertisementApp.Common.Status;
using FluentValidation.Results;

namespace AdvertisementApp.Business.Extensions
{
    public static class ValidationResultExtension
    {
        public static List<CustomValidationError> ConvertToCustomValidationError(this ValidationResult validationResult)
        {
            List<CustomValidationError> errors = new List<CustomValidationError>();
            foreach (var error in validationResult.Errors)
            {
                errors.Add(new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                });
            }

            return errors;
        }
    }
}
