using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
	public class SimpleList<T> : IEnumerable<T>//наследование от встроенного интерфейса перечисления
		where T : IComparable
	{
		/*первый и последний элементы списка ставим под защиту для работы исключительно в данном классе*/
		//ссылки на контейнеры 
		protected SimpleListItem<T> FirstListElem = null;//первый 
		protected SimpleListItem<T> LastListElem = null;//последний 
		int count;//защищенное свойство, показывающее количество контейнеров односвязного списка
		public int Count//свойство, показывающее количество контейнеров
		{
			get
			{
				return count;
			}
			protected set/*защищенный тип метода установки значения 
			количества контейнера выбран для работы с количеством контейнера исключительно
			в данном классе или его наследниках без возможности изменить это количество в какой-либо другой части программы*/
			{
				count = value;
			}
		}
		public void Add(T element)//метод добавления элемента в конец списка
		{
			SimpleListItem<T> newItem = new SimpleListItem<T>(element);//создание нового контейнера элемента на основе переданных данных
			this.Count++;
			/*добавление контейнера к цепочке контейнеров*/
			if (LastListElem == null)//добавление первого контейнера в список (только для самого первого элента, добавленного в список)
			{
				//список из одного контейнера
				this.FirstListElem = newItem;
				this.LastListElem = newItem;
			}
			else//добавление следующих контейнеров
			{
				this.LastListElem.next = newItem;//присоединение элемента к цепочке
				this.LastListElem = newItem;//установка присоединенног элемента в качестве полседнего
			}
		}

		public SimpleListItem<T> GetElemNumb(int numb)//получение контейнера по его порядковому номеру
		{
			SimpleListItem<T> temp = this.FirstListElem;//создание текущего контейнера и задание его равным первому элементу списка
			int k = 0;//внутренний счетчик
			while (k < numb)//пропускаем нужное количество контейнеров путем прохождения от первого до переданного при помощи next так как список односвязный
			{
				temp = temp.next;//переход к следующему контейнеру
				k++;
			}
			if ((numb < 0) || (numb >= this.Count))//выход за границы
			{
				throw new Exception("Выход за допустимыйе границы номеров элементов");
			}
			return temp;
		}
		public T Get(int number)//возвращает данные требуемого контейнера
		{
			return GetElemNumb(number).dataSave;
		}

		public IEnumerator<T> GetEnumerator()//перебор всех элементов списка и их возврат
		{
			SimpleListItem<T> current = this.FirstListElem;
			while (current != null)//перебор элементов
			{
				yield return current.dataSave;//возврат текущего значения
				current = current.next;//переход к следующему элементу
			}
		}

		//вызывает обобщенную реализацию GetEnumerator
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Sort()//сортировка
		{
			Sort(0, this.Count - 1);
		}
		private void Sort(int low, int high)//быстрая сортировка
		{
			int i = low;
			int j = high;
			T x = Get((low + high) / 2);//средний элемент коллекции, который предположительно на своем месте
			do
			{
				while (Get(i).CompareTo(x) < 0)
					++i;
				while (Get(j).CompareTo(x) > 0)
					--j;
				if (i <= j)
				{
					Swap(i, j);
					i++; j--;
				}
			} while (i <= j);

			if (low < j)
				Sort(low, j);
			if (i < high)
				Sort(i, high);
		}

		private void Swap(int i, int j)//вспомогательный метод для обмена элементов при сортировке
		{
			SimpleListItem<T> ci = GetElemNumb(i);
			SimpleListItem<T> cj = GetElemNumb(j);
			/*перемена местами двух элементов*/
			T temp = ci.dataSave;
			ci.dataSave = cj.dataSave;
			cj.dataSave = temp;
		}
	}
}