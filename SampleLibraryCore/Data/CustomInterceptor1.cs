using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace SampleLibraryCore.Data
{
    public class CustomInterceptor1 : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"Started saving changes.");

            return new ValueTask<InterceptionResult<int>>(result);
        }

        public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData,
            int result,
            CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"Saved {result} No of changes.");

            return new ValueTask<int>(result);
        }

        public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
        {
            Debug.WriteLine($"Dude {result}");
            return base.SavedChanges(eventData, result);
        }
    }
}
