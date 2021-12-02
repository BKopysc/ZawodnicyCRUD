using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ZawodnicyCRUD;

namespace ZawodnicyCRUDTest
{
    
    [TestClass]
    public class SkiJumperServiceTest : TestBase
    {

        [TestInitialize]
        public void TestInitialize()
        {
            SkiJumpersDB = new MockedSkiJumpers();
            SkiJumper_1_Poland = SkiJumpersDB.GetSkiJumper(1, "Poland");
            SkiJumper_10_Poland = SkiJumpersDB.GetSkiJumper(10, "Poland");
            SkiJumper_1_Germany = SkiJumpersDB.GetSkiJumper(1, "Germany");
            SkiJumper_5_Germany = SkiJumpersDB.GetSkiJumper(5, "Germany");
        }

        [TestMethod]
        [Description("Check for adding new ski jumper")]
        [Owner("Bartlomiej")]
        [Priority(4)]
        [TestCategory("Adding")]
        public void ShouldCreateNewSkiJumper()
        {
            SkiJumperService = new SkiJumperService();
            string fromCall;

            fromCall = SkiJumperService.Create(SkiJumper_1_Poland);
            SkiJumper readed = SkiJumperService.Read(1);

            TestContext.WriteLine("Create properly new ski jumper: id:1, Poland");

            Assert.AreEqual(SkiJumper_1_Poland, readed);
        }

        [TestMethod]
        [Description("Check for AddingException")]
        [Owner("Bartlomiej")]
        [Priority(3)]
        [TestCategory("AddingException")]
        public void ShouldNotCreateSkiJumperWithSameId()
        {
            SkiJumperService = new SkiJumperService();
            string fromCall;

            SkiJumperService.Create(SkiJumper_1_Germany);
            fromCall = SkiJumperService.Create(SkiJumper_1_Poland);

            TestContext.WriteLine("Trying to add existed ski jumper with id:1");
            Assert.AreEqual("IdExists", fromCall);
        }

        [TestMethod]
        [Description("Check for thrown ArgumentNullException")]
        [Owner("Bartlomiej")]
        [Priority(2)]
        [TestCategory("Exception")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldNotAddNullSkiJumper()
        {
            SkiJumperService = new SkiJumperService();

            SkiJumper ski = null;
            TestContext.WriteLine("Trying to add null skijumper");
            SkiJumperService.Create(ski);
        }

        [TestMethod]
        [Description("Check for thrown ArgumentOutOfRangeException")]
        [Owner("Bartlomiej")]
        [Priority(2)]
        [TestCategory("Exception")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldNotReadNotExistedSkiJumper()
        {
            SkiJumperService = new SkiJumperService();

            TestContext.WriteLine("Trying to read not-existed ski jumper with id = 5");
            SkiJumperService.Create(SkiJumper_1_Poland);
            SkiJumperService.Read(5);

        }

        [TestMethod]
        [Description("Check for reading skijumper")]
        [Owner("Bartlomiej")]
        [Priority(4)]
        [TestCategory("Reading")]
        public void ShouldReadExistedSkiJumper()
        {
            SkiJumperService = new SkiJumperService();

            TestContext.WriteLine("Trying to read existed ski jumper with id = 1");
            SkiJumperService.Create(SkiJumper_1_Germany);
            SkiJumper readed = SkiJumperService.Read(1);

            Assert.AreEqual(SkiJumper_1_Germany, readed);
        }

        [TestMethod]
        [Description("Check for updating skijumper")]
        [Owner("Bartlomiej")]
        [Priority(4)]
        [TestCategory("Updating")]
        public void ShouldUpdateExistedSkiJumper()
        {
            SkiJumperService = new SkiJumperService();
            string fromCall;

            TestContext.WriteLine("Trying to update skijumper");
            SkiJumperService.Create(SkiJumper_1_Germany);
            fromCall = SkiJumperService.Update(SkiJumper_1_Poland);
            SkiJumper readed = SkiJumperService.Read(1);

            TestContext.WriteLine(fromCall);
            Assert.AreNotEqual(SkiJumper_1_Germany.Name, SkiJumper_1_Poland.Name);
        }

        [TestMethod]
        [Description("Check for thrown ArgumentOutOfRangeException")]
        [Owner("Bartlomiej")]
        [Priority(2)]
        [TestCategory("Exception")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldNotUpdateForNotExistedSkiJumper()
        {
            SkiJumperService = new SkiJumperService();
            string fromCall;

            TestContext.WriteLine("Trying to update not existed skijumper");
            SkiJumperService.Update(SkiJumper_1_Germany);
        }

        [TestMethod]
        [Description("Check for deleting skijumper")]
        [Owner("Bartlomiej")]
        [Priority(4)]
        [TestCategory("Deleting")]
        public void ShouldDeleteExistedSkiJumper()
        {
            SkiJumperService = new SkiJumperService();
            string fromCall;

            TestContext.WriteLine("Trying to delete exsited skijumper");
            SkiJumperService.Create(SkiJumper_1_Poland);
            SkiJumperService.Delete(1);

            try
            {
                SkiJumperService.Read(1);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }

            Assert.Fail("Failed while removing skijumper");
        }

        [TestMethod]
        [Description("Check for thrown ArgumentOutOfRangeException")]
        [Owner("Bartlomiej")]
        [Priority(2)]
        [TestCategory("Exception")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldNotRemoveNotExistedSkiJumper()
        {
            SkiJumperService = new SkiJumperService();
            string fromCall;

            TestContext.WriteLine("Trying to delete not - exsited skijumper");
            SkiJumperService.Delete(1);

        }

        [TestMethod]
        [Description("Check for filtring by Country")]
        [Owner("Bartlomiej")]
        [Priority(3)]
        [TestCategory("Filtring")]
        public void ShouldFiltrByCountry()
        {
            SkiJumperService = new SkiJumperService();
            string Country = "Poland";

            TestContext.WriteLine("Trying to get filtred list of SkiJumpers");
            SkiJumperService.Create(SkiJumper_1_Poland);
            SkiJumperService.Create(SkiJumper_10_Poland);
            SkiJumperService.Create(SkiJumper_5_Germany);
            List<SkiJumper> SkiJumperList = SkiJumperService.FiletrByCountry(Country);

            foreach(SkiJumper s in SkiJumperList)
            {
                if(s.Country != Country)
                {
                    Assert.Fail("Filter doesnt work properly");
                }
            }

        }

        [TestMethod]
        [Description("Check for thrown ArgumentOutOfRangeException")]
        [Owner("Bartlomiej")]
        [Priority(2)]
        [TestCategory("Exception")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldNotFilterByNotExistedCountry()
        {
            SkiJumperService = new SkiJumperService();
            string Country = "Unknown";
            

            TestContext.WriteLine("Trying to filter by unexisted country");
            SkiJumperService.Create(SkiJumper_1_Poland);
            SkiJumperService.Create(SkiJumper_10_Poland);
            SkiJumperService.Create(SkiJumper_5_Germany);
            SkiJumperService.FiletrByCountry(Country);
        }
    }
}
