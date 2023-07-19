using FastReport.AdvMatrix;
using shepOSMudBlazorCrud.Models;
using shepOSMudBlazorCrud.Repository;

namespace shepOSMudBlazorCrud.Services
{
    public class ComboboxItemService: IComboboxItemService
    {
        private readonly shepOSDbContext _dbContext;

        public ComboboxItemService(shepOSDbContext context)
        {
            _dbContext = context;
        }

        public ComboboxItemDTO GetEmpty()
        {
            return new ComboboxItemDTO
            {
                Code = 0,
                Title = "-"
            };
        }

        public ComboboxItemDTO GetRecord(int Class, int Code)
        {
            ComboboxItemDTO? oRecord = GetComboboxList(Class).FirstOrDefault(x => x.Code == Code);
            return oRecord is null ? GetEmpty() : oRecord;
        }

        public List<ComboboxItemDTO> 
            GetComboboxList(int Class) => _dbContext.ComboboxItems
                              .Where(x => x.Class == Class)
                              .ToList().Select(x => new ComboboxItemDTO
                              {
                                  Code = x.Code,
                                  Title = x.Title
                              }).ToList();

    }
}
