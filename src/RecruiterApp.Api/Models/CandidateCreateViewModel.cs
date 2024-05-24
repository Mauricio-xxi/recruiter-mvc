using System.ComponentModel.DataAnnotations;

namespace RecruiterApp.Api.Models
{
    public class CandidateCreateViewModel
    {
        public CandidateCreateViewModel()
        {
            CandidateExperiences = new List<CandidateExperienceViewModel>();
        }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // Experiences
        public List<CandidateExperienceViewModel> CandidateExperiences { get; set; }

    }
    public class CandidateExperienceViewModel
    {
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
