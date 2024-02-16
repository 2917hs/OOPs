using System;
namespace InterviewQA.GenericDocPrinting
{
	public interface IStoreDocument<T>
	{
		T Store(T document);
	}
}

