using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PermissionDTO : GenericDTO
    {
        public override string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string? Description { get ; set; }
        public string Resource { get; set; } = null!;
    }
}
