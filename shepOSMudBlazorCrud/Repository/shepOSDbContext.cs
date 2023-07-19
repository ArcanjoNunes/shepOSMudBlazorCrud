using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shepOSMudBlazorCrud.Models;
using shepOSMudBlazorCrud.Services;
using Microsoft.EntityFrameworkCore;

namespace shepOSMudBlazorCrud.Repository
{
    public class shepOSDbContext : DbContext
    {
        public DbSet<UserDataSchema> UserDataSchema { get; set; }

        public DbSet<ComboboxItem> ComboboxItems { get; set; }
        public DbSet<ComboboxItemDTO> ComboboxItemsDTO { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public shepOSDbContext(DbContextOptions<shepOSDbContext> options) : base(options)
        {
        }

    }
}
