using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Test
{
	public class Square : Rectangle, IPrint//наследуется от класса Rectangle и реализует интерфес IPtint
	{
		public Square(double side_size) : base(side_size, side_size)
		{
			this.Type = "Квадрат";
		}//конструктор, вызывающий конструтор класса Прямоугольник, но теперь
		 //он принимает длину прямоугольника как сторону квадрата и высоту прямоугольника как сторону квадрата, и передает в конструктор базового класса
		 //так как метод вычисления площади определен в родительском классе Прямоугольник, заново переопределять его не нужно
		 //он корректно выполнится аналогично как и в конструкторе, засчет передачи параметра длины одной стороны как длины и как ширины
	}
}
