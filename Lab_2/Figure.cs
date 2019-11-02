using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2Test
{
	public abstract class Figure : IComparable
	{
		public string Type { get; set; }
		public abstract double Area();
		public override string ToString()
		{
			return this.Type + " площадью " + this.Area().ToString();
		}
		public int CompareTo(object obj)
		{
			Figure f = (Figure)obj;
			//Сравнение
			if (this.Area() < f.Area())
				return -1;//если площадь текущего объекта меньше площади передаваемого объекта
			else
			{
				if (this.Area() == f.Area())
					return 0;//если площади текущего и передаваемого объектов равно
				else
					return 1;//если площадь текущего больше, чем площадь передаваемого
			}
		}
	}
}
