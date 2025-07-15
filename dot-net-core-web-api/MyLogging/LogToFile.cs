namespace dot_net_core_web_api.MyLogging
{
    public class LogToFile :IMyLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("LogToFile");
        }
    }
}
