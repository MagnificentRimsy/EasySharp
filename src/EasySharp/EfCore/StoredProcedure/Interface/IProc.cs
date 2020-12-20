using System;
using System.Collections.Generic;
using System.Text;

namespace EasySharp.EfCore.StoredProcedure.Interface
{
    public interface IProc<T>
    {
        public T Id { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public DateTime? LastModifiedAtUtc { get; set; }
    }
}
