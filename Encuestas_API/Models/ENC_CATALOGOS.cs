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
    
    public partial class ENC_CATALOGOS
    {
        public decimal IDCATALOGO { get; set; }
        public decimal IDTIPOCAT { get; set; }
        public string DATOSDELCATALOGO { get; set; }
    
        public virtual ENC_TIPOCATALOGO ENC_TIPOCATALOGO { get; set; }
    }
}