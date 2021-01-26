using System.ComponentModel.DataAnnotations;

namespace RoyalEstate.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}