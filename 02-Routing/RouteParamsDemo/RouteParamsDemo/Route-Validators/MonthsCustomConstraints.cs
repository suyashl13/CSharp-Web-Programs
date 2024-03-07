using System;
using System.Text.RegularExpressions;

namespace RouteParamsDemo.RouteValidators;


public class MonthsCustomConstraints: IRouteConstraint
{
	public MonthsCustomConstraints()
	{
	}

    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
        if (!httpContext.Request.RouteValues.ContainsKey(routeKey)) return false;
        Regex regex = new Regex($"^(jan|feb|march|apr|may)$");
        String monthValue = Convert.ToString(httpContext.Request.RouteValues.ContainsKey(routeKey));

        return regex.IsMatch(monthValue);
    }
}

