using Application.Wrappers;
using MediatR;

namespace Application.Features.Settings.PropertyCore.Properties.Queries.GetByInspectionTemplateVersionId
{
    public class GetByInspectionTemplateVersionIdQuery : IRequest<Response<IEnumerable<int>?>>
    {
        public int Id { get; set; }
    }
}