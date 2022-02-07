using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class SearchDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JoinedName => FirstName + "" + LastName;
    }
}