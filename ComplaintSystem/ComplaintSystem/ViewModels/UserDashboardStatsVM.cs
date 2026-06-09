namespace ComplaintSystem.ViewModels
{
    public class UserDashboardStatsVM
    {
        public int Total { get; set; }
        public int Pending { get; set; }
        public int InProgress { get; set; }
        public int Resolved { get; set; }
        public int Rejected { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
    }
}
