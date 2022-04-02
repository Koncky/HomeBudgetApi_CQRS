using HomeBudgetApi_CQRS.Models;
using HomeBudgetApi_CQRS.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HomeBudgetApi_CQRS.Features.Fees.Commands
{
    public class CreateFeeCommand : IRequest<Fee>
    {
        public Fee Fee { get; set; }

        public class CreateFeeCommandHandler : IRequestHandler<CreateFeeCommand, Fee>
        {
            private readonly IFeesService _feesService;

            public CreateFeeCommandHandler(IFeesService feesService)
            {
                _feesService = feesService;
            }

            public async Task<Fee> Handle(CreateFeeCommand command, CancellationToken cancellationToken)
            {
                if(command.Fee == null)
                {
                    return default;
                }
                return await _feesService.CreateFee(command.Fee);
            }
        }
    }
}
