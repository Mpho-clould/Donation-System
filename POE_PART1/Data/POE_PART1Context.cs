using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using POE_PART1.Models;

namespace POE_PART1.Data
{
    public class POE_PART1Context : IdentityDbContext
    {
        public POE_PART1Context (DbContextOptions<POE_PART1Context> options)
            : base(options)
        {
        }

        public DbSet<POE_PART1.Models.Monetary_donations> Monetary_donations { get; set; } = default!;


        public DbSet<POE_PART1.Models.disaster>? disaster { get; set; }

        public DbSet<POE_PART1.Models.Category>? Category { get; set; }

        public DbSet<POE_PART1.Models.GoodsDonation>? GoodsDonation { get; set; }


        public DbSet<AppUser> AppUser { get; set; }

        public DbSet<POE_PART1.Models.activeDisaster>? activeDisaster { get; set; }

        public DbSet<POE_PART1.Models.MoneysAllocate>? MoneysAllocate { get; set; }

        public DbSet<POE_PART1.Models.GoodsAllocation>? GoodsAllocation { get; set; }

        public DbSet<POE_PART1.Models.Purchase>? Purchase { get; set; }

    }
}
