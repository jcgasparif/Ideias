// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace Softsige.Ideias.Domain.Entities.Models
{
    public partial class AspNetUserClaims : EntityModel
    {
        
        //public int Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}