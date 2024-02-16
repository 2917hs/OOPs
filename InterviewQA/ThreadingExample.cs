using System;
namespace InterviewQA
{
	public class ThreadingExample
	{
		public ThreadingExample()
		{
			Thread th = new Thread(new ThreadStart(() => PrintNumber(1)));
			th.Start();
            PrintNumber(2);

			Task t = new Task(() => PrintNumber(3));
			t.Start();
			PrintNumber(4);
		}

		private void PrintNumber(int occurance)
		{
			switch (occurance)
			{
				case 1:
                    Enumerable.Range(1, 10).ToList().ForEach(x => Console.WriteLine($"from thread {x}"));
                    break;
                case 2:
                    Enumerable.Range(1, 10).ToList().ForEach(x => Console.WriteLine($"from thread-seq {x}"));
                    break;
                case 3:
                    Enumerable.Range(1, 10).ToList().ForEach(x => Console.WriteLine($"from task {x}"));
                    break;
                case 4:
                    Enumerable.Range(1, 10).ToList().ForEach(x => Console.WriteLine($"from task-seq {x}"));
                    break;
            }
		}
	}
}

