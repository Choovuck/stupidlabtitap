//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TILab1WPF.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Result
    {
        public int RNum { get; set; }
        public int LNum { get; set; }
        public int ANum { get; set; }
        public int Range { get; set; }
        public int AWeight { get; set; }
    
        public virtual Alternative Alternative { get; set; }
        public virtual LPR LPR { get; set; }
    }
}
