using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
	public class SimpleListItem<T>//класс - контейнер элемента списка
	{
		public T dataSave { get; set; }//свйоство - предназначено для хранения данных
		public SimpleListItem<T> next { get; set; }//фактически - указатель на следующий элемент списка
		
		public SimpleListItem(T param)//конструктор, передающий в свойство параметр data обобщенного типа T
		{
			this.dataSave = param;
		}
	}
}