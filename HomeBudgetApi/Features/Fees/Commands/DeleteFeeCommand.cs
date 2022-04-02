using HomeBudgetApi_CQRS.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HomeBudgetApi_CQRS.Features.Fees.Commands
{
    public class DeleteFeeCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteFeeCommandHandler : IRequestHandler<DeleteFeeCommand, int>
        {
            private readonly IFeesService _feesService;

            public DeleteFeeCommandHandler(IFeesService feesService)
            {
                _feesService = feesService;
            }

            public async Task<int> Handle(DeleteFeeCommand command, CancellationToken cancellationToken)
            {
                var fee = await _feesService.GetFeeById(command.Id);
                if (fee == null)
                    return default;

                return await _feesService.DeleteFee(fee);
            }
        }
    }
}
