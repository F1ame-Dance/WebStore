﻿using WebStore.Entities.Base.Interfaces;
using WebStoreDomain.Entity.Base;

namespace WebStore.Domain.Entities
{
    public class Brand : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
    }
}
