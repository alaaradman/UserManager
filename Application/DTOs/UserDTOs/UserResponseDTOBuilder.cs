using Application.DTOs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserDTOs
{
   public class UserResponseDTOBuilder: IUserResponseDTOBuilder
    {
    private readonly UserResponseDTO _userResponseDTO;

        //constructor
    private UserResponseDTOBuilder(bool isSuccess, string defaultMessage)
    {
        _userResponseDTO = new UserResponseDTO
        {
            IsSuccess = isSuccess,
            Message = isSuccess ? defaultMessage : null
        };
    }
        
    public UserResponseDTO Success(string successMessage = "Add Successfully")
    {
            _userResponseDTO.Message = successMessage;
        return Build();
    }

    public  UserResponseDTOBuilder Failure(string errorMessage="Fail")
    {
        return new UserResponseDTOBuilder(false, errorMessage);
    }
        public  UserResponseDTOBuilder NewSuccess(string Message="Sauccess")
    {
        return new UserResponseDTOBuilder(true, Message);
    }

    public  UserResponseDTOBuilder SuccessWithData(string id, string name, string username, string email, string phone, string profile, bool accountStatus)
    {
        return Failure()
            .WithId(id)
            .WithName(name)
            .WithUsername(username)
            .WithEmail(email)
            .WithPhone(phone)
            .WithProfile(profile)
            .WithAccountStatus(accountStatus);
    }

    public  UserResponseDTOBuilder FailureWithData(string errorMessage)
    {
        return Failure(errorMessage);
    }

    public UserResponseDTOBuilder WithId(string id)
    {
        _userResponseDTO.Id = id;
        return this;
    }

    public UserResponseDTOBuilder WithName(string name)
    {
        _userResponseDTO.Name = name;
        return this;
    }

    public UserResponseDTOBuilder WithUsername(string username)
    {
        _userResponseDTO.Username = username;
        return this;
    }

    public UserResponseDTOBuilder WithEmail(string email)
    {
        _userResponseDTO.Email = email;
        return this;
    }

    public UserResponseDTOBuilder WithPhone(string phone)
    {
        _userResponseDTO.Phone = phone;
        return this;
    }

    public UserResponseDTOBuilder WithProfile(string profile)
    {
        _userResponseDTO.profile = profile;
        return this;
    }

    public UserResponseDTOBuilder WithAccountStatus(bool accountStatus)
    {
        _userResponseDTO.AccountStatus = accountStatus;
        return this;
    }

    public UserResponseDTOBuilder WithMessage(string message)
    {
        _userResponseDTO.Message = message;
        return this;
    }

    public UserResponseDTO Build()
    {
        return _userResponseDTO;
    }
}
}
