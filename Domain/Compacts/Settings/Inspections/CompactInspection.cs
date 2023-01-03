using Domain.Entities.Base;

namespace Domain.Compacts.Settings.Inspections
{
    public class CompactInspection : Entity
    {
        public int TemplateVersionId { get; set; }
        public string Description { get; private set; }
        public string Address { get; set; } = string.Empty;
        public string LegalEntity { get; private set; }
        public string CodeEntity { get; set; } = string.Empty;
        public string PropertyType { get; private set; }
        public int InspectionStatus { get; private set; }
        public decimal FillStatus { get; private set; }
        public int UserId { get; private set; }
        public string UserName { get; private set; }

        #region EF Constructor

#pragma warning disable CS8618
        private CompactInspection()
        {
        }
#pragma warning restore CS8618

        #endregion EF Constructor
    }
}