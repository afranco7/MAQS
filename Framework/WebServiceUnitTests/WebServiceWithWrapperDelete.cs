﻿//--------------------------------------------------
// <copyright file="WebServiceWithDriverDelete.cs" company="Magenic">
//  Copyright 2018 Magenic, All rights Reserved
// </copyright>
// <summary>Web service delete unit tests</summary>
//--------------------------------------------------
using Magenic.Maqs.BaseWebServiceTest;
using Magenic.Maqs.Utilities.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using WebServiceTesterUnitTesting.Model;

namespace WebServiceTesterUnitTesting
{
    /// <summary>
    /// Test web service gets using the base test driver
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WebServiceWithDriverDelete : BaseWebServiceTest
    {
        /// <summary>
        /// Delete Json request to assert status code
        /// </summary>
        [TestMethod]
        [TestCategory(TestCategories.WebService)]
        public void DeleteJSONSerializedVerifyStatusCode()
        {
            var result = this.WebServiceDriver.DeleteWithResponse("/api/XML_JSON/Delete/1", "application/json", true);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        /// <summary>
        /// Delete Json request to assert status code
        /// </summary>
        [TestMethod]
        [TestCategory(TestCategories.WebService)]
        public void DeleteJSONSerializedVerifyStatusCodeWithAndWithoutHeaderOverride()
        {
            var result = this.WebServiceDriver.DeleteWithResponse("/api/XML_JSON/Delete/2", "application/json", false);
            Assert.AreEqual(HttpStatusCode.Conflict, result.StatusCode);

            this.WebServiceDriver.HttpClient.DefaultRequestHeaders.Add("pass", "word");
            result = this.WebServiceDriver.DeleteWithResponse("/api/XML_JSON/Delete/2", "application/json", true);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        /// <summary>
        /// Delete with JSON type
        /// </summary>
        #region DeleteWithType
        [TestMethod]
        [TestCategory(TestCategories.WebService)]
        public void DeleteJSONWithType()
        {
            var result = this.WebServiceDriver.Delete<ProductJson>("/api/XML_JSON/Delete/1", "application/json", true);
            Assert.AreEqual(result, null);
        }
        #endregion

        /// <summary>
        /// Delete XML request using status code
        /// </summary>
        [TestMethod]
        [TestCategory(TestCategories.WebService)]
        public void DeleteXMLSerializedVerifyStatusCode()
        {
            var result = this.WebServiceDriver.DeleteWithResponse("/api/XML_JSON/Delete/1", "application/xml", true);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        /// <summary>
        /// Verify that the response does not return a message
        /// </summary>
        #region DeleteWithXML
        [TestMethod]
        [TestCategory(TestCategories.WebService)]
        public void DeleteXMLSerializedVerifyEmptyString()
        {
            var result = this.WebServiceDriver.Delete("/api/XML_JSON/Delete/1", "application/xml", true);
            Assert.AreEqual(string.Empty, result);
        }
        #endregion

        /// <summary>
        /// Delete string request without content utility
        /// </summary>
        [TestMethod]
        [TestCategory(TestCategories.WebService)]
        public void DeleteStringWithoutMakeContent()
        {
            var result = this.WebServiceDriver.Delete("/api/String/Delete/1", "text/plain", true);
            Assert.AreEqual(string.Empty, result);
        }

        /// <summary>
        /// Delete string request with content utility
        /// </summary>
        [TestMethod]
        [TestCategory(TestCategories.WebService)]
        public void DeleteStringWithMakeContent()
        {
            var result = this.WebServiceDriver.Delete("/api/String/Delete/1", "text/plain", true);
            Assert.AreEqual(string.Empty, result);
        }

        /// <summary>
        /// Delete string request to verify status code
        /// </summary>
        #region DeleteWithStringResponse
        [TestMethod]
        [TestCategory(TestCategories.WebService)]
        public void DeleteStringMakeContentStatusCode()
        {
            var result = this.WebServiceDriver.DeleteWithResponse("/api/String/Delete/1", "text/plain", true);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
        #endregion

        /// <summary>
        /// Delete request to vi
        /// </summary>
        [TestMethod]
        [TestCategory(TestCategories.WebService)]
        public void DeleteExpectContentError()
        {
            var result = this.WebServiceDriver.DeleteWithResponse("/api/String/Delete/43", "text/plain", false);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }

        /// <summary>
        /// Delete error 
        /// </summary>
        [TestMethod]
        [TestCategory(TestCategories.WebService)]
        public void DeleteExpectError()
        {
            var result = this.WebServiceDriver.Delete("/api/String/Delete/43", "text/plain", false);
            Assert.AreEqual("{\"Message\":\"Resource was not found\"}", result);
        }
    }
}