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
    
    public partial class ENC_USUARIOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ENC_USUARIOS()
        {
            this.ENC_EMPLEADOS = new HashSet<ENC_EMPLEADOS>();
            this.ENC_ENCUESTAS_APLICADAS = new HashSet<ENC_ENCUESTAS_APLICADAS>();
        }
    
        public decimal IDUSUARIO { get; set; }
        public decimal IDROLES { get; set; }
        public string NOMBREUSUARIO { get; set; }
        public string PASSWORD { get; set; }
        public System.DateTime FECHACREACION { get; set; }
        public string ESTATUS { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ENC_EMPLEADOS> ENC_EMPLEADOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ENC_ENCUESTAS_APLICADAS> ENC_ENCUESTAS_APLICADAS { get; set; }
        public virtual ENC_ROLES ENC_ROLES { get; set; }
    }
}
