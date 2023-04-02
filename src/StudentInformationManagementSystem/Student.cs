using System;

namespace StudentInformationManagementSystem
{
	public class Student
	{
		public string name;
		public string id;
		public string birth;
		public string department;
		public string tel;

		public Student(string name, string id, string birth, string department, string tel)
		{
			this.name = name;
			this.id = id;
			this.birth = birth;
			this.department = department;
			this.tel = tel;
		}
	}
}
