using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanWebApi.WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Authorize]
    public abstract class BaseV1Controller : BaseController
    {
    }
}