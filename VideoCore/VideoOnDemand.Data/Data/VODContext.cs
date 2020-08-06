using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using VideoOnDemand.Data.Data.Entities;

namespace VideoOnDemand.Data.Data
{
    public class VODContext : IdentityDbContext<User>
    {
        public VODContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
