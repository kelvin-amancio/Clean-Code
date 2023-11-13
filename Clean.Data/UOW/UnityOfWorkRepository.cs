using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Infrastructure.UOW
{
    public class UnityOfWorkRepository<T> : IUnityOfWorkRepository<T> where T : class
    {
        public void AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
