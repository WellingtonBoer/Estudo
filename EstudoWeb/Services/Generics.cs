namespace EstudoWeb.Services
{
    public interface IGenericRepository<T> where T : class
    {
        void Adicionar(T obj);
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public void Adicionar(T obj)
        {
            //Adicionar algo

            //Vá lá no Startup olhar como que se configura isso pra injetar certinho.
        }
    }
}
