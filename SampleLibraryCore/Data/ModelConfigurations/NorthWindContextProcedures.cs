using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace SampleLibraryCore.Data.ModelConfigurations
{
    public partial class NorthWindContextProcedures
    {
        private readonly NorthWindContext _context;

        public NorthWindContextProcedures(NorthWindContext context)
        {
            _context = context;
        }

        public async Task<int> sp_dropdiagram(string diagramname, int? owner_id, OutputParameter<int> returnValue = null)
        {
            var parameterdiagramname = new SqlParameter
            {
                ParameterName = "diagramname",
                Size = 256,
                Value = diagramname ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.NVarChar,
            };

            var parameterowner_id = new SqlParameter
            {
                ParameterName = "owner_id",
                Value = owner_id ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[sp_dropdiagram] @diagramname, @owner_id", parameterdiagramname, parameterowner_id, parameterreturnValue);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
