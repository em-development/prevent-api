using Adapters.Repositories.Settings.Inspections.InspectionMaintenance.Inspections;
using Adapters.Services.BaseLogs;
using Application.Exceptions.Common;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections;
using Domain.Enums.Inspections.Inspections;
using DTO.Settings.Inspections.InspectionMaintenance.Inspections;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.Inspections.Commands.ScheduleInspection
{
    public class ScheduleInspectionHandler : IRequestHandler<ScheduleInspectionRequest, Response<InspectionDTO>>
    {
        private readonly IInspectionRepository _inspectionRepository;
        private readonly IInspectionScheduleRepository _inspectionScheduleRepository;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public ScheduleInspectionHandler(
            IInspectionRepository inspectionRepository,
            IInspectionScheduleRepository inspectionScheduleRepository,
            ILogService logService,
            IMapper mapper
            )
        {
            _inspectionRepository = inspectionRepository;
            _inspectionScheduleRepository = inspectionScheduleRepository;
            _logService = logService;
            _mapper = mapper;
        }

        public async Task<Response<InspectionDTO>> Handle(
            ScheduleInspectionRequest request,
            CancellationToken cancellationToken)
        {
            Inspection? inspection = await _inspectionRepository.GetByIdAsync(request.Id);

            if (inspection == null)
            {
                throw new NotFoundException("api-entity-inspection",
                    ("api-entity-inspection-field-id", request.Id)
                );
            }

            var inspectionSchedule = await _inspectionScheduleRepository.GetByIdAsync(request.Id);

            if (inspectionSchedule == null)
            {
                InspectionSchedule newInspectionSchedule = new(
                    request.Id,
                    request.InspectionSchedule.Date
                    );

                await _inspectionScheduleRepository.InsertAsync(newInspectionSchedule);

                inspection.SetStatus(InspectionStatusEnum.SCHEDULED);
                await _inspectionRepository.UpdateAsync(inspection!);

                await _logService.SCHEDULED_SETTINGS_INSPECTION(inspection);
            }
            else
            {
                if (inspectionSchedule.Date <= DateTime.Now.Date)
                {
                    throw new Exception("Só é possível alterar o agendamento até um dia antes da data já agendada.");
                }

                inspectionSchedule.SetDate(request.InspectionSchedule.Date);
                await _inspectionScheduleRepository.UpdateAsync(inspectionSchedule);

                await _logService.UPDATE_SCHEDULED_SETTINGS_INSPECTION(inspection);
            }

            inspection = await _inspectionRepository.GetByIdWithIncludesAsync(inspection.Id);

            return new Response<InspectionDTO>(_mapper.Map<InspectionDTO>(inspection));
        }
    }
}
