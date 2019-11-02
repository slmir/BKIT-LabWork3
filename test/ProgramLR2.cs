using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
	class ProgramLR2
	{
		static void Main(string[] args)
		{
			Console.Title = "Мирсонов Вячеслав РТ5-31Б";
			Rectangle obj1 = new Rectangle(10, 20);//создание объекта класса Прямокгольник и параметров в конструктор
			Square obj2 = new Square(15);//создание объекта класса Квадрат и передача параметра в конструктор
			Circle obj3 = new Circle(20);//создание объекта класса Круг и передача параметра в конструктор
			Console.ForegroundColor = ConsoleColor.Green;
			obj1.Print();//вызов метода печати данных об объекте класса Прямоугольник
			obj2.Print();//вызов метода печати данных об объекте класса Квадрат          
			obj3.Print();//вызов метода печати данных об объекте класса Окружность         
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.ReadLine();
		}
	}
}