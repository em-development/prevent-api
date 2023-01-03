using Domain.Entities.Base;
using Domain.Enums.Inspections.Inspections;
using Domain.ValueObjects.General;

namespace Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections
{
    public class InspectionStatus : Entity
    {
        public EnumDescription Description { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private InspectionStatus()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual IEnumerable<Inspection>? Inspections { get; private set; }

        public InspectionStatus(InspectionStatusEnum groupEnum)
        {
            Id = (int)groupEnum;
            Description = EnumDescription.CreateValid(typeof(InspectionStatusEnum), groupEnum, GetType().Name.ToLower());
        }

    }
}