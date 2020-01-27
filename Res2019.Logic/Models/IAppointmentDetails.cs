namespace Res2019.Logic.Models
{
    public interface IAppointmentDetails
    {
        string AppointmentDay { get; set; }
        string AppointmentDuration { get; set; }
        string AppointmentLength { get; set; }
        string AppointmentTime { get; set; }
        string Email { get; set; }
        string Forename { get; set; }
        string Surname { get; set; }
        string Telephone { get; set; }
        string IsOccupied { get; set; }
        string Name { get; set; }
    }
}