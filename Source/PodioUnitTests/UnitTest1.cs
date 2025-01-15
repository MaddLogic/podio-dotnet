using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Threading.Tasks;
using PodioAPI;

namespace PodioUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private string _clientSecret = "<clientsecret>";
        private string _clientId = "<clientid>"; 
        private string _password = "<podio_user_pw>";
        private string _podioUsername = "<podio_user_name>";

        [TestMethod]
        public async Task AuthenticateWithPassword()
        {
            try
            {
                var clientSecret = _clientSecret;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                Podio podio = new Podio(_clientId, clientSecret);
                var x=   await podio.AuthenticateWithPassword(_podioUsername, _password);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail();
            }

        }

        [TestMethod]
        public async Task AuthenticateWithApp()
        {
            try
            {
                var clientSecret = _clientSecret;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                Podio podio = new Podio(_clientId, clientSecret);
                var x=   await podio.AuthenticateWithApp(_clientId, clientSecret);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail();
            }

        }

        [TestMethod]
        public async Task GetOrganizations()
        {
            try
            {
                var clientSecret = _clientSecret;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                Podio podio = new Podio(_clientId, clientSecret);
                var x=   await podio.AuthenticateWithPassword(_podioUsername, _password);

                var orgs = await podio.OrganizationService.GetOrganizations();

                Assert.IsTrue(orgs.Count > 0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail();
            }

        }

        [TestMethod]
        public async Task GetItems()
        {
            try
            {
                var clientSecret = _clientSecret;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                Podio podio = new Podio(_clientId, clientSecret);
                var x = await podio.AuthenticateWithApp("17957133", "a3c8964c8e064a3fa2a708704589a949");

                var items = await podio.ItemService.FilterItemsByView(17957133, 34525146, 500);

                Assert.IsTrue(items.Total > 0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail();
            }

        }
    }
}
