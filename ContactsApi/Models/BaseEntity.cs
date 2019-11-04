using System;
using System.ComponentModel.DataAnnotations;

using PKey = System.Guid;

namespace ContactsApi.Models
{
    public abstract class BaseEntity 
    {
        // [Key]    Key by default:  https://docs.microsoft.com/en-us/ef/core/modeling/keys
        public Guid Id { get; set; }
    }
}