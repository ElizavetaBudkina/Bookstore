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
    public partial class Form_worker : Form
    {
        public Form_worker()
        {
            InitializeComponent();
            Workers_Load();
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
            dataGridView_books.Columns.Add("id", "Код записи");
            dataGridView_books.Columns.Add("Name", "Название книги");
            dataGridView_books.Columns.Add("Price", "Цена (Р)");
            dataGridView_books.Columns.Add("LIM", "Ограничение 18+");
            dataGridView_books.Columns.Add("rack", "Стеллаж");
            dataGridView_books.Columns.Add("shelf", "Полка");
            dataGridView_books.Columns.Add("place", "Место");
        }
        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), 
                record.GetBoolean(3), record.GetInt32(4), record.GetString(5), record.GetInt32(6));
        }
        private void RefreshDataGrid_books(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"SELECT * FROM select_books('{Id_store.id}')";
            NpgsqlCommand command = new NpgsqlCommand(queryString, db.getConnection());
            db.openConnection();
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }
        private void CreateColumns_customers()
        {
            dataGridView_cust.Columns.Add("id", "Код клиента");
            dataGridView_cust.Columns.Add("Fam", "Фамилия");
            dataGridView_cust.Columns.Add("Im", "Имя");
            dataGridView_cust.Columns.Add("Ot", "Отчество");
            dataGridView_cust.Columns.Add("data_birth", "Дата рождения");
            dataGridView_cust.Columns.Add("kol_book", "Кол-во купленных книг");
            dataGridView_cust.Columns.Add("sum_pay", "Сумма покупок (Р)");
            dataGridView_cust.Columns.Add("reduct", "Скидка пост. клиента");
        }
        private void RefreshDataGrid_customers(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"SELECT * FROM select_customers('{Id_store.id}')";
            NpgsqlCommand command = new NpgsqlCommand(queryString, db.getConnection());
            db.openConnection();
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                dgw.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                reader.GetString(3), reader.GetDateTime(4).ToShortDateString(), reader.GetInt32(5), reader.GetDouble(6), reader.GetBoolean(7));
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
            string queryString = $"SELECT * FROM select_sales('{Id_store.id}')";
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
        private void Workers_Load()
        {
            CreateColumns_books();
            RefreshDataGrid_books(dataGridView_books);
            CreateColumns_customers();
            RefreshDataGrid_customers(dataGridView_cust);
            CreateColumns_sales();
            RefreshDataGrid_sales(dataGridView_sales);
        }
        private void dataGridView_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_books.Rows[selectedRow];
                if ((row.Cells[0].Value != null) && (row.Cells[1].Value != null) &&
                    (row.Cells[2].Value != null) && (row.Cells[3].Value != null) &&
                    (row.Cells[4].Value != null) && (row.Cells[5].Value != null) &&
                    (row.Cells[6].Value != null))
                {
                    //ins_bookid.Text = row.Cells[0].Value.ToString();
                    ins_bookname.Text = row.Cells[1].Value.ToString();
                    ins_rack.Text = row.Cells[4].Value.ToString();
                    ins_shelf.Text = row.Cells[5].Value.ToString();
                    ins_place.Text = row.Cells[6].Value.ToString();
                    delete_idlist.Text = row.Cells[0].Value.ToString();
                    update_rackbook.Text = row.Cells[4].Value.ToString();
                    update_shelfbook.Text = row.Cells[5].Value.ToString();
                    update_placebook.Text = row.Cells[6].Value.ToString();

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
                    ins_famcust.Text = row.Cells[1].Value.ToString();
                    ins_imcust.Text = row.Cells[2].Value.ToString();
                    ins_otcust.Text = row.Cells[3].Value.ToString();
                    ins_databirthcust.Text = row.Cells[4].Value.ToString();
                    ins_kolbookcust.Text = row.Cells[5].Value.ToString();
                    ins_sumpaycust.Text = row.Cells[6].Value.ToString();
                    id_checkon18.Text = row.Cells[0].Value.ToString();
                }
                else { MessageBox.Show("Пустая строка"); }

            }
        }

        private void dataGridView_sales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_sales.Rows[selectedRow];
                if ((row.Cells[0].Value != null) && (row.Cells[1].Value != null) &&
                    (row.Cells[2].Value != null) && (row.Cells[3].Value != null))
                {
                    ins_idcustsales.Text = row.Cells[0].Value.ToString();
                    ins_idstaffsales.Text = row.Cells[1].Value.ToString();
                    ins_kolbooksales.Text = row.Cells[2].Value.ToString();
                    ins_sumpaysales.Text = row.Cells[3].Value.ToString();

                }
                else { MessageBox.Show("Пустая строка"); }

            }
        }

        private void on_store_id_Click(object sender, EventArgs e) //книги
        {
            this.Hide();
            Store_id_m store_id = new Store_id_m();
            store_id.Show();
        }

        private void button3_Click(object sender, EventArgs e) //продажи
        {
            this.Hide();
            Store_id_m store_id = new Store_id_m();
            store_id.Show();
        }

        private void button1_Click(object sender, EventArgs e) //клиенты
        {
            this.Hide();
            Store_id_m store_id = new Store_id_m();
            store_id.Show();
        }

        private void update_table_Click(object sender, EventArgs e)
        {
            RefreshDataGrid_books(dataGridView_books);
        }

        private void update_tablecust_Click(object sender, EventArgs e)
        {
            RefreshDataGrid_customers(dataGridView_cust);
        }


        private void update_tablesales_Click(object sender, EventArgs e)
        {
            RefreshDataGrid_sales(dataGridView_sales);
        }

        private void ins_custbutton_Click(object sender, EventArgs e)
        {
            db.openConnection();
            var Fam = ins_famcust.Text;
            var Im = ins_imcust.Text;
            var Ot = ins_otcust.Text;
            var data_birth = ins_databirthcust.Text;
            int kol_book = 0;
            int sum_pay = 0;
            var reduct = false;


            if ((ins_famcust.Text != string.Empty) && (ins_imcust.Text != string.Empty) && (ins_otcust.Text != string.Empty) &&
                (ins_databirthcust.Text != string.Empty))
            {
                if (int.TryParse(ins_kolbookcust.Text, out kol_book) && int.TryParse(ins_sumpaycust.Text, out sum_pay))
                {
                    if ((kol_book > 100) || (sum_pay > 30000)) { reduct = true; }
                    Convert.ToDateTime(data_birth);
                    string queryString = $"CALL ins_cust('{Fam}', '{Im}', '{Ot}', '{data_birth}', '{kol_book}', '{sum_pay}', '{reduct}', '{Id_store.id}')";
                    NpgsqlCommand command = new NpgsqlCommand(queryString, db.getConnection());

                    
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись создана!");
                    RefreshDataGrid_customers(dataGridView_cust);
                }
                else MessageBox.Show("Некорректный ввод");
            } else MessageBox.Show("Недостаточно данных! Обязательны к заполнению: фамилия, имя, отчество, дата рождения.");
            db.closeConnection();
        }
       
        private void ins_salesbutton_Click(object sender, EventArgs e)
        {
            db.openConnection();
            var id_cust = ins_idcustsales.Text;
            var id_staff = ins_idstaffsales.Text;
            int kol_book = 0;
            int sum_pay = 0;
            var  b1 = false;
            var b2 = false;
            if ((ins_idcustsales.Text != string.Empty) && (ins_idstaffsales.Text != string.Empty) && (ins_kolbooksales.Text != string.Empty) &&
                (ins_sumpaysales.Text != string.Empty))
            {
                if (int.TryParse(ins_kolbooksales.Text, out kol_book) && int.TryParse(ins_sumpaysales.Text, out sum_pay))
                {
                    var sql = $"SELECT * FROM poisk_staff('{id_staff}', '{Id_store.id}')";
                    NpgsqlCommand command1 = new NpgsqlCommand(sql, db.getConnection());
                    b1 = (bool)command1.ExecuteScalar();

                    var sql2 = $"SELECT * FROM poisk_cust('{id_cust}', '{Id_store.id}')";
                    NpgsqlCommand command2 = new NpgsqlCommand(sql2, db.getConnection());
                    b2 = (bool)command1.ExecuteScalar();
                    if (b1)
                    {
                        if (b2)
                        {
                            string s1 = $"CALL books_pay('{id_cust}', '{kol_book}', '{sum_pay}')";
                            NpgsqlCommand command3 = new NpgsqlCommand(s1, db.getConnection());
                            command3.ExecuteNonQuery();
                            string s2 = $"CALL book_sales('{id_staff}', '{kol_book}')";
                            NpgsqlCommand command4 = new NpgsqlCommand(s2, db.getConnection());
                            command4.ExecuteNonQuery();

                            s1 = $"SELECT * FROM kol_book('{id_cust}')";
                            NpgsqlCommand command5 = new NpgsqlCommand(s1, db.getConnection());
                            var k = Convert.ToInt32(command5.ExecuteScalar());
                            s1 = $"SELECT * FROM sum_pay('{id_cust}')";
                            NpgsqlCommand command6 = new NpgsqlCommand(s1, db.getConnection());
                            var s = Convert.ToInt32(command6.ExecuteScalar());
                            if ((k > 100) || (s > 300000))
                            {
                                var s6 = $"CALL update_reduct('{id_cust}')";
                                NpgsqlCommand command7 = new NpgsqlCommand(s6, db.getConnection());
                                command7.ExecuteNonQuery();
                            }
                            //MessageBox.Show($"'{k}', '{s}'");
                            string queryString = $"CALL ins_sales('{id_cust}', '{id_staff}', '{kol_book}', '{sum_pay}')";
                            NpgsqlCommand command = new NpgsqlCommand(queryString, db.getConnection());
                            command.ExecuteNonQuery();
                            MessageBox.Show("Запись создана!");
                            RefreshDataGrid_sales(dataGridView_sales);
                        }
                        else MessageBox.Show("Клиента с таким кодом не существует!");

                    }
                    else MessageBox.Show("Сотрудника с таким кодом не существует!");


                }
                else MessageBox.Show("Некорректный ввод");
            }
            else MessageBox.Show("Недостаточно данных! Обязательны к заполнению: код клиента, код сотрудника, количество купленных книг, сумма покупки.");
            db.closeConnection();

        }

        private void ins_listbookbutton_Click(object sender, EventArgs e)
        {
            db.openConnection();
            var bookid = ins_bookid.Text;
            var bookname = ins_bookname.Text;
            int rack;
            var shelf = ins_shelf.Text;
            int place;
            bool f;

            if (((ins_bookid.Text != String.Empty) || (ins_bookname.Text != String.Empty)) && (ins_shelf.Text != String.Empty) &&
                (ins_rack.Text != String.Empty) && (ins_place.Text != String.Empty))
            {
                if (int.TryParse(ins_rack.Text, out rack) && int.TryParse(ins_place.Text, out place))
                {
                    string s = $"SELECT * FROM update_loc('{rack}', '{shelf}', '{place}', '{Id_store.id}')";
                    NpgsqlCommand command1 = new NpgsqlCommand(s, db.getConnection());
                    f = Convert.ToBoolean(command1.ExecuteScalar());
                    if (!f)
                    {
                        string queryString;
                        if (ins_bookid.Text != String.Empty) 
                        {
                            queryString = $"CALL ins_listbookid('{Id_store.id}', '{bookid}', '{rack}', '{shelf}', '{place}')";
                            NpgsqlCommand command = new NpgsqlCommand(queryString, db.getConnection());


                            command.ExecuteNonQuery(); //добавить проверку на нарушение внешнего ключа
                            MessageBox.Show("Запись создана!");
                            RefreshDataGrid_books(dataGridView_books);
                        }
                        else
                        {
                            queryString = $"CALL ins_listbookname('{Id_store.id}', '{bookname}', '{rack}', '{shelf}', '{place}')";
                            NpgsqlCommand command = new NpgsqlCommand(queryString, db.getConnection());


                            command.ExecuteNonQuery(); //добавить проверку на нарушение внешнего ключа
                            MessageBox.Show("Запись создана!");
                            RefreshDataGrid_books(dataGridView_books);
                        }
                    
                    }else MessageBox.Show("Данное местоположение занято.");
                    
                }
                else MessageBox.Show("Некорректный ввод");
            }
            else MessageBox.Show("Недостаточно данных! Обязательны к заполнению: номер стеллажа, номер полки(A-Z), номер места, код книги или название книги.");
            db.closeConnection();
        }
        
        private void Update_listbook_Click(object sender, EventArgs e)
        {
            Update_loc.dgv = dataGridView_books;
            Boolean f = false;
            string queryString;
            if ((update_shelfbook.Text != String.Empty) && (update_placebook.Text != String.Empty) && (update_rackbook.Text != String.Empty))
            {
                Regex r = new Regex("[A-Z]{1}");
                MatchCollection matches = r.Matches(update_shelfbook.Text);
                if (matches.Count > 0) { f = true; }
                if (int.TryParse(update_rackbook.Text, out Update_loc.rack) && int.TryParse(update_placebook.Text, out Update_loc.place)
                    && f)
                {
                    Update_loc.shelf = update_shelfbook.Text;
                    db.openConnection();
                    //MessageBox.Show($"'{Update_loc.rack}', '{Update_loc.shelf}', '{Update_loc.place}','{Id_store.id}'");
                    queryString = $"SELECT * FROM update_loc('{Update_loc.rack}', '{Update_loc.shelf}', '{Update_loc.place}', '{Id_store.id}')";
                    NpgsqlCommand command = new NpgsqlCommand(queryString, db.getConnection());

                    Update_loc.f = Convert.ToBoolean(command.ExecuteScalar());
                    //MessageBox.Show($"'{Update_loc.f}'");
                    if (Update_loc.f)
                    {
                        this.Hide();
                        Updatelistbook update = new Updatelistbook();
                        update.Show();
                    }
                    else MessageBox.Show("Записи с таким местоположением не найдено!");


                }
                else MessageBox.Show("Некорректный ввод");

            }
            else MessageBox.Show("Недостаточно данных! Обязательны к заполнению: номер стеллажа, номер полки(A-Z), номер места.");

        }

        private void checkon18_Click(object sender, EventArgs e)
        {
            db.openConnection();
            Boolean f;
            int ind;
            int index = dataGridView_cust.CurrentCell.RowIndex;
            byte flag = 0;
            for (int id = 0; id < dataGridView_cust.Rows.Count - 1; id++)
            {
                if (Convert.ToInt32(dataGridView_cust.Rows[id].Cells[0].Value) == Convert.ToInt32(id_checkon18.Text))
                {
                    index = id;
                    flag = 1;
                }


            }
            if ((flag == 0) && (id_checkon18.Text != String.Empty))
            {
                MessageBox.Show("Записи с такими данными в таблице нет!");
                return;
            }
            //else MessageBox.Show("Запись найдена.");
            ind = Convert.ToInt32(dataGridView_cust.Rows[index].Cells[0].Value);
            
            var queryString = $"SELECT * FROM Checkon18('{ind}')";

            var command = new NpgsqlCommand(queryString, db.getConnection());
            f = Convert.ToBoolean(command.ExecuteScalar());
            if (f)
            {
                MessageBox.Show("Клиенту есть 18 лет!");
            }
            else MessageBox.Show("Клиенту нет 18 лет!");
            
            db.closeConnection();
        }

        private void delete_book_Click(object sender, EventArgs e)
        {

            db.openConnection();

            int ind;
            int index = dataGridView_books.CurrentCell.RowIndex;
            byte flag = 0;
            if ((delete_idlist.Text == String.Empty) && (delete_bookname.Text == String.Empty))
            {
                MessageBox.Show("Данные не введены. Обязательно к заполнению: код книги или название.");
                return;
            }
            
            for (int id = 0; id < dataGridView_books.Rows.Count - 1; id++)
            {
                if(delete_bookname.Text != String.Empty)
                { 
                    if (Convert.ToInt32(dataGridView_books.Rows[id].Cells[1].Value) == Convert.ToInt32(delete_bookname.Text))
                    {
                        index = id;
                        flag = 1;
                    }
                }
                if (delete_idlist.Text != String.Empty)
                {
                    if (Convert.ToInt32(dataGridView_books.Rows[id].Cells[0].Value) == Convert.ToInt32(delete_idlist.Text))
                    {
                        index = id;
                        flag = 1;
                    }
                }
               


            }
            if ((flag == 0) && ((delete_idlist.Text != String.Empty) && delete_bookname.Text == String.Empty))
            {
                MessageBox.Show("Записи с такими данными в таблице нет!");
                return;
            }
            else MessageBox.Show("Запись найдена.");
            ind = Convert.ToInt32(dataGridView_books.Rows[index].Cells[0].Value);
            var deletQuery = $"CALL delete_listbook('{ind}')";

            var command = new NpgsqlCommand(deletQuery, db.getConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Запись удалена.");

            dataGridView_books.Rows[index].Visible = false;

            db.closeConnection();
        }
    }
}

