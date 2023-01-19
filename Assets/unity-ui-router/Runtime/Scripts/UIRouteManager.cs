using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Nox7atra.UIRouter
{
    public static class UIRouteManager
    {
        private static Dictionary<string, Type> _routesData;
        private static Stack<string> _screensStack;
        private static string _mainScreenRoute;
        public static void OpenUrl(string route)
        {
            _screensStack.Push(route);
            var payload = ParseParams(route, out route);
            if (_routesData.ContainsKey(route))
            {
                var type = _routesData[route];
                var obj = Object.FindObjectOfType(type, true) as MonoBehaviour;
                if (obj != null)
                {
                    obj.gameObject.SetActive(true);
                    obj.SendMessage("Show", payload);
                }
                else
                {
                    Debug.LogError($"There no object of type:{type.Name}");
                }
            }
            else
            {
                Debug.LogError($"There no route with name: {route}");
            }
        }

        private static void HideUrl(string route)
        {
            var payload = ParseParams(route, out route);
            if (_routesData.ContainsKey(route))
            {
                var type = _routesData[route];
                var obj = Object.FindObjectOfType(type, true) as MonoBehaviour;
                if (obj != null)
                {
                    obj.SendMessage("Hide", payload);
                }
                else
                {
                    Debug.LogError($"There no object of type:{type.Name}");
                }
            }
            else
            {
                Debug.LogError($"There no route with name: {route}");
            }
        }
        public static void ReleaseLastScreen()
        {
            if (_screensStack.Count > 0)
            {
                _screensStack.Pop();
            }
        }

        public static void SetMainScreenRoute(string route)
        {
            _mainScreenRoute = route;
        }
        
        public static void ProceedBack()
        {
            if (_screensStack.Count > 0)
            {
                var lastScreen = _screensStack.Pop();
                HideUrl(lastScreen);
                if (_screensStack.Count > 0)
                {
                    var prevScreen = _screensStack.Pop();
                    OpenUrl(prevScreen); 
                }
                else
                {
                    OpenUrl(_mainScreenRoute);
                }
            }
            else
            {
                OpenUrl(_mainScreenRoute);
            }
        }
        
        private static Dictionary<string, string> ParseParams(string fullRoute, out string route)
        {
            var routeEnd = fullRoute.Split("/")[^1];
            var result  = new Dictionary<string, string>();
            var routeParams = routeEnd.Split("?");
            if (routeParams.Length > 1)
            {
                var parameters = routeParams[1].Split("&");
                if (parameters.Length > 0)
                {
                    foreach (var param in parameters)
                    {
                        var data = param.Split("=");
                        if (data.Length > 1)
                        {
                            result[data[0]] = data[1]; 
                        }
                    }
                }
                route = fullRoute.Split("?")[0];
            }
            else
            {
                route = fullRoute;
            }
            return result;
        }
        
        static UIRouteManager()
        {
            _screensStack = new Stack<string>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            _routesData = new Dictionary<string, Type>();
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();
                foreach(Type type in types)
                {
                    var attributes = type.GetCustomAttributes(typeof(UIRouteAttribute), true);
                    if (attributes.Length > 0)
                    {
                        var uiRoute = attributes[0] as UIRouteAttribute;
                        _routesData[uiRoute.Route] = type;
                    }
                }
            }
        }
    }
}