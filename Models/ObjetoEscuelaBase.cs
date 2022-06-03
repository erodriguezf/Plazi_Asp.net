    namespace HolamundoMVC.Models;
    public abstract class ObjetoEscuelaBase
    {
        public virtual string  Nombre { get; set; } 
         public string Id { get;  set; }  

         public ObjetoEscuelaBase(){
             this.Id =Guid.NewGuid().ToString();
         }

         public override string ToString(){
             return $"{Nombre} {Id}";
         }
    }