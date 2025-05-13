using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Zhaoxi.SmartParking.Server.ICommon;
using Zhaoxi.SmartParking.Server.IService;
using Zhaoxi.SmartParking.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Zhaoxi.SmartParking.Server.Service
{
    public class FileUpgradeService : BaseService, IFileUpgradeService
    {
        public FileUpgradeService(IDbConnectionFactory contextFactor) : base(contextFactor)
        {

        }

        public int AddOrUpdate(UpgradeFile upgradeFile)
        {
            var query = (from q in Context.Set<UpgradeFile>()
                         where q.FileName == upgradeFile.FileName
                         select q.FileId).ToList();

            var entity = Context.Entry(upgradeFile);
            if (query.Count() > 0)
            {
                upgradeFile.FileId = query[0];
                entity.State = EntityState.Modified;
            }
            else
            {
                entity.State = EntityState.Added;
            }
            return Context.SaveChanges();
        }
    }
}
