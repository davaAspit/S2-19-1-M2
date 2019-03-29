using S2.AspNet.Repetition.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace S2.AspNet.Repetition.DAL
{
    public class MemeCreationRepository : RepositoryBase
    {
        public int Insert(MemeCreation memeCreation)
        {
            string sql =
                $"INSERT INTO MemeCreations " +
                $"VALUES ({memeCreation.MemeImageId}, CURRENT_TIMESTAMP, '{memeCreation.Text}', '{memeCreation.Position}', '{memeCreation.Color}', '{memeCreation.Size}')";
            return ExecuteNonQuery(sql);
        }

        public MemeCreation GetRandomMeme()
        {
            //return new MemeCreation() { Text = "Tilfældig tekst", Color = "White", Position = "Bottom-left", Size = "Small", CreationTime = DateTime.Now };
            return GetRandomMemeInSql();
        }

        private MemeCreation GetRandomMemeInCsharp()
        {
            List<MemeCreation> memeCreations = new List<MemeCreation>();
            string sql = "SELECT MemeCreations.*, Url, AltText FROM MemeCreations JOIN MemeImages ON MemeCreations.MemeImg = MemeImages.Id";

            DataTable memeImagesTable = ExecuteQuery(sql);

            foreach (DataRow row in memeImagesTable.Rows)
            {
                MemeCreation memeCreation = ExtractMemeCreation(row);

                memeCreations.Add(memeCreation);
            }
            Random rnd = new Random();
            return memeCreations[rnd.Next(0, memeCreations.Count)];
        }

        private MemeCreation ExtractMemeCreation(DataRow row)
        {
            int memeCreationId = (int)row["Id"];
            string url = (string)row["Url"];
            string altText = (string)row["AltText"];
            int memeImageId = (int)row["MemeImg"];
            string memeText = (string)row["MemeText"];
            string position = (string)row["Position"];
            string size = (string)row["Size"];
            string color = (string)row["Color"];
            DateTime creationTime = (DateTime)row["TimeStamp"];

            MemeImage memeImage = new MemeImage(memeImageId, url, altText);
            MemeCreation memeCreation = new MemeCreation()
            {
                Id = memeCreationId,
                Color = color,
                CreationTime = creationTime,
                MemeImage = memeImage,
                Position = position,
                MemeImageId = memeImageId,
                Size = size,
                Text = memeText
            };
            return memeCreation;
        }

        private MemeCreation GetRandomMemeInSql()
        {
            string sql = "SELECT TOP(1) MemeCreations.*, Url, AltText FROM MemeCreations JOIN MemeImages ON MemeCreations.MemeImg = MemeImages.Id ORDER BY NEWID()";

            DataTable memeImagesTable = ExecuteQuery(sql);


            if (memeImagesTable.Rows.Count > 0)
            {
                DataRow row = memeImagesTable.Rows[0];

                MemeCreation memeCreation = ExtractMemeCreation(row);
                return memeCreation; 
            }
            return null;
        }

    }
}
