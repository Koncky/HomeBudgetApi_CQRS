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
    public class GetAllFeesQuery : IRequest<IEnumerable<Fee>>
    {
        public class GetAllFeesQueryHandler : IRequestHandler<GetAllFeesQuery, IEnumerable<Fee>>
        {
            private readonly IFeesService _feesService;

            public GetAllFeesQueryHandler(IFeesService feesService)
            {
                _feesService = feesService;
            }

            public async Task<IEnumerable<Fee>> Handle(GetAllFeesQuery query, CancellationToken cancellationToken)
            {
                return await _feesService.GetFees();
            }
        }
    }
}
