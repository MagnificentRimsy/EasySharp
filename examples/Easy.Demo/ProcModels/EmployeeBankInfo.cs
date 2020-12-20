using EasySharp.EfCore.StoredProcedure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Easy.Demo.ProcModels
{
    public class EmployeeBankInfo : IProc<Guid>
    {
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime CreatedAtUtc { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? LastModifiedAtUtc { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
