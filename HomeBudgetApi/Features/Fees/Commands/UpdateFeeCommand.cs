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
    public class UpdateFeeCommand : IRequest<int>
    {
        public int Id { get; set; }
        public Fee Fee { get; set; }

        public class UpdateFeeCommandHandler : IRequestHandler<UpdateFeeCommand, int>
        {
            private readonly IFeesService _feesService;

            public UpdateFeeCommandHandler(IFeesService feesService)
            {
                _feesService = feesService;
            }

            public async Task<int> Handle(UpdateFeeCommand command, CancellationToken cancellationToken)
            {
                if (command.Id != command.Fee.Id)
                    return default;

                return await _feesService.UpdateFee(command.Fee);
            }
        }
    }
}
