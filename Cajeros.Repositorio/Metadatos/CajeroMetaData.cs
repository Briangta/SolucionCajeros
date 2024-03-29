//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template made by Louis-Guillaume Morand.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace Cajeros.Repositorio
{
    
    
    public class CajeroMetaData
    {
    	[Key]
        [Required]
        public virtual int IdCajero
        {
            get;
            set;
        }
    	
        [StringLength(255, ErrorMessage="El campo no puede ser mayor a 255 caracteres")]
        [Required]
        public virtual string Nombre
        {
            get;
            set;
        }
    	
        [StringLength(255, ErrorMessage="El campo no puede ser mayor a 255 caracteres")]
        public virtual string Lat
        {
            get;
            set;
        }
    	
        [StringLength(255, ErrorMessage="El campo no puede ser mayor a 255 caracteres")]
        public virtual string Lng
        {
            get;
            set;
        }
    }
}
