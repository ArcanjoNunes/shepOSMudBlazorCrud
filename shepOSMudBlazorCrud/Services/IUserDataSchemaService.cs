using shepOSMudBlazorCrud.Models;

namespace shepOSMudBlazorCrud.Services
{
    public interface IUserDataSchemaService
    {
        System.Data.DataTable GetUserDataSchemaRecord();
        UserDataSchema GetUserDataSchemaRecord(int Reference);
    }
}
