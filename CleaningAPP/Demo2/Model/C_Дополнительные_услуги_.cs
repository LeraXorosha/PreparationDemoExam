//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demo2.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class C_Дополнительные_услуги_
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_Дополнительные_услуги_()
        {
            this.C_Услуги_в_зявке_ = new HashSet<C_Услуги_в_зявке_>();
        }
    
        public int id { get; set; }
        public string Название { get; set; }
        public Nullable<double> Стоимость_за_ед_ { get; set; }
        public string Единица { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Услуги_в_зявке_> C_Услуги_в_зявке_ { get; set; }
    }
}
