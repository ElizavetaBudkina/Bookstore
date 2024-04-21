using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Npgsql;

namespace TR_BEA_A_10_20
{
    public partial class Updatelistbook : Form
    {
        public Updatelistbook()
        {
            InitializeComponent();
        }
        class DB
        {

            NpgsqlConnection np = new NpgsqlConnection("Server=localhost; port=5432; user id =postgres; password=P_yuriko2000; database=tr_bea_a_10_20;");
            public void openConnection()
            {
                if (np.State == System.Data.ConnectionState.Closed)
                    np.Open();
            }
            public void closeConnection()
            {
                if (np.State == System.Data.ConnectionState.Open)
                    np.Close();
            }
            public NpgsqlConnection getConnection()
            {
                return np;
            }
        }
        DB db = new DB();
        private void Update_listbook_1_Click(object sender, EventArgs e)
        {
            string queryString;
            int rack;
            string shelf = update_shelfbook_new.Text;
            int place;
            Boolean f = false;
            if ((update_shelfbook_new.Text != String.Empty) && (update_placebook_new.Text != String.Empty) && (update_rackbook_new.Text != String.Empty))
            {
                Regex r = new Regex("[A-Z]{1}");
                MatchCollection matches = r.Matches(update_shelfbook_new.Text);
                if (matches.Count > 0) { f = true; }
                if (int.TryParse(update_rackbook_new.Text, out rack) && int.TryParse(update_placebook_new.Text, out place)
                    && f)
                {
                    shelf = update_shelfbook_new.Text;
                    db.openConnection();
                    //MessageBox.Show($"'{Update_loc.rack}', '{Update_loc.shelf}', '{Update_loc.place}','{Id_store.id}'");
                    queryString = $"CALL update_place('{Update_loc.rack}', '{Update_loc.shelf}', '{Update_loc.place}', '{Id_store.id}', '{rack}', '{shelf}', '{place}')";
                    NpgsqlCommand command = new NpgsqlCommand(queryString, db.getConnection());

                    command.ExecuteNonQuery();
                    MessageBox.Show("Местоположение книги изменено");
                    this.Hide();
                    Form_worker worker = new Form_worker();
                    worker.Show();
                }
                else MessageBox.Show("Некорректный ввод");

            }
            else MessageBox.Show("Недостаточно данных! Обязательны к заполнению: номер стеллажа, номер полки(A-Z), номер места.");
            db.closeConnection();
        }

        private void on_worker_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_worker worker = new Form_worker();
            worker.Show();
        }
    }
}
