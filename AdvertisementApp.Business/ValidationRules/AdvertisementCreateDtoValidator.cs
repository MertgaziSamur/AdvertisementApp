﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvertisementApp.Dtos;
using FluentValidation;
using FluentValidation.Validators;

namespace AdvertisementApp.Business.ValidationRules
{
    public class AdvertisementCreateDtoValidator : AbstractValidator<AdvertisementCreateDto>
    {
        public AdvertisementCreateDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();

        }
    }
}
