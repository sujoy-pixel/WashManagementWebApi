namespace Erp.Application.Auth
{
    public class UserForReturnDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string EmployeeId { get; set; }
        public string PhoneNumber { get; set; }

        public int HeadOfficeId { get; set; }
        public int BranchOfficeId { get; set; }
        public string BranchOfficeName { get; set; }
        public string FinYearTitle { get; set; }
        public int FinYearId { get; set; }

    }
}
