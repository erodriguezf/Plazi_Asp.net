
    public class Evaluación:ObjetoEscuelaBase
    {
         public Alumno Alumno { get; set; }

         public Asignatura Asignatura { get; set; }

         public float calificacion { get; set; }

          public override string ToString(){
             return $"{Alumno} {Asignatura} {calificacion}";
         }
    }