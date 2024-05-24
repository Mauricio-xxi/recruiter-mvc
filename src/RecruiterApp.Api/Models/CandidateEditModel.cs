using System.ComponentModel.DataAnnotations;

namespace RecruiterApp.Api.Models
{
    public class CandidateEditViewModel
    {
        public int IdCandidate { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public List<CandidateExperienceEditViewModel> CandidateExperiences { get; set; } = new List<CandidateExperienceEditViewModel>();

        public List<int> ExperiencesToRemove { get; set; } = new List<int>();
    }

    public class CandidateExperienceEditViewModel
    {
        public int IdCandidateExperience { get; set; }
        [Required]
        public string Company { get; set; }

        [Required]
        public string Job { get; set; }

        public string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BeginDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
