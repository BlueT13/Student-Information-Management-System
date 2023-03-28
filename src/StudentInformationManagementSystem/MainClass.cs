using System;
using System.Xml.Linq;

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

	internal class MainClass
	{
		public static void Main(string[] args)
		{
			MainMenu();
		}

		// 메인 메뉴
		public static void MainMenu()
		{
			Console.WriteLine("1. Insertion");
			Console.WriteLine("2. Search");
			Console.WriteLine("3. Sorting Option");
			Console.WriteLine("4. Exit");
			Console.Write(">");
			int input = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine();
			switch (input)
			{
				case 1:
					Insertion();
					break;

				case 2:
					Search();
					break;

				case 3:
					SortingOption();
					break;

				case 4:
					Exit();
					return;
			}
		}

		// 학생 정보 Dictionary로 저장
		public static Dictionary<string, Student> students = new Dictionary<string, Student>();

		// 학생 정보 입력
		public static void Insertion()
		{
			Console.Write("Name ");
			string name = Console.ReadLine();

			Console.Write("Student ID (10 digits) ");
			string id = Console.ReadLine();

			Console.Write("Birth Year (4 digits) ");
			string birth = Console.ReadLine();

			Console.Write("Department ");
			string department = Console.ReadLine();

			Console.Write("Tel ");
			string tel = Console.ReadLine();

			Student student = new Student(name, id, birth, department, tel);
			students.Add(id, student);
			Console.WriteLine();
			MainMenu();
		}

		// 학생 정보 탐색
		public static void Search()
		{
			Console.WriteLine("1. Search by name");
			Console.WriteLine("2. Search by student ID (10 numbers)");
			Console.WriteLine("3. Search by admission year (4 numbers)");
			Console.WriteLine("4. Search by department name");
			Console.WriteLine("5. List All");
			Console.Write(">");
			int input = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine();
			switch (input)
			{
				case 1:
					SearchByName();
					break;

				case 2:
					Console.WriteLine();
					SearchByID();
					break;

				case 3:
					Console.WriteLine();
					SearchByBirth();
					break;

				case 4:
					Console.WriteLine();
					SearchByDepartment();
					break;

				case 5:
					Console.WriteLine();
					ListAll();
					break;
			}
			Console.WriteLine();
			MainMenu();
		}

		// 학생 정보 정렬
		public static void SortingOption()
		{
			Console.WriteLine("1. Sort by name");
			Console.WriteLine("2. Sort by student ID");
			Console.WriteLine("3. Sort by Admission Year");
			Console.WriteLine("4. Sort by Department name");
			Console.Write(">");
			int input = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine();
			switch (input)
			{
				case 1:
					SortByName();
					break;

				case 2:
					Console.WriteLine();
					SortByID();
					break;

				case 3:
					Console.WriteLine();
					SortByBirth();
					break;

				case 4:
					Console.WriteLine();
					SortByDepartment();
					break;
			}
			Console.WriteLine();
			MainMenu();
		}

		// 프로그램 종료
		public static void Exit()
		{
			Console.Write("프로그램을 종료합니다.");
		}

		private static void SearchByName()
		{
			Console.Write("Name keyword? ");
			string name = Console.ReadLine();
			Console.WriteLine("Name\tStudentID\tDept\t\tBirth Year\tTel");
			bool dataExist = false;
			foreach (Student student in students.Values)
			{
				if (student.name == name)
				{
					Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", student.name, student.id, student.department, student.birth, student.tel);
					dataExist = true;
				}
			}
			if (!dataExist)
			{
				Console.WriteLine("Data does not exist.");
			}
		}

		private static void SearchByID()
		{
			Console.Write("ID keyword? ");
			string id = Console.ReadLine();
			Console.WriteLine("Name\tStudentID\tDept\t\tBirth Year\tTel");
			bool dataExist = false;
			foreach (Student student in students.Values)
			{
				if (student.id == id)
				{
					Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", student.name, student.id, student.department, student.birth, student.tel);
				}
			}
			if (!dataExist)
			{
				Console.WriteLine("Data does not exist.");
			}
		}

		private static void SearchByBirth()
		{
			Console.Write("Birth keyword? ");
			string birth = Console.ReadLine();
			Console.WriteLine("Name\tStudentID\tDept\t\tBirth Year\tTel");
			bool dataExist = false;
			foreach (Student student in students.Values)
			{
				if (student.birth == birth)
				{
					Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", student.name, student.id, student.department, student.birth, student.tel);
				}
			}
			if (!dataExist)
			{
				Console.WriteLine("Data does not exist.");
			}
		}

		private static void SearchByDepartment()
		{
			Console.Write("Department name keyword? ");
			string department = Console.ReadLine();
			Console.WriteLine("Name\tStudentID\tDept\t\tBirth Year\tTel");
			bool dataExist = false;
			foreach (Student student in students.Values)
			{
				if (student.department == department)
				{
					Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", student.name, student.id, student.department, student.birth, student.tel);
				}
			}
			if (!dataExist)
			{
				Console.WriteLine("Data does not exist.");
			}
		}

		private static void ListAll()
		{
			Console.WriteLine("Name\tStudentID\tDept\t\tBirth Year\tTel");
			foreach (Student student in students.Values)
			{
				Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", student.name, student.id, student.department, student.birth, student.tel);
			}
		}

		private static void SortByName()
		{

		}

		private static void SortByID()
		{

		}

		private static void SortByBirth()
		{

		}

		private static void SortByDepartment()
		{

		}
	}
}
