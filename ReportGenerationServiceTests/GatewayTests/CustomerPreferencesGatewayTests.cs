//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using ReportGenerationService.Enums;
//using ReportGenerationService.Gateways;
//using ReportGenerationService.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using DayOfWeek = ReportGenerationService.Enums.DayOfWeek;

//namespace ReportGenerationServiceTests.GatewayTests
//{
//    [TestClass]
//    public class CustomerPreferencesGatewayTests
//    {
//        [TestMethod]
//        public void GenerateCustomerMarketInfoReport_DayPreferenceType_Is_Never_Then_Check_Is_Not_Added()
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
//                    }
//                }
//            };

//            var gateway = new CustomerPreferencesGateway();

//            // Act
//            var res = gateway.GenerateCustomerMarketInfoReport(form);

//            // Assert
//            Assert.AreEqual(0, res.Where(r => r.Value.Contains("A")).Count());
//        }

//        [TestMethod]
//        public void GenerateCustomerMarketInfoReport_DayPreferenceType_Is_EveryDay_Then_Check_If_Added_Everyday()
//        {
//            // Arrange
//            var form = new CustomerPreferencesForm
//            {
//                CustomerPreferences = new Customer[]
//                {
//                    new Customer
//                    {
//                        Customer = "A",
//                        Type = DayPreferenceType.EveryDay,
//                        SpecificDaysOfWeek = null,
//                        SpecificMonthDay = null
//                    }
//                }
//            };

//            var gateway = new CustomerPreferencesGateway();

//            // Act
//            var res = gateway.GenerateCustomerMarketInfoReport(form);

//            // Assert
//            Assert.AreEqual(90, res.Where(r => r.Value.Contains("A")).Count());
//        }

//        [TestMethod]
//        public void GenerateCustomerMarketInfoReport_DayPreferenceType_Is_DaysOfWeek_Then_Check_If_Added_To_SpecificDaysOfWeek()
//        {
//            // Arrange
//            var customerPreferences = new Tuple<DateTime, List<string>>[90];

//            for (int i = 0; i < 90; i++)
//            {
//                customerPreferences[i] = Tuple.Create(DateTime.Now.AddDays(i), new List<string>());
//            }

//            var numberOfDaysToApplyTo = customerPreferences.Where(t => t.Item1.DayOfWeek == (System.DayOfWeek)DayOfWeek.Monday ||
//                                                                       t.Item1.DayOfWeek == (System.DayOfWeek)DayOfWeek.Wednesday ||
//                                                                       t.Item1.DayOfWeek == (System.DayOfWeek)DayOfWeek.Saturday)
//                                                                        .Count();

//            var form = new CustomerPreferencesForm
//            {
//                CustomerPreferences = new Customer[]
//                {
//                    new Customer
//                    {
//                        Customer = "A",
//                        Type = DayPreferenceType.DaysOfWeek,
//                        SpecificDaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Saturday },
//                        SpecificMonthDay = null
//                    }
//                }
//            };

//            var gateway = new CustomerPreferencesGateway();

//            // Act
//            var res = gateway.GenerateCustomerMarketInfoReport(form);

//            // Assert
//            Assert.AreEqual(numberOfDaysToApplyTo, res.Where(r => r.Value.Contains("A")).Count());
//        }

//        [TestMethod]
//        public void GenerateCustomerMarketInfoReport_DayPreferenceType_Is_SpecificDayOfMonth_Then_Check_If_Added_To_SpecificMonthDay()
//        {
//            // Arrange
//            var specificMonthsDay = 25;
//            var customerPreferences = new Tuple<DateTime, List<string>>[90];
//            for (int i = 0; i < 90; i++)
//            {
//                customerPreferences[i] = Tuple.Create(DateTime.Now.AddDays(i), new List<string>());
//            }

//            var numberOfDaysToApplyTo = customerPreferences.Where(t => t.Item1.Day == specificMonthsDay).Count();

//            var form = new CustomerPreferencesForm
//            {
//                CustomerPreferences = new Customer[]
//                {
//                    new Customer
//                    {
//                        Customer = "A",
//                        Type = DayPreferenceType.SpecificDayOfMonth,
//                        SpecificDaysOfWeek = null,
//                        SpecificMonthDay = (byte)specificMonthsDay
//                    }
//                }
//            };

//            var gateway = new CustomerPreferencesGateway();

//            // Act
//            var res = gateway.GenerateCustomerMarketInfoReport(form);

//            // Assert
//            Assert.AreEqual(numberOfDaysToApplyTo, res.Where(r => r.Value.Contains("A")).Count());
//        }

//        [TestMethod]
//        public void GenerateCustomerMarketInfoReport_DayPreferenceType_Is_All_Then_Check_If_Added()
//        {
//            // Arrange
//            var specificMonthsDay = 11;
//            var customerPreferences = new Tuple<DateTime, List<string>>[90];
//            for (int i = 0; i < 90; i++)
//            {
//                customerPreferences[i] = Tuple.Create(DateTime.Now.AddDays(i), new List<string>());
//            }

//            var numberOfMonthlyDaysAppliedTo = customerPreferences.Where(t => t.Item1.Day == specificMonthsDay).Count();

//            var numberOfWeeklyDaysAppliedTo = customerPreferences.Where(t => t.Item1.DayOfWeek == (System.DayOfWeek)DayOfWeek.Sunday ||
//                                                                       t.Item1.DayOfWeek == (System.DayOfWeek)DayOfWeek.Tuesday ||
//                                                                       t.Item1.DayOfWeek == (System.DayOfWeek)DayOfWeek.Friday)
//                                                                        .Count();

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
//                        SpecificDaysOfWeek = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Tuesday, DayOfWeek.Friday },
//                        SpecificMonthDay = null
//                    },
//                    new Customer
//                    {
//                        Customer = "D",
//                        Type = DayPreferenceType.SpecificDayOfMonth,
//                        SpecificDaysOfWeek = null,
//                        SpecificMonthDay = (byte)specificMonthsDay
//                    }
//                }
//            };

//            var gateway = new CustomerPreferencesGateway();

//            // Act
//            var res = gateway.GenerateCustomerMarketInfoReport(form);

//            // Assert
//            Assert.AreEqual(0, res.Where(r => r.Value.Contains("A")).Count());
//            Assert.AreEqual(90, res.Where(r => r.Value.Contains("B")).Count());
//            Assert.AreEqual(numberOfWeeklyDaysAppliedTo, res.Where(r => r.Value.Contains("C")).Count());
//            Assert.AreEqual(numberOfMonthlyDaysAppliedTo, res.Where(r => r.Value.Contains("D")).Count());
//        }
//    }
//}
