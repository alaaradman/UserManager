using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities
{
    public partial class Group: GenericProperties
    {
        public Group()
        {
            GroupHierarchyChildGroups = new HashSet<GroupHierarchy>();
            GroupHierarchyParentGroups = new HashSet<GroupHierarchy>();
            UserGroups = new HashSet<UserGroup>();
        }

        [Key]
        [StringLength(255)]
        [Unicode(false)]
        //public string Id { get; set; } = null!;
        public override string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [StringLength(255)]
        [Unicode(false)]
       // public string Name { get; set; } = null!;
        public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [Column(TypeName = "text")]
        public string? Description { get; set; }

        [InverseProperty("ChildGroup")]
        public virtual ICollection<GroupHierarchy> GroupHierarchyChildGroups { get; set; }
        [InverseProperty("ParentGroup")]
        public virtual ICollection<GroupHierarchy> GroupHierarchyParentGroups { get; set; }
        [InverseProperty("Group")]
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
}
