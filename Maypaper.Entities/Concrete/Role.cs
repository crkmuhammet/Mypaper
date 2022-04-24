using System;
using System.Collections.Generic;
using Maypaper.Shared.Entities.Abstract;

namespace Maypaper.Entities.Concrete
{
    public class Role : EntityBase, IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
