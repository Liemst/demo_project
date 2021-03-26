using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_GitHub
{
    class QLnguoidung
    {
        public int Check_Config()
        {
            if (Properties.Settings.Default.ChuoiKetNoi == string.Empty)
            return 1;// Chuỗi cấu hình không tồn tại
            SqlConnection _Sqlconn = new SqlConnection(Properties.Settings.Default.ChuoiKetNoi);
            try
            {
                if (_Sqlconn.State == System.Data.ConnectionState.Closed)
                    _Sqlconn.Open();
                return 0;// Kết nối thành công chuỗi cấu hình hợp lệ
            }
            catch
            {
                return 2;// Chuỗi cấu hình không phù hợp.
            }
        }
        public int Check_User(string pUser, string pPass)
            {
                SqlDataAdapter daUser = new SqlDataAdapter("select * from QL_NguoiDung where TenDangNhap='" + pUser + "' and MatKhau ='" + pPass + "'",Properties.Settings.Default.ChuoiKetNoi);
                DataTable dt = new DataTable();
                daUser.Fill(dt);
                if (dt.Rows.Count == 0)
                    return 10;// User không tồn tại
                else if (dt.Rows[0][2] == null || dt.Rows[0][2].ToString() == "False")
                {
                    return 20;// Không hoạt động
                }
                    return 30;// Đăng nhập thành công
            }
    }
}
