using Application.DTOs;
using Application.DTOs.Interfaces;
using Application.DTOs.UserDTOs;
using Application.DtoServices.UserServices;
using Application.Interfaces.IDtoServeices;
using Application.Interfaces.IServices;
using Core.Entities;
using Core.Interfaces;
using Moq;

public class UserDtoServiceTests
{
    private readonly   Mock<IRepository<User>> userRepositoryMock;
    private readonly   Mock<IUserConverter> userConverterMock;
    private readonly  Mock<IPasswordService> passwordServiceMock;
    private readonly  Mock<IUserResponseDTOBuilder> userResponseDtoBuilderMock;
    private readonly  Mock<UserResponseDTOBuilder> userResponse;

    public UserDtoServiceTests()
    {
        userRepositoryMock = new Mock<IRepository<User>>();
        userConverterMock = new Mock<IUserConverter>();
        passwordServiceMock = new Mock<IPasswordService>();
        userResponseDtoBuilderMock = new Mock<IUserResponseDTOBuilder>();
        userResponse= new Mock<UserResponseDTOBuilder>();
    }

    [Theory]
    [InlineData("hashedpass", "salt")]
    public async Task AddAsync_ValidUser_ReturnsSuccessResponse(string hashedPassword, string salt)
    {
        // Arrange
        

        var userDtoService = new UserDtoService(userRepositoryMock.Object, userConverterMock.Object, passwordServiceMock.Object, userResponseDtoBuilderMock.Object);

        var userDto = new UserDTO
        {
            // Set valid user data
        };

     

        userRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<User>()))
            .ReturnsAsync(new User { /* Set user entity properties */ });

        passwordServiceMock.Setup(service => service.GenerateSaltAsync())
            .ReturnsAsync(salt);

        passwordServiceMock.Setup(service => service.HashPasswordAsync(It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(hashedPassword);

        userConverterMock.Setup(converter => converter.ConverToEntityUser(It.IsAny<UserDTO>()))
            .Returns(new User { /* Set user entity properties */ });

        userConverterMock.Setup(converter => converter.ConverToResponseDto(It.IsAny<User>()))
            .Returns(new UserResponseDTO { /* Set user response DTO properties */ });

        // Act
        var result = await userDtoService.AddAsync(userDto);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<UserResponseDTO>(result);
        // Add more assertions based on your requirements
    }

    [Theory]
    [InlineData("validUserId")]
    
    public async Task GetByIdAsync_ValidId_ReturnsUserResponseTrue(string userId)
    {
        // Arrange
        

        var userDtoService = new UserDtoService(userRepositoryMock.Object, userConverterMock.Object, passwordServiceMock.Object, userResponseDtoBuilderMock.Object);

       

        userRepositoryMock.Setup(repo => repo.GetByIdAsync(userId))
            .ReturnsAsync(new User { /* Set user entity properties */ });

        userConverterMock.Setup(converter => converter.ConverToResponseDto(It.IsAny<User>()))
            .Returns(new UserResponseDTO { /* Set user response DTO properties */ });

        // Act
        var result = await userDtoService.GetByIdAsync(userId);

        // Assert
        Assert.NotNull(result);
       
        Assert.IsType<UserResponseDTO>(result);
        // Add more assertions based on your requirements
    }
    
    [Theory]
   
    [InlineData(null)]
    public async Task GetByIdAsync_ValidId_ReturnsUserResponseNull(string userId)
    {
        // Arrange
        

        var userDtoService = new UserDtoService(userRepositoryMock.Object, userConverterMock.Object, passwordServiceMock.Object, userResponseDtoBuilderMock.Object);

       

        userRepositoryMock.Setup(repo => repo.GetByIdAsync(userId))
            .ReturnsAsync(new User { /* Set user entity properties */ });

        userConverterMock.Setup(converter => converter.ConverToResponseDto(It.IsAny<User>()))
            .Returns(new UserResponseDTO { /* Set user response DTO properties */ });

        // Act
        var result = await userDtoService.GetByIdAsync(userId);

        // Assert
       
       
        Assert.IsType<UserResponseDTO>(result);
        // Add more assertions based on your requirements
    }

    [Fact]
    public async Task GetAllAsync_ReturnsListOfUserResponses()
    {
        // Arrange
        

        var userDtoService = new UserDtoService(userRepositoryMock.Object, userConverterMock.Object, passwordServiceMock.Object, userResponseDtoBuilderMock.Object);

        var users = new List<User> { /* Create a list of user entities */ };

        userRepositoryMock.Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(users);

        userConverterMock.Setup(converter => converter.ConverToResponseDto(It.IsAny<User>()))
            .Returns(new UserResponseDTO { /* Set user response DTO properties */ });

        // Act
        var result = await userDtoService.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<UserResponseDTO>>(result);
        // Add more assertions based on your requirements
    }

    [Theory]
    [InlineData("validUserId", true)]
    public async Task DeleteAsync_ValidId_ReturnsSuccessResponse(string userId, bool isSuccess)
    {
        // Arrange


        var userDtoService = new UserDtoService(userRepositoryMock.Object, userConverterMock.Object, passwordServiceMock.Object, userResponseDtoBuilderMock.Object);

      

        userRepositoryMock.Setup(repo => repo.DeleteAsync(userId))
            .ReturnsAsync(isSuccess);

        userResponseDtoBuilderMock.Setup(builder => builder.Success(It.IsAny<string>()))
     .Returns(new UserResponseDTO());

        // Act
        var result = await userDtoService.DeleteAsync(userId);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<UserResponseDTO>(result);
        // Add more assertions based on your requirements
    }

    // Add more test methods for other scenarios, and update the mocks and assertions accordingly
}
