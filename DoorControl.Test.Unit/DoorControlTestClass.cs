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

            _uut =  new DoorControl();
        }

        [Test]
        public void EntryIdTest()
        {
            _uut.RequestEntry(1234);

            _FakeUserValidation.ValidateEntryRequest(1234).Returns(true);

            _FakeDoor.Received(1).Open();
        }



    }
}
