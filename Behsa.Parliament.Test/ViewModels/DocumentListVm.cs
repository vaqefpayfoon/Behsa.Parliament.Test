using System;
using System.Collections.Generic;
using System.Text;

namespace Behsa.Parliament.Test.ViewModels
{
    public class DocumentListVm
    {
        public DocumentListVm()
        {
            Documents = new List<DocumentVm>();
        }

        public int AllDocumentsCount { get; set; }//این دو فعلا نیازی نیست
        public int CurrentDocumentsCount { get; set; }//این دو فعلا نیازی نیست
        public IList<DocumentVm> Documents { get; set; }

        public class DocumentVm
        {
            public string FileName { get; set; }
            public int Order { get; set; }
            public string EntityName { get; set; }
            public Guid EntityId { get; set; }
            public Guid DocumentId { get; set; }
            public string MainFormat { get; set; }
            public byte[] FileBytes { get; set; }
            public string Type { get; set; }
            public string Description { get; set; }
        }
    }


}
