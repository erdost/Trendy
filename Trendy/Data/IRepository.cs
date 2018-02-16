using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Trendy.Data
{

    public interface IRepository<Entity> where Entity : EntityBase
    {
        IList<Entity> SearchFor(Expression<Func<Entity, bool>> predicate, int pageSize, int pageIndex);
    }
}
