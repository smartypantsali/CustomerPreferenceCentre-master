// using Framework.Common.Enums;
// using Framework.Common.Interfaces;
// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using Moq;
// using ReportGenerationService.Api.v1.Models;
// using System.Collections.Generic;

// namespace ReportGenerationServiceTests.ControllerTests
// {
//    [TestClass]
//    public class CustomerPreferencesControllerTests
//    {
//        [TestMethod]
//        public void GetAllCustomerPreferencesReport_ValidationError_418()
//        {
//            // Arrange
//            var form = new CustomersForm
//            {
//                Customers = new Customer[]
//                {
//                    new Customer
//                    {
//                        Name = "A",
//                        CustomerPreference = new CustomerPreference
//                        {
//                            SpecificDaysOfWeek = null,
//                            Type = DayPreferenceType.SpecificDayOfMonth,
//                            SpecificMonthDay = null
//                        }
//                    }
//                }
//            };

//            var mocks = new MockRepository(MockBehavior.Strict);

//            var preferencesValidationMock = mocks.Create<IReport<CustomerPreferenceReport, Customer>>();
//            preferencesValidationMock.Setup(m => m.Validate(It.IsAny<CustomerPreferencesForm>()))
//                .Returns(HttpResponses.TeapotResult(ApiOffences.SpecificDayOfMonthMustHaveValue, "SpecificMonthDay"));

//            var controller = new CustomerController(null, preferencesValidationMock.Object);

//            // Act
//            var res = controller.GetCustomerMarketInfoReport(form);

//            // Assert
//            mocks.Verify();
//            Assert.AreEqual(418, ((HttpResponses)res.Result).StatusCode);
//        }

//        [TestMethod]
//        public void GetCustomerMarketInfoReport_Success()
//        {
//            // Arrange
//            var form = new CustomerPreferencesForm
//            {
//                CustomerPreferences = new Customer[]
//                {
//                    new Customer
//                    {
//                        Customer = "A",
//                        SpecificDaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday },
//                        Type = DayPreferenceType.DaysOfWeek,
//                        SpecificMonthDay = null
//                    }
//                }
//            };

//            var mocks = new MockRepository(MockBehavior.Strict);

//            var preferencesValidationMock = mocks.Create<IValidate<CustomerPreferencesForm>>();
//            preferencesValidationMock.Setup(m => m.Validate(It.IsAny<CustomerPreferencesForm>()))
//                .Returns((HttpResponses)null);

//            var customerPreferencesGwMock = mocks.Create<ICustomerPreferencesGateway>();
//            customerPreferencesGwMock.Setup(m => m.GenerateCustomerMarketInfoReport(It.IsAny<CustomerPreferencesForm>()))
//                .Returns(new Dictionary<string, string[]>());

//            var controller = new CustomerController(customerPreferencesGwMock.Object, preferencesValidationMock.Object);

//            // Act
//            var res = controller.GetCustomerMarketInfoReport(form);

//            // Assert
//            mocks.Verify();
//            Assert.IsNull(res.Result);
//        }
//    }
// }
