using Bogus;
using Library.Models.Clinicians;
using Library.Models.Reservations;
using Library.Models.Rooms;
using System.Collections.Generic;

namespace Library.Factory.Rooms
{
    class RoomFactory
    {

        public static Room CreateRoom(RoomType RoomType)
        {
            Room r = new();
            r.RoomType = RoomType;

            return r;
        }
    }
}
