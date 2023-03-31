using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AdvertisementApp.UI.Models;
using FluentValidation;

namespace AdvertisementApp.UI.ValidationRules
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {
        //[Obsolete]
        public UserCreateModelValidator()
        {
            //CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş olamaz.");
            RuleFor(x => x.Password).MinimumLength(3).WithMessage("Şifre en az 3 karakter olmalı.");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Şifreler eşleşmiyor.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soy ad boş olamaz.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Ad alanı boş olamaz.");
            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Cinsiyet alanı boş olamaz.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş olamaz.");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakter olmalıdır.");
            RuleFor(x => new
            {
                x.UserName,
                x.FirstName
            }).Must(x => CanNotFirstname(x.UserName, x.FirstName)).WithMessage("Kullanıcı adı, adınızı içeremez.").When(x => x.UserName != null && x.FirstName != null);
        }

        private bool CanNotFirstname(string userName, string firstName)
        {
            return !userName.Contains(firstName);
        }
    }
}
