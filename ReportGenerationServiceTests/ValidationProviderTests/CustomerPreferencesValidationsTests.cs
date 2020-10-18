//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using ReportGenerationService.Enums;
//using ReportGenerationService.Models;
//using ReportGenerationService.ValidationProviders;
//using System.Text;
//using DayOfWeek = ReportGenerationService.Enums.DayOfWeek;

//namespace ReportGenerationServiceTests.ValidationProviderTests
//{
//    [TestClass]
//    public class CustomerPreferencesValidationsTests
//    {
//        [TestMethod]
//        [DataRow(0)]
//        [DataRow(29)]
//        [DataRow(35)]
//        public void Validate_If_SpecificMonthDay_Not_Between_1_28_Error(int dayOfMonth)
//        {
//            // Arrange
//            var form = new CustomerPreferencesForm
//            {
//                CustomerPreferences = new Customer[]
//                {
//                    new Customer
//                    {
//                        Customer = "A",
//                        SpecificDaysOfWeek = null,
//                        Type = DayPreferenceType.SpecificDayOfMonth,
//                        SpecificMonthDay = (byte)dayOfMonth
//                    }
//                }
//            };

//            var customerPreferencesValidations = new CustomerPreferencesValidations();

//            // Act
//            var res = customerPreferencesValidations.Validate(form);

//            // Assert
//            var content = UTF8Encoding.UTF8.GetString(res.Content);
//            Assert.IsNotNull(res);
//            Assert.AreEqual("{\"SpecificMonthDay\":{\"ErrorCode\":\"value_must_be_between_1_and_28\"}}", content);
//        }

//        [TestMethod]
//        public void Validate_If_SpecificMonthDay_Is_Null_When_DayPreferenceType_Is_SpecificDayOfMonth_Error()
//        {
//            // Arrange
//            var form = new CustomerPreferencesForm
//            {
//                CustomerPreferences = new Customer[]
//                {
//                    new Customer
//                    {
//                        Customer = "A",
//                        SpecificDaysOfWeek = null,
//                        Type = DayPreferenceType.SpecificDayOfMonth,
//                        SpecificMonthDay = null
//                    }
//                }
//            };

//            var customerPreferencesValidations = new CustomerPreferencesValidations();

//            // Act
//            var res = customerPreferencesValidations.Validate(form);

//            // Assert
//            var content = UTF8Encoding.UTF8.GetString(res.Content);
//            Assert.IsNotNull(res);
//            Assert.AreEqual("{\"form\":{\"ErrorCode\":\"specificDayOfMonth_must_be_specified\"}}", content);
//        }

//        [TestMethod]
//        public void Validate_If_SpecificDaysOfWeek_Is_Null_When_DayPreferenceType_Is_DaysOfWeek_Error()
//        {
//            // Arrange
//            var form = new CustomerPreferencesForm
//            {
//                CustomerPreferences = new Customer[]
//                {
//                    new Customer
//                    {
//                        Customer = "A",
//                        SpecificDaysOfWeek = null,
//                        Type = DayPreferenceType.DaysOfWeek,
//                        SpecificMonthDay = null
//                    }
//                }
//            };

//            var customerPreferencesValidations = new CustomerPreferencesValidations();

//            // Act
//            var res = customerPreferencesValidations.Validate(form);

//            // Assert
//            var content = UTF8Encoding.UTF8.GetString(res.Content);
//            Assert.IsNotNull(res);
//            Assert.AreEqual("{\"form\":{\"ErrorCode\":\"specificDaysOfWeek_must_be_specified\"}}", content);
//        }

//        [TestMethod]
//        public void Validate_Successful_Return_Null()
//        {
//            // Arrange
//            var form = new CustomerPreferencesForm
//            {
//                CustomerPreferences = new Customer[]
//                {
//                    new Customer
//                    {
//                        Customer = "A",
//                        Type = DayPreferenceType.Never,
//                        SpecificDaysOfWeek = null,
//                        SpecificMonthDay = null
//                    },
//                    new Customer
//                    {
//                        Customer = "B",
//                        Type = DayPreferenceType.EveryDay,
//                        SpecificDaysOfWeek = null,
//                        SpecificMonthDay = null
//                    },
//                    new Customer
//                    {
//                        Customer = "C",
//                        Type = DayPreferenceType.DaysOfWeek,
//                        SpecificDaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Friday },
//                        SpecificMonthDay = null
//                    },
//                    new Customer
//                    {
//                        Customer = "D",
//                        Type = DayPreferenceType.SpecificDayOfMonth,
//                        SpecificDaysOfWeek = null,
//                        SpecificMonthDay = (byte)25
//                    }
//                }
//            };

//            var customerPreferencesValidations = new CustomerPreferencesValidations();

//            // Act
//            var res = customerPreferencesValidations.Validate(form);

//            // Assert
//            Assert.IsNull(res);
//        }
//    }
//}
