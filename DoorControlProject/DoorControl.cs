using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControlProject
{
    public class DoorControl
    {
        private IDoor _door;
        private IUserValidation _userValidation;

        public DoorControl(IDoor door, IUserValidation userValidation)
        {
            _door = door;
            _userValidation = userValidation;
        }

        public void RequestEntry(int id)
        {
            if (_userValidation.ValidateEntryRequest(id) == true)
            {
                _door.Open();
            }
        }

        public void DoorOpen()
        {
            _door.Close();
        }

        public void DoorClosed()
        {

        }

        public void RaiseAlarm()
        {
            
        }



    }
}
