using shepOSMudBlazorCrud.Models;
using shepOSMudBlazorCrud.Repository;
using System.Data;

namespace shepOSMudBlazorCrud.Services
{
    public class UserDataSchemaService: IUserDataSchemaService
    {
        private readonly shepOSDbContext _dbContext;

        public UserDataSchemaService(shepOSDbContext context)
        {
            _dbContext = context;
        }

        public DataTable GetUserDataSchemaRecord()
        {
            return shepOS.shepOSLibrary.ToDataTableSingle(GetUserDataSchemaRecord(1), shepOS.shepOSLibrary.REPORT_USER_DATASCHEMA);
        }

        public UserDataSchema GetUserDataSchemaRecord(int Reference)
        {
            return _dbContext.UserDataSchema.SingleOrDefault(x => x.uds_Reference == Reference) ?? new UserDataSchema();
        }
    }
}
