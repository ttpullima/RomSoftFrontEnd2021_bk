namespace Romsoft.GESTIONCLINICA.Common
{
    public class PaginationParameter
    {
        public string OrderBy { get; set; }
        public int Start { get; set; }
        public int CurrentPage { get; set; }
        public int AmountRows { get; set; }
        public string WhereFilter { get; set; }
    }
}
