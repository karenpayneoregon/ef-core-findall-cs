using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SampleLibrary.Extensions
{
    public static class DbContextExtensions
    {
        private static readonly MethodInfo ContainsMethod = typeof(Enumerable).GetMethods()
            .FirstOrDefault(mi => mi.Name == "Contains" && mi.GetParameters().Length == 2)
            .MakeGenericMethod(typeof(object));
        
        /// <summary>
        /// Find by primary key
        /// </summary>
        /// <typeparam name="T">Model to find against</typeparam>
        /// <param name="dbContext">Valid DbContext for model</param>
        /// <param name="keyValues">primary key values</param>
        /// <returns>Array of T for matching records from keyValues</returns>
        public static Task<T[]> FindAllAsync<T>(this DbContext dbContext, params object[] keyValues) where T : class
        {
            var entityType = dbContext.Model.FindEntityType(typeof(T));
            var primaryKey = entityType.FindPrimaryKey();

            if (primaryKey.Properties.Count != 1)
            {
                throw new NotSupportedException("Only a single primary key is supported");
            }

            var pkProperty = primaryKey.Properties[0];
            var pkPropertyType = pkProperty.ClrType;

            // validate passed key values
            foreach (var keyValue in keyValues)
            {
                if (!pkPropertyType.IsInstanceOfType(keyValue))
                {
                    throw new ArgumentException($"Key value '{keyValue}' is not of the right type");
                }
            }

            // retrieve member info for primary key
            var pkMemberInfo = typeof(T).GetProperty(pkProperty.Name);

            if (pkMemberInfo == null)
            {
                throw new ArgumentException("Type does not contain the primary key as an accessible property");
            }

            // build lambda expression
            var parameter = Expression.Parameter(typeof(T), "e");
            var body = Expression.Call(null, ContainsMethod,
                Expression.Constant(keyValues),
                Expression.Convert(Expression.MakeMemberAccess(parameter, pkMemberInfo), typeof(object)));
            var predicateExpression = Expression.Lambda<Func<T, bool>>(body, parameter);

            return dbContext.Set<T>().Where(predicateExpression).ToArrayAsync();
        }
    }
}
