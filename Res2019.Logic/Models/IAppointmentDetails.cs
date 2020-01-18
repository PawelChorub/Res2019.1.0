namespace Res2019.Logic.Models
{
    public interface IAppointmentDetails
    {
        string AppointmentDay { get; set; }
        string AppointmentDuration { get; set; }
        string AppointmentLength { get; set; }
        string AppointmentTime { get; set; }
        string CustomerEmail { get; set; }
        string CustomerForename { get; set; }
        string CustomerSurname { get; set; }
        string CustomerTelephoneNumber { get; set; }
        string IsOccupied { get; set; }
        string ServiceName { get; set; }
    }
}