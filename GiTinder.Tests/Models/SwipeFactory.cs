using GiTinder.Models;

namespace GiTinder.Tests.Models
{
    class SwipeFactory
    {
        public static Swipe CreateSwipe()
        {

            return new Swipe()
            {
                SwipingUserId = "Filip",
                SwipedUserId = "O'Potamus",
                Direction = SwipeDirection.Left
            };
        }

        public static Swipe CreateSwipeWithNullSwipingUserId()
        {
            var swipe = CreateSwipe();
            swipe.SwipingUserId = null;
            return swipe;
        }

        public static object CreateSwipeWithNullSwipedUserId()
        {
            var swipe = CreateSwipe();
            swipe.SwipedUserId = null;
            return swipe;
        }
    }
}
