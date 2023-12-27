using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities
{
    public partial class Permission: GenericProperties
    {
        public Permission()
        {
            RolePermissions = new HashSet<RolePermission>();
        }

        [Key]
        [StringLength(255)]
        [Unicode(false)]
       // public string Id { get; set; } = null!;
        public override string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [StringLength(255)]
        [Unicode(false)]
       // public string Name { get; set; } = null!;
        public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [Column(TypeName = "text")]
        public string? Description { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string Resource { get; set; } = null!;

        [InverseProperty("Permission")]
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
