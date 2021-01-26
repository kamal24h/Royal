using System.Threading.Tasks;
using RoyalEstate.Models.TokenAuth;
using RoyalEstate.Web.Controllers;
using Shouldly;
using Xunit;

namespace RoyalEstate.Web.Tests.Controllers
{
    public class HomeController_Tests: RoyalEstateWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}