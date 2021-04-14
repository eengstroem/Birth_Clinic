using Library.Models.Births;
using Library.Models.Reservations;
using Library.Models.Rooms;
using System;

namespace Library.Factory.Reservations
{
    public class ReservationFactory
    {
        //public static Reservation CreateFakeReservation(RoomType RoomType, DateTime StartTime)
        //{

        //    DateTime EndTime = StartTime;

        //    //we have no idea how birth works. Labour takes 12 hours we guess
        //    switch (RoomType)
        //    {
        //        case RoomType.BIRTH:
        //            EndTime = StartTime.AddHours(-12);
        //            break;
        //        case RoomType.REST:
        //            EndTime = StartTime.AddHours(4);
        //            break;
        //        case RoomType.MATERNITY:
        //            EndTime = StartTime.AddDays(-5);
        //            break;
        //    }

        //    var o = new Reservation()
        //    {
        //        IsEndedEarly = false,
        //        StartTime = StartTime,
        //        EndTime = EndTime,
        //    };

        //    return o;
        //}
    }
}
