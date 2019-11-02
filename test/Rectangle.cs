using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2
{
	public class Rectangle : Figure, IPrint
	{
			double high;//высота прямоугольника
			double wdth;//ширина прямоугольника
			public Rectangle() { }
			public Rectangle(double hg, double wd)//конструктор
			{
				this.high = hg;
				this.wdth = wd;
				this.Type = "Прямоугольник";
			}
			public override double Area()//переопределнный метод вычисления площади
			{
				double S = Math.Round(this.wdth * this.high, 4);//переопределение функции нахождения площади круга с точностью до 4-ого знака после запятой
				return S;
			}
			public void Print()//метод печати данных об объекте
			{
				Console.WriteLine(this.ToString());
			}
	}
}