using Examples.Charge.Domain.Aggregates.PersonAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Application.Dtos
{
    public class PersonDto
    {
        public string Name { get; set; }
        public int BusinessEntityID { get; set; }

        public ICollection<PersonPhone> Phones { get; set; }
    }
}
