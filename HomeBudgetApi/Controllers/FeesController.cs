using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBudgetApi_CQRS.Data;
using HomeBudgetApi_CQRS.Features.Fees.Commands;
using HomeBudgetApi_CQRS.Features.Fees.Queries;
using HomeBudgetApi_CQRS.Models;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetApi_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/fees
        [HttpGet]
        public async Task<IEnumerable<Fee>> Get()
        {
            //Include - loading relationship data from another entity
            return await _mediator.Send(new GetAllFeesQuery());
        }
        // GET api/fees/5
        [HttpGet("{id}")]
        public async Task<Fee> Get(int id)
        {
            return await _mediator.Send(new GetFeeByIdQuery() { Id = id });
        }

        // POST api/fees
        [HttpPost]
        public async Task<Fee> Post([FromBody] Fee fee)
        {
            return await _mediator.Send(new CreateFeeCommand() { Fee = fee });
        }

        // PUT api/fees/5
        [HttpPut("{id}")]
        public async Task<Fee> Put(int id, [FromBody] Fee fee)
        {
            await _mediator.Send(new UpdateFeeCommand() { Id = id, Fee = fee });

            return fee;
        }

        // DELETE api/fees/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await _mediator.Send(new DeleteFeeCommand() { Id = id });
        }
    }
}
