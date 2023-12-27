using Application.DTOs;
using Application.DTOs.Interfaces;
using Application.DTOs.UserDTOs;
using Application.Interfaces.IDtoServeices;
using Application.Interfaces.IServices;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DtoServices.UserServices
{
    public class UserDtoService : IUserDto
    {
        private readonly IRepository<User> _repository;
        private readonly IUserConverter _converter;
        private readonly IUniqueIdentifier _uniqueId;
        private readonly IPasswordService _passwordService;
        private readonly IUserResponseDTOBuilder _userResponseDTOBuilder;


        public UserDtoService(IRepository<User> repository, IUserConverter converter, IPasswordService passwordService, IUserResponseDTOBuilder userResponseDTOBuilder)
        {
            this._repository = repository;
            this._converter = converter;
            this._passwordService = passwordService;
            this._userResponseDTOBuilder = userResponseDTOBuilder;
        }
        public async Task<UserResponseDTO> AddAsync(UserDTO entity)
        {
            try
            { //if(ModelState.IsValid)
                if(entity != null)
                {
                    if(entity.Password== entity.ConfirmPassword)
                    {
                        var salt =await  _passwordService.GenerateSaltAsync();
                        var hashedPassword =  await _passwordService.HashPasswordAsync(entity.Password, salt);
                        entity.Password = hashedPassword;
                        entity.Salt= salt;
                        entity.Id= await _uniqueId.GenerateUniqueId();
                        var user=_converter.ConverToEntityUser(entity);
                        var result=await _repository.AddAsync(user);
                        if(result != null)
                        {
                            var userResponse = _converter.ConverToResponseDto(result);
                            return userResponse;
                        }
                        else
                        {
                            var failureDTO = _userResponseDTOBuilder.Failure("Failed to add user. repo failed.").Build();
                            return failureDTO;
                        }

                    }
                    else
                    {

                        var failureDTO = _userResponseDTOBuilder.FailureWithData("Password Is not Identical").Build();
                        return failureDTO;
                    }
                  
                    
                   
                }
                else
                {
                    var failureDTO = _userResponseDTOBuilder.Failure("Failed to add user. Validation failed.").Build() ;
                    return failureDTO;

                }

            }
            catch (Exception ex)
            {
                var failureDTO = _userResponseDTOBuilder.Failure("Exception: "+ex.Message).Build();
                return failureDTO;

            }
        }

        public Task<UserResponseDTO> UpdateAsync(UserDTO entity)
        {
            throw new NotImplementedException();
        }

       
        public async Task<UserResponseDTO> GetByIdAsync(string id)
        {
            try
            {
                if(id == null)
                {
                    var failureDTO = _userResponseDTOBuilder.Failure("Wrong Data: user id is wrong or missed").Build();
                    return failureDTO;
                }
                else
                {
                    var user=await _repository.GetByIdAsync(id);
                    if(user != null)
                    {

                        var userResponse =  _converter.ConverToResponseDto(user);
                        return userResponse;

                    }
                    else
                    {
                        var failureDTO = _userResponseDTOBuilder.Failure("Repo: Failed To get user  ").Build();
                        return failureDTO;
                    }
                }

            }catch (Exception ex)
            {
                var failureDTO = _userResponseDTOBuilder.Failure("Exception: " + ex.Message).Build();
                return failureDTO;
            }
        }

        public async Task<IEnumerable<UserResponseDTO>> GetAllAsync()
        {
            try
            {
               
                    var users = await _repository.GetAllAsync();
                    if (users != null)
                    {
                         List<UserResponseDTO> userResponse = new List<UserResponseDTO>();
                        foreach (var user in users)
                            {
                                userResponse.Add(_converter.ConverToResponseDto(user));
                            }
                        
                        return userResponse;

                    }
                    else
                    {
                        var failureDTO = _userResponseDTOBuilder.Failure("Repo: Failed To get user  ").Build();
                        return  (IEnumerable<UserResponseDTO>)failureDTO;
                     }
                

            }
            catch (Exception ex)
            {
                var failureDTO = _userResponseDTOBuilder.Failure("Exception: " + ex.Message).Build();
                return (IEnumerable<UserResponseDTO>)failureDTO;
            }
        }


        public async Task<UserResponseDTO> DeleteAsync(string id)
        {

            try
            {
                if (id == null)
                {
                    var failureDTO = _userResponseDTOBuilder.Failure("Wrong Data: user id is wrong or missed").Build();
                    return failureDTO;
                }
                else
                {
                    bool isDeleted = await _repository.DeleteAsync(id);
                    if (isDeleted)
                    {

                        var userResponse = _userResponseDTOBuilder.Success("Deleted Successfully!");
                        return userResponse;

                    }
                    else
                    {
                        var failureDTO = _userResponseDTOBuilder.Failure("Repo: Failed To get user  ").Build();
                        return failureDTO;
                    }
                }

            }
            catch (Exception ex)
            {
                var failureDTO = _userResponseDTOBuilder.Failure("Exception: " + ex.Message).Build();
                return failureDTO;
            }
        }


    }
}
