using BloodDonation.Application.Commands.CreateDonor;
using BloodDonation.Application.Queries.GetAllDonors;
using BloodDonation.Application.Queries.GetDonorById;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonation.Controllers
{
    [Route("api/donors")]
    public class DonorsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DonorsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get(GetAllDonorsQuery getAllDonorsQuery)
        {
            var donors = await _mediator.Send(getAllDonorsQuery);

            return Ok(donors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetDonorByIdQuery(id);

            var donor =  await _mediator.Send(query);

            if (donor == null)
            {
                return NotFound();
            }
            return Ok(donor);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDonorCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
    }
}
