using Application.BusinessLogic.Objava.Queries.GetAllQuery;
using Application.Common.Helpers;
using Application.Common.Interfaces;
using Application.Shared.Services.Queries.GetAll;
using Application.Shared.Services.Queries.GetForDropdown;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.BusinessLogic.AdministrativnaJedinica.Queries.GetForDropdown
{
    public class GetAdmJediniceForDropdownQueryHandler : GetForDropdownQueryHandler<AdmJedinicaDropdownViewModel, GetAdmJediniceForDropdownQuery, Domain.Entities.AdministrativnaJedinica>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAdmJediniceForDropdownQueryHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}

