using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace StudentInformationManagementSystem
{
	internal class MainClass
	{
		public static void Main(string[] args)
		{
			MainMenu();
			
		}

		public static void MainMenu()
		{
			Console.WriteLine("1. Insertion");
			Console.WriteLine("2. Search");
			Console.WriteLine("3. Sorting Option");
			Console.WriteLine("4. Exit");
			Console.Write(">_");
			int input = Convert.ToInt32(Console.ReadLine());
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
			Console.WriteLine();
		}

		public static void Insertion()
		{
			// 학생 정보 저장
			Console.Write("Name ");
			string name = Console.ReadLine();

			Console.Write("Student ID (10 digits) ");
			int id = Convert.ToInt32(Console.ReadLine());

			Console.Write("Birth Year (4 digits) ");
			int birth = Convert.ToInt32(Console.ReadLine());

			Console.Write("Department ");
			string department = Console.ReadLine();

			Console.Write("Tel ");
			int tel = Convert.ToInt32(Console.ReadLine());

			MainMenu();
		}

		public static void Search()
		{
			// 저장한 학생 정보 탐색
			Console.WriteLine("1.Search by name ");
			Console.WriteLine("2.Search by student ID(10 numbers) ");
			Console.WriteLine("3.Search by admission year(4 numbers) ");
			Console.WriteLine("4.Search by department name ");
			Console.WriteLine("5.List All ");
			Console.Write("> ");
			int input = Convert.ToInt32(Console.ReadLine());

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
			MainMenu();
		}

		public static void SortingOption()
		{
			// 저장한 학생 정보 정렬
			MainMenu();
		}

		public static void Exit()
		{
			// 프로그램 종료
			Console.Write("프로그램을 종료합니다.");
		}

		private static void SearchByName()
		{

		}

		private static void SearchByID()
		{

		}

		private static void SearchByBirth()
		{

		}

		private static void SearchByDepartment()
		{

		}

		private static void ListAll()
		{

		}
	}
}
