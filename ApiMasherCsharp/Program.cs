using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ApiMasherCsharp
{
    class Program
    {
        /// <summary>
        /// Sets up the parameters to use for the API in an ArrayList.
        /// </summary>
        static void Main(string[] args)
        {

            DoHttp GuardianPost = new DoHttp();
            ArrayList GuardinCategories = new ArrayList();
            GuardinCategories.Add("Uk");
            GuardinCategories.Add("World");
            GuardinCategories.Add("Sport");
            GuardinCategories.Add("Football");
            GuardinCategories.Add("Life&style");
            GuardinCategories.Add("Culture");
            GuardinCategories.Add("Business");
            GuardinCategories.Add("Travel");
            GuardinCategories.Add("Technology");
            GuardinCategories.Add("Travel");
            GuardinCategories.Add("Environment");

            foreach (string Category in GuardinCategories) {
                System.Threading.Thread.Sleep(1000); // pause for second !Important do not remove even for testing
                // max 12 calls per second, or we will get banned
                // max 5000 total calls per month
                // Check Monthly Tally if in doubt
                // http://explorer.content.guardianapis.com/#/search?q=Uk&show-fields=all&date-id=date%2Flast24hours&api-key=
                // from above URL check the   "total": in the response field
                
                dynamic Result = GuardianPost.DoGet("http://content.guardianapis.com/search?q=" + Category + "&show-fields=all&date-id=date%2Flast24hours&api-key=);
              
              };
        
         
        }
    }
}
