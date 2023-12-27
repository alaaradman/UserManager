using Application.DTOs;
using Application.DTOs.Interfaces;
using Application.DTOs.UserDTOs;
using Application.Interfaces.IDtoServeices;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DtoServices.UserServices
{
    public class UserConverterService : IUserConverter
    {

        private readonly IUserResponseDTOBuilder _userResponseDTOBuilder;
        public UserConverterService(IUserResponseDTOBuilder userResponseDTOBuilder)
        {
            this._userResponseDTOBuilder = userResponseDTOBuilder;  
        }
        public User ConverToEntityUser(UserDTO userDto)
        {
            var user = new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Email = userDto.Email,
                Username = userDto.Username,
                Phone = userDto.Phone,
                Salt = userDto.Salt,
                PasswordHash = userDto.Password,
                AccountStatus = userDto.AccountStatus,
                Profile = userDto.profile,
            };
            return user;

           
        }

        public UserResponseDTO ConverToResponseDto(User user)
        {
            if (user != null)
            {
                var successDTO = _userResponseDTOBuilder.NewSuccess("User added successfully")
                          .WithId(user.Id)
                          .WithName(user.Name)
                          .WithUsername(user.Username)
                          .WithEmail(user.Email)
                          .WithAccountStatus(user.AccountStatus)
                         .Build();
                return successDTO;
            }
            else { return null; }
        }
    }
}
