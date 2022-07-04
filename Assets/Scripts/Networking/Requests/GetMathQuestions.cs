namespace Networking.Requests
{
    public struct GetMathQuestions : INetworkRequest
    {
        public string BasePath
        {
            get => NetworkRequest.MathQuestionsBaseUrl;
            set => throw new System.NotImplementedException();
        }

        public string Path
        {
            get => "questions";
            set => throw new System.NotImplementedException();
        }

        public object RequestBody
        {
            get => null;
            set => throw new System.NotImplementedException();
        }

        public Method Method
        {
            get => Method.Get;
            set => throw new System.NotImplementedException();
        }
    }
}