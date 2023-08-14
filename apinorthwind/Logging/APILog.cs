namespace apinorthwind.Logging
{
    public class APILog
    {
        public int Id { get; set; }
        public string RequestUrl { get; set; }
        public string HttpMethod { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }
        public DateTime timeof { get; set; }   
        public string EndPoint { get; set; }
    }
}
