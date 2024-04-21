using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace TR_BEA_A_10_20
{
    public partial class Form_manager : Form
    {
        public Form_manager()
        {
            InitializeComponent();

            Manager_Load();
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
        enum RowState
        {
            Existed,
            New,
            Modified,
            ModifiedNew,
            Deleted
        }
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id", "Код сотрудника");
            dataGridView1.Columns.Add("Fam", "Фамилия");
            dataGridView1.Columns.Add("Im", "Имя");
            dataGridView1.Columns.Add("Ot", "Отчество");
            dataGridView1.Columns.Add("passport", "Паспорт");
            dataGridView1.Columns.Add("CNILC", "СНИЛС");
            dataGridView1.Columns.Add("Post", "Должность");
            dataGridView1.Columns.Add("Salary", "Зарплата (в тыс.руб.)");
            dataGridView1.Columns.Add("salesbooks", "Кол-во проданных книг");
        }
        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"SELECT * FROM select_staf('{Id_store.id}')";
            NpgsqlCommand command = new NpgsqlCommand(queryString, db.getConnection());
            db.openConnection();
            NpgsqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                dgw.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6),
                reader.GetDouble(7), reader.GetInt32(8));
            }
            reader.Close();
        }
        private void Manager_Load()
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }
        private void deleteRow()
        {
            db.openConnection();

            int ind;
            int index = dataGridView1.CurrentCell.RowIndex;
            byte flag = 0;
            for (int id = 0; id < dataGridView1.Rows.Count - 1; id++)
            {
                if (Convert.ToInt32(dataGridView1.Rows[id].Cells[0].Value) == Convert.ToInt32(id_delete.Text))
                {
                    index = id;
                    flag = 1;
                }
                
                
            }
            if ((flag == 0) && (id_delete.Text != String.Empty))
            {
                MessageBox.Show("Записи с такими данными в таблице нет!");
                return;
            }
            else MessageBox.Show("Запись найдена.");
            ind = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
            var deletQuery = $"CALL staf_delete('{ind}')";

            var command = new NpgsqlCommand(deletQuery, db.getConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Запись удалена.");
            
            dataGridView1.Rows[index].Visible = false;

            db.closeConnection();
        }
       
        private void delete_staff_Click(object sender, EventArgs e)
        {
            deleteRow();
        }


        private void insert_staffbutton_Click(object sender, EventArgs e)
        {
            db.openConnection();
            var Fam = Fam_ins.Text;
            var Im = Im_ins.Text;
            var Ot = Ot_ins.Text;
            var Pas = Pas_ins.Text;
            var Cnilc = Cnilc_ins.Text;
            var Post = "Работник";
            int Salary;
            int salesbooks = 0;

            if ((Post_ins.Text != string.Empty) && ((Post_ins.Text == "Менеджер") || (Post_ins.Text == "Работник"))) { Post = Post_ins.Text; }

            if ((Fam_ins.Text != string.Empty) && (Im_ins.Text != string.Empty) && (Ot_ins.Text != string.Empty) &&
                (Pas_ins.Text != string.Empty) && (Cnilc_ins.Text != string.Empty) && (Salary_ins.Text != string.Empty))
            {
                if (int.TryParse(Salary_ins.Text, out Salary))
                {

                    int.TryParse(salesbooks_ins.Text, out salesbooks);
                    string queryString = $"CALL staflist_ins('{Fam}', '{Im}', '{Ot}', '{Pas}', '{Cnilc}', '{Post}', '{Salary}', '{salesbooks}', '{Id_store.id}')";
                    NpgsqlCommand command = new NpgsqlCommand(queryString, db.getConnection());

                    /*!*/
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись создана!");
                    RefreshDataGrid(dataGridView1);
                }
                else MessageBox.Show("Некорректный ввод");
            } else MessageBox.Show("Недостаточно данных! Обязательны к заполнению: фамилия, имя, отчество, паспорт, СНИЛС, зарплата.");
            db.closeConnection();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
                var selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[selectedRow];
                    if ((row.Cells[0].Value != null) && (row.Cells[1].Value != null) &&
                        (row.Cells[2].Value != null) && (row.Cells[3].Value != null) &&
                        (row.Cells[4].Value != null) && (row.Cells[5].Value != null) &&
                        (row.Cells[6].Value != null) && (row.Cells[7].Value != null) &&
                        (row.Cells[8].Value != null)) 
                    {
                        
                       id_delete.Text = row.Cells[0].Value.ToString();
                        Id_update.Text = row.Cells[0].Value.ToString();
                        Fam_ins.Text = row.Cells[1].Value.ToString();
                        Im_ins.Text = row.Cells[2].Value.ToString();
                        Ot_ins.Text = row.Cells[3].Value.ToString();
                        Pas_ins.Text = row.Cells[4].Value.ToString();
                        Cnilc_ins.Text = row.Cells[5].Value.ToString();
                        Post_ins.Text = row.Cells[6].Value.ToString();
                        Salary_ins.Text = row.Cells[7].Value.ToString();
                        salesbooks_ins.Text = row.Cells[8].Value.ToString();
                    } 
                    else { MessageBox.Show("Пустая строка"); }

                }
        }

        private void Update_salarybutton_Click(object sender, EventArgs e)
        {
            db.openConnection();
            
            int Salary;

            int index = dataGridView1.CurrentCell.RowIndex;
            int ind;
            int flag = 0;
            
            

            for (int id = 0; id < dataGridView1.Rows.Count - 1; id++)
            {
                if (Convert.ToInt32(dataGridView1.Rows[id].Cells[0].Value) == Convert.ToInt32(Id_update.Text))
                {
                    index = id;
                    flag = 1;
                }
            }
            if ((flag == 0) && (Id_update.Text != String.Empty))
            {
                MessageBox.Show("Запись с такими Кодом сотрудника в таблице нет!");
                return;
            }
            else MessageBox.Show("Запись найдена!");
            ind = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
            if (int.TryParse(salary_update.Text, out Salary))
            {
                string queryString = $"CALL staf_update('{ind}', '{Salary}')";
                NpgsqlCommand command = new NpgsqlCommand(queryString, db.getConnection());

                command.ExecuteNonQuery();
                MessageBox.Show("Запись обновлена!");
                RefreshDataGrid(dataGridView1);
            }
            else MessageBox.Show("Некорректный ввод");
            db.closeConnection();
        }

        private void Bonus_button_Click(object sender, EventArgs e)
        {
            db.openConnection();
            
            /*int[] salary_old = new int[n];
            int[] id_max_sb = new int[n]; //0, 1 */
            string queryString;

            {
                for (int i = 1; i < Flag.n + 1; i++) // 1, 2
                {
                    // обнуление бонуса (возвращение зарплаты к стандартной)
                    queryString = $"CALL update_salary('{Flag.id_max_sb[i - 1]}', '{Flag.salary_old[i - 1]}')";
                    NpgsqlCommand command2 = new NpgsqlCommand(queryString, db.getConnection());
                    command2.ExecuteNonQuery();
                }
                RefreshDataGrid(dataGridView1);
                MessageBox.Show("Обнуление бонуса");
                
            }
            for (int i = 1; i < Flag.n+1; i++) // 1, 2
            {
                //поиск id с максимальным salesbooks
                queryString = $"SELECT * FROM max_salesbooks('{i}', '{Id_store.id}')";
                NpgsqlCommand command = new NpgsqlCommand(queryString, db.getConnection());
                Flag.id_max_sb[i-1] = Convert.ToInt32(command.ExecuteScalar());
                //запоминание salary для найденного id
                queryString = $"SELECT * FROM select_salary('{Flag.id_max_sb[i-1]}')";
                NpgsqlCommand command1 = new NpgsqlCommand(queryString, db.getConnection());
                Flag.salary_old[i - 1] = Convert.ToInt32(command1.ExecuteScalar());
                // для найденного id увеличение зарплаты (начисление бонуса)
                queryString = $"CALL update_salary('{Flag.id_max_sb[i - 1]}', '{Convert.ToInt32(Flag.salary_old[i - 1] * 1.20)}')";
                NpgsqlCommand command2 = new NpgsqlCommand(queryString, db.getConnection());
                command2.ExecuteNonQuery();

            }
            RefreshDataGrid(dataGridView1);
            MessageBox.Show("Бонус начислен");
            // обнуление salebooks
            queryString = $"CALL salesbooks_nool('{Id_store.id}')";
            NpgsqlCommand command3 = new NpgsqlCommand(queryString, db.getConnection());
            command3.ExecuteNonQuery();
            
            RefreshDataGrid(dataGridView1);
            MessageBox.Show("Кол-во проданных книг обнулено");
            
            db.closeConnection();
        }

        private void on_store_id_Click(object sender, EventArgs e)
        {
            this.Hide();
            Store_id_m store_id = new Store_id_m();
            store_id.Show();
        }

        private void update_table_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }
    }
}
