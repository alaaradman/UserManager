using Application.DTOs;
using Application.DTOs.UserDTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IDtoServeices
{
    public interface IUserDto: IGenericDTO<UserResponseDTO, UserDTO>
    {
      
    }
}
