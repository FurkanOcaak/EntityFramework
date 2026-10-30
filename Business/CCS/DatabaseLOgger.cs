namespace Business.CCS
{
    public class DatabaseLOgger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Veritabanına Loglandı");
        }
    }

}
