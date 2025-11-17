using FiapCloud.Users.App.Common;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloud.Users.Api.Controllers;

public abstract class BaseController : ControllerBase
{
    protected IActionResult FromResult<T>(Result<T> result)
    {
        if (result.Success)
            return Ok(result.Data);

        return BadRequest(result);
    }
}