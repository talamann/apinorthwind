namespace apinorthwind.Logging
{
    public class APILogService
    {
        private readonly APILogDbContext _dbContext;

        public APILogService(APILogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void LogApiDetails(APILog apiLog)
        {
            _dbContext.APILogs.Add(apiLog);
            _dbContext.SaveChanges();
        }
    }
}
