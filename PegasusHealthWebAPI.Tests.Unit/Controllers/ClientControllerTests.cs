using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Moq;
using PegasusHealthWebAPI.Controllers;
using PegasusHealthWebAPI.Models;
using PegasusHealthWebAPI.Strategies.RequestStrategy;
using TestUtilities;
using Xunit;

namespace PegasusHealthWebAPI.Tests.Unit.Controllers {
    public class ClientControllerTests {
        public class GetSupplyRequests {
        }

        public class GetAcknowledgedSupplyRequests {
            
        }

        public class GetSupplyRequest {
            
        }

        public class PostSupplyRequest {
            [Theory]
            [AutoMoqData]
            public async Task ReturnsBadRequestWhenSupplyRequestDTONull(
                [Frozen] IFixture fixture,
                [Frozen] IRequestStrategy requestStrategy) {
                Mock.Get<IRequestStrategy>(requestStrategy)
                    .Setup(rs => rs.CreateRequest(It.IsAny<IEnumerable<SupplyRequest>>()));

                var sut = fixture.Create<ClientController>();
                var result = await sut.PostSupplyRequest(null);
                
                Mock.Get(requestStrategy).Verify(rs => rs.CreateRequest(It.IsAny<IEnumerable<SupplyRequest>>()), Times.Once);
            }
        }
    }
}