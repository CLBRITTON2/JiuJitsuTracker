using JiuJitsuTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiuJitsuTracker.DataAccess.Repository.IRepository
{
    public interface IClassInfoRepository : IRepository<ClassInfo>
    {
        void Update(ClassInfo obj);
        void Save();
    }
}
