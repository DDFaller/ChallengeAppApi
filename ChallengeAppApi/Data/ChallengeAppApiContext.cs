using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChallengeAppApi.Models;
using System.Drawing.Text;

namespace ChallengeAppApi.Data
{
    public class ChallengeAppApiContext : DbContext
    {
        public ChallengeAppApiContext (DbContextOptions<ChallengeAppApiContext> options)
            : base(options)
        {
        }

        public DbSet<ChallengeAppApi.Models.ChallengeEntity> Challenges { get; set; } = default!;
    }
}
