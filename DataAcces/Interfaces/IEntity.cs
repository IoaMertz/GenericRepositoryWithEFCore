using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }

    
}
