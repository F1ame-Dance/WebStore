﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Entities.Base.Interfaces;
using WebStoreDomain.Entity.Base;

namespace WebStore.Domain.Entities
{
    [Table("Brands")]
    public class Brand : NamedEntity, IOrderedEntity
    {
       //[Column("BrandOrder")]
        public int Order { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
