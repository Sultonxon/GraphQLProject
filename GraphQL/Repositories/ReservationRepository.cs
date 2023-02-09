using GraphQLServer.Data;
using GraphQLServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLServer.Repositories;


public class ReservationRepository
{
    private readonly MyHotelDbContext _myHotelDbContext;

    public ReservationRepository(MyHotelDbContext myHotelDbContext)
    {
        _myHotelDbContext = myHotelDbContext;
    }

    public async Task<List<Reservation>> GetAll()
    {
        return await _myHotelDbContext
            .Reservations
            .Include(x => x.Room)
            .Include(x => x.Guest)
            .ToListAsync();
    }
}
