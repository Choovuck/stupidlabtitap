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
    
    public partial class Mark
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mark()
        {
            this.Vectors = new HashSet<Vector>();
        }
    
        public int MNum { get; set; }
        public int CNum { get; set; }
        public string MName { get; set; }
        public int MRange { get; set; }
        public int NumMark { get; set; }
        public int NormMark { get; set; }
    
        public virtual Criterion Criterion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vector> Vectors { get; set; }
    }
}
