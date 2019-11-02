﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2
{
	public class Circle : Figure, IPrint
	{
		double radius;//радиус фигуры
		public Circle() { }
		public Circle(double rad)//конструктор
		{
			this.radius = rad;
			this.Type = "Окружность";
		}
		public override double Area()//переопределяем метод вычисления площади
		{
			double S = Math.Round(Math.Pow(this.radius, 2) * Math.PI, 4);//переопределение функции нахождения площади круга с точностью до 4-ого знака после запятой
			return S;
		}
		public void Print()//вывод данных об объекте
		{
			Console.WriteLine(this.ToString());
		}
	}
}