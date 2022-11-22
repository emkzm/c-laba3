using System;
using System.Linq;
using static System.Console;

namespace Classes_learn
{
	public class ID_TABLE // static IDs table to control a number of objects
	{
		private int[] id = new int[0];  // array of IDs
		private int curr_index; // always should show as the latest id in the table
		
		public ID_TABLE(/*int size*/)
		{
			Array.Resize(ref id, 32); // size = 32 objects
			this.curr_index = 0; // curr index point to the latest free id_place
		}
		
		public bool add(int id)
		{
			if (this.curr_index == this.id.Length) return false;
			for (int i = 0; i < this.curr_index; i++) if (id == this.id[i]) return false; 
			this.id[this.curr_index++] = id;
			return true;
		}
		
		public bool remove(int id)
		{
			for (int i = 0; i < this.curr_index; i++) 
			if (id == this.id[i] && this.id[i] != 0)
			{
				for (int j = i; j < this.id.Length-1; j++) this.id[j] = this.id[j+1];
				curr_index--;
				return true;
			}
			return false;
		}
		public void print_id_table(bool full = false)
		{	
			int n;
			if (full) n = this.id.Length;
			else n = curr_index + 1;
			for (int i = 0; i < n; i++) 
			{
				Console.WriteLine ("#{0} - {1}", i, this.id[i]);
			}
		}
		public bool isExisting(int id)
		{
			return false;
		}
		~ID_TABLE()
		{
			
		}
	}

	public class Fruit
	{
		public int x = 5, y = 3, z = 2;
	}
	
	public class Pear : Fruit 
	{
		public new int x = 4, y = 1, z = 7;
		public void print()
		{
			Console.WriteLine(" Pear Native  : x = {0} y = {1} z = {2}", this.x, this.y, this.z);
			Console.WriteLine(" Pear Parent  : x = {0} y = {1} z = {2}", base.x, base.y, base.z);
		}
	}

	public class Bear : Pear 
	{
		public new int x = 999, y = 1231, z = 71234;
		public void print()
		{
			Console.WriteLine(" Bear Native  : x = {0} y = {1} z = {2}", this.x, this.y, this.z);
			Console.WriteLine(" Bear Parent  : x = {0} y = {1} z = {2}", base.x, base.y, base.z);
		}
	}

	public class Banana : Fruit 
	{
		public new int x;
		public void print()
		{
			Console.WriteLine(" Banana Native  : x = {0} y = {1} z = {2}", this.x, this.y, this.z);
			Console.WriteLine(" Banana Parent  : x = {0} y = {1} z = {2}", base.x, base.y, base.z);
		}
	}
	
	public class Item
	{
		private int id;
		private static int count = 0;
		public Item ()
		{
			System.Random random = new System.Random();  
			this.id = random.Next();
			count++;
		}
		public int GetId()
		{
			return this.id;
		}
		public static int GetCount()
		{
			return count;
		}
		~Item()
		{
			System.Diagnostics.Trace.WriteLine("OBJECT ID {0} HAS DESTROYED NOW", this.id.ToString());
			count--;
		}
	}
	
	public class Rectangle:Item
	{
		private int FSideA;
		private int FSideB;
		private string FName;

		public int Perimeter
		{
			get
			{
				return (FSideA + FSideB) * 2;
			}
		}

		public string Name
		{
			set
			{
				FName = value;
			}
			get 
			{
				return FName;
			}
		}
		
		public int SideA
		{
			get
			{
				return FSideA;
			}
		}

		public int SideB
		{
			get
			{
				return FSideB;
			}
		}
		public Rectangle():base()
		{
			this.FSideA = 1;
			this.FSideB = 1;
			this.FName = "Rectangle 1x1";
			
		}
		
		public Rectangle(string FName, int FSideA, int FSideB):base()
		{
			this.FName = FName;
			this.FSideA = FSideA;
			this.FSideB = FSideB;
		}
		~Rectangle()
		{
			System.Diagnostics.Trace.WriteLine(this.Name + " destroyed");
		}
	}
	
	public class MyArray<T>:Item
	{
		private T[] array = new T[0];
		private int index;
		
		public MyArray():base()
		{
			this.index = 0;
		}
		
		public MyArray(int size):base()
		{
			Array.Resize(ref this.array, size);
			this.index = 0;
		}
		public void Print(bool dmode = false)
		{
			for (int i = 0; i < this.array.Length; i++)
			{
				if (dmode) Console.WriteLine("array [{0}] = {1} ", i,  this.array[i]);
				else Console.Write("{0} ", this.array[i]);
			}
		}
		public void Resize(int new_size)
		{
			Array.Resize(ref this.array, new_size);
		}
		public void Add(T item)
		{
			if (this.array.Length <= index) throw new Exception("OUT OF array");
			this.array[this.index++] = item;
		}
		public T GetLastElem()
		{
			if (this.array.Length <= index) throw new Exception("OUT OF array");
			return this.array[this.index--];
		}
		public T GetByIndex(int index)
		{
			if (index > this.index) return default(T);
			return this.array[index];
		}
		public int GetSize()
		{
			return this.array.Length;
		}
		public bool isItemExisted(int index)
		{
			if (index >=this.index) return false;
			return true;
		}
		~MyArray()
		{
			System.Diagnostics.Trace.WriteLine("MyArray has destroyed");
		}
	}
	
