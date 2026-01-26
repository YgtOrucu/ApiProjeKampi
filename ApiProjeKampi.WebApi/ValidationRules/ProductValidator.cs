using ApiProjeKampi.WebApi.Entities;
using FluentValidation;

namespace ApiProjeKampi.WebApi.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Ürün adını boş geçmeyiniz")
                .MinimumLength(5).WithMessage("En azn 5 karakter veri girişi olmalı")
                .MaximumLength(50).WithMessage("En fazla 50 karakter veri girişi olmalı");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün adını boş geçmeyiniz").
                LessThan(1000).WithMessage("Fiyat 1000'den büyük olamaz").
                GreaterThan(0).WithMessage("Fiyat 0'dan küçük olamaz");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama adını boş geçmeyiniz")
               .MinimumLength(5).WithMessage("En az 5 karakter veri girişi olmalı")
               .MaximumLength(50).WithMessage("En fazla 50 karakter veri girişi olmalı");
        }
    }
}
