using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoorControlProject;
using NUnit.Framework;
using NSubstitute;

namespace DoorControlTest.Unit
{
    [TestFixture]
    public class DoorControlTestClass
    {
        private IDoor _FakeDoor;
        private IUserValidation _FakeUserValidation;
        private DoorControl _uut;

        [SetUp]
        public void SetUp()
        {
            _FakeDoor = Substitute.For<IDoor>();
            _FakeUserValidation = Substitute.For<IUserValidation>();

            _uut =  new DoorControl(_FakeDoor, _FakeUserValidation);
        }

        [Test]
        public void EntryIdTest()
        {
            _FakeUserValidation.ValidateEntryRequest(1234).Returns(true);

            _uut.RequestEntry(1234);

            _FakeDoor.Received(1).Open();
        }

        [Test]
        public void EntryIdTestFalse()
        {
            _FakeUserValidation.ValidateEntryRequest(1234).Returns(true);

            _uut.RequestEntry(8790);

            _FakeDoor.Received(0).Open();
        }

    }
}
