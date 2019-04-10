using System;
using System.Collections.Generic;
using System.Text;
using UnitTestExamples.BL;
using Xunit;

namespace UnitTestExamples.BLTest
{
    public class FileInfoTest
    {
        [Fact]
        public void ToString_ReturnsFileName()
        {
            List<CustomFileInfo> fileInfos = new List<CustomFileInfo>()
            {
                new MovingImageFileInfo(10, 1920, 1080,"Pollefiction", 40000, DateTime.Now)
            };

            foreach (var fileInfo in fileInfos)
            {
                Console.WriteLine(fileInfo.ToString());
            }
        }
    }
}
