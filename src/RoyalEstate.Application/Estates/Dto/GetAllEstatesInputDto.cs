using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace RoyalEstate.Estates.Dto
{
    public class GetAllEstatesInputDto : IPagedAndSortedResultRequest
    {
        public long? IdServiceType { get; set; }
        public long? IdEstateType { get; set; }
        public int MaxResultCount { get; set; }
        public int SkipCount { get; set; }
        public string Sorting { get; set; }
    }
}
