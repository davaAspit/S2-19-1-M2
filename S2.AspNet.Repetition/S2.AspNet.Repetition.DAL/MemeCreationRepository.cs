using S2.AspNet.Repetition.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace S2.AspNet.Repetition.DAL
{
    public class MemeCreationRepository : RepositoryBase
    {
        public MemeCreationRepository(string conString) : base(conString)
        {
        }

        public int Insert(MemeCreation memeCreation)
        {
            string sql = 
                $"INSERT INTO MemeCreations " +
                $"VALUES ({memeCreation.MemeImageId}, CURRENT_TIMESTAMP, '{memeCreation.Text}', '{memeCreation.Position}', '{memeCreation.Color}', '{memeCreation.Size}')";
            return ExecuteNonQuery(sql);
        }
    }
}
