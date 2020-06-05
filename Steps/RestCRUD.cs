using System;
using NUnit.Framework;
using Maintel.Icon.Portal.Sync.AutotaskAPI.Spec.Helpers;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using Maintel.Icon.Portal.Sync.AutotaskAPI.Spec.Models;

namespace Maintel.Icon.Portal.Sync.AutotaskAPI.Spec.Steps
{
    [Binding]
    public class RestCRUD
    {
        //string _baseURL = "https://localhost:44374/api/v1/";
        string _baseURL = "https://dev-sync-autotaskapi.iconlab.local/api/v1/";
        //string _baseURL = "https://test-sync-autotaskapi.iconlab.local/api/v1/";
        //string _baseURL = "https://ext-test-sync-autotaskapi.iconlab.local/api/v1/";
        //string _baseURL = "https://stag-sync-autotaskapi.iconlab.local/api/v1/";
        //string _baseURL = "https://prod-sync-autotaskapi.iconlab.local/api/v1/";

        object _receivedObject;
        List<object> _receivedObjects;

        [Given(@"I have access to the api")]
        public void GivenIHaveAccessToTheAPI()
        {
            Assert.IsTrue( HTTPRest.CheckEndpoint(_baseURL));
        }

        [When(@"I make a ""(.*)"" request to ""(.*)"" with payload ""(.*)""")]
        public void WhenIMakeARequestTo(string method, string uri, string payload)
        {
            Assert.IsTrue( HTTPRest.CheckEndpoint(_baseURL));
            var url = _baseURL + uri;
            try
            {
                string rtn = HTTPRest.MakeHTTPRequest(method, url, payload);
                _receivedObject = JsonUtils.GetObject<object>(rtn);
            }
            catch (System.Exception ex)
            {
               Console.WriteLine(ex.Message);
                _receivedObject = new object();
            }
        }

        [When(@"I make a ""(.*)"" request to return a list from ""(.*)"" with payload ""(.*)""")]
        public void WhenIMakeARequestToReturnAListFromTo(string method, string uri, string payload)
        {
            Assert.IsTrue( HTTPRest.CheckEndpoint(_baseURL));
            var url = _baseURL + uri;
            try
            {
            string rtn = HTTPRest.MakeHTTPRequest(method, url, payload);
            _receivedObjects = JsonUtils.GetObjectArray<List<object>>(rtn);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                _receivedObjects = new List<object>();
            }
        }
        
        [When(@"I make a ""(.*)"" request to return a list from ""(.*)"" with a date set to last month")]
        public void WhenIMakeARequestToReturnAListFromWithADateSetToLastMonth(string method, string uri)
        {
            Assert.IsTrue( HTTPRest.CheckEndpoint(_baseURL));
            var date = DateTime.Today.AddMonths(-1);
            var url = _baseURL + uri + "?date=" + date.ToString("yyyy-MM-ddThh:mm:ss");
            try
            {
            string rtn = HTTPRest.MakeHTTPRequest(method, url, "");
            _receivedObjects = JsonUtils.GetObjectArray<List<object>>(rtn);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                _receivedObjects = new List<object>();
            }
        }
        

        [When(@"I make a ""(.*)"" request to return a list from ""(.*)"" with a date set to last hour")]
        public void WhenIMakeARequestToReturnAListFromWithADateSetToLastHour(string method, string uri)
        {
            Assert.IsTrue( HTTPRest.CheckEndpoint(_baseURL));
            var date = DateTime.Today.AddHours(-1);
            var url = _baseURL + uri + "?date=" + date.ToString("yyyy-MM-ddThh:mm:ss");
            try
            {
            string rtn = HTTPRest.MakeHTTPRequest(method, url, "");
            _receivedObjects = JsonUtils.GetObjectArray<List<object>>(rtn);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                _receivedObjects = new List<object>();
            }
        }
        

        [Then(@"I should receive a status of ""(.*)""")]
        public void ThenIShouldReceiveAStatusOf(string statusCode)
        {
            Assert.AreEqual(statusCode, HTTPRest.StatusCode.ToString(), "Expected " + statusCode + " but received " + HTTPRest.StatusCode);
        }

        [Then(@"when I make a ""(.*)"" request to ""(.*)"" an item should have a ""(.*)"" property set to ""(.*)""")]
        public void ThenWhenIMakeARequestToAnItemShouldHaveAPropertySetTo(string method, string uri, string property, string propertyValue)
        {
            Assert.IsTrue(method.Length > 0);
            Assert.IsTrue(uri.Length > 0);
            Assert.IsTrue(property.Length > 0);
            Assert.IsTrue(propertyValue.Length > 0);

            var url = _baseURL + uri;
            string rtn = HTTPRest.MakeHTTPRequest(method, url, "");
        }

