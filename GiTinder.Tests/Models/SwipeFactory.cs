using System;
using GiTinder.Models;

namespace GiTinder.Tests.Models
{
    class SwipeFactory
    {
        public static Swipe CreateSwipe()
        {
            return new Swipe("Michel", "Dugésier", SwipeDirection.Left);
        }

        public static Swipe CreateSwipeWithNullUserId()
        {
            var swipe = CreateSwipe();
            swipe.UserId = null;
            return swipe;
        }

        public static object CreateSwipeWithNullSwipedUserId()
        {
            var swipe = CreateSwipe();
            swipe.SwipedUserId = null;
            return swipe;
        }

        public static object CreateSwipeWithNullTimestamp()
        {
            var swipe = CreateSwipe();
            swipe.Timestamp = null;
            return swipe;
        }
    }
}
