using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestExamples.BL
{
    public class DocumentFileInfo : CustomFileInfo
    {
        public DocumentFileInfo(string fileName, int fileSize, DateTime creationTime) 
            : base(fileName, fileSize, creationTime)
        {
        }
    }
}
