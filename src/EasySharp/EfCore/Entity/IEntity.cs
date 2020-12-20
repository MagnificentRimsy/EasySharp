﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EasySharp.EfCore.Entity
{
    public interface IEntity<T>
    {
        public T Id { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public DateTime? LastModifiedAtUtc { get; set; }
    }
}
