//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineExaminationSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Query
    {
        public int QueryId { get; set; }
        public int QuestionId { get; set; }
        public string Query1 { get; set; }
        public string Answer { get; set; }
    
        public virtual Question Question { get; set; }
    }
}