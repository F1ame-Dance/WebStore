﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Entities.Base.Interfaces;


namespace WebStoreDomain.Entity.Base
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}