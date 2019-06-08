using System.ComponentModel.DataAnnotations;

namespace EToken.API.Model
{
    public class TokenVerficationModel
    {
        [Required]
        [StringLength(8, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        public string Token { get; set; }
    }
}
