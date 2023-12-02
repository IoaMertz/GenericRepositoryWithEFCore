using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public class kati : IEntity<int>
    {
        public int KatiId { get; init; }
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
