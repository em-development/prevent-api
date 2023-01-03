using Domain.Entities.Base;
using Domain.Entities.Inspections.Inspections;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionAnswers;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionProperties;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using Domain.Entities.Settings.PropertyCore.Properties;
using Domain.Entities.Settings.Users;
using Domain.Enums.Inspections.Inspections;
using Domain.ValueObjects.Inspections.Inspections;

namespace Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections
{
    public class Inspection : Entity
    {
        public int PropertyId { get; private set; }
        public int InspectorId { get; private set; }
        public bool IsHighRisk { get; private set; }
        public CoverageBegin CoverageBegin { get; private set; }
        public CoverageEnd CoverageEnd { get; private set; }
        public decimal CoveragePremium { get; private set; }
        public int TemplateVersionId { get; private set; }
        public int StatusId { get; private set; }

        #region EF Constructor

#pragma warning disable CS8618
        public Inspection()
        {
        }
#pragma warning restore CS8618

        #endregion EF Constructor

        public virtual Property? Property { get; private set; }
        public virtual InspectionTemplateVersion? InspectionTemplateVersion { get; private set; }
        public virtual InspectionStatus? InspectionStatus { get; private set; }
        public virtual User? Inspector { get; private set; }
        public virtual IEnumerable<InspectionResponsable>? InspectionResponsables { get; private set; }
        public virtual IEnumerable<InspectionAnswer>? InspectionAnswers { get; private set; }
        public virtual IEnumerable<InspectionPropertyCoverage>? InspectionPropertyCoverages { get; private set; }
        public virtual IEnumerable<InspectionPropertyBuilding>? InspectionPropertyBuildings { get; private set; }
        public virtual InspectionSchedule? InspectionSchedule { get; private set; }
        public virtual IEnumerable<InspectionAttachment>? InspectionAttachments { get; private set; }

        public Inspection(
            bool isHighRisk,
            int propertyId,
            int inspectorId,
            string coverageBegin,
            string coverageEnd,
            decimal coveragePremium,
            int templateVersionId
        )
        {
            IsHighRisk = isHighRisk;
            PropertyId = propertyId;
            InspectorId = inspectorId;
            CoverageBegin = CoverageBegin.CreateValid(coverageBegin, GetType().Name);
            CoverageEnd = CoverageEnd.CreateValid(coverageEnd, GetType().Name);
            CoveragePremium = coveragePremium;
            TemplateVersionId = templateVersionId;
        }

        public void SetIsHighRisk(bool isHighRisk)
        {
            IsHighRisk = isHighRisk;
        }

        public void SetPropertyId(int propertyId)
        {
            PropertyId = propertyId;
        }

        public void SetInspectorId(int inspectorId)
        {
            InspectorId = inspectorId;
        }

        public void SetTemplateVersionId(int templateVersionId)
        {
            TemplateVersionId = templateVersionId;
        }

        public void SetStatus(InspectionStatusEnum status)
        {
            StatusId = (int) status;
        }
    }
}