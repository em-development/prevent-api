using Domain.Entities.Base;

namespace Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections
{
    public class InspectionSchedule : Entity
    {
        public DateTime Date { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        public InspectionSchedule()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual Inspection? Inspection { get; private set; }

        public InspectionSchedule(
            int id,
            DateTime date
            )
        {
            Id = id;
            Date = date;
        }

        public void SetDate(DateTime date)
        {
            Date = date;
        }

    }
}
