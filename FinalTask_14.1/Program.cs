using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalTask_14._1
{
	class Program
	{
		public static List<Contact> phoneBook = new List<Contact>();
		static void Main(string[] args)
		{
			InitPhoneBook(); // инициализация книги
			
			int lines = 3; // добавим настройку: число строк на странице
			decimal pages = Math.Ceiling((decimal)phoneBook.Count / lines); // сразу вычисляется количество страниц

			while (true)
			{
				Console.Write("номер страницы (число от 1 до {0}, 0 - выход)", pages);
				
				// с консоли посимвольно читается число
				string strPage = ""; // строковое представление числа
				while (true)
				{
					char input = Console.ReadKey().KeyChar; // поймали символ
					if (Char.IsDigit(input)) strPage += input; // добавили к строковому представлению числа, если цифра
					if (input == '\r') break; // если Enter - закончили отлов символов
				}

				if (strPage == "0") break; // условие выхода из бесконечного цикла

				// проверяем, число ли это
				bool parsed = Int32.TryParse(strPage, out int pageNumber);


				if (!parsed || pageNumber > pages)
				{
					Console.WriteLine();
					Console.WriteLine("Страницы не существует");
				}
				else
				{
					// пропускаем нужное количество элементов и берем сколько указано для показа на странице
					var pageContent = phoneBook
						.OrderBy(x => x.Name)
						.ThenBy(x => x.Age)
						.Skip((pageNumber - 1) * lines)
						.Take(lines);
					
					Console.WriteLine();
					Console.WriteLine($"страница №{pageNumber}");

					// выводим результат
					foreach (var entry in pageContent)
						Console.WriteLine(": {0,-30} : {1:15} : {2,3} :", entry.Name, entry.PhoneNumber, entry.Age); //);
					 
					Console.WriteLine();
				}
			}
		}

		static void InitPhoneBook()
		{
			phoneBook.Add(new Contact("Игорь", "+7 903 999 0001", 19));
			phoneBook.Add(new Contact("Сергей", "+7 905 995 9192", 37));
			phoneBook.Add(new Contact("Анатолий", "+7 913 300 5500", 33));
			phoneBook.Add(new Contact("Валерий", "+7 923 941 0161", 27));
			phoneBook.Add(new Contact("Сергей", "+7 950 297 9990", 22));
			phoneBook.Add(new Contact("Иннокентий", "+7 904 313 4616", 67));
			phoneBook.Add(new Contact("Андрей", "+7 951 994 2424", 23));
			phoneBook.Add(new Contact("Сергей", "+7 991 001 7771", 27));
			phoneBook.Add(new Contact("Дмитрий", "+7 990 990 9090", 29));
			phoneBook.Add(new Contact("Василий", "+7 933 111 8228", 24));
			phoneBook.Add(new Contact("Андрей", "+7 999 945 0051", 44));
			phoneBook.Add(new Contact("Сергей", "+7 999 904 5515", 51));
			phoneBook.Add(new Contact("Иван", "+7 999 967 5321", 36));
			phoneBook.Add(new Contact("Игорь", "+7 901 849 9420", 42));
			phoneBook.Add(new Contact("Анна", "+7 906 655 6565", 29));
			phoneBook.Add(new Contact("Василий", "+7 903 904 3434", 48));      
		}
	}
}
