using System;
namespace InterviewQA.GenericDocPrinting
{
	public interface IDocumentProcessor<T>
	{
		void Process(T document);
	}
}

