using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Password_Bank
{
    class dbcodes
    {
        OleDbCommand cmd;
        OleDbDataReader dr;
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\pbdb.mdb;Jet OLEDB:Database Password=00991982*");

        public DataGridView listing(DataGridView dgv)
        {
            try
            {
                cmd = new OleDbCommand("select * from data", connect);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
                return dgv;
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format(Localization.dbcodes_Error_Main, "ERR_DGVLISTING"), Localization.dbcodes_Error_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return dgv;
            }
        }

        public DataGridView listingrecycle(DataGridView dgv)
        {
            try
            {
                cmd = new OleDbCommand("select * from recycle", connect);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
                return dgv;
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format(Localization.dbcodes_Error_Main, "ERR_DGVLISTINGRECYCLE"), Localization.dbcodes_Error_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return dgv;
            }
        }

        public DataGridView search(DataGridView dgv, string word)
        {
            try
            {
                connectstate();
                cmd = new OleDbCommand("select * from data where (description like '%' + @word + '%')", connect);
                cmd.Parameters.AddWithValue("@word", word);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv.DataSource = dt;
                    return dgv;
                }
                else
                {
                    MessageBox.Show(Localization.frmMainCode_NoSuchData_Main,Localization.frmMainCode_NoSuchData_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dr.Close();
                    return dgv;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format(Localization.dbcodes_Error_Main, "ERR_DGVSEARCHING"), Localization.dbcodes_Error_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return dgv;
            }
        }

        public void add(string email, string pass, string description)
        {
            try
            {
                connectstate();
                cmd = new OleDbCommand("select * from data where email=@email and pass=@pass and description=@desc", connect);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Parameters.AddWithValue("@description", description);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show(Localization.dbcodes_AlreadyExists_Main, Localization.dbcodes_AlreadyExists_Main, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    cmd = new OleDbCommand("insert into data (email,pass,description) values (@email,@pass,@description)", connect);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.ExecuteNonQuery();
                    connect.Close();
                    MessageBox.Show(Localization.dbcodes_Add_Main, Localization.dbcodes_Add_Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format(Localization.dbcodes_Error_Main, "ERR_ADD"), Localization.dbcodes_Error_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public void update(int id, string email, string pass, string description)
        {
            try
            {
                connectstate();
                cmd = new OleDbCommand("update data set email=@email, pass=@pass, description=@desc where ID=@id", connect);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Parameters.AddWithValue("@desc", description);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show(Localization.dbcodes_Update_Main, Localization.dbcodes_Update_Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format(Localization.dbcodes_Error_Main, "ERR_UPDATE"), Localization.dbcodes_Error_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public void tempdelete(int id)
        {
            try
            {
                connectstate();
                cmd = new OleDbCommand("insert into recycle select * from data where ID=@id", connect);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("delete from data where ID=@id", connect);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show(Localization.dbcodes_Delete_Main, Localization.dbcodes_Delete_Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format(Localization.dbcodes_Error_Main, "ERR_TEMPDEL"), Localization.dbcodes_Error_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public void restore(int id)
        {
            try
            {
                connectstate();
                cmd = new OleDbCommand("insert into data select * from recycle where ID=@id", connect);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("delete from recycle where ID=@id", connect);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show(Localization.dbcodes_Restore_Main, Localization.dbcodes_Restore_Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format(Localization.dbcodes_Error_Main, "ERR_RESTORE"), Localization.dbcodes_Error_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public void permdelete(int id)
        {
            try
            {
                connectstate();
                cmd = new OleDbCommand("delete from recycle where ID=@id", connect);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show(Localization.dbcodes_Permdelete_Main,Localization.dbcodes_Permdelete_Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format(Localization.dbcodes_Error_Main, "ERR_PERMDEL"), Localization.dbcodes_Error_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public void connectstate()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format(Localization.dbcodes_Error_Main, "ERR_CONNECTSTATE"), Localization.dbcodes_Error_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public bool logexist()
        {
            try
            {
                connectstate();
                cmd = new OleDbCommand("select count(*) from logindata", connect);
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format(Localization.dbcodes_Error_Main, "ERR_CLASSLOGEXIST"), Localization.dbcodes_Error_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return false;
            }
        }

        public string email()
        {
            try
            {
                string mail = "";
                connectstate();
                cmd = new OleDbCommand("select * from logindata", connect);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    mail = dr["email"].ToString();
                }
                dr.Close();
                connect.Close();
                return mail;
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format(Localization.dbcodes_Error_Main, "ERR_GETEMAIL"), Localization.dbcodes_Error_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return "ERROR";
            }
        }

        public string password()
        {
            try
            {
                string password = "";
                connectstate();
                cmd = new OleDbCommand("select * from logindata", connect);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    password = dr["pass"].ToString();
                }
                dr.Close();
                connect.Close();
                return password;
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format(Localization.dbcodes_Error_Main, "ERR_GETPASS"), Localization.dbcodes_Error_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return "ERROR";
            }
        }

        public bool login(string password)
        {
            try
            {
                connectstate();
                cmd = new OleDbCommand("select * from logindata where pass=@pass", connect);
                cmd.Parameters.AddWithValue("@pass", password);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    connect.Close();
                    dr.Close();
                    return true;
                }
                else
                {
                    connect.Close();
                    dr.Close();
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format(Localization.dbcodes_Error_Main, "ERR_LOGIN"), Localization.dbcodes_Error_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return false;
            }
        }

        public void register(string email, string password)
        {
            try
            {
                connectstate();
                cmd = new OleDbCommand("insert into logindata (email,pass) values (@email,@pass)", connect);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@pass", password);
                cmd.ExecuteNonQuery();
                connect.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format(Localization.dbcodes_Error_Main, "ERR_REGISTER"), Localization.dbcodes_Error_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public void updateinfo(string email, string password)
        {
            try
            {
                connectstate();
                cmd = new OleDbCommand("update logindata set email=@email, pass=@pass", connect);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@pass", password);
                cmd.ExecuteNonQuery();
                connect.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format(Localization.dbcodes_Error_Main, "ERR_UPDATEINFO"), Localization.dbcodes_Error_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public void renewpassword(string newpassword)
        {
            try
            {
                connectstate();
                cmd = new OleDbCommand("update logindata set pass=@pass", connect);
                cmd.Parameters.AddWithValue("@pass", newpassword);
                cmd.ExecuteNonQuery();
                connect.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format(Localization.dbcodes_Error_Main, "ERR_RENEWPASS"), Localization.dbcodes_Error_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}