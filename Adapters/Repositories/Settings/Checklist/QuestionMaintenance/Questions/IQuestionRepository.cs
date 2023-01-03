using Adapters.Repositories.Base;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;

namespace Adapters.Repositories.Settings.Checklist.QuestionMaintenance.Questions
{
    public interface IQuestionRepository :
        IGetByIdRepository<Question>,
        IInsertRepository<Question>,
        IUpdateRepository<Question>
    {
        IQueryable<Question> SearchToDashboard(
            string? filter,
            string? orderDirection,
            string? orderBy
        );

        IQueryable<Question> SearchToSideForm(
            string? filter,
            string? orderDirection,
            string? orderBy
        );

        Task<Question?> GetByIdWithVersions(int id);
        Task<IEnumerable<Question>?> GetByChecklistVersionId(int id);
    }
}
