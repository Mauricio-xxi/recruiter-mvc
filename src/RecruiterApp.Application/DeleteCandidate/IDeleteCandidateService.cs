namespace RecruiterApp.Application.DeleteCandidate
{
    public interface IDeleteCandidateService
    {
        Task DeleteCandidateAsync(int IdCandidate);
    }
}
