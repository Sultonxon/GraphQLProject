using GraphQLServer.Entities;
using GraphQLServer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLServer.Controllers
{
    [Route("api/[controller]")]
    public class ReservationController : Controller
    {
        private readonly ReservationRepository _reservationRepository;

        public ReservationController(ReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        [HttpGet("[action]")]
        public async Task<List<Reservation>> List()
        {
            return await _reservationRepository.GetAll();
        }
    }
}
