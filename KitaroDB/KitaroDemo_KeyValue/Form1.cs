using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KitaroDemo
{
    public partial class Form1 : Form
    {
        private KitaroDB.DB db;

        public Form1()
        {
            InitializeComponent();

            //Open a KitaroDB key/value file. The file will be created if it does not exist.
            db = KitaroDB.DB.Create("MyFile.ism");
            
            //Display the current content of the file
            showFileData();
        }

        private void showFileData()
        {
            List<Person> items = new List<Person>();

            //Position to the first record
            KitaroDB.DBCursor cursor = db.Seek(KitaroDB.DBReadFlags.NoLock);

            if (cursor != null)
            {
                //Load existing records into the backing store
                do
                    items.Add(Person.FromJson(cursor.GetString()));
                while (cursor.MoveNext());
            }

            bs.DataSource = items;
        }

        private bool addRecord()
        {
            var item = new Person()
            {
                PersonID = txtKey.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text
            };

            try
            {
                db.Insert(item.PersonID, item.ToJson());
                showFileData();
                return true;

            }
            catch (KitaroDB.KeyException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool deleteRecord(string key)
        {
            try
            {
                db.Delete(key);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            if (addRecord())
            {
                txtKey.Clear();
                txtFirstName.Clear();
                txtLastName.Clear();
                txtKey.Focus();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            db.Dispose();
        }

        private void grid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var item = e.Row.DataBoundItem as Person;
            if (deleteRecord(item.PersonID))
                showFileData();
            e.Cancel = true;
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 1)
            {
                var p = grid.SelectedRows[0].DataBoundItem as Person;
                txtKey.Text = p.PersonID;
                txtFirstName.Text = p.FirstName;
                txtLastName.Text = p.LastName;
            }
            else
            {

            }
        }

    }

}
