using BackEnd.PrevisaoSync.Application.Dtos.User;
using BackEnd.PrevisaoSync.Application.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.PrevisaoSync.API.Controllers.User;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet("GetUser/{id}/userId/{userId}")]
    public IActionResult GetUser(int id, int userId)
    {
        try
        {
            var user = _userService.GetUserAsync(userId).Result;
            if (!user.Success)
                return NotFound("Não foi localizado o usuário!");
            if (!user.Success)
                return BadRequest(user.Message);

            return Ok(user.Data);
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Erro ao buscar os dados do usuário: {e.Message}");
        }
    }

    [HttpPost("CreateUser")]
    public IActionResult CreateUser(UserDto userDto)
    {
        try
        {
            var userCreated = _userService.CreateUserAsync(userDto).Result;

            if (!userCreated.Success)
                return BadRequest(userCreated.Message);

            return Ok(userCreated.Data);
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Erro ao criar o usuário: {e.Message}");
        }
    }

    [HttpDelete("RemoveUser/{userId}")]
    public IActionResult RemoveUser(int userId)
    {
        try
        {
            var userRemoved = _userService.DeleteUserAsync(userId).Result;
            if (!userRemoved.Success)
                return BadRequest(userRemoved.Message);
            return Ok($"Usuário removido com sucesso!");
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Erro ao deletar o usuário: {e.Message}");
        }
    }

    [HttpPatch("UpdateUser/{userId}")]
    public IActionResult UpdateUser(UserDto userDto, int userId)
    {
        try
        {
            var userUpdated = _userService.UpdateUserAsync(userId, userDto).Result;
            if (!userUpdated.Success)
                return BadRequest(userUpdated.Message);
            return Ok(userUpdated.Data);
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Erro ao atualizar o usuário: {e.Message}");
        }
    }
}