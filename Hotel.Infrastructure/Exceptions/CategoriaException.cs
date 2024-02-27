public class CategoriaException : Exception
{
    public CategoriaException(string mensaje) : base(mensaje)
    {
        //logica para guardar expecion
        //Despes de guardar se envia por correo
    }
}