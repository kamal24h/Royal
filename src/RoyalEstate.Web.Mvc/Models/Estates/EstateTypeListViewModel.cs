using System.Collections.Generic;
using RoyalEstate.Estates.Dto;

namespace RoyalEstate.Web.Models.Estates
{
    public class EstateTypeListViewModel
    {
        public IReadOnlyList<EstateTypeDto> EstateTypes { get; set; }
    }
}
