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
    
    public partial class TemporaryTest
    {
        public int TestId { get; set; }
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public Nullable<int> TotalRightAnswer { get; set; }
        public Nullable<int> TotalWrongAnswer { get; set; }
        public Nullable<int> ObtainedMark { get; set; }
        public string Answer { get; set; }
        public Nullable<bool> isCorrect { get; set; }
    
        public virtual Exam Exam { get; set; }
        public virtual Student Student { get; set; }
    }
}