using System;

namespace Nox7atra.UIRouter
{
    [AttributeUsage(AttributeTargets.Class)]
    public class UIRouteAttribute : Attribute
    {
        public string Route;
        public UIRouteAttribute(string fullRoute)
        {
            Route = fullRoute;
        }
    }
}
