using Csla;
using Csla.Configuration;
using Csla.Core;
using CslaExemple.BLLNetStandard;
using CslaExemple.DalEfNetStandard;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CslaExemple.UI.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"Début du programme");
            try
            {
                Csla.ApplicationContext.User = new Csla.Security.UnauthenticatedPrincipal();

                var list = ResourceList.GetResourceListAsync().GetAwaiter().GetResult();
                Console.WriteLine($"resource count {list.Count}");
                foreach (var item in list)
                {
                    Console.WriteLine($"Resource Name:{item.Name}");
                }


                var resourceEdit = ResourceEdit.NewResourceEditAsync().GetAwaiter().GetResult();
                resourceEdit.FirstName = "Kévin";
                resourceEdit.LastName = "VERNET";

                resourceEdit.WaitForAllRulesToComplete().GetAwaiter().GetResult();

                if (!resourceEdit.IsSavable)
                {
                    Console.WriteLine($"Resource non sauvegardable");
                    return;
                }

                resourceEdit = resourceEdit.SaveAsync().GetAwaiter().GetResult();
                Console.WriteLine($"Sauvegarde réussi.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error. Message: {ex.Message} - StackTrace:{ex.StackTrace}");
            }
            finally
            {
                Console.WriteLine($"Fin du programme, appuyer sur une touche pour terminer.");
                Console.ReadLine();
            }
        }
    }
}
