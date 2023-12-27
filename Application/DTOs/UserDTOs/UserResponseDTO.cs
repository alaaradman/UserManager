using Application.DTOs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserDTOs
{

    public class UserResponseDTO : GenericDTO
    {

        //success
        public override string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Username { get ; set ; } = null!;
        public string Email { get ; set ; } = null!;
        public string Phone { get ; set ; } = null!;
        public string profile { get ; set ; } = null!;
        public bool AccountStatus { get ; set ; }
        public string Message { get ; set ; } = null!;
        public bool IsSuccess { get ; set ; }
       
    }
}
