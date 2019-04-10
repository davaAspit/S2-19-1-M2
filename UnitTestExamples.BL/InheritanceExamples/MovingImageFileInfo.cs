using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestExamples.BL
{
    public class MovingImageFileInfo : ImageFileInfo
    {
        private int duration;

        public MovingImageFileInfo(int duration, int width, int height, string fileName, int fileSize, DateTime creationTime) 
            : base(width, height, fileName, fileSize, creationTime)
        {
            Duration = duration;
        }

        public int Duration { get => duration; set => duration = value; }

        public override string ToString()
        {
            return $"Video: {FileName}";
        }
    }
}
