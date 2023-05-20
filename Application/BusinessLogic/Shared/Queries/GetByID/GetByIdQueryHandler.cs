﻿using Application.Common.Helpers;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq.Expressions;

namespace Application.BusinessLogic.Shared.Queries.GetByID
{
    public class GetByIdQueryHandler<TViewModel,TQuery, TEntity> : IRequestHandler<TQuery,TViewModel>
        where TViewModel : class
        where TQuery : GetByIdQuery<TViewModel>
        where TEntity : class

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TViewModel> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var keyName = _context.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey()
                .Properties
                .Select(x => x.Name)
                .SingleOrDefault();

            var viewModel = await _context.Set<TEntity>()
                .Where(ExpressionHelper<TEntity>.CreateExpression(keyName, request.Id))
                .ProjectTo<TViewModel>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();

            return viewModel;
        }

    }
}