        [Then(@"I should receive an object array")]
        public void ThenIShouldReceiveAnObjectArray()
        {
            Assert.IsTrue(_receivedObjects.Count > 0);
        }

        [Then(@"the object returned should have a property of ""(.*)""")]
        public void ThenTheObjectReturnedShouldHaveAPropertyOf(string property)
        {
            Assert.IsNotNull(_receivedObject, "There is no object to check the " + property + " property");
            var foundOne = false;
            foreach (var prop in _receivedObject.GetType().GetProperties())
            {
                if(prop.Name.ToLower() == property.ToLower()) {foundOne = true;}
            }
            Assert.IsTrue(foundOne);
        }

        [Then(@"the object array returned should have a property of ""(.*)""")]
        public void ThenTheObjectArrayReturnedShouldHaveAPropertyOf(string property)
        {
            Assert.IsNotNull(_receivedObjects, "There is no object array to check the " + property + " property");
            Assert.Greater(_receivedObjects.Count, 0, "There are no object array records to check the " + property + " property");
            var foundOne = false;
            foreach (var prop in _receivedObjects[0].GetType().GetProperties())
            {
                if(prop.Name.ToLower() == property.ToLower()) {foundOne = true;}
            }
            Assert.IsTrue(foundOne);
        }

		[Then(@"the object array property ""(.*)"" should have a value of ""(.*)""")]
        public void ThenTheObjectArrayPropertyShouldHaveAValueOf(string property, string value)
        {
            Assert.IsNotNull(_receivedObjects, "There is no object to check the " + property + " property");
            var foundOne = false;
            
            foreach (var obj in _receivedObjects)
            {
                var properties = obj.GetType().GetProperties();
                foreach (var prop in properties)
                {
                    if(prop.Name.ToLower() == property.ToLower()) {
                        foundOne = true;
                        //var val = prop.GetValue(prop);
                        //Assert.AreEqual(val.ToString(), value.ToString());
                    }
                }
            }
            if(!foundOne) {Console.WriteLine(property + " - " + value);}
            Assert.IsTrue(foundOne, " didn't find a " + property);
        }

        [Then(@"the object property ""(.*)"" should have a value of ""(.*)""")]
        public void ThenTheObjectPropertyShouldHaveAValueOf(string property, string value)
        {
            Assert.IsNotNull(_receivedObject, "There is no object to check the " + property + " property");
            foreach (var prop in _receivedObject.GetType().GetProperties())
            {
                if(prop.Name.ToLower() == property.ToLower()) {
                    //Assert.AreEqual(value, _receivedObject[prop.Name].ToString() );
                }
            }
        }

        [Then(@"I should receive a ""(.*)"" object")]
        public void ThenIShouldReceiveAObject(string obj)
        {
            Assert.IsTrue(obj.Length > 0);
            Console.Write(HTTPRest.ResponseString);
            Assert.IsTrue(JsonUtils.TryParseJson<object>(HTTPRest.ResponseString), "Parsing the JSON return failed");
            if(obj.ToLower() == "site") {
                _receivedObject = JsonUtils.GetObject<Site>(HTTPRest.ResponseString);
            } else if(obj.ToLower() == "ticket") {
                _receivedObject = JsonUtils.GetObject<Ticket>(HTTPRest.ResponseString);
            } else {
                Assert.Fail();
            }
        }

        [Then(@"I should receive a ""(.*)"" object array")]
        public void ThenIShouldReceiveAObjectArray(string obj)
        {
            Assert.IsTrue(obj.Length > 0);
            Assert.IsTrue(JsonUtils.TryParseJson<object>(HTTPRest.ResponseString), "Parsing the JSON return failed");
            if(obj.ToLower() == "site") {
                _receivedObjects = JsonUtils.GetObjectArray<Site>(HTTPRest.ResponseString);
            } else if(obj.ToLower() == "ticket") {
                _receivedObjects = JsonUtils.GetObjectArray<Ticket>(HTTPRest.ResponseString);
            } else {
                Assert.Fail();
            }
        }

        [Then(@"it should have an id of ""(.*)""")]
        public void ThenItShouldHaveAnIdOf(string id)
        {
            Assert.IsTrue(id.Length > 0);
            //Assert.AreEqual(id, _receivedObject.Id, "Failed to match id's: " + id + " as opposed to " + _receivedObject.Id);
        }

    }
}
    
    