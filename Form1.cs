using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace TR_BEA_A_10_20
{
    
    //string connString = "Server=localhost; port=5432; user id =postgres; password=P_yuriko2000; database=tr_bea_a_10_20;";
    public partial class Form1 : Form
    {
        public Form1()
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
            /*try
            {
               np.Open();
                vivod.Text = "Открылся";
            }
            catch(Exception ex)
            {
                vivod.Text = "Ошибка";
            }*/
        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {
            String logUser = logintextBox.Text;
            String pasUser = pastextBox.Text;

            DB db = new DB();
            DataTable table = new DataTable();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM roles WHERE login=@ul AND password=@up", db.getConnection());
            command.Parameters.Add("@ul", NpgsqlTypes.NpgsqlDbType.Varchar).Value = logUser;
            command.Parameters.Add("@up", NpgsqlTypes.NpgsqlDbType.Varchar).Value = pasUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                if ((pasUser == "67890") && (logUser == "Manager"))
                {
                    Id_store.fl = 1;
                    this.Hide();
                    Store_id_m manager = new Store_id_m(); 
                    manager.Show();
                }
                if ((pasUser == "10293") && (logUser == "Worker"))
                {
                    Id_store.fl = 2;
                    this.Hide();
                    Store_id_m worker = new Store_id_m();
                    worker.Show();
                }
                if ((pasUser == "12345") && (logUser == "Director"))
                {
                    this.Hide();
                    Form_director director = new Form_director();
                    director.Show();
                }
            }

            else
                MessageBox.Show("Нет такого логина или пароля");
            db.closeConnection();
        }
    }public static class Id_store
        {
            public static int id;
            public static int fl;
        }
    public static class Flag
    {
        public static int n = 2;
        public static bool f = false;
        public static int[] salary_old = new int[n];
        public static int[] id_max_sb = new int[n];
    }

    public static class Update_loc
    {
        public static int rack;
        public static string shelf;
        public static int place;
        public static DataGridView dgv;
        public static bool f;
    }
}
