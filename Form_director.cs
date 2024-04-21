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
    public partial class Form_director : Form
    {
        public Form_director()
        {
            InitializeComponent();
            Director_Load();
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
        private void CreateColumns_books()
        {
            dataGridView_books.Columns.Add("id", "Код книги");
            dataGridView_books.Columns.Add("Name", "Название книги");
            dataGridView_books.Columns.Add("Price", "Цена (Р)");
            dataGridView_books.Columns.Add("LIM", "Ограничение 18+");
        }
        private void ReadSingleRow_books(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2),
                record.GetBoolean(3));
        }
        private void RefreshDataGrid_books(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"SELECT * FROM select_books()";
            NpgsqlCommand command = new NpgsqlCommand(queryString, db.getConnection());
            db.openConnection();
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_books(dgw, reader);
            }
            reader.Close();
        }
        private void CreateColumns_role()
        {
            dataGridView_role.Columns.Add("login", "Логин");
            dataGridView_role.Columns.Add("password", "Пароль");
        }
        private void ReadSingleRow_role(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetString(0), record.GetString(1));
        }
        private void RefreshDataGrid_role(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"SELECT * FROM select_roles()";
            NpgsqlCommand command = new NpgsqlCommand(queryString, db.getConnection());
            db.openConnection();
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_role(dgw, reader);
            }
            reader.Close();
        }
        private void CreateColumns_store()
        {
            dataGridView_stor.Columns.Add("id", "Код магазина");
            dataGridView_stor.Columns.Add("City", "Город");
            dataGridView_stor.Columns.Add("Street", "Улица");
            dataGridView_stor.Columns.Add("House", "Дом");
        }
        private void RefreshDataGrid_store(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"SELECT * FROM select_store()";
            NpgsqlCommand command = new NpgsqlCommand(queryString, db.getConnection());
            db.openConnection();
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                dgw.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
            }
            reader.Close();
        }
        private void CreateColumns_staff()
        {
            dataGridView_staff.Columns.Add("id", "Код сотрудника");
            dataGridView_staff.Columns.Add("Fam", "Фамилия");
            dataGridView_staff.Columns.Add("Im", "Имя");
            dataGridView_staff.Columns.Add("Ot", "Отчество");
            dataGridView_staff.Columns.Add("passport", "Паспорт");
            dataGridView_staff.Columns.Add("CNILC", "СНИЛС");
            dataGridView_staff.Columns.Add("Post", "Должность");
            dataGridView_staff.Columns.Add("Salary", "Зарплата (в тыс.руб.)");
            dataGridView_staff.Columns.Add("salesbooks", "Кол-во проданных книг");
            dataGridView_staff.Columns.Add("id_store", "Код магазина");
        }
        private void RefreshDataGrid_staff(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"SELECT * FROM select_staff()";
            NpgsqlCommand command = new NpgsqlCommand(queryString, db.getConnection());
            db.openConnection();
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                dgw.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6),
                reader.GetDouble(7), reader.GetInt32(8), reader.GetInt32(9));
            }
            reader.Close();
        }
        private void CreateColumns_sales()
        {
            dataGridView_sales.Columns.Add("id_customers", "Код клиента");
            dataGridView_sales.Columns.Add("id_staff", "Код сотрудника");
            dataGridView_sales.Columns.Add("ko_book", "Кол-во купленных книг");
            dataGridView_sales.Columns.Add("sum_pay", "Сумма покупки (Р)");
            dataGridView_sales.Columns.Add("ts", "время покупки");
        }
        private void RefreshDataGrid_sales(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"SELECT * FROM select_sales()";
            NpgsqlCommand command = new NpgsqlCommand(queryString, db.getConnection());
            db.openConnection();
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                dgw.Rows.Add(reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3),
                reader.GetDouble(4), reader.GetDateTime(5));
            }
            reader.Close();
        }
        private void CreateColumns_cust()
        {
            dataGridView_cust.Columns.Add("id", "Код клиента");
            dataGridView_cust.Columns.Add("Fam", "Фамилия");
            dataGridView_cust.Columns.Add("Im", "Имя");
            dataGridView_cust.Columns.Add("Ot", "Отчество");
            dataGridView_cust.Columns.Add("data_birth", "Дата рождения");
            dataGridView_cust.Columns.Add("kol_book", "Кол-во купленных книг");
            dataGridView_cust.Columns.Add("sum_pay", "Сумма покупок (Р)");
            dataGridView_cust.Columns.Add("reduct", "Скидка пост. клиента");
            dataGridView_cust.Columns.Add("id_store", "Код магазина");

        }
        private void RefreshDataGrid_cust(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"SELECT * FROM select_cust()";
            NpgsqlCommand command = new NpgsqlCommand(queryString, db.getConnection());
            db.openConnection();
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                dgw.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                reader.GetString(3), reader.GetDateTime(4).ToShortDateString(), reader.GetInt32(5), reader.GetDouble(6), reader.GetBoolean(7), reader.GetInt32(8));
            }
            reader.Close();
        }
        private void CreateColumns_list()
        {
            dataGridView_list.Columns.Add("id", "Код книги");
            dataGridView_list.Columns.Add("Name", "Название книги");
            dataGridView_list.Columns.Add("Price", "Цена (Р)");
            dataGridView_list.Columns.Add("LIM", "Ограничение 18+");
            dataGridView_list.Columns.Add("number", "Номер книги в магазине");
            dataGridView_list.Columns.Add("id_store", "Код магазина");

        }
        private void RefreshDataGrid_list(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"SELECT * FROM select_list_dir()";
            NpgsqlCommand command = new NpgsqlCommand(queryString, db.getConnection());
            db.openConnection();
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                dgw.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2),
                reader.GetBoolean(3), reader.GetInt32(4), reader.GetInt32(5));
            }
            reader.Close();
        }
        private void Director_Load()
        {
            CreateColumns_books();
            RefreshDataGrid_books(dataGridView_books);
            CreateColumns_staff();
            RefreshDataGrid_staff(dataGridView_staff);
            CreateColumns_role();
            RefreshDataGrid_role(dataGridView_role);
            CreateColumns_store();
            RefreshDataGrid_store(dataGridView_stor);
            CreateColumns_sales();
            RefreshDataGrid_sales(dataGridView_sales);
            CreateColumns_cust();
            RefreshDataGrid_cust(dataGridView_cust);
            CreateColumns_list();
            RefreshDataGrid_list(dataGridView_list);

        }
        private void on_form_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void return_staff_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void return_cust_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void return_sales_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void return_store_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        
       

        private void update_tablestor_Click(object sender, EventArgs e)
        {
            RefreshDataGrid_store(dataGridView_stor);
        }

        private void dataGridView_stor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_stor.Rows[selectedRow];
                if ((row.Cells[0].Value != null) && (row.Cells[1].Value != null) &&
                    (row.Cells[2].Value != null) && (row.Cells[3].Value != null))
                {
                    ins_idstore.Text = row.Cells[0].Value.ToString();
                    ins_city.Text = row.Cells[1].Value.ToString();
                    ins_street.Text = row.Cells[2].Value.ToString();
                    ins_house.Text = row.Cells[3].Value.ToString();
                    delete_idstore.Text = row.Cells[0].Value.ToString();
                }
                else { MessageBox.Show("Пустая строка"); }

            }
        } 
        private void ins_storebutton_Click(object sender, EventArgs e)
        {
            db.openConnection();
            var idstore = ins_idstore.Text;
            var City = ins_city.Text;
            var Street = ins_street.Text;
            var House = ins_house.Text;

            if ((ins_city.Text != string.Empty) && (ins_street.Text != string.Empty) && (ins_house.Text != string.Empty))
            {
                if (ins_idstore.Text != string.Empty)
                {
                    string queryString = $"CALL ins_store('{idstore}', '{City}', '{Street}', '{House}')";
                    NpgsqlCommand command = new NpgsqlCommand(queryString, db.getConnection());


                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись создана!");
                    RefreshDataGrid_store(dataGridView_stor);
                }
                else
                {
                    string queryString = $"CALL ins_store('{City}', '{Street}', '{House}')";
                    NpgsqlCommand command = new NpgsqlCommand(queryString, db.getConnection());
                
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись создана!");
                    RefreshDataGrid_store(dataGridView_stor);
                }
               
            }
            else MessageBox.Show("Недостаточно данных! Обязательны к заполнению: город, улица, дом.");
            db.closeConnection();
        }

        private void delete_store_Click(object sender, EventArgs e)
        {
            db.openConnection();

            int ind;
            int index = dataGridView_stor.CurrentCell.RowIndex;
            byte flag = 0;
            if (delete_idbooks.Text == String.Empty)
            {
                MessageBox.Show("Данные не введены. Обязательно к заполнению: код магазина.");
                return;
            }
            for (int id = 0; id < dataGridView_stor.Rows.Count - 1; id++)
            {

                if (Convert.ToInt32(dataGridView_stor.Rows[id].Cells[0].Value) == Convert.ToInt32(delete_idstore.Text))
                {
                    index = id;
                    flag = 1;
                }


            }
            if ((flag == 0) && (delete_idstore.Text != String.Empty))
            {
                MessageBox.Show("Записи с такими данными в таблице нет!");
                return;
            }
            else MessageBox.Show("Запись найдена.");
            ind = Convert.ToInt32(dataGridView_stor.Rows[index].Cells[0].Value);
            var deletQuery = $"CALL delete_store('{ind}')";

            var command = new NpgsqlCommand(deletQuery, db.getConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Запись удалена.");

            dataGridView_stor.Rows[index].Visible = false;

            db.closeConnection();
        }

        private void ins_booksbutton_Click(object sender, EventArgs e)
        {
            db.openConnection();
            var idbooks = ins_idstore.Text;
            var Name = ins_booksname.Text;
            int price;
            Boolean LIM;

            if ((ins_booksname.Text != string.Empty) && (ins_booksprice.Text != string.Empty) && (ins_booksLIM.Text != string.Empty))
            {
                if (int.TryParse(ins_booksprice.Text, out price) && bool.TryParse(ins_booksLIM.Text, out LIM))
                {
                
                    if (ins_idstore.Text != string.Empty)
                    {
                        string queryString = $"CALL ins_books('{idbooks}', '{Name}', '{price}', '{LIM}')";
                        NpgsqlCommand command = new NpgsqlCommand(queryString, db.getConnection());


                        command.ExecuteNonQuery();
                        MessageBox.Show("Запись создана!");
                        RefreshDataGrid_store(dataGridView_books);
                    }
                    else
                    {
                        string queryString = $"CALL ins_books('{Name}', '{price}', '{LIM}')";
                        NpgsqlCommand command = new NpgsqlCommand(queryString, db.getConnection());

                        command.ExecuteNonQuery();
                        MessageBox.Show("Запись создана!");
                        RefreshDataGrid_books(dataGridView_books);
                    }
                }
                else MessageBox.Show("Некорректный ввод");

            }
            else MessageBox.Show("Недостаточно данных! Обязательны к заполнению: название книги, цена, ограничение.");
            db.closeConnection();
        }

        private void delete_booksbutton_Click(object sender, EventArgs e)
        {
            db.openConnection();

            int ind;
            int index = dataGridView_books.CurrentCell.RowIndex;
            byte flag = 0;
            if (delete_idbooks.Text == String.Empty) 
            { 
                MessageBox.Show("Данные не введены. Обязательно к заполнению: код книги.");
                return;
            }
            for (int id = 0; id < dataGridView_books.Rows.Count - 1; id++)
            {

                if (Convert.ToInt32(dataGridView_books.Rows[id].Cells[0].Value) == Convert.ToInt32(delete_idbooks.Text))
                {
                    index = id;
                    flag = 1;
                }


            }
            if ((flag == 0) && (delete_idbooks.Text != String.Empty))
            {
                MessageBox.Show("Записи с такими данными в таблице нет!");
                return;
            }
            else MessageBox.Show("Запись найдена.");
            ind = Convert.ToInt32(dataGridView_books.Rows[index].Cells[0].Value);
            var deletQuery = $"CALL delete_books('{ind}')";

            var command = new NpgsqlCommand(deletQuery, db.getConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Запись удалена.");

            dataGridView_books.Rows[index].Visible = false;

            db.closeConnection();
        }

        private void dataGridView_books_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_books.Rows[selectedRow];
                if ((row.Cells[0].Value != null) && (row.Cells[1].Value != null) &&
                    (row.Cells[2].Value != null) && (row.Cells[3].Value != null))
                {
                    ins_idbooks.Text = row.Cells[0].Value.ToString();
                    ins_booksname.Text = row.Cells[1].Value.ToString();
                    ins_booksprice.Text = row.Cells[2].Value.ToString();
                    ins_booksLIM.Text = row.Cells[3].Value.ToString();
                    delete_idbooks.Text = row.Cells[0].Value.ToString();
                }
                else { MessageBox.Show("Пустая строка"); }

            }
        }

        private void update_list_Click(object sender, EventArgs e)
        {
            RefreshDataGrid_list(dataGridView_list);
        }

        private void update_tablesales_Click(object sender, EventArgs e)
        {
            RefreshDataGrid_sales(dataGridView_sales);
        }

        private void update_tablestaff_Click(object sender, EventArgs e)
        {
            RefreshDataGrid_staff(dataGridView_staff);
        }

        private void update_tablecust_Click(object sender, EventArgs e)
        {
            RefreshDataGrid_cust(dataGridView_cust);
        }

        private void return_list_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void update_tablebooks_Click(object sender, EventArgs e)
        {
            RefreshDataGrid_books(dataGridView_books);
        }

        private void dataGridView_staff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_staff.Rows[selectedRow];
                if ((row.Cells[0].Value != null) && (row.Cells[1].Value != null) &&
                    (row.Cells[2].Value != null) && (row.Cells[3].Value != null) &&
                    (row.Cells[4].Value != null) && (row.Cells[5].Value != null) &&
                    (row.Cells[6].Value != null) && (row.Cells[7].Value != null) &&
                    (row.Cells[8].Value != null) && (row.Cells[9].Value != null))
                {

                    delete_staff.Text = row.Cells[0].Value.ToString();
                    Fam_ins.Text = row.Cells[1].Value.ToString();
                    Im_ins.Text = row.Cells[2].Value.ToString();
                    Ot_ins.Text = row.Cells[3].Value.ToString();
                    Pas_ins.Text = row.Cells[4].Value.ToString();
                    Cnilc_ins.Text = row.Cells[5].Value.ToString();
                    Post_ins.Text = row.Cells[6].Value.ToString();
                    Salary_ins.Text = row.Cells[7].Value.ToString();
                    salesbooks_ins.Text = row.Cells[8].Value.ToString();
                    ins_staffstore.Text = row.Cells[9].Value.ToString();
                }
                else { MessageBox.Show("Пустая строка"); }

            }
        }

        private void dataGridView_cust_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_cust.Rows[selectedRow];
                if ((row.Cells[0].Value != null) && (row.Cells[1].Value != null) &&
                    (row.Cells[2].Value != null) && (row.Cells[3].Value != null) &&
                    (row.Cells[4].Value != null) && (row.Cells[5].Value != null) &&
                    (row.Cells[6].Value != null) && (row.Cells[7].Value != null))
                {
                    ins_idcust.Text = row.Cells[0].Value.ToString();
                    ins_famcust.Text = row.Cells[1].Value.ToString();
                    ins_imcust.Text = row.Cells[2].Value.ToString();
                    ins_otcust.Text = row.Cells[3].Value.ToString();
                    ins_databirthcust.Text = row.Cells[4].Value.ToString();
                    ins_kolbookcust.Text = row.Cells[5].Value.ToString();
                    ins_sumpaycust.Text = row.Cells[6].Value.ToString();
                    ins_reductcust.Text = row.Cells[7].Value.ToString();
                    ins_custstore.Text = row.Cells[8].Value.ToString();
                    delete_cust.Text = row.Cells[0].Value.ToString();
                }
                else { MessageBox.Show("Пустая строка"); }

            }
        }

        private void ins_custbutton_Click(object sender, EventArgs e)
        {
            db.openConnection();
            int id;
            var Fam = ins_famcust.Text;
            var Im = ins_imcust.Text;
            var Ot = ins_otcust.Text;
            var data_birth = ins_databirthcust.Text;
            int kol_book = 0;
            int sum_pay = 0;
            var reduct = false;
            int idstore;


            if ((ins_famcust.Text != string.Empty) && (ins_imcust.Text != string.Empty) && (ins_otcust.Text != string.Empty) &&
                (ins_databirthcust.Text != string.Empty))
            {
                if (ins_idcust.Text == String.Empty)
                {
                    if (ins_kolbookcust.Text != String.Empty) { if (! int.TryParse(ins_kolbookcust.Text, out kol_book))
                        { MessageBox.Show("Некорректный ввод"); return; } }
                    if (ins_sumpaycust.Text != String.Empty)
                    {
                        if (!int.TryParse(ins_sumpaycust.Text, out sum_pay))
                        { MessageBox.Show("Некорректный ввод"); return; }
                    }
                    if (int.TryParse(ins_custstore.Text, out idstore))
                    {
                        if ((kol_book > 100) || (sum_pay > 30000)) { reduct = true; }
                        Convert.ToDateTime(data_birth);
                        string queryString = $"CALL ins_cust('{Fam}', '{Im}', '{Ot}', '{data_birth}', '{kol_book}', '{sum_pay}', '{reduct}', '{idstore}')";
                        NpgsqlCommand command = new NpgsqlCommand(queryString, db.getConnection());


                        command.ExecuteNonQuery();
                        MessageBox.Show("Запись создана!");
                        RefreshDataGrid_cust(dataGridView_cust);
                    }
                    else MessageBox.Show("Некорректный ввод");
                }
                else
                {
                    if (ins_kolbookcust.Text != String.Empty)
                    {
                        if (!int.TryParse(ins_kolbookcust.Text, out kol_book))
                        { MessageBox.Show("Некорректный ввод"); return; }
                    }
                    if (ins_sumpaycust.Text != String.Empty)
                    {
                        if (!int.TryParse(ins_sumpaycust.Text, out sum_pay))
                        { MessageBox.Show("Некорректный ввод"); return; }
                    }
                    if (int.TryParse(ins_custstore.Text, out idstore) && int.TryParse(ins_idcust.Text, out id))
                    {

                        if ((kol_book > 100) || (sum_pay > 30000)) { reduct = true; }
                        Convert.ToDateTime(data_birth);
                        string queryString = $"CALL ins_cust('{id}', '{Fam}', '{Im}', '{Ot}', '{data_birth}', '{kol_book}', '{sum_pay}', '{reduct}', '{idstore}')";
                        NpgsqlCommand command = new NpgsqlCommand(queryString, db.getConnection());


                        command.ExecuteNonQuery();
                        MessageBox.Show("Запись создана!");
                        RefreshDataGrid_cust(dataGridView_cust);
                    }
                    else MessageBox.Show("Некорректный ввод");
                }
            }
            else MessageBox.Show("Недостаточно данных! Обязательны к заполнению: фамилия, имя, отчество, дата рождения.");
            db.closeConnection();
        }

        private void delete_custbutton_Click(object sender, EventArgs e)
        {
            db.openConnection();

            int ind;
            int index = dataGridView_cust.CurrentCell.RowIndex;
            byte flag = 0;
            if (delete_cust.Text == String.Empty)
            {
                MessageBox.Show("Данные не введены. Обязательно к заполнению: код клиента.");
                return;
            }
            for (int id = 0; id < dataGridView_books.Rows.Count - 1; id++)
            {

                if (Convert.ToInt32(dataGridView_books.Rows[id].Cells[0].Value) == Convert.ToInt32(delete_cust.Text))
                {
                    index = id;
                    flag = 1;
                }


            }
            if ((flag == 0) && (delete_cust.Text != String.Empty))
            {
                MessageBox.Show("Записи с такими данными в таблице нет!");
                return;
            }
            else MessageBox.Show("Запись найдена.");
            ind = Convert.ToInt32(dataGridView_cust.Rows[index].Cells[0].Value);
            var deletQuery = $"CALL delete_cust('{ind}')";

            var command = new NpgsqlCommand(deletQuery, db.getConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Запись удалена.");

            dataGridView_books.Rows[index].Visible = false;

            db.closeConnection();
        }

        private void ins_staffbutton_Click(object sender, EventArgs e)
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
            int idstore;

            if ((Post_ins.Text != string.Empty) && ((Post_ins.Text == "Менеджер") || (Post_ins.Text == "Работник"))) { Post = Post_ins.Text; }

            if ((Fam_ins.Text != string.Empty) && (Im_ins.Text != string.Empty) && (Ot_ins.Text != string.Empty) &&
                (Pas_ins.Text != string.Empty) && (Cnilc_ins.Text != string.Empty) && (Salary_ins.Text != string.Empty) && (ins_staffstore.Text != string.Empty))
            {
                if (int.TryParse(Salary_ins.Text, out Salary) && int.TryParse(ins_staffstore.Text, out idstore))
                {

                    int.TryParse(salesbooks_ins.Text, out salesbooks);
                    string queryString = $"CALL staflist_ins('{Fam}', '{Im}', '{Ot}', '{Pas}', '{Cnilc}', '{Post}', '{Salary}', '{salesbooks}', '{idstore}')";
                    NpgsqlCommand command = new NpgsqlCommand(queryString, db.getConnection());

                    /*!*/
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись создана!");
                    RefreshDataGrid_staff(dataGridView_staff);
                }
                else MessageBox.Show("Некорректный ввод");
            }
            else MessageBox.Show("Недостаточно данных! Обязательны к заполнению: фамилия, имя, отчество, паспорт, СНИЛС, зарплата, код магазина.");
            db.closeConnection();
        }

        private void delete_staffbutton_Click(object sender, EventArgs e)
        {
            db.openConnection();

            int ind;
            int index = dataGridView_staff.CurrentCell.RowIndex;
            byte flag = 0;
            for (int id = 0; id < dataGridView_staff.Rows.Count - 1; id++)
            {
                if (Convert.ToInt32(dataGridView_staff.Rows[id].Cells[0].Value) == Convert.ToInt32(delete_staff.Text))
                {
                    index = id;
                    flag = 1;
                }


            }
            if ((flag == 0) && (delete_staff.Text != String.Empty))
            {
                MessageBox.Show("Записи с такими данными в таблице нет!");
                return;
            }
            else MessageBox.Show("Запись найдена.");
            ind = Convert.ToInt32(dataGridView_staff.Rows[index].Cells[0].Value);
            var deletQuery = $"CALL staf_delete('{ind}')";

            var command = new NpgsqlCommand(deletQuery, db.getConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Запись удалена.");

            dataGridView_staff.Rows[index].Visible = false;

            db.closeConnection();
        }
    }
}
