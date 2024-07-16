using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Data;
using OrderManagementSystem.Models;
using OrderManagementSystem.Repositories;
using OrderManagementSystem.Services;
using Xunit;

public class UserServiceTests
{
    private readonly UserService _userService;
    private readonly OrderManagementDbContext _context;

    public UserServiceTests()
    {
        var options = new DbContextOptionsBuilder<OrderManagementDbContext>()
            .UseInMemoryDatabase(databaseName: "OrderManagementDbTest")
            .Options;
        _context = new OrderManagementDbContext(options);
        var userRepository = new UserRepository(_context);
        _userService = new UserService(userRepository);
    }

    [Fact]
    public async Task RegisterUser_ShouldCreateUser()
    {
        var user = new User
        {
            Username = "testuser",
            PasswordHash = "password"
        };

        var createdUser = await _userService.RegisterUserAsync(user);

        Assert.NotNull(createdUser);
        Assert.Equal(user.Username, createdUser.Username);
    }

    [Fact]
    public async Task AuthenticateUser_ShouldReturnUser()
    {
        var user = new User
        {
            Username = "testuser",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("password")
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        var authenticatedUser = await _userService.AuthenticateUserAsync(user.Username, "password");

        Assert.NotNull(authenticatedUser);
        Assert.Equal(user.Username, authenticatedUser.Username);
    }
}
