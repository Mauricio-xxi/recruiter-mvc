namespace RecruiterApp.Domain.Entities
{
    public class Candidate : EntityBase
    {
        public int IdCandidate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }

        // Relationships

        public ICollection<CandidateExperience> CandidateExperiences { get; set; }

    }
}
