using EasySharp.EfCore.StoredProcedure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Easy.Demo.ProcModels
{
    /// <summary>
    /// 
    /// </summary>
    public class Employee : IProc<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreatedAtUtc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastModifiedAtUtc { get; set; }
    }
}
