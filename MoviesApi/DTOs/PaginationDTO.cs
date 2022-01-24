namespace MoviesApi.DTOs
{
    public class PaginationDTO
    {
        public int Page { get; set; } = 1;
        private int recordsperPage = 10;
        private readonly int maxRecordsPerPage = 50;

        public int RecordsPerPage
        {
            get { return recordsperPage; }
            set { recordsperPage = (value > maxRecordsPerPage) ? maxRecordsPerPage : value; }
        }

    }
}
