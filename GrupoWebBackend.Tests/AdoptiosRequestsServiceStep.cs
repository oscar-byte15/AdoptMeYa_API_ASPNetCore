using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using GrupoWebBackend.DomainAdoptionsRequests.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using GrupoWebBackend.Security.Resources;
using Newtonsoft.Json;

namespace GrupoWebBackend.Tests
{
    [Binding]
    public class AdoptiosRequestsServiceStep:WebApplicationFactory<Startup>
    {
        private readonly WebApplicationFactory<Startup>_factory;
        private HttpClient _client;
        private Uri _baseUri;
        private AdoptionsRequestsResource AdoptionsRequests { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }
        private UserResource User { get; set; }

        public AdoptiosRequestsServiceStep(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        [Given(@"The Endpoint https://localhost:(.*)/api/v(.*)/AdoptionsRequests is available")]
        public void GivenTheEndpointHttpsLocalhostApiVAdoptionsRequestsIsAvailable(int port, int version)
        {
            _baseUri = new Uri($"https://localhost:{port}/api/v{version}/AdoptionsRequests");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions{BaseAddress = _baseUri});
        }
        
    
        [When(@"A adoption request is sent")]
        public void WhenAAdoptionRequestIsSent(Table saveAdoptionsRequests)
        {
            var resource = saveAdoptionsRequests.CreateSet<SaveAdoptionsRequestsResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = _client.PostAsync(_baseUri, content);
        }
        [Then(@"A Response with Status (.*) is received")]
        public void ThenAResponseWithStatusIsReceived(int expectedStatus)
        {  
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatuCode = Response.Result.StatusCode.ToString();
            Assert.AreEqual(expectedStatusCode, actualStatuCode);
        }


        [Given(@"A User is already stored for AdoptionsRequests")]
        public async void GivenAUserIsAlreadyStoredForAdoptionsRequests(Table saveUserResourceData)
        {
            var saveUserResource = saveUserResourceData.CreateSet<SaveAdoptionsRequestsResource>().First();
            var userUri = new Uri("https://localhost:5001/api/v1/Users");
            var content = new StringContent(saveUserResource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var userResponse = _client.PostAsync(userUri, content);
            var userResponseData = await userResponse.Result.Content.ReadAsStringAsync();
            var existingUser = JsonConvert.DeserializeObject<UserResource> (userResponseData);
            User = existingUser;
        }

        [Then(@"AAdoptionRequests With Status (.*) is received")]
        public void ThenAAdoptionRequestsWithStatusIsReceived(int  expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatuCode = Response.Result.StatusCode.ToString();
            Assert.AreEqual(expectedStatusCode, actualStatuCode);
        }

        [When(@"A post adoption request is sent")]
        public void WhenAPostAdoptionRequestIsSent(Table saveAdoptionsRequestsResource)
        {
            var resource = saveAdoptionsRequestsResource.CreateSet<SaveAdoptionsRequestsResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = _client.PostAsync(_baseUri, content);
        }

        [When(@"An a delete request of adoptions requests is sent")]
        public void WhenAnADeleteRequestOfAdoptionsRequestsIsSent(Table table)
        {
                 }

        [Given(@"the endpoint https://localhost:(.*)/api/v(.*)/AdoptionsRequests/(.*) is available")]
        public void GivenTheEndpointHttpsLocalhostApiVAdoptionsRequestsIsAvailable(int port, int version, int id)
        {
            _baseUri = new Uri($"https://localhost:{port}/api/v{version}/AdoptionsRequests/{id}");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions{BaseAddress = _baseUri});
        }

        [When(@"An update  adoption request is sent")]
        public void WhenAnUpdateAdoptionRequestIsSent(Table table)
        {
            var resource = table.CreateSet<SaveAdoptionsRequestsResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, "application/json");
            Response = _client.PutAsync(_baseUri, content);
        }
    }
}