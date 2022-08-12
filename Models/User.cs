using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace aspnet_core_web_api_sample.Models
{
    /// <summary>
    /// 유저 정보
    /// </summary>
    public class User
    {
        /// <summary>
        /// 유저 아이디
        /// </summary>
        [Required(ErrorMessage = "id 필수 값 누락")]
        [MinLength(2, ErrorMessage = "id 최소 2자")]
        [MaxLength(10, ErrorMessage = "id 최대 10자")]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// 유저 이름
        /// </summary>
        [Required(ErrorMessage = "name 필수 값 누락")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// 유저 나이
        /// </summary>
        [Required(ErrorMessage = "age 필수 값 누락")]
        [Range(1,100, ErrorMessage = "age는 1~100세 사이만 입력됩니다")]
        [JsonPropertyName("age")]
        public int Age { get; set; }

        /// <summary>
        /// 유저 생일 (yyyy-MM-dd)
        /// </summary>
        [Required(ErrorMessage = "birthday 필수 값 누락 (yyyy-MM-dd)")]
        [JsonPropertyName("birthDay")]
        public DateOnly BirthDay { get; set; }

        /// <summary>
        /// 유저 소개
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [MinLength(2, ErrorMessage = "bio 최소 10자")]
        [MaxLength(10, ErrorMessage = "bio 최대 100자")]
        [JsonPropertyName("bio")]
        public string? Bio { get; set; }
    }
}
