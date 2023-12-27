using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities
{
    public partial class UserRole
    {
        [Key]
        public int Id { get; set; }
        [Column("UserID")]
        [StringLength(255)]
        [Unicode(false)]
        public string? UserId { get; set; }
        [Column("RoleID")]
        [StringLength(255)]
        [Unicode(false)]
        public string? RoleId { get; set; }

        [ForeignKey("RoleId")]
        [InverseProperty("UserRoles")]
        public virtual Role? Role { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("UserRoles")]
        public virtual User? User { get; set; }
    }
}
