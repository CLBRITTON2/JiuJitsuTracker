using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiuJitsuTracker.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IClassInfoRepository ClassInfo { get; }
        void Save();
    }
}
