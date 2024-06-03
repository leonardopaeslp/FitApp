namespace WebApiExercisio.Models
{
    public class ResponseModel<T>
    {
        public T? Data { get; set; } 
        public string Mensagem {  get; set; }   
        public bool Status { get; set; }    
    }
}
