using System;

namespace S2.AspNet.Repetition.Entities
{
    public class MemeImage
    {
        public MemeImage()
        {

        }
        public MemeImage(int id, string url, string altText)
        {
            Id = id;
            Url = url;
            AltText = altText;
        }

        public int Id { get; set; }
        public string Url { get; set; }
        public string AltText { get; set; }
    }
}
