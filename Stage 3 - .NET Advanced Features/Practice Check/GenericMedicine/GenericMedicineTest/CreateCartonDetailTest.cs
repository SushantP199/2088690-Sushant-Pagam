using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GenericMedicine;

namespace GenericMedicineTest
{
    [TestFixture]
    public class CreateCartonDetailTest
    {
        Program program = null;

        Medicine medicine = new Medicine()
        {
            Id = 1,
            Name = "spp",
            GenericMedicineName = "pcm",
            Composition = "coo",
            ExpiryDate = new DateTime(2023, 01, 01),
            PricePerStrip = 4.5
        };

        [SetUp]
        public void Init()
        {
            program = new Program();
        }

        [Test]
        [TestCase(10, "2022-04-09", "ijk")]
        public void CartonObjectCreationTest(int c, DateTime date, string addr)
        {

            Assert.DoesNotThrow(() => program.CreateCartonDetail(c, date, addr, medicine));
        }

        [Test]
        [TestCase(-1, "2021-02-17", "ijk")]
        public void StripCountTest(int c, DateTime date, string addr)
        {
            Assert.That(() => program.CreateCartonDetail(c, date, addr, medicine), Throws.Exception);
        }

        [Test]
        [TestCase(10, "2020-01-11", "ijk", null)]
        public void NullMedicineObjectTest(int c, DateTime date, string addr, Medicine med)
        {
            Assert.AreEqual(program.CreateCartonDetail(c, date, addr, med), null);
        }

        [Test]
        [TestCase(10, "2019-12-20", "ijk")]
        public void LaunchDateLessThanCurrentDateTest(int c, DateTime date, string addr)
        {
            Assert.That(() => program.CreateCartonDetail(c, date, addr, medicine), Throws.Exception);
        }
    }
}
