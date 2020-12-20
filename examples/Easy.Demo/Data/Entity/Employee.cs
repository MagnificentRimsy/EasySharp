using EasySharp.EfCore.StoredProcedure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Easy.Demo.Data.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class Employee : IProc<Guid>
    {

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
    }
}
