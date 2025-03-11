namespace RoomBookingApp.Domain.BaseModels;

public abstract class RoomBookingBase
{
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public DateTime Date { get; set; }
}
