using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace TR_BEA_A_10_20
{ 
    
    public partial class Store_id_m : Form
    {
        public Store_id_m()
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
        private void buttonlogin_Click(object sender, EventArgs e)
        {

        }

        private void idstore_button_Click(object sender, EventArgs e)
        {
            bool b = false;
            DB db = new DB();
            DataTable table = new DataTable();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            db.openConnection();
            if (int.TryParse(idstore_textbox.Text, out Id_store.id))
            {
                var sql = $"SELECT * FROM poisk_store('{Id_store.id}')";

                NpgsqlCommand command = new NpgsqlCommand(sql, db.getConnection());
                b = (bool)command.ExecuteScalar();
                if (b)
                {
                    if (Id_store.fl == 1)
                    {
                        this.Hide();
                        Form_manager manager = new Form_manager();
                        manager.Show();
                    }
                    if (Id_store.fl == 2)
                    {
                        this.Hide();
                        Form_worker worker = new Form_worker();
                        worker.Show();
                    }
                }
                else MessageBox.Show("Такого кода магазина не существует");
            }
            else MessageBox.Show("Некорректный ввод");

            db.closeConnection();
        }

        private void on_form_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}

