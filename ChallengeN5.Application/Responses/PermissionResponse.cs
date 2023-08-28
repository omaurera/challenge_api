using System;
namespace ChallengeN5.Application.Responses
{
	public class PermissionResponse
	{
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public int IdPermissionType { get; set; }
        public string PermissionType { get; set; }
    }
}

