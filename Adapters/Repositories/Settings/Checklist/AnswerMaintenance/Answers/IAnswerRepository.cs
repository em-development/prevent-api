using Adapters.Repositories.Base;
using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;

namespace Adapters.Repositories.Settings.Checklist.AnswerMaintenance.Answers
{
    public interface IAnswerRepository :
        IGetByIdRepository<Answer>,
        IInsertRepository<Answer>,
        IUpdateRepository<Answer>
    {
        IQueryable<Answer> SearchToDashboard(
            string? filter,
            string? orderDirection,
            string? orderBy
        );

        IQueryable<Answer> SearchToSideForm(
            string? filter,
            string? orderDirection,
            string? orderBy
        );

        Task<Answer?> GetByIdWithVersions(int id);
    }
}
