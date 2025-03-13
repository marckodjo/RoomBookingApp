using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RoomBookingApp.Persistence;

namespace RoomBookingApp.Api
{
    public class EnsureDatabase
    {
        public static void EnsureDatabaseCreated(SqliteConnection conn)
        {
            var builder = new DbContextOptionsBuilder<RoomBookingAppDbContext>();
            builder.UseSqlite(conn);

            using var context = new RoomBookingAppDbContext(builder.Options);
            context.Database.EnsureCreated();
        }
    }
}
