using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RusMProject.Domain.Entities;
using RusMProject.Persistance.Configurations.Common;
using RusMProjectApplication.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Proxies;

namespace RusMProject.Persistance.Configurations.Main
{
    public class ExceptionNotificationConfiguration : BaseEntityConfiguration<ExceptionNotification>, IEntityConfigurationAble
    {
        public override void Configure(EntityTypeBuilder<ExceptionNotification> builder)
        {
            base.Configure(builder);

            builder.ToTable("ExceptionNotifications");

            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("nvarchar(100)");
            builder.Property(x => x.Description).HasColumnName("Description").HasColumnType("nvarchar(500)");

            builder.HasData(new List<ExceptionNotification>
            { 
                new ExceptionNotification() 
                {Id = 1,CreatorDate=DateTime.Now, CreatorUserId=1,IsActive=true, EditorDate=null,EditorUserId=null, Name="Not Found", Description="There is no data available corresponding this request"  },
                    new ExceptionNotification() 
                    {Id=2, CreatorDate=DateTime.Now, CreatorUserId=1,IsActive=true, EditorDate=null,EditorUserId=null, Name="Bad Request", Description="The request the you made is incorrect or corrupt"  },
             
                    new ExceptionNotification() 
                    {Id=3, CreatorDate=DateTime.Now, CreatorUserId=1,IsActive=true, EditorDate=null,EditorUserId=null, Name="Server Error", Description="An error occurred on the server"  },
             
                    new ExceptionNotification() 
                    {Id=4, CreatorDate=DateTime.Now, CreatorUserId=1,IsActive=true, EditorDate=null,EditorUserId=null, Name="Client Error", Description="Data is must not null,zero or empty"  },

                    new ExceptionNotification()
                    {Id=5, CreatorDate=DateTime.Now, CreatorUserId=1,IsActive=true, EditorDate=null,EditorUserId=null, Name="Client Error For Lang", Description="No matching language found"  },

                    new ExceptionNotification()
                    {Id=6, CreatorDate=DateTime.Now, CreatorUserId=1,IsActive=true, EditorDate=null,EditorUserId=null, Name="Not Found For Language", Description="There is no data in the database that matches the given language"  },

                    new ExceptionNotification()
                    {Id=7, CreatorDate=DateTime.Now, CreatorUserId=1,IsActive=true, EditorDate=null,EditorUserId=null, Name="Server Error Parent Child", Description="The given language does not exist in the databases"  },

                    new ExceptionNotification()
                    {Id=8, CreatorDate=DateTime.Now, CreatorUserId=1,IsActive=true, EditorDate=null,EditorUserId=null, Name="Not Found For Id", Description="There is no word in the database that matches the given id"  },

                    new ExceptionNotification()
                    {Id=9, CreatorDate=DateTime.Now, CreatorUserId=1,IsActive=true, EditorDate=null,EditorUserId=null, Name="Not Found For Language Or Id", Description="There is no data in the database that matches the given language or id"  },

                    new ExceptionNotification()
                    {Id=10, CreatorDate=DateTime.Now, CreatorUserId=1,IsActive=true, EditorDate=null,EditorUserId=null, Name="Client Error For Model", Description="The given language does not exist in the databases"  },

                    new ExceptionNotification()
                    {Id=11, CreatorDate=DateTime.Now, CreatorUserId=1,IsActive=true, EditorDate=null,EditorUserId=null, Name="AuthenticationTokenIsRequired", Description="AuthenticationToken Is Required"  },
            });
        }
    }
}
