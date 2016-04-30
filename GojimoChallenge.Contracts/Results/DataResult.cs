namespace GojimoChallenge.Contracts.Results
{
    public class DataResult<T>
    {
        public DataResult(T data, string eTag = null)
        {
            Data = data;
            Result = Result.Ok;
           if(!string.IsNullOrWhiteSpace(eTag))ETag = eTag;
        }
        public DataResult(Result res)
        {
            Result = res;
        }

        public T Data { get; set; }
        public Result Result { get; set; }

        public string ErrorMessage { get; set; }
        public bool IsOk { get { return Result == Result.Ok; } }

        public string ETag { get; set; }
    }
}