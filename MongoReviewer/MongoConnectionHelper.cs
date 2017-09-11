using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoReviewer
{
    public class MongoConnectionHelper
    {
        public static string[] GetMongoServerHost()
        {
            string values = ConfigurationManager.AppSettings["MongoDB"];
            if (string.IsNullOrEmpty(values)) return null;

            return values.Split(';');

        }

        public static void GetMongoServer(String hostName, out MongoServer server, out List<MongoDatabase> DBNames)
        {
            server = new MongoClient(hostName).GetServer();
            if(server == null)
            {
                DBNames = null;
                return;
            }
            DBNames = new List<MongoDatabase>();
            IEnumerable<string> DBList = server.GetDatabaseNames();
            if (DBList != null)
            {
                foreach(string s in DBList)
                {
                    MongoDatabase database = server.GetDatabase(s);
                    DBNames.Add(database);
                }
            }
            
            return;
        }
        public static void GetAllCollections(MongoDatabase db, out List<MongoCollection<BsonDocument>> Collections)
        {
            Collections = new List<MongoCollection<BsonDocument>>();
            IEnumerable<string> list = db.GetCollectionNames();
            foreach(string s in list)
            {
                MongoCollection<BsonDocument> col = db.GetCollection<BsonDocument>(s);
                Collections.Add(col);
            }
        }

        //public static void GetAllTables()
    }
}
