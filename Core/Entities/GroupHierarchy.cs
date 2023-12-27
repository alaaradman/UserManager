using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities
{
    [Table("GroupHierarchy")]
    public partial class GroupHierarchy
    {
        [Key]
        public int Id { get; set; }
        [Column("ParentGroupID")]
        [StringLength(255)]
        [Unicode(false)]
        public string? ParentGroupId { get; set; }
        [Column("ChildGroupID")]
        [StringLength(255)]
        [Unicode(false)]
        public string? ChildGroupId { get; set; }

        [ForeignKey("ChildGroupId")]
        [InverseProperty("GroupHierarchyChildGroups")]
        public virtual Group? ChildGroup { get; set; }
        [ForeignKey("ParentGroupId")]
        [InverseProperty("GroupHierarchyParentGroups")]
        public virtual Group? ParentGroup { get; set; }
    }
}
