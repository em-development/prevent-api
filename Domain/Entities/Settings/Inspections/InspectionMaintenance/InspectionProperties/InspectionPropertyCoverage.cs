using Domain.Entities.Base;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections;
using Domain.ValueObjects.Inspections.InspectionsPropertyCoverages;

namespace Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionProperties
{
    public class InspectionPropertyCoverage : Entity
    {
        public int InspectionId { get; private set; }
        public int CoverageId { get; private set; }
        public Coverage Coverage { get; private set; }
        public decimal Value { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        public InspectionPropertyCoverage()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual Inspection? Inspection { get; private set; }

        public InspectionPropertyCoverage(
            int inspectionId,
            int coverageId,
            string coverage,
            decimal value
            )
        {
            InspectionId = inspectionId;
            CoverageId = coverageId;
            Coverage = Coverage.CreateValid(coverage, this.GetType().Name);
            Value = value;
        }

        public void SetCoverage(string coverage)
        {
            Coverage = Coverage.CreateValid(coverage, this.GetType().Name);
        }

        public void SetValue(decimal value)
        {
            Value = value;
        }
    }
}
