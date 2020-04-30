using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleLibrary.Interfaces;

namespace SampleLibrary.Extensions
{
    /// <summary>
    /// https://stackoverflow.com/questions/45096799/filter-all-queries-trying-to-achieve-soft-delete
    /// https://haacked.com/archive/2019/07/29/query-filter-by-interface/
    ///
    /// https://github.com/dotnet/efcore/issues/10275
    /// </summary>
    public static class EFFilterExtensions
    {
        public static void SetSoftDeleteFilter(this ModelBuilder modelBuilder, Type entityType)
        {
            SetSoftDeleteFilterMethod.MakeGenericMethod(entityType).Invoke(null, new object[] { modelBuilder });
        }

        static readonly MethodInfo SetSoftDeleteFilterMethod = typeof(EFFilterExtensions)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Single(methodInfo => methodInfo.IsGenericMethod && methodInfo.Name == "SetSoftDeleteFilter");

        public static void SetSoftDeleteFilter<TEntity>(this ModelBuilder modelBuilder) where TEntity : class, ISoftDeleteModel
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(entity => !entity.IsDeleted);
        }



    }
}
