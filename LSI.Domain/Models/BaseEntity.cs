using System;
using System.Collections.Generic;
using System.Text;

namespace LSI.Domain.Models
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
