using System;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace StudentInformationManagementSystem
{
	// TODO(이태환): 프린트 메소드와 기능 메소드 분류
	internal class MainClass
	{
		public static string format = "{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}";

		// 리스트나 벡터를 사용해도 무방
		public static Dictionary<string, Student> students = new Dictionary<string, Student>();

		public static void Main(string[] args)
		{
			if (File.Exists("C:\\Users\\YongHo\\Student-Information-Management-System\\file1.txt"))
			{
				Load();
			}
			// 재귀 안되도록
			while (MainMenu()) { }
		}

		private static void Load()
		{
			// using을 안쓰면 reader.Close() 사용 필요
			StreamReader reader = new StreamReader("C:\\Users\\YongHo\\Student-Information-Management-System\\file1.txt");
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
				reader.Close();
			}
		}

		// 함수명은 동사로
		public static bool MainMenu()
		{
			Console.WriteLine("1. Insertion");
			Console.WriteLine("2. Search");
			Console.WriteLine("3. Sorting Option");
			Console.WriteLine("4. Exit");
			Console.Write(">");
			int input = Convert.ToInt32(Console.ReadLine());

			// 잘못된 숫자 입력 시 디폴트문 내용이 없어서 종료 됨 (예외 처리 필요)
			// 잘못된 숫자를 입력해도 switch문에는 진입은 함
			bool terminateFlag = true;
			Console.WriteLine();
			switch (input)
			{
				case 1:
					Insertion();
					//terminateFlag = true;
					break;

				case 2:
					Search();
					//terminateFlag = true;
					break;

				case 3:
					SortingOption();
					//terminateFlag = true;
					break;

				case 4:
					Console.Write("프로그램을 종료합니다.");
					terminateFlag = false;
					break;
			}
			return terminateFlag;
		}

		public static void Insertion()
		{
			Console.Write("Name ");
			string name = Console.ReadLine();
			if (name.Length > 15)
			{
				throw new ArgumentException("Student ID must be 10 digits");
			}

			Console.Write("Student ID (10 digits) ");
			string id = Console.ReadLine();
			if (id.Length != 10)
			{
				throw new ArgumentException("Student ID must be 10 digits");
			}

			Console.Write("Birth Year (4 digits) ");
			string birth = Console.ReadLine();
			if (birth.Length != 4)
			{
				throw new ArgumentException("birth length must be 4 characters");
			}

			Console.Write("Department ");
			string department = Console.ReadLine();

			Console.Write("Tel ");
			string tel = Console.ReadLine();

			// try catch는 비정상적인 값이 입력됐을때 사용하면 좋음
			// 지금 경우는 단순히 중복되는 단어이므로 containskey를 사용해서 예외처리
			if (students.ContainsKey(id))
			{
				Console.WriteLine();
				Console.WriteLine("Error : Already inserted");
			}
			else
			{
				Student student = new Student(name, id, birth, department, tel);
				students.Add(id, student);
				students = SortByName(students);
				Save(students);
			}
			Console.WriteLine();
		}

		public static void Save(Dictionary<string, Student> students)
		{
			using (StreamWriter writer = new StreamWriter("C:\\Users\\YongHo\\Student-Information-Management-System\\file1.txt"))
			{
				foreach (Student student in students.Values)
				{
					writer.WriteLine("{0},{1},{2},{3},{4}", student.name, student.id, student.birth, student.department, student.tel);
				}
			}
		}

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
		}

		// TODO(이태환): PrintStudent 메소드 필요, 매개변수는 Student student
		private static void SearchByName()
		{
			Console.Write("Name keyword? ");
			string name = Console.ReadLine();
			Console.WriteLine(format, "Name", "StudentID", "Dept", "Birth Year", "Tel");
			bool dataExist = false;

			// Map은 이렇게 접근
			if (students.ContainsKey(name))
			{
				Student student = students[name];
				Console.WriteLine(format, student.name, student.id, student.department, student.birth, student.tel);
			}
			else
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
		}

		// 코드 분석 필요
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
	}
}
