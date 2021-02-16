using Abp.Application.Services.Dto;

namespace RoyalEstate.Estates.Dto
{
    public class PagedEstateTypeResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool IsActive { get; set; }
    }
}
