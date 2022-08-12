using System.Text.Json.Serialization;

namespace aspnet_core_web_api_sample.Models
{
    /// <summary>
    /// 유저 응답
    /// </summary>
    public class UserResponse
    {
        /// <summary>
        /// 성공 실패 유무
        /// </summary>
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        /// <summary>
        /// 에러 메시지
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// 유저 정보
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("user")]
        public User User { get; set; }
    }
}
