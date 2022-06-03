   namespace HolamundoMVC.Models;
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.Collections.Generic;
   public class Escuela:ObjetoEscuelaBase{
        public int? AñoCreacion{get; set;}
    
        public string? Pais { get; set; }
      
        public string? Ciudad { get; set; }
        [Required(ErrorMessage ="Ingrese la direccion")]
         public string Direcion { get; set; }
        public List<Curso>? cursos { get; set; }
        public TipoEscuela TipoEscuela { get; set; }
       
        public Escuela()
        {
          
        }
        public string info() {
           return $" el nombre es: {Nombre},su año:  {AñoCreacion} \n la ciuad es {Ciudad}";
        }

        

    }
