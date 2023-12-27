using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities
{
    public partial class RolePermission
    {
        [Key]
        public int Id { get; set; }
        [Column("RoleID")]
        [StringLength(255)]
        [Unicode(false)]
        public string? RoleId { get; set; }
        [Column("PermissionID")]
        [StringLength(255)]
        [Unicode(false)]
        public string? PermissionId { get; set; }

        [ForeignKey("PermissionId")]
        [InverseProperty("RolePermissions")]
        public virtual Permission? Permission { get; set; }
        [ForeignKey("RoleId")]
        [InverseProperty("RolePermissions")]
        public virtual Role? Role { get; set; }
    }
}
