using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MongoReviewer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string[] servers = MongoConnectionHelper.GetMongoServerHost();
            TreeNode root = TV1.Nodes.Add("Servers");
            foreach(string s in servers)
            {
                TreeNode serverNode = root.Nodes.Add(s);
                MongoServer server;
                List<MongoDatabase> dbs;
                MongoConnectionHelper.GetMongoServer(s, out server, out dbs);
                serverNode.Tag = server;
                foreach(MongoDatabase db in dbs)
                {
                    TreeNode colNode = serverNode.Nodes.Add(db.Name);
                    colNode.Tag = db;
                    List<MongoCollection<BsonDocument>> collections;
                    MongoConnectionHelper.GetAllCollections(db, out collections);
                    foreach (MongoCollection<BsonDocument> cs in collections)
                    {
                        TreeNode tableName = colNode.Nodes.Add(cs.Name);
                        tableName.Tag = cs;
                    }
                    //colNode.
                }
                //MongoConnectionHelper.GetAllCollections
            }
            
        }

        private void TV1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LV.Items.Clear();
            object o = e.Node.Tag;
            MongoCollection<BsonDocument> bo = o as MongoCollection<BsonDocument>;
            if (bo != null)
            {
                MongoCursor<BsonDocument> docs = bo.FindAll();
                foreach(BsonDocument doc in docs)
                {
                    IEnumerable<BsonElement> boes = doc.Elements;
                    ListViewItem lvi = new ListViewItem();

                    //object id;
                    //Type tt;
                    //IIdGenerator vv;
                    //doc.GetDocumentId(out id, out tt, out vv);
                    BsonValue outvalue;
                    doc.TryGetValue("_id", out outvalue);
                    if (outvalue != null)
                    {
                        lvi.Text = doc["_id"].ToString();
                        
                        lvi.SubItems.Add(boes.Count().ToString());
                        lvi.SubItems.Add("Document");
                        LV.Items.Add(lvi);
                        foreach (BsonElement boe in boes)
                        {

                            string Header = boe.Name;
                            BsonValue value = boe.Value;

                            string strValue = value.ToString();
                            string strType = value.GetType().ToString();
                            ListViewItem subLV = new ListViewItem();
                            subLV.Text = "     " + Header;
                            subLV.SubItems.Add(strValue);
                            subLV.SubItems.Add(strType);
                            LV.Items.Add(subLV);
                        }
                     
                    }
                    System.Windows.Forms.ListView.ColumnHeaderCollection columns = LV.Columns;
                    for (int i = 0; i < columns.Count; i++)
                    {
                        columns[i].Width = -1;
                    }
                }
            }
        }
    }
}
