using COBAShop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace COBAShop.Data.Configurations
{
    public class CoreUploadFileConfiguration : IEntityTypeConfiguration<CoreUploadFiles>
    {
        public void Configure(EntityTypeBuilder<CoreUploadFiles> builder)
        {
            builder.ToTable("CoreUploadFiles");
            builder.HasKey(x => x.Id);
        }
    }
}