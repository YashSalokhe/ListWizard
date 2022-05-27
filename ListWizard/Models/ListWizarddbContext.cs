using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ListWizard.Models
{
    public class ListWizarddbContext: IdentityDbContext<User>
    {
        public ListWizarddbContext(DbContextOptions<ListWizarddbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
