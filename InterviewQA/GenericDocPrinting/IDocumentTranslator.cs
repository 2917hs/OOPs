using System;
namespace InterviewQA.GenericDocPrinting
{
	public interface IDocumentTranslator<T>
    {
        T Translate(T document, Language language);
    }
}

