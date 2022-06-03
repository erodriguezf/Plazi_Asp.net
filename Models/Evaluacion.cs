    namespace HolamundoMVC.Models;
     using System.ComponentModel.DataAnnotations;
    using System;
    using System.Collections.Generic;
    public class Evaluación:ObjetoEscuelaBase
    {
        [ Required(ErrorMessage= "El nombre del la evalución es requerido")]
          [MinLength(5,ErrorMessage ="El nombre de la evaluación dede ser de minimo 5 caracteres")]
        public override string Nombre {set;get;}
         public Alumno? Alumno { get; set; }

         public string? AlumnoId { get; set; }

         public Asignatura? Asignatura { get; set; }
        
         public string? AsignaturaId { get; set; }

         public float calificacion { get; set; }

          public override string ToString(){
             return $"{Alumno} {Asignatura} {calificacion}";
         }
    }