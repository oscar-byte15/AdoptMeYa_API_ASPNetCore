using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GrupoWebBackend.DomainAdvertisements.Resources;
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
    public class AddRequestServiceTestsSteps:WebApplicationFactory<Startup>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private UserResource User { get; set; }
        private AdvertisementResource Advertisement { get; set; }
        private ConfiguredTaskAwaitable<HttpResponseMessage> Response
        {
            get;
            set;
        }
        public AddRequestServiceTestsSteps(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Given(@"the endpoint https://localhost:(.*)/api/v(.*)/Advertisements is available\.")]
        public void GivenTheEndpointHttpsLocalhostApiVAdvertisementsIsAvailable(int port, int version)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/v{version}/Advertisements");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions{BaseAddress = BaseUri});
        }

        [When(@"A Post Request of Advertisement is sent")]
        public void WhenAPostRequestOfAdvertisementIsSent(Table savePostResource)
        {
            var resource = savePostResource.CreateSet<SaveAdvertisementResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content).ConfigureAwait(false);
        }

        [Then(@"An Advertisement response with status (.*) is received")]
        public void ThenAnAdvertisementResponseWithStatusIsReceived(int expectedStatus)
        {
            HttpStatusCode statusCode = (HttpStatusCode) expectedStatus;
            Assert.AreEqual(statusCode.ToString(), Response.GetAwaiter().GetResult().StatusCode.ToString());
        }

        [Given(@"A User is already stored for Advertisement")]
        public async void GivenAUserIsAlreadyStoredForAdvertisement(Table saveUserResourceData)
        {
            var saveUserResource = saveUserResourceData.CreateSet<SaveAdvertisementResource>().First();
            var userUri = new Uri("https://localhost:5001/api/v1/Users");
            var content = new StringContent(saveUserResource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var userResponse = Client.PostAsync(userUri, content);
            var userResponseData = await userResponse.Result.Content.ReadAsStringAsync();
            var existingUser = JsonConvert.DeserializeObject<UserResource> (userResponseData);
            User = existingUser;
        }

        [Given(@"An advertisement is already stored")]
        public async void GivenAnAdvertisementIsAlreadyStored(Table existingAdvertisementResource)
        {
            var resource = existingAdvertisementResource.CreateSet<SaveAdvertisementResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var advertisementResponse = Client.PostAsync(BaseUri, content);
            var advertisementResponseData = await advertisementResponse.Result.Content.ReadAsStringAsync();
            var existingAdvertisement = JsonConvert.DeserializeObject<AdvertisementResource>(advertisementResponseData);
            Advertisement = existingAdvertisement;

        }
        [When(@"an a deleting request is sent")]
        public void WhenAnADeletingRequestIsSent()
        {
            Response = Client.DeleteAsync(BaseUri).ConfigureAwait(false);
        }
        [Given(@"the endpoint https://localhost:(.*)/api/v(.*)/Advertisements/(.*) is available\.")]
        public void GivenTheEndpointHttpsLocalhostApiVAdvertisementsIsAvailable(int port, int version, int id)
        {
           BaseUri = new Uri($"https://localhost:{port}/api/v{version}/publications/{id}");
           Client = _factory.CreateClient(new WebApplicationFactoryClientOptions{BaseAddress = BaseUri});
        }


        [When(@"An update Advertising request is sent")]
        public void WhenAnUpdateAdvertisingRequestIsSent(Table table)
        {
            var resource = table.CreateSet<SaveAdvertisementResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, "application/json");
            Response = Client.PutAsync(BaseUri, content).ConfigureAwait(false);
        }
    }
}