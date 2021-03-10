using System;

namespace FinalTask_14._1
{
	/// <summary>
	/// запись контакта из телефонного справочника
	/// </summary>
	public class Contact
	{
		public Contact(string name, string phoneNumber, byte age) // метод-конструктор
		{
			Name = name;
			PhoneNumber = phoneNumber;
			Age = age;
		}

		public string Name { get; }
		public string  PhoneNumber { get; }
		public byte Age { get; }
	}
}
