using Domain.Entities.Base;
using Domain.ValueObjects.General;
using Domain.ValueObjects.Settings.Countries;

namespace Domain.Entities.Settings.Countries
{
    public sealed class Country : Entity
    {
        public Description Description { get; private set; }
        public Lang Lang { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private Country() { }
#pragma warning restore CS8618
        #endregion EF Constructor

        public Country(string description, string lang)
        {
            Description = Description.CreateValid(description, GetType().Name.ToLower());
            Lang = Lang.CreateValid(lang, GetType().Name.ToLower());
        }

        public Country(int id, string description, string lang)
        {
            Id = id;
            Description = Description.CreateValid(description, GetType().Name.ToLower());
            Lang = Lang.CreateValid(lang, GetType().Name.ToLower());
        }
    }
}
