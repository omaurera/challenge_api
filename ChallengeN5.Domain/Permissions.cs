using ChallengeN5.Domain.Commons;

namespace ChallengeN5.Domain
{
	public class Permissions : BaseDomainModel
	{
		public string EmployeeName { get; set; }
		public string EmployeeLastName { get; set; }
		public int PermissionType { get; set; }
		public DateTime PermissionDate { get; set; }
	}
}

