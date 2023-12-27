using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities
{
    [Index("Username", Name = "UQ__Users__536C85E4215E9BCF", IsUnique = true)]
    public partial class User: GenericProperties
    {
        public User()
        {
            UserGroups = new HashSet<UserGroup>();
            UserRoles = new HashSet<UserRole>();
        }

        [Key]
        [StringLength(255)]
        [Unicode(false)]
        //public string Id { get; set; } = null!;
        public override string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [StringLength(255)]
        [Unicode(false)]
        public string Username { get; set; } = null!;
        [StringLength(255)]
        [Unicode(false)]
        public string PasswordHash { get; set; } = null!;
        [StringLength(255)]
        [Unicode(false)]
        public string Salt { get; set; } = null!;
        public string Profile { get; set; } = null!;
        [StringLength(255)]
        [Unicode(false)]
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        [StringLength(255)]
        [Unicode(false)]
       // public string Name { get; set; } = null!;
        public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [Column(TypeName = "datetime")]
        public DateTime? LastLoginTimestamp { get; set; }
        public bool AccountStatus { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<UserGroup> UserGroups { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