	public class ClassA
	{
		public int a;
		public ClassA(int a)
		{
			this.a = a;
		}

	}

	public class ClassB : ClassA
	{
		public int b;
		public ClassB(int a, int b) : base(a)
		{
			this.b = b;
		}
	}

	public class ClassC
	{
		public int a;
		public ClassC(int a)
		{
			this.a = a;
		}
	}

	
	public static class Program
	{
		public static void Cout(this string str, params object[] args)
		{
			Console.WriteLine(str, args);
		}

		public static void Main()
		{
			/*
			Rectangle myRectangle1 = new Rectangle();
			Console.WriteLine(myRectangle1.GetFName());
			Console.WriteLine("Perimeter: {0}\nID: {1}", myRectangle1.GetPerimeter(), myRectangle1.GetId());
			Console.ReadKey();
			Rectangle myRectangle2 = new Rectangle("Big rectangle", 5, 10);
			Console.WriteLine(myRectangle2.GetFName());
			Console.WriteLine("Perimeter: {0}\nID: {1}", myRectangle2.GetPerimeter(), myRectangle2.GetId());
			Console.ReadKey();
			Console.WriteLine("There are {0} objects", Rectangle.GetCount());
			//Console.ReadKey();
			*/
			
			/*
			MyArray<int> arr = new MyArray<int>(10);
			for (int i = 0; i < 10; i++)
			{
				Console.Write("arr[{0}] = ", i);
				int n;
				int.TryParse(Console.ReadLine(), out n);
				arr.add(n);
			}
			arr.Print(true);
			*/
			// ------------------------------ THE MOST INTERESTING IS HERE
			
			/*Console.WriteLine("\tarray of rectangles");
			MyArray<Rectangle> array = new MyArray<Rectangle>();
			while(true)
			{
				try
				{
					Console.Write("# ");
					string msg = Console.ReadLine();
					if (msg == "help")
					{
						Console.WriteLine("size     - get current size of array");
						Console.WriteLine("resize   - edit current size of array");
						Console.WriteLine("makerect - make new rect and push it to array");
						Console.WriteLine("printall - print all elements");
						Console.WriteLine("printi   - print i element");
						Console.WriteLine("exit     - exit from program");
					}
					else if (msg == "size")
					{ 
						Console.WriteLine("Size of array = {0}", array.GetSize());
					}
					else if (msg == "resize")
					{
						Console.Write("New size of array = ");
						array.Resize(int.Parse(Console.ReadLine()));
					}
					else if (msg == "exit")
					{ 
						break; 
					}
					else if (msg == "makerect")
					{
						Console.Write("Name of rectangle = ");
						string name = Console.ReadLine();
						Console.Write("Side A of rectangle = ");
						int sideA = int.Parse(Console.ReadLine());
						Console.Write("Side B of rectangle = ");
						int sideB = int.Parse(Console.ReadLine());
						
						array.Add(new Rectangle(name, sideA, sideB));
					}
					else if (msg == "printall")
					{
						for (int i = 0; i < array.GetSize(); i++)
						{
							if (array.isItemExisted(i))
							{
								Rectangle temp = array.GetByIndex(i);
								Console.WriteLine("\tRectangle {0}", i);
								Console.WriteLine("Name   = {0}", temp.Name);
								//Console.WriteLine("    ID = {0}", temp.GetId());
								Console.WriteLine("Side A = {0}", temp.SideA);
								Console.WriteLine("Side B = {0}", temp.SideB);
							}
						}
					}
					
					else 
					{
						Console.WriteLine("Unknown command: \"{0}\"", msg);
					}
				}
				catch (System.Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			
			Console.WriteLine("Good bye...");
			*/

			/*
			Pear pear = new Pear(); // GRUSHA
			Banana banana = new Banana();
			Bear bear = new Bear();
			
			pear.print();
			Console.WriteLine();
			banana.print();
			Console.WriteLine();
			bear.print();
			"Hello World".Cout();
			*/

			ClassA obja = new ClassA(5);
			ClassB objb = new ClassB(10, 15);
			ClassC objc = new ClassC(25);
			ClassB objb2;

			// objb2 = (ClassB) obja; // improper cast

			"obja a = {0}".Cout(obja.a);
			"objb a = {0}\nobjb b = {1}".Cout(objb.a, objb.b);
			"objc a = {0}".Cout(objc.a);
			"obja b = {0}".Cout(objb2.b);

			obja = objb; // obja is now pointing to ClassB
			"".Cout();
			objb.a = 69;
			
			objb2 = (ClassB) obja; // proper cast
			 
			"obja a = {0}".Cout(obja.a);
			"objb a = {0}\nobjb b = {1}".Cout(objb.a, objb.b);
			"objc a = {0}".Cout(objc.a);
			"obja b = {0}".Cout(objb2.b);
			
			//------------------------------------
					
			//int n = int.Parse(Console.ReadLine());
			//SomeClass<int> someObject = new SomeClass<int>(n);
			
			/*
			int n = int.Parse(Console.ReadLine());
			Item[] item = new Item[n];
			for (int i = 0; i < n; i++)
			{
				item[i] = new Item();
				Console.WriteLine("Object ID:{0} spawned", item[i].GetId());
			}
			*/
			
			/*
			ID_TABLE id_table = new ID_TABLE();
			id_table.add(1);
			id_table.add(2);
			id_table.add(1);
			id_table.print_id_table();
			*/
		}
	}
}