using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
	public class Matrix3D<T>
	{
		/*Основная структура данных для хранения трехмерной разреженной матрицы - словарь _matrix*/
		Dictionary<string, T> _matrix = new Dictionary<string, T>();//описание словаря для хранения значений
		int maxST_X;//количество элементов трехмерной матрицы по горизонтали (максимальное количество столбцов)
		int maxSTR_Y;// количество элементов трехмерной матрицы по вертикали (максимальное количество строк)
		int maxGL_Z;//количество элементов трехмерной матрицы в глубину
		T NullElem;//пустой элемент типа T(передаваемый тип матрицы), который возвращается если элемент с нужными координатами не был задан
		public Matrix3D(int x, int y, int z, T NullElement)//конструктор
		{
			this.maxST_X = x;
			this.maxSTR_Y = y;
			this.maxGL_Z = z;
			this.NullElem = NullElement;
		}

		public T this[int x, int y, int z]//индексатор для доступа к данных
		{
			set
			{
				CheckBounds(x, y, z);//метод проверки границ
				string key = DictKey(x, y, z);//метод формирования ключа
				this._matrix.Add(key, value);//добавление в матрицу значения по ключу (x,y)
			}
			get
			{
				CheckBounds(x, y, z);
				string key = DictKey(x, y, z);
				if (this._matrix.ContainsKey(key))//если матрица (словарь) содержит рассматриваемый ключ (ключи задаются в ProgramLR3 после инициализации матрицы)
				{
					return this._matrix[key];//возвращение ключа
				}
				else
				{
					return this.NullElem;//возвращение нулевого/пустого значения
				}
			}
		}

		void CheckBounds(int x, int y, int z)//метод проверки выхода за границы рассматриваемой трехмерной разреженной матрицы
		{
			if (x < 0 || x >= this.maxST_X)
				throw new Exception("x=" + x + " выходит за границы");
			if (y < 0 || y >= this.maxSTR_Y)
				throw new Exception("y=" + y + " выходит за границы");
			if (z < 0 || z >= this.maxGL_Z)
				throw new Exception("z=" + z + " выходит за границы");
		}

		string DictKey(int x, int y, int z)//формирования ключа на основе индексов ячейки трехмерной разреженной матрицы
		{
			return x.ToString() + "_" + y.ToString() + "_" + z.ToString();//для элемента, находящегося в ячейке [1,0,2] его ключ будет записан в виде "1_0_2"
		}

		public override string ToString()
		{
			StringBuilder b = new StringBuilder();
			Console.WriteLine("Вывод 'срезов' матрицы по значениям глубины z\nТо есть выводятся двумерные матрицы (параметры x и y) по очереди в соответствии текущему значению z");
			for (int k = 0; k < this.maxGL_Z; k++)
			{
				Console.ForegroundColor = ConsoleColor.White;
				b.Append("\n" + "Для значения " + "z = " + k + "\n");
				//Console.ResetColor();
				for (int j = 0; j < this.maxSTR_Y; j++)
				{
					b.Append("[");//открывающая строку двумерного массива скобка
					for (int i = 0; i < this.maxST_X; i++)
					{
						if (i > 0)
							b.Append("\t");//добавление табуляции, если рассматриваемый элемент не первый (нулевой) в строке двумерной матрицы
						T t = this[i, j, k];//параметр типа T (передаваемого), в который кладется значение рассматриваемой ячейки трехмерной разреженной матрицы
						if (t != null)//если параметр не пустой
						{
							b.Append(t.ToString());//в двумерную матрицу добавляется результат работы переопределенного для каждого конкрентого класса метода ToString 
						}
						else//если ключ элемента не является частью словаря
						{
							//более форматированный вывод
							if (i > 0 && i < 2)
								b.Append("\t - \t");
							else
								b.Append(" - ");
						}
					}
					b.Append("]\n\n");//закрывающая строку двумерого массива свобка
				}
			}
			return b.ToString();//возвращение всей строки - трехмерной разреженной матрицы
		}
	}
}