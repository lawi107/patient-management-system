namespace PatientManagement.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateAdmitted { get; set; }
        public string Gender { get; set; }
        public DateTime DateofBirth { get; set; }
        public int ContactInformation {  get; set; }
        public string Email {  get; set; }

        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public int ConditionId { get; set; }
        public virtual Condition Condition { get; set; }
    }
}
