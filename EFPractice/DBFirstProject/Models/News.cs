//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBFirstProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class News
    {
        public virtual Category Category { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<int> ViewCount { get; set; }
        public string Photo { get; set; }
        public Nullable<int> CategoryId { get; set; }
    
    }
}
