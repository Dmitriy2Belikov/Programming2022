using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programming.Core;
using Programming.Core.Domain.Developer;
using Programming.Core.Interfaces;
using Programming.Core.Interfaces.Repositories;

namespace Programming.Infrastructure.Repositories
{
    public class DeveloperRepository : Repository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
