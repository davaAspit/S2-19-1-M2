using S2.AspNet.Repetition.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace S2.AspNet.Repetition.DAL
{
    public class MemeImageRepository : RepositoryBase
    {
        public MemeImage GetMostOftenUsedMemeImage()
        {
            //Get all MemeCreations

            List<MemeCreation> allMemeCreations = new List<MemeCreation>();

            //Baaaad code
            List<int> memeImages = new List<int>(int.MaxValue);

            foreach (MemeCreation memeCreation in allMemeCreations)
            {
                memeImages[memeCreation.MemeImageId]++;
            }

            int memeImageIdBadWay = memeImages.IndexOf(memeImages.Max());


            //Better code
            Dictionary<int, int> occurencesOfImage = new Dictionary<int, int>();
            
            foreach (MemeCreation memeCreation in allMemeCreations)
            {
                if(occurencesOfImage.ContainsKey(memeCreation.MemeImageId))
                {
                    occurencesOfImage[memeCreation.MemeImageId]++;
                }
                else
                {
                    occurencesOfImage.Add(memeCreation.MemeImageId, 1);
                }
            }

            //The Id of the most used Image is:
            int memeImageIdBetterWay = occurencesOfImage.Max().Key;

        }
        public List<MemeImage> GetAllMemeImages()
        {
            List<MemeImage> memeImages = new List<MemeImage>();
            string sql = "SELECT * FROM MemeImages";

            DataTable memeImagesTable = ExecuteQuery(sql);

            foreach (DataRow row in memeImagesTable.Rows)
            {
                int id = (int)row["Id"];
                string url = (string)row["Url"];
                string altText = (string)row["AltText"];

                MemeImage memeImage = new MemeImage(id, url, altText);
                memeImages.Add(memeImage);
            }

            return memeImages;
        }

        public int InsertMemeImage(MemeImage memeImage)
        {
            string sql = $"INSERT INTO MemeImages VALUES('{memeImage.Url}', '{memeImage.AltText}')";
            return ExecuteNonQuery(sql);
        }

        public string GetMemeImageUrl(int memeImageId)
        {
            string sql = $"SELECT Url FROM MemeImages WHERE id = {memeImageId}";
            DataTable memeImagesTable = ExecuteQuery(sql);

            if (memeImagesTable.Rows.Count > 0)
            {
                return (string)memeImagesTable.Rows[0]["Url"];
            }
            throw new ArgumentException($"Did not find the image with id = {memeImageId}");
        }
    }
}
