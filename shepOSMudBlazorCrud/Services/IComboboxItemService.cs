using shepOSMudBlazorCrud.Models;

namespace shepOSMudBlazorCrud.Services
{
    public interface IComboboxItemService
    {
        List<ComboboxItemDTO> GetComboboxList(int Class);
        ComboboxItemDTO GetEmpty();
        ComboboxItemDTO GetRecord(int Class, int Code);
    }
}
