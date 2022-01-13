using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DirtRivalsswag.Models;

namespace DirtRivalsswag.DBContext
{
    public class MetaDataConfig : IEntityTypeConfiguration<MetaData>
    {

        public void Configure(EntityTypeBuilder<MetaData> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(t => t.Challenges)
                    .IsRequired();
        }
        protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MetaDataConfig());
        }

    }
}
