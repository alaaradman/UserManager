using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities
{
    public partial class UserGroup
    {
        [Key]
        public int Id { get; set; }
        [Column("UserID")]
        [StringLength(255)]
        [Unicode(false)]
        public string? UserId { get; set; }
        [Column("GroupID")]
        [StringLength(255)]
        [Unicode(false)]
        public string? GroupId { get; set; }

        [ForeignKey("GroupId")]
        [InverseProperty("UserGroups")]
        public virtual Group? Group { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("UserGroups")]
        public virtual User? User { get; set; }
    }
}
