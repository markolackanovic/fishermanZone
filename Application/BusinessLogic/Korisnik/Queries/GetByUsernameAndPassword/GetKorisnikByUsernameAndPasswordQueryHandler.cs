using Application.Authentification;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Security;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Korisnik.Queries.GetByUsernameAndPassword
{
    public class GetKorisnikByUsernameAndPasswordQueryHandler : IRequestHandler<GetKorisnikByUsernameAndPasswordQuery, LoggedUserViewModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IJwtProvider _jwtProvider;

        public GetKorisnikByUsernameAndPasswordQueryHandler(IApplicationDbContext context, IMapper mapper, IJwtProvider jwtProvider)
        {
            _context = context;
            _mapper = mapper;
            _jwtProvider = jwtProvider;
        }

        public async Task<LoggedUserViewModel> Handle(GetKorisnikByUsernameAndPasswordQuery request, CancellationToken cancellationToken)
        {
            var passHasher = new PasswordHasher(new OptionsWrapper<HashingOptions>(new HashingOptions()));

            var loggedInUser = new LoggedUserViewModel();

            var users = await _context.Set<Domain.Entities.Korisnik>()
                .Where(u => u.KorisnickoIme == request.KorisnickoIme && u.Aktivno)
                .ProjectTo<LoggedUserViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            foreach (var user in users)
            {
                if (passHasher.Check(user.Lozinka, request.Lozinka).Verified)
                {
                    loggedInUser = user;
                    break;
                }
            }

            loggedInUser.Token = await _jwtProvider.GenerateTokenAsync(loggedInUser);
            loggedInUser.Lozinka = string.Empty;

            return loggedInUser;
        }
    }
}

