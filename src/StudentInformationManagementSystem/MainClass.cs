using System;
using System.Runtime.CompilerServices;
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
		// 학생 정보 Dictionary로 저장
		public static Dictionary<string, Student> students = new Dictionary<string, Student>();

		public static void Main(string[] args)
		{
			if (File.Exists("C:\\Users\\YongHo\\Student-Information-Management-System\\students.txt"))
			{
				students = Load();
			}
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
			students = SortByName(students);
			Save(students);
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
					SearchByID();
					break;

				case 3:
					SearchByBirth();
					break;

				case 4:
					SearchByDepartment();
					break;

				case 5:
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
					students = SortByName(students);
					Console.WriteLine("Sort by name complete");
					break;

				case 2:
					students = SortByID(students);
					Console.WriteLine("Sort by ID complete");
					break;

				case 3:
					students = SortByBirth(students);
					Console.WriteLine("Sort by Admission Year complete");
					break;

				case 4:
					students = SortByDepartment(students);
					Console.WriteLine("Sort by Department name complete");
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

		public static string format = "{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}";
		private static void SearchByName()
		{
			Console.Write("Name keyword? ");
			string name = Console.ReadLine();
			Console.WriteLine(format, "Name", "StudentID", "Dept", "Birth Year", "Tel");
			bool dataExist = false;
			foreach (Student student in students.Values)
			{
				if (student.name == name)
				{
					Console.WriteLine(format, student.name, student.id, student.department, student.birth, student.tel);
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
			Console.WriteLine(format, "Name", "StudentID", "Dept", "Birth Year", "Tel");
			bool dataExist = false;
			foreach (Student student in students.Values)
			{
				if (student.id == id)
				{
					Console.WriteLine(format, student.name, student.id, student.department, student.birth, student.tel);
					dataExist = true;
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
			Console.WriteLine(format, "Name", "StudentID", "Dept", "Birth Year", "Tel");
			bool dataExist = false;
			foreach (Student student in students.Values)
			{
				if (student.birth == birth)
				{
					Console.WriteLine(format, student.name, student.id, student.department, student.birth, student.tel);
					dataExist = true;
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
			Console.WriteLine(format, "Name", "StudentID", "Dept", "Birth Year", "Tel");
			bool dataExist = false;
			foreach (Student student in students.Values)
			{
				if (student.department == department)
				{
					Console.WriteLine(format, student.name, student.id, student.department, student.birth, student.tel);
					dataExist = true;
				}
			}
			if (!dataExist)
			{
				Console.WriteLine("Data does not exist.");
			}
		}

		private static void ListAll()
		{
			Console.WriteLine(format, "Name", "StudentID", "Dept", "Birth Year", "Tel");
			foreach (Student student in students.Values)
			{
				Console.WriteLine(format, student.name, student.id, student.department, student.birth, student.tel);
			}
		}

		private static Dictionary<string, Student> SortByName(Dictionary<string, Student> students)
		{
			return students.OrderBy(x => x.Value.name).ToDictionary(x => x.Key, x => x.Value);
		}

		private static Dictionary<string, Student> SortByID(Dictionary<string, Student> students)
		{
			return students.OrderBy(x => x.Value.id).ToDictionary(x => x.Key, x => x.Value);
		}

		private static Dictionary<string, Student> SortByBirth(Dictionary<string, Student> students)
		{
			return students.OrderBy(x => x.Value.birth).ToDictionary(x => x.Key, x => x.Value);
		}

		private static Dictionary<string, Student> SortByDepartment(Dictionary<string, Student> students)
		{
			return students.OrderBy(x => x.Value.department).ToDictionary(x => x.Key, x => x.Value);
		}

		public static void Save(Dictionary<string, Student> students)
		{
			using (StreamWriter writer = new StreamWriter("C:\\Users\\YongHo\\Student-Information-Management-System\\students.txt"))
			{
				foreach (Student student in students.Values)
				{
					writer.WriteLine("{0}, {1}, {2}, {3}, {4}", student.name, student.id, student.birth, student.department, student.tel);
				}
			}
		}

		public static Dictionary<string, Student> Load()
		{
			using (StreamReader reader = new StreamReader("C:\\Users\\YongHo\\Student-Information-Management-System\\students.txt"))
			{
				string line;
				while ((line = reader.ReadLine()) != null)
				{
					string[] fields = line.Split(',');
					string name = fields[0];
					string id = fields[1];
					string birth = fields[2];
					string department = fields[3];
					string tel = fields[4];

					Student student = new Student(name, id, birth, department, tel);
					students.Add(id, student);
				}
			}

			return students;
		}
	}
}
