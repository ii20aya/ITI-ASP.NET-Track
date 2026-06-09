namespace ComplaintSystem.ViewModels
{
    public class DashboardStatsVM
    {
        public int Total { get; set; }
        public int Pending { get; set; }
        public int InProgress { get; set; }
        public int Resolved { get; set; }
        public int Rejected { get; set; }
    }
}
