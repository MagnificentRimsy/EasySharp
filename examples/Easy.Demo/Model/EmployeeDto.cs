using System;

namespace Easy.Demo.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeDto
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
