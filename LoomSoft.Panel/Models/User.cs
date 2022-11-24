namespace LoomSoft.Panel.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string RegistrationNumber { get; set; }
        public string MailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int UserLevel { get; set; }
        public bool IsAdmin { get; set; }


        public virtual List<UserRole> UserRoles { get; set; }
        public virtual List<UserDepartment> UserDepartments { get; set; }
        public virtual List<UserPhoto> UserPhotos { get; set; }
        public virtual List<UserCompany> UserCompanies { get; set; }
    }
}
