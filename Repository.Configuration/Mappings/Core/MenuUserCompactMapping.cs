using Domain.Compacts.Settings.Core.Menus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Mappings.Core
{
    public class MenuUserCompactMapping : IEntityTypeConfiguration<MenuUserCompact>
    {
        public void Configure(EntityTypeBuilder<MenuUserCompact> builder)
        {
            builder.HasNoKey();

            builder.HasOne(x => x.Menu)
                .WithMany()
                .HasForeignKey("Id");

            builder.ToView("vw_MenusUser", "core");
        }
    }
}