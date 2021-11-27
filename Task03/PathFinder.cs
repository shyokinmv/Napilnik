namespace Task03
{
    class PathFinder
    {
        ILogWriter _logger;

        public PathFinder(ILogWriter logger)
        {
            _logger = logger;
        }

        public void Find(string target)
        {
            var msg = $"ищем {target}";
            _logger?.WriteError(msg);
        }
    }
}
