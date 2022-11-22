/*
1) Разработать класс для представления объекта матрица, состоящая из элементов типа double. 
2) Определить конструктор с двумя параметрами целого типа – размерность матрицы, 
    который можно использовать как конструктор умолчания. 
3) Определить конструктор, 
    который создаёт новую матрицу таким образом, 
	что все её элементы больше элементов другой матрицы на заданное число, 
    и который можно использовать как конструктор копирования. 
4) Определить деструктор. 
5) Определить преобразования из переменной типа double в матрицу – заполнение матрицы и 
    из матрицы в переменную типа double – среднее арифметическое элементов матрицы.

*/
using System;
namespace laba3
{

    public class Matrix
   	{
        private double[][] values;
        public Matrix(int rows = 2, int columns = 2)
       	{
        	this.values = new double[rows][];
			for (int i = 0; i < columns; i++)
			{
				this.values[i] = new double[columns];
			} 
        }

		public double[][] matrix
		{
			get
			{
				return values;
			}
		}

		public Matrix(Matrix source, int n = 0)
		{
			this.values = new double[source.matrix.Length][];
			for (int i = 0; i < source.matrix.Length; i++)
			{
				this.values[i] = new double[source.matrix[i].Length];
				for (int j = 0; j < this.values[i].Length; j++)
				{
					this.values[i][j] = source.matrix[i][j] + n;
				}
			}
		}

		~Matrix()
		{
			System.Diagnostics.Trace.WriteLine("Matrix has been destroyed");
		}

		public void fill()
		{
			for (int i = 0; i < this.values.Length; i++)
			{
				for (int j = 0; j < this.values[i].Length; j++)
				{
					Console.Write("value [{0}][{1}] = ", i, j);
					this.values[i][j] = double.Parse(Console.ReadLine());
					
				}
			}
		}
		
		public void print()
		{
			for (int i = 0; i < this.values.Length; i++)
			{
				for (int j = 0; j < this.values[i].Length; j++)
				{
					Console.Write(" {0} ", this.values[i][j]);
				}
				Console.WriteLine();
			}
		}
		public double mean_average()
		{
			double sum = 0;
			for (int i = 0; i < this.values.Length; i++) 
			{
				for (int j = 0; j < this.values[i].Length; j++) 
				{
					sum += this.values[i][j];
				}
			}
			return sum / (this.values.Length * this.values[0].Length);
		}
    }

    public static class Program
   	{
        public static void Main()
       	{
            Console.WriteLine("Laba3");
			Matrix matrix = new Matrix();
			matrix.fill();
			matrix.print();
			Console.WriteLine("Mean average of matrix is {0}", matrix.mean_average());
       	}
   	}
}