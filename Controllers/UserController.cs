using aspnet_core_web_api_sample.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_core_web_api_sample.Controllers
{
    /// <summary>
    /// 유저 관리 API
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [Produces("application/json", "application/xml")]
    public class UserController : ControllerBase
    {
        readonly ILogger<UserController> _logger;

        public UserController(IConfiguration configuration, ILogger<UserController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 유저 추가
        /// </summary>
        /// <param name="user">유저 정보</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(
            [FromBody] User user)
        {
            _logger.LogTrace("create");
            _logger.LogDebug("create");
            _logger.LogInformation("create");
            _logger.LogWarning("create");
            _logger.LogError("create");
            _logger.LogCritical("create");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Created(Url.RouteUrl(1), new UserResponse 
            { 
                Success = true,
                User = user
            });
        }

        /// <summary>
        /// 유저 조회
        /// </summary>
        /// <param name="userId">유저 아이디</param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAsync(
            string userId)
        {
            if (userId.Trim() == "hong")
            {
                return Ok(new UserResponse() { 
                    Success = true,
                    User = new User()
                    {
                        Id = "hong",
                        Name = "홍길동",
                        Age = 30,
                        BirthDay = new DateOnly(1977, 10, 31),
                        Bio = "안녕하세요"
                    }
                });
            }
            else
            {
                return BadRequest(new UserResponse()
                {
                    Success = false,
                    Message = "해당 아이디가 존재하지 않습니다."
                });
            }
        }

        /// <summary>
        /// 유저 정보 수정
        /// </summary>
        /// <param name="user">수정 할 유저 정보</param>
        /// <returns></returns>
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateAsync(
            string userId,
            [FromBody] User user)
        {
            return Ok(new UserResponse() { 
                Success = true,
                Message = "성공적으로 수정 되었습니다.",
                User = user
            });
        }

        /// <summary>
        /// 유저 탈퇴
        /// </summary>
        /// <param name="userId">유저 아이디</param>
        /// <returns></returns>
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteAsync(
            string userId)
        {
            return NoContent();
        }
    }
}
