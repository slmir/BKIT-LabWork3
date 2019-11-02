using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Test
{
	public class ProgramLR2
	{
		/// <summary>
		/// Version 1.0.6
		/// 
		/// </summary>
			static void Main(string[] args)
			{
				Console.Title = "Мирсонов Вячеслав РТ5-31Б";
				string str = "нет";
				do//цикл выполняется, пока пользователь не завершит выполнение программы
				{
					Console.WriteLine("Выберете одну из предлложенных фигур, площадь которой вы хотите вычислить: \n");
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("1. Прямоугольник \n2. Квадрат \n3. Круг");//вывод возможных вариантов
					Console.ForegroundColor = ConsoleColor.Gray;
					Console.Write("\nВведите номер выбранного варианта: ");
					char v = Convert.ToChar(Console.ReadLine());//ожидание ввода выбранного варианта
					Console.WriteLine("\nВведите следующие значения для выбранной геометрической фигуры");
					switch (v)//для обозначения вводимого коэффициента
					{
						case '1'://если выбран Прямоугольник
							Console.Write("Введите высоту прямоугольника: ");
							double v_rect = Convert.ToDouble(Console.ReadLine());//высота прямоугольника
							Console.Write("Введите ширину прямоугольника: ");
							double w_rect = Convert.ToDouble(Console.ReadLine());//ширина прямоугольника
							Rectangle obj1 = new Rectangle(v_rect, w_rect);//создание объекта класса Прямокгольник и передача введеных ранее параметров в конструктор
							Console.ForegroundColor = ConsoleColor.Green;
							obj1.Print();//вызов метода печати данных об объекте (выбранной геометрической фигуре)
							break;
						case '2':
							Console.Write("Введите длину стороны квадрата: ");
							double cz = Convert.ToDouble(Console.ReadLine());//длина стороны квадрата
							Square obj2 = new Square(cz);//создание объекта класса Квадрат и передача введеного ранее параметра в конструктор
							Console.ForegroundColor = ConsoleColor.Green;
							obj2.Print();//вызов метода печати данных об объекте (выбранной геометрической фигуре)
							break;
						case '3':
							Console.Write("Введите радиус круга: ");
							double rd = Convert.ToDouble(Console.ReadLine());//радиус круга
							Circle obj3 = new Circle(rd);//создание объекта класса Круг и передача введеного ранее параметра в конструктор
							Console.ForegroundColor = ConsoleColor.Green;
							obj3.Print();//вызов метода печати данных об объекте (выбранной геометрической фигуре)
							break;
					}
					Console.ForegroundColor = ConsoleColor.Gray;
					Console.Write("\nДля продолжения работы введите 'да', для прекращения 'нет': ");
					str = Convert.ToString(Console.ReadLine());//строка, вводимая пользователем как ответ на желание продолжить либо прекратить выполнение программы
					Console.Write("\n");
				} while (str == "да");//пока пользователь желает продолжать выполнение программы
				Console.ReadLine();
			}
	}
}
