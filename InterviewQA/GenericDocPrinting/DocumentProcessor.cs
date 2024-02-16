using System;
namespace InterviewQA.GenericDocPrinting
{
	public class DocumentProcessor<T> : IDocumentProcessor<T>
	{
        private readonly IDocumentTranslator<T> translator;
        private readonly IStoreDocument<T> storeDocument;

        public DocumentProcessor(IDocumentTranslator<T> translator,
			IStoreDocument<T> storeDocument)
		{
            this.translator = translator;
            this.storeDocument = storeDocument;
        }

		public void Process(T document)
        {
            var engVersion = translator.Translate(document, Language.English);
            storeDocument.Store(engVersion);
        }
    }
}

