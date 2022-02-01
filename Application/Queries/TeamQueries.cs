using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using MediatR;

namespace Application.Queries
{
    public class TeamQueries
    {
        public class TeamQuery : IRequest<List<Team>>
        {

        }
    }
}