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
    
    
    public class UsuariosMetaData
    {
    	[Key]
        [Required]
        public virtual int IdUsuario
        {
            get;
            set;
        }
    	
        [StringLength(255, ErrorMessage="El campo no puede ser mayor a 255 caracteres")]
        [Required]
        public virtual string Nombres_
        {
            get;
            set;
        }
    	
        [StringLength(255, ErrorMessage="El campo no puede ser mayor a 255 caracteres")]
        [Required]
        public virtual string Apellidos
        {
            get;
            set;
        }
    	
        [StringLength(255, ErrorMessage="El campo no puede ser mayor a 255 caracteres")]
        [Required]
        public virtual string Correo
        {
            get;
            set;
        }
    	
        [StringLength(255, ErrorMessage="El campo no puede ser mayor a 255 caracteres")]
        [Required]
        public virtual string Clave
        {
            get;
            set;
        }
        [Required]
        public virtual int IdRol
        {
            get;
            set;
    
        }
    }
}
