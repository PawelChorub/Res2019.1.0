namespace Res2019.Logic.Models
{
    public interface IAppointment
    {
        string AppointmentDate { get; set; }
        string AppointmentDuration { get; set; }
        string AppointmentLength { get; set; }
        string AppointmentTime { get; set; }
        string IsOccupied { get; set; }
    }
}