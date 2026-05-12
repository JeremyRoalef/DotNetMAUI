namespace CITA355_FinalProject
{
    internal class APISearchResponse : APIResponse
    {
        public List<SearchResult> Results { get; set; }

        public APISearchResponse() : base()
        {

        }
    }
}
