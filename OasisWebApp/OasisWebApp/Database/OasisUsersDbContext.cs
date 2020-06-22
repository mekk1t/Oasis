using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OasisWebApp.Database
{
    public class OasisUsersDbContext : IdentityDbContext
    {
        public OasisUsersDbContext(DbContextOptions<OasisUsersDbContext> options)
            :base (options)
        {

        }
    }
}
