using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Marka İsmi Boş Bırakılamaz.");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Marka İsmi En Az 2 Karakter Olmalıdır.");
        }
    }
}
