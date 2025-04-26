using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TTCN
{
    internal class DAO
    {
        public static SqlConnection conn;

        public static void Connect()
        {
            if (conn == null)
            {
                conn = new SqlConnection();
                conn.ConnectionString = "Data Source=NGU\\SQLEXPRESS01;Initial Catalog=QlyBanHang;Integrated Security=True";
            }
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }

        public static void Close()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public static DataTable LoadDataToTable(string sql)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public static void FillDataToCombo(ComboBox cmb, string sql, string value, string display)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            cmb.DataSource = dt;
            cmb.ValueMember = value;
            cmb.DisplayMember = display;
        }

        // Hàm thực thi INSERT, UPDATE, DELETE
        public static void ExecuteSQL(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }

        // Hàm kiểm tra trùng khoá
        public static bool CheckKey(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, conn);
            DataTable table = new DataTable();
            dap.Fill(table);
            return table.Rows.Count > 0;
        }

        // Hàm xoá bản ghi
        public static void DeleteRecord(string tableName, string condition)
        {
            string sql = $"DELETE FROM {tableName} WHERE {condition}";
            ExecuteSQL(sql);
        }

        // Hàm tìm kiếm bản ghi
        public static DataTable SearchData(string tableName, string condition)
        {
            string sql = $"SELECT * FROM {tableName} WHERE {condition}";
            return LoadDataToTable(sql);
        }

        // Hàm lấy giá trị đầu tiên của dòng đầu tiên
        public static string getValueFromMa(string sql)
        {
            string ketQua = "";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                ketQua = reader.GetValue(0).ToString();
            }
            reader.Close();
            return ketQua;
        }
    }
}
