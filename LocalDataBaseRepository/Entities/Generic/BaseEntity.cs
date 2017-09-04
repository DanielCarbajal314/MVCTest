using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalDataBaseRepository.Entities.Generic
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; internal set; }

        public BaseEntity()
        {
            this.CreatedDate = DateTime.Now;
        }
    }
}
