using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.CreateBrand
{
    public partial class CreateBrandCommand:IRequest<CreatedBrandDto>
    {
        public string Name { get; set; }

        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandDto>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;

            public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
            }

            public async Task<CreatedBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                // BusinessRules ile eklenen markanın kontrolünü yaptık
                await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);

                Brand mappedBrand = _mapper.Map<Brand>(request); // Brandı mappledik
                Brand createdBrand = await _brandRepository.AddAsync(mappedBrand); // Veritabanına ekledik
                CreatedBrandDto createdBrandDto = _mapper.Map<CreatedBrandDto>(createdBrand); //Veritabanına eklediğimiz nesineyi Dtoya mappledik

                return createdBrandDto;

            }
        }
    }
}
