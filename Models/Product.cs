namespace TableDependencyWithSignalR.Models
{
    public class Product:ModelBase
    {
        public double Price { get; set; }   
        public Category? Category { get; set; }  
    }
}
