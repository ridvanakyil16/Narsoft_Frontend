namespace LoomSoft.Panel.Models
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string CompanyCode { get; set; }
        public int DepartmentType { get; set; }

        public virtual List<CompanyLogo> CompanyLogo { get; set; }
        public virtual List<UserCompany> UserCompanies { get; set; }
    }
}
