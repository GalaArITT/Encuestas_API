//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Encuestas_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ENC_ROLES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ENC_ROLES()
        {
            this.ENC_USUARIOS = new HashSet<ENC_USUARIOS>();
        }
    
        public decimal IDROLES { get; set; }
        public string TIPOROL { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ENC_USUARIOS> ENC_USUARIOS { get; set; }
    }
}
