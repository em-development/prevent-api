using Domain.Entities.Base;
using Domain.Entities.Settings.LegalEntityCore.LegalEntityContacts;

namespace Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections
{
    public class InspectionResponsable : Entity
    {
        public int InspectionId { get; private set; }
        public int LegalEntityContactId { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        public InspectionResponsable()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual Inspection? Inspection { get; private set; }
        public virtual LegalEntityContact? LegalEntityContact { get; private set; }

        public InspectionResponsable(
            int inspectionId,
            int legalEntityContactId
            )
        {
            InspectionId = inspectionId;
            LegalEntityContactId = legalEntityContactId;
        }

    }
}
