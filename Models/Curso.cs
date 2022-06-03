    namespace HolamundoMVC.Models;
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.Collections.Generic;

    public class Curso:ObjetoEscuelaBase
    {
       // [Required(ErrorMessage= "Se requiere incluir una dirección")]
       public string? Direcion { get; set; }
      
       public List<Asignatura>? Asignaturas { get; set; }
       public List<Alumno>? Alumnos { get; set; }
       public TipoJornada TipoJornada { get; set; }
       public string? EscuelaId { get; set; }

       public Escuela? Escuela { get; set; } 

          [Required(ErrorMessage= "El nombre del curso es requerido")]
          [StringLength(5)]
       public override string Nombre {set;get;}

      /* public Curso (string nombre, TipoJornada tipoJornada){
             this.Nombre=nombre;
             this.TipoJornada=TipoJornada;
       }*/

    }
