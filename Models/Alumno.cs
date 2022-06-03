     using System.ComponentModel.DataAnnotations;
    using System;
    using System.Collections.Generic;
    namespace HolamundoMVC.Models;
    public class Alumno:ObjetoEscuelaBase
    {
         public List<Evaluación>? evaluaciones { get; set; } 
         public string? CursoId { get; set; } 
         public Curso? Curso { get; set; }

             [Required(ErrorMessage= "El nombre del estudiante es requerido")]
          public override string Nombre {set;get;}
    }
