namespace RecruiterApp.Domain.Entities
{
    public class CandidateExperience : EntityBase
    {
        public int IdCandidateExperience{ get; set; }
        public int IdCandidate { get; set; }
        public string Company {  get; set; }
        public string Job { get; set;}
        public string Description { get; set;}
        public decimal Salary { get; set;}
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        // Relationships

        public Candidate Candidate { get; set; }
    }
}
