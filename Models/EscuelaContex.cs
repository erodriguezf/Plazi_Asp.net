using Microsoft.EntityFrameworkCore;

namespace HolamundoMVC.Models
{
    public class EscuelaContex: DbContext
    {
        public DbSet<Escuela> Escuelas {get; set;}
        public DbSet<Asignatura> Asignaturas {get; set;}
        public DbSet<Alumno> Alumnos {get; set;}
         public DbSet<Curso> Cursos {get; set;}
        public DbSet<Evaluación> Evaluaciones {get; set;}

        public EscuelaContex(DbContextOptions<EscuelaContex> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            var EscuelaN = new Escuela();
                 EscuelaN.Nombre="Plazi Go";
                 EscuelaN.AñoCreacion=2010;
                 EscuelaN.Id= Guid.NewGuid().ToString();
                 EscuelaN.Ciudad="Bogotá";
                 EscuelaN.Pais="Colombia";
                 EscuelaN.Direcion="Cra 6ta con calle 75";
                 EscuelaN.TipoEscuela=TipoEscuela.secuandaria;
                 
                 var Cursos = CargarCursos(EscuelaN);

                 var Asignaturas= CargarAsignaturas(Cursos);

                 var Alumnos= CargarAlumnos(Cursos);

                 var Evaluaciones= CargarEvaluaciones(Asignaturas,Alumnos);

                  modelBuilder.Entity<Escuela>().HasData(EscuelaN);

                  modelBuilder.Entity<Curso>().HasData(Cursos.ToArray());

                  modelBuilder.Entity<Asignatura>().HasData(Asignaturas.ToArray());

                  modelBuilder.Entity<Alumno>().HasData(Alumnos.ToArray());

                 modelBuilder.Entity<Evaluación>().HasData(Evaluaciones.ToArray());


        }

        private List<Alumno> GenerarAlumnosAlAzar(Curso curso, int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { 
                                   CursoId=curso.Id,
                                   Nombre = $"{n1} {n2} {a1}" ,
                                   Id=Guid.NewGuid().ToString()
                                   };

            return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
        }

        public static  List<Curso> CargarCursos(Escuela EscuelaN){
            return new List<Curso>(){
                        new Curso(){Id = Guid.NewGuid().ToString(), EscuelaId = EscuelaN.Id, Nombre = "101",TipoJornada = TipoJornada.diurna,Direcion="Okala14"},
                        new Curso() {Id = Guid.NewGuid().ToString(), EscuelaId = EscuelaN.Id, Nombre = "201", TipoJornada = TipoJornada.diurna,Direcion="Okala141"},
                        new Curso ()  {Id = Guid.NewGuid().ToString(), EscuelaId = EscuelaN.Id, Nombre = "301", TipoJornada =TipoJornada.diurna,Direcion="Okala141"},
                        new Curso() {Id = Guid.NewGuid().ToString(), EscuelaId = EscuelaN.Id, Nombre = "401", TipoJornada =TipoJornada.vipespectina,Direcion="Okala141" },
                        new Curso() {Id = Guid.NewGuid().ToString(), EscuelaId = EscuelaN.Id, Nombre = "501",TipoJornada = TipoJornada.vipespectina,Direcion="Okala141"},
                       };
        }

         private List<Alumno> CargarAlumnos(List<Curso> cursos)
        {
            var listaAlumnos = new List<Alumno>();

            Random rnd = new Random();
            foreach (var curso in cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                var tmplist = GenerarAlumnosAlAzar(curso, cantRandom);
                listaAlumnos.AddRange(tmplist);
            }
            return listaAlumnos;
        }

         public static List<Asignatura> CargarAsignaturas(List<Curso> Cursos){
             var Listacompleta = new List<Asignatura>();
              foreach (var curso in Cursos)
                {
                    var templist = new List<Asignatura> {
                            new Asignatura{ Id = Guid.NewGuid().ToString(), CursoId = curso.Id,Nombre="Matemáticas"} ,
                            new Asignatura{Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre="Educación Física"},
                            new Asignatura{Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre="Castellano"},
                            new Asignatura{Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre="Ciencias Naturales"},
                            new Asignatura{Id = Guid.NewGuid().ToString(), CursoId = curso.Id, Nombre="Programación"}

                   }; 
                   Listacompleta.AddRange(templist);
                  // curso.Asignaturas=templist;
                }
                return Listacompleta;
             }

             public static List<Evaluación> CargarEvaluaciones(List<Asignatura> asignaturas,List<Alumno> alumnos){
                var Listacompleta = new List<Evaluación>();
                var rdn = new Random();
                foreach(var asignatura in asignaturas  ){
                    foreach(var alumno in alumnos){
                     var templist = new List<Evaluación> {
                            new Evaluación{ Id = Guid.NewGuid().ToString(),AsignaturaId=asignatura.Id, Nombre=$"evaluacion de {asignatura.Nombre}",AlumnoId=alumno.Id
                            ,calificacion= MathF.Round((5*(float)rdn.NextDouble()),2)} ,
                     };
                      Listacompleta.AddRange(templist);
                   };  
                }
                 return Listacompleta;
             }

    }
}