using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
	public class SimpleStack<T> : SimpleList<T> where T : IComparable//наследуется от класса односвязного списка
	{
		public void Push(T elem)//запись в стек
		{
			Add(elem);//добавление в конец списка
		}

		public T Pop()//чтение с удалением из стека, вершина - конец списка(LIFO)
		{
			T res = default(T);//значение для данного типа Т по умолчанию
			if (this.Count == 0)//если список пуст
				return res;
			if (this.Count == 1)//если список сотсоит из единственного элемента
			{
				//возвращаются его данные и список переводится в состояние пустого
				res = this.FirstListElem.dataSave;
				this.FirstListElem = null;
				this.LastListElem = null;
			}
			else//в списке больше одного элемента
			{
				SimpleListItem<T> newLastElem = this.GetElemNumb(this.Count - 2);//новым последним ставится предпоследний элемент списка
																				 //Чтение значения из последнего элемента
				res = LastListElem.dataSave;//записываем в результат последний эемент
				this.LastListElem = newLastElem;//теперь предпоследний элемент считается последним
				newLastElem.next = null;//последний элемент удаляется из списка
			}
			this.Count--;//уменьшение количества элементов в списке
			return res;
		}

	}
}