using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Rules
{
    public class AuthsBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthsBusinessRules(IUserRepository userRepository)
        {
        _userRepository=userRepository;
        }

        public async Task EmailCanNotBeDublicatedWhenRegistered(string email) // email kullanılıyorsa
        {
            User? user = await _userRepository.GetAsync(x => x.Email == email);
            if (user != null) throw new BusinessException("Mail alread exists");
        }
    }
}
