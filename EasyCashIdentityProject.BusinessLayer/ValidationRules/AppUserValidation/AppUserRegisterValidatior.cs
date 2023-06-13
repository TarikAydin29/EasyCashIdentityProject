using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.BusinessLayer.ValidationRules.AppUserValidation
{
    public class AppUserRegisterValidatior : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidatior()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş olamaz.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş olamaz.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı boş olamaz.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş olamaz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş olamaz.");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre tekrar alanı boş olamaz.");

            RuleFor(x => x.Name).MaximumLength(30).WithMessage("İsim en fazla 30 karakter olabilir.");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("İsim en az 2 karakter olabilir.");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Parolalar eşleşmiyor.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz.");
        }
    }
}
