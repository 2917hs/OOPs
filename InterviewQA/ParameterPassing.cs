using System;
namespace InterviewQA
{
	public class ParameterPassing
	{
		private int intValue = 0;

		TestParameterPassing tpp = new TestParameterPassing();

		public ParameterPassing()
		{
			Console.WriteLine(intValue);
			Console.WriteLine(tpp.intValueRef);
			intValue = 1;
			tpp.intValueRef = 1;

			Add(intValue);
			Console.WriteLine(intValue);
			Console.WriteLine(tpp.intValueRef);
		}

		public (int a, int b, int c, int d) Add(int a)
		{
			return (1, 2, 3, 4);
		}
	}

	public class TestParameterPassing
	{
		public int intValueRef { get; set; }
	}
}

