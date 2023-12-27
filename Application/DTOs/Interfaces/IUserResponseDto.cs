using Application.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Interfaces
{
    public interface IUserResponseDTOBuilder
    {
        UserResponseDTOBuilder FailureWithData(string errorMessage);
        UserResponseDTO Success(string successMessage);
        UserResponseDTOBuilder Failure(string errorMessage);
        UserResponseDTOBuilder NewSuccess(string successMessage);

        UserResponseDTOBuilder SuccessWithData(string id, string name, string username, string email, string phone, string profile, bool accountStatus);
         UserResponseDTO Build(); // Return type is UserResponseDTO
    }

}
