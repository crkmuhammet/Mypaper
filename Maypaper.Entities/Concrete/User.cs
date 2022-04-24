using System;
using System.Collections.Generic;
using Maypaper.Shared.Entities.Abstract;

namespace Maypaper.Entities.Concrete
{
    public class User : EntityBase, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }

        // Bir kullanıcı yalnızca 1 Role Sahip olabilir.
        public int RoleId { get; set; }
        public Role Role { get; set; }

        // Bir kullanıcı birden fazla döküman ekleyebilir.
        public ICollection<Article> Articles { get; set; }
        // Bir kullanıcı birden fazla soru ekleyebilir.
        public ICollection<Question> Questions { get; set; }
    }
}
