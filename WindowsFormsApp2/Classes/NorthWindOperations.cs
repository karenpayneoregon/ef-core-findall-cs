using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleLibraryCore.Data;
using SampleLibraryCore.Models;

namespace WindowsFormsApp2.Classes
{
    /// <summary>
    /// Methods to interact with the SQL-Server database NorthWindAzureForInserts
    /// </summary>
    public class NorthWindOperations
    {
        /// <summary>
        /// Get an <see cref="Employee"/> by an existing primary key
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns>Employee for identifier</returns>
        public static async Task<Employee> ReadEmployee(int identifier)
        {
            await using var context = new NorthWindContext();
            
            return await Task.Run(() => 
                context.Employees.FirstOrDefaultAsync(emp => emp.EmployeeId == identifier));
        }

        /// <summary>
        /// Read Employee current values from the database
        /// </summary>
        /// <param name="identifier">Employee key to return data for</param>
        /// <returns>Employee for identifier</returns>
        public static Employee OriginalEmployee(int identifier)
        {
            var context = new NorthWindContext();

            /*
             * AsNoTracking indicates that the ChangeTracker is not tracking the entity
             */
            return context.Employees.AsNoTracking().FirstOrDefault(employee => employee.EmployeeId == identifier);
        }

        /// <summary>
        /// Save a single <see cref="Employee"/>
        /// </summary>
        /// <param name="employee"><see cref="Employee"/></param>
        /// <returns>1 for success, other values failure</returns>
        public static bool SaveEmployee(Employee employee)
        {
            /*
             * Connect to database
             */
            using var context = new NorthWindContext();
            context.SavedChanges += ContextOnSavedChanges;
            context.SaveChangesFailed += ContextOnSaveChangesFailed;

            /*
             * Tell Entity Framework we are saving changes to an existing record,
             */
            context.Entry(employee).State = EntityState.Modified;

            /*
             * SaveChanges returns count of changes e.g. one record = 1, two records = 2 etc.
             * While 0 means nothing updated.
             *
             * Contrary to the above the ChangeTracker for EF Core will return 1 even if no
             * properties changed.
             */
            return context.SaveChanges() == 1;
        }

        private static void ContextOnSaveChangesFailed(object? sender, SaveChangesFailedEventArgs saveChangesFailedEvent)
        {
            Debug.WriteLine(saveChangesFailedEvent.Exception.Message);
        }

        private static void ContextOnSavedChanges(object? sender, SavedChangesEventArgs savedChangesEvent)
        {
            Console.WriteLine();
        }
    }
}
