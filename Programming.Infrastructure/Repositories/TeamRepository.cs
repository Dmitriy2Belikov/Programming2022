using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programming.Core;
using Programming.Core.Domain.Team;
using Programming.Core.Interfaces;
using Programming.Core.Interfaces.Repositories;

namespace Programming.Infrastructure.Repositories
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
