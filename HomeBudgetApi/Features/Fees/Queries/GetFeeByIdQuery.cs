using HomeBudgetApi_CQRS.Models;
using HomeBudgetApi_CQRS.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HomeBudgetApi_CQRS.Features.Fees.Queries
{
    public class GetFeeByIdQuery : IRequest<Fee>
    {
        public int Id { get; set; }

        public class GetFeeByIdQueryHandler : IRequestHandler<GetFeeByIdQuery, Fee>
        {
            private readonly IFeesService _feesService;

            public GetFeeByIdQueryHandler(IFeesService feesService)
            {
                _feesService = feesService;
            }

            public async Task<Fee> Handle(GetFeeByIdQuery query, CancellationToken cancellationToken)
            {
                return await _feesService.GetFeeById(query.Id);
            }
        }
    }
}
