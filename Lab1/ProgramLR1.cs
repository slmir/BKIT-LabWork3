using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
//commit
{
	class ProgramLR1
	{
		static double Dec(double a, double b, double c)//вычисление и проверка дискриминанта
		{
			double dec = Math.Pow(b, 2) - 4 * a * c;//дискриминант
			if (dec >= 0)
				return dec;
			else
			{
				NoDecision();
				return 0;
			}
		}
		static void NoDecision()//при отсутсвии решений
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Решений нет");
			Console.ReadLine();
			Environment.Exit(0);//остановка выполнения, так как решений нет
		}
		static void Decisions(double y1, double y2)//вывод решений, получает на вход решения y1 и у2, которые соответсвуют квадратам возможных решений х1, х2, х3, х4
		{
			double x1 = 0;
			double x2 = 0;
			double x3 = 0;
			double x4 = 0;
			Console.ForegroundColor = ConsoleColor.Green;
			if (y1 == 0 && y2 != 0)//если решение у1 равно 0
			{
				x1 = 0;
				x2 = 0;
				x3 = Math.Sqrt(y2);
				x4 = -Math.Sqrt(y2);
			}
			if (y1 != 0 && y2 == 0)//если решение у2 равно 0
			{
				x3 = 0;
				x4 = 0;
				x1 = Math.Sqrt(y1);
				x2 = -Math.Sqrt(y1);
			}
			if (y1 == 0 && y2 == 0)//единственно возмонжое решение равно 0
			{
				x1 = 0;
				x2 = 0;
				Console.WriteLine("Решения: x1 = {0}", x1);
				Console.ReadLine();
				Environment.Exit(0);//остановка выполнения, так как решения обработаны
			}
			if (y1 != 0 && y2 != 0)//2 или больше возможных решений
			{
				x1 = Math.Sqrt(y1);
				x2 = -Math.Sqrt(y1);
				x3 = Math.Sqrt(y2);
				x4 = -Math.Sqrt(y2);
			}
			if ((y1 >= 0 && y2 < 0) || (x1 == x3))//вывод если решения дает только у1 или у1=у2
			{
				Console.WriteLine("Решения: x1 = {0}, x2 = {1}", x1, x2);
				Console.ReadLine();
				Environment.Exit(0);//остановка выполнения, так как решения обработаны
			}
			if (y1 < 0 && y2 >= 0)
			{
				Console.WriteLine("Решения: x1 = {0}, x2 = {1}", x3, x4);
				Console.ReadLine();
				Environment.Exit(0);//остановка выполнения, так как решения обработаны
			}
			if (y1 >= 0 && y2 >= 0)
				if (x1 == 0)
					Console.WriteLine("Решения: x1 = {0}, x2 = {1}, x3 = {2}", x1, x3, x4);
				else if (x3 == 0)
					Console.WriteLine("Решения: x1 = {0}, x2 = {1}, x3 = {2}", x1, x2, x3);
				else
					Console.WriteLine("Решения: x1 = {0}, x2 = {1}, x3 = {2}, x4 = {3}", x1, x2, x3, x4);
		}
		static bool Check(string A)//проверка корректности введеных коэффициентов
		{
			double coeff;
			if (Double.TryParse(A, out coeff))//возвращает значение булевого типа, если строку удалось преобразовать в число с плавающей точкой
				return true;
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine();
				Console.WriteLine("Значение коэффициента введено некорректно, попробуйте еще раз");
				return false;
			}
		}
		static double Ent(char v)//ввод коэффициента, получает на вход символ обрабатываемого в данный моммент коэффициента
		{
			switch (v)//для обозначения вводимого коэффициента
			{
				case 'a':
					Console.Write("Введите коэфициент А: ");
					break;
				case 'b':
					Console.Write("Введите коэфициент B: ");
					break;
				case 'c':
					Console.Write("Введите коэфициент C: ");
					break;
			}
			string A = Console.ReadLine();
			bool pv = Check(A);
			if (pv == true)//введено корректно
				return Convert.ToDouble(A);
			else//введено некорректно - повторный ввод нужного коэффициента
			{
				Console.ForegroundColor = ConsoleColor.Gray;
				return Ent(v);
			}
		}

		static void Main(string[] args)
		{
			double x = -1;
			double y1 = -1;
			double y2 = -1;
			double deck;
			Console.Title = "Мирсонов Вячеслав РТ5-31Б";
			/*Ввод и проверка корректности коэффициентов*/
			Console.WriteLine("Пожалуйста, введите коэфициенты биквадратного уравнения, используя символы:");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("0 1 2 3 4 5 6 7 8 9 ',' /* запятая */ '-' /* минус */ ");
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine();
			double a = Ent('a');
			double b = Ent('b');
			double c = Ent('c');
			Console.WriteLine("Коэффициенты: A = {0}, B = {1}, C = {2}", a, b, c);

			/*Обработка коэфициентов*/
			/*АЛГОРИТМ РЕШЕНИЯ: ЗАМЕНА у = х^2 C ПОСЛЕДУЮЩИМ РЕШЕНИЕМ КВАДРАТНОГО УРАВНЕНИЯ ОТНОСИТЕЛЬНО у. ПОСЛЕ ВЫЧЕСЛЕНИЯ у1 и у2 ВОЗВРАЩАЕМСЯ К ЗАМЕНЕ И НАХОДИМ х СООТВЕТСВЕННО*/
			if (a == 0 && b != 0)//есть коэффициент при х4
			{
				y1 = ((-1) * c) / b;
				if (y1 < 0)
					NoDecision();
			}
			if (b == 0 && a != 0)//есть коэффициент при х2
			{
				x = ((-1) * c) / a;
				y1 = Math.Sqrt(x);//сразу присваиваем решениям у1,2 + и - корень из x^4 = ... соответсвенно
				y2 = -Math.Sqrt(x);
				if (x < 0)
					NoDecision();
			}
			if (a == 0 && b == 0 && c != 0)//нулевые коэффициенты при х4, х2
				NoDecision();
			if (a == 0 && b == 0 && c == 0)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Решений бесконечно много");
				Console.ReadLine();
				Environment.Exit(0);//остановка выполнения, так как решения обработаны
			}
			if (a != 0 && b != 0)//не нулевые коэффициенты при х4, х2
			{
				if (c == 0)
				{
					y1 = ((-1) * b) / a;
					y2 = 0;
				}
				else
				{
					deck = Dec(a, b, c);//вычисление дискриминанта
					y1 = (((-1) * b) + Math.Sqrt(deck)) / (2 * a);
					y2 = (((-1) * b) - Math.Sqrt(deck)) / (2 * a);
				}
			}
			if (y1 >= 0 || y2 >= 0)//хотя бы одно решение неотрицательно
				Decisions(y1, y2);
			else
				NoDecision();
			Console.ReadLine();
		}
	}
}
