using System;
using System.Collections.Generic;
using System.Text;

namespace S2.AspNet.Repetition.Entities
{
    public class MemeCreation
    {
        public MemeCreation()
        {

        }

        public MemeCreation(int memeImageId, DateTime creationTime, string text, string position, string color, string size)
        {
            MemeImageId = memeImageId;
            CreationTime = creationTime;
            Text = text;
            Position = position;
            Color = color;
            Size = size;
        }

        public MemeCreation(int id, int memeImageId, DateTime creationTime, string text, string position, string color, string size)
        {
            Id = id;
            MemeImageId = memeImageId;
            CreationTime = creationTime;
            Text = text;
            Position = position;
            Color = color;
            Size = size;
        }

        public int Id { get; set; }
        public int MemeImageId { get; set; }
        public MemeImage MemeImage { get; set; }
        public DateTime CreationTime { get; set; }
        public string Text { get; set; }
        public string Position { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
    }
}
