using System.Text.Json;
using Asp.Versioning;
using aspnet_core_web_api_sample.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace aspnet_core_web_api_sample.Controllers
{
    /// <summary>
    /// 유저 관리 API
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        const string X_TRACE_ID = "x-trace-id";

        readonly ILogger<UserController> _logger;
        JsonSerializerOptions _jsonSerializerOptions;

        public UserController(IConfiguration configuration, ILogger<UserController> logger, IOptions<JsonOptions> options)
        {
            _logger = logger;
            _jsonSerializerOptions = options.Value.JsonSerializerOptions;
        }

        /// <summary>
        /// 유저 추가
        /// </summary>
        /// <param name="traceId">x-trace-id</param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(
            [FromHeader(Name=X_TRACE_ID)] string? traceId,
            [FromBody] User user)
        {
            _logger.LogTrace($"create");

            try
            {
                if (!ModelState.IsValid) //모델에 맞지 않게 파라메터가 넘어왔을 시
                {
                    _logger.LogWarning($"create"); 

                    return BadRequest(ModelState);
                }

                return Created(Url.RouteUrl(1), new UserResponse
                {
                    Success = true,
                    JoinDate = DateTime.Now,
                    User = user
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"create");

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// 유저 조회
        /// </summary>
        /// <param name="traceId">x-trace-id</param>
        /// <param name="userId">유저 아이디</param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAsync(
            [FromHeader(Name = X_TRACE_ID)] string? traceId,
            string userId)
        {
            _logger.LogDebug($"param={Request.GetDisplayUrl()}");

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
        /// <param name="traceId">x-trace-id</param>
        /// <param name="user">수정 할 유저 정보</param>
        /// <returns></returns>
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateAsync(
            [FromHeader(Name = X_TRACE_ID)] string? traceId,
            string userId,
            [FromBody] User user)
        {
            _logger.LogDebug($"param={Request.GetDisplayUrl()}");

            return Ok(new UserResponse() { 
                Success = true,
                Message = "성공적으로 수정 되었습니다.",
                User = user
            });
        }

        /// <summary>
        /// 유저 탈퇴
        /// </summary>
        /// <param name="traceId">x-trace-id</param>
        /// <param name="userId">유저 아이디</param>
        /// <returns></returns>
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteAsync(
            [FromHeader(Name = X_TRACE_ID)] string? traceId,
            string userId)
        {
            _logger.LogDebug($"param={Request.GetDisplayUrl()}");

            try
            {
                throw new Exception("aaaaa");
            }
            catch(Exception ex)
            {   
                _logger.LogError($"ex={ex.Message}");
            }

            return NoContent();
        }
    }
}
