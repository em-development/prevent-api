using Domain.Entities.Base;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections;
using Domain.ValueObjects.Settings.Inspections;

namespace Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionProperties
{
    public class InspectionPropertyBuilding : Entity
    {
        public int InspectionId { get; private set; }
        public decimal Measures { get; private set; }
        public InspectionPropertyBuildingDescription Description { get; private set; }
        public BuildingPattern BuildingPattern { get; private set; }
        public decimal BuildingPatternRate { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        public InspectionPropertyBuilding()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual Inspection? Inspection { get; private set; }

        public InspectionPropertyBuilding(
            int inspectionId,
            decimal measures,
            string description,
            string buildingPattern,
            decimal buildingPatternRate
            )
        {
            InspectionId = inspectionId;
            Measures = measures;
            Description = InspectionPropertyBuildingDescription.CreateValid(description, this.GetType().Name);
            BuildingPattern = BuildingPattern.CreateValid(buildingPattern, this.GetType().Name);
            BuildingPatternRate = buildingPatternRate;
        }

    }
}
