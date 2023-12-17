using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService.Services
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://mywebserviceproject.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod (Description = "This webservice method greets user according to the time of the day")]
        public string GreetAssistant(string name)
        {
            // Get the current time
            DateTime currentTime = DateTime.Now;

            // Extract the hour from the current time
            int currentHour = currentTime.Hour;

            // Determine the time of the day and generate a greeting
            string greeting;
            if (currentHour >= 5 && currentHour < 12)
            {
                greeting = $"Good morning {name}.";
            }
            else if (currentHour >= 12 && currentHour < 16)
            {
                greeting = $"Good afternoon {name}";
            }
            else if (currentHour >= 16 && currentHour < 22)
            {
                greeting = $"Good evening {name}.";
            }
            else
            {
                greeting = $"Why are you awake {name}, good night!";
            }

            return greeting;
        }

        [WebMethod (Description = "This webservice method Convert temperature from Fahrenheit to Celsius")]
        // Convert temperature from Fahrenheit to Celsius
        public double FahrenheitToCelsius(double fahrenheit)
        {
            double convertedFahrenheitValue = (fahrenheit - 32) * 5 / 9;
            return convertedFahrenheitValue;
        }

        [WebMethod (Description = "This webservice method Convert temperature from Celsius to Fahrenheit")]
        // Convert temperature from Celsius to Fahrenheit
        public double CelsiusToFahrenheit(double celsius)
        {
            double convertedCelsiusValue = (celsius * 9 / 5) + 32; ;
            return convertedCelsiusValue;
        }

        // result to be returned when the SolveQuadraticEquation method resolves and produces a response
        public class QuadraticResult
        {
            // returns true if the equation can be solved using quadratic formular else if returns false
            public bool HasSolution { get; set; }
            // Root1 and root2 are the roots answers 
            public double? Root1 { get; set; }
            public double? Root2 { get; set; }
            // Error message is returned incase of error or an exception is thrown by the method
            public string ErrorMessage { get; set; }
        }

        [WebMethod (Description = "This webservice method solves a quadratic equation using the quadratic formula. " +
            "The function takes the coefficients a, b, and c as input and returns a QuadraticResult object containing information about the roots.")]
        // Solve quadratic equations using the quadratic formular
        // a,b and c are the coefficients 

        public QuadraticResult SolveQuadraticEquation(double a, double b, double c)
            {
                try
                {
                    double discriminant = b * b - 4 * a * c;

                    if (discriminant < 0)
                    {
                        return new QuadraticResult
                        {
                            HasSolution = false,
                            ErrorMessage = "No real roots (complex roots)."
                        };
                    }

                    double sqrtDiscriminant = Math.Sqrt(discriminant);
                    double root1 = (-b + sqrtDiscriminant) / (2 * a);
                    double root2 = (-b - sqrtDiscriminant) / (2 * a);

                    return new QuadraticResult
                    {
                        HasSolution = true,
                        Root1 = root1,
                        Root2 = root2
                    };
                }
                catch (Exception ex)
                {
                    return new QuadraticResult
                    {
                        HasSolution = false,
                        ErrorMessage = ex.Message
                    };
                }
            }
        
    }
}
