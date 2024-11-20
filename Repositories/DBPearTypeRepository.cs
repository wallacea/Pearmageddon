using Microsoft.Extensions.Caching.Memory;
using Pearmageddon.Objects;
using System.Data;
using System.Data.SqlClient;

namespace Pearmageddon.Repositories
{
    public class DBPearTypeRepository(IConfiguration config, IMemoryCache cache) : IPearTypeRepository
    {
        
        public PearType Get(int id)
        {
            return GetAll().FirstOrDefault(pt => pt.ID == id);
        }

        public IEnumerable<PearType> GetAll()
        {
            List<PearType> pearTypes = cache.Get<IEnumerable<PearType>>("PearTypes")?.ToList();
            if(pearTypes == null) { 
                pearTypes = new List<PearType>();

                using SqlConnection connection = new SqlConnection(config["ConnectionStrings:Pearmageddon"]);
                using SqlCommand command = new SqlCommand("SELECT * FROM PearType", connection);
                //using SqlCommand command = new SqlCommand("PearType_GetList", connection);
                //command.CommandType = CommandType.StoredProcedure;
                command.Connection.Open();
                using SqlDataReader reader = command.ExecuteReader(); 
                while(reader.Read())
                {
                    PearType pType = new PearType();
                    pType.ID = (int)reader["ID"];
                    pType.Name = reader["Name"].ToString();
                    pType.Color = reader["Color"].ToString();
                    pType.Timestamp = (DateTime)reader["Timestamp"];
                    pearTypes.Add(pType);
                }
                cache.Set("PearTypes", pearTypes);
            }
            return pearTypes;
        }

        public void Save(PearType pearType)
        {
            using SqlConnection connection = new SqlConnection(config["ConnectionStrings:Pearmageddon"]);
            using SqlCommand command = new SqlCommand("PearType_InsertUpdate", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection.Open();
            if(pearType.ID.HasValue)
            {
                command.Parameters.AddWithValue("@ID", pearType.ID.Value);
            }
            command.Parameters.AddWithValue("@Name", pearType.Name);
            command.Parameters.AddWithValue("@Color", pearType.Color);
            command.ExecuteNonQuery();
            cache.Remove("PearTypes");
        }
    }
}
