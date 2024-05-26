using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonation.Controllers
{
    [Route("api/donations")]
    public class DonationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DonationsController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
