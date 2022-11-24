using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using GrupoWebBackend.DomainPublications.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace GrupoWebBackend.Tests
{
    [Binding]
    public class PublicationServiceTestSteps:WebApplicationFactory<Startup>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;
        private Uri _baseUri;

        private ConfiguredTaskAwaitable<HttpResponseMessage> Response
        {
            get;
            set;
        }
        public PublicationServiceTestSteps(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Given(@"the endpoint https://localhost:(.*)/api/v(.*)/publications is available")]
        public void GivenTheEndpointHttpsLocalhostApiVPublicationsIsAvailable(int port, int version)
        {
            _baseUri = new Uri($"https://localhost:{port}/api/v{version}/publications");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions{BaseAddress = _baseUri});
        }

        [Given(@"A User is already stored")]
        public void GivenAUserIsAlreadyStored(Table table)
        {
            ScenarioContext.StepIsPending();
        }

        [When(@"A publication is sent")]
        public void WhenAPublicationIsSent(Table savePostResource)
        {
            var resource = savePostResource.CreateSet<SavePublicationResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, "application/json");
            Response = _client.PostAsync(_baseUri, content).ConfigureAwait(false);
        }

        [Then(@"a response with status (.*) is received")]
        public void ThenAResponseWithStatusIsReceived(int expectedStatus)
        {
            HttpStatusCode statusCode = (HttpStatusCode) expectedStatus;
            Assert.AreEqual(statusCode.ToString(), Response.GetAwaiter().GetResult().StatusCode.ToString());

        }


        [Given(@"the endpoint https://localhost:(.*)/api/v(.*)/publications/(.*) is available")]
        public void GivenTheEndpointHttpsLocalhostApiVPublicationsIsAvailable(int port, int version, int id)
        {
            _baseUri = new Uri($"https://localhost:{port}/api/v{version}/publications/{id}");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions{BaseAddress = _baseUri});
        }

        [When(@"An update  publication is sent")]
        public void WhenAnUpdatePublicationIsSent(Table updatePostResource)
        {
            var resource = updatePostResource.CreateSet<SavePublicationResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, "application/json");
            Response = _client.PutAsync(_baseUri, content).ConfigureAwait(false);
        }

        [When(@"An a delete request is sent")]
        public void WhenAnADeleteRequestIsSent()
        {
            Response = _client.DeleteAsync(_baseUri).ConfigureAwait(false);
        }

        [Given(@"the endpoint https://localhost:(.*)/api/v(.*)/publications/(.*) is not available")]
        public void GivenTheEndpointHttpsLocalhostApiVPublicationsIsNotAvailable(int port, int version, int id)
        {
            _baseUri = new Uri($"https://localhost:{port}/api/v{version}/publications/{id}");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions{BaseAddress = _baseUri});
        }
        

        [When(@"A get publications by user request is sent")]
        public void WhenAGetPublicationsByUserRequestIsSent()
        {
            Response = _client.GetAsync(_baseUri).ConfigureAwait(false);
        }

        [Given(@"the endpoint https://localhost:(.*)/api/v(.*)/Users/(.*)/publications is available now")]
        public void GivenTheEndpointHttpsLocalhostApiVUsersPublicationsIsAvailableNow(int port, int version, int id)
        {
            _baseUri = new Uri($"https://localhost:{port}/api/v{version}/Users/{id}/publications");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions{BaseAddress = _baseUri});
        }
    }
}