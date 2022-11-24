using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GrupoWebBackend.DomainPets.Resources;
using GrupoWebBackend.Security.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace GrupoWebBackend.Tests
{
    [Binding]
    public class PetServiceSteps: WebApplicationFactory<Startup>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;
        private Uri _baseUri;
        private PetResource Pet { get; set; }
        private UserResource User { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }
        public PetServiceSteps(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Given(@"The Endpoint https://localhost:(.*)/api/v(.*)/Pets is available")]
        public void GivenTheEndpointHttpsLocalhostApiVPetsIsAvailable(int port, int version)
        {
            _baseUri = new Uri($"https://localhost:{port}/api/v{version}/Pets");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions{BaseAddress = _baseUri});
        }

        [Given(@"A user is already stored")]
        public async void GivenAUserIsAlreadyStored(Table saveUserResourceData)
        {
            var saveUserResource = saveUserResourceData.CreateSet<SavePetResource>().First();
            var userUri = new Uri("https://localhost:5001/api/v1/Users");
            var content = new StringContent(saveUserResource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var userResponse = _client.PostAsync(userUri, content);
            var userResponseData = await userResponse.Result.Content.ReadAsStringAsync();
            var existingUser = JsonConvert.DeserializeObject<UserResource> (userResponseData);
            User = existingUser;
        }

        [When(@"A Post Request is sent")]
        public void WhenAPostRequestIsSent(Table savePetResource)
        {
            var resource = savePetResource.CreateSet<SavePetResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = _client.PostAsync(_baseUri, content);
        }

        [Then(@"A Response With Status (.*) is received")]
        public void ThenAResponseWithStatusIsReceived(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatuCode = Response.Result.StatusCode.ToString();
            Assert.AreEqual(expectedStatusCode, actualStatuCode);
        }
    }
}