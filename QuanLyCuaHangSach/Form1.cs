using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangSach
{
    //Msv: 2051060448
    //Họ và tên : Hoàng Nghĩa Đức
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=HOANGDUC\SQLEXPRESS;Initial Catalog=QuanLyCuaHangSach;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable khosach = new DataTable();
        DataTable muasach = new DataTable();
        DataTable thongke= new DataTable();
        DataTable timkiem = new DataTable();
        void loaddatakhosach()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from Khosach";
            adapter.SelectCommand = command;
            khosach.Clear();
            adapter.Fill(khosach);
            dtgv_Khosach.DataSource = khosach;
        }
        void loaddatamuasach()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from Muasach" ;
            adapter.SelectCommand = command;
            muasach.Clear();
            adapter.Fill(muasach);
            dtgv_Mua.DataSource = muasach;
            
        }

        public Form1()
        {
            InitializeComponent();
        }
        
        private void btn_Them_Click(object sender, EventArgs e)
        {
           
            
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddatakhosach();
            //LoadCBTensach();
            LoadCBNhaXuatBan();
            LoadCBTacgia();
            LoadCBLoaisach();
         
        }

        private void dtgv_Khosach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            int i;
            i = dtgv_Khosach.CurrentRow.Index;
            txt_Masach.Text = dtgv_Khosach.Rows[i].Cells[0].Value.ToString();
            txt_Loaisach.Text = dtgv_Khosach.Rows[i].Cells[1].Value.ToString();
            txt_Tensach.Text = dtgv_Khosach.Rows[i].Cells[2].Value.ToString();
            txt_Tacgia.Text = dtgv_Khosach.Rows[i].Cells[3].Value.ToString();
            txt_Nhaxuatban.Text = dtgv_Khosach.Rows[i].Cells[4].Value.ToString();
            txt_Soluong.Text = dtgv_Khosach.Rows[i].Cells[5].Value.ToString();
            txt_Giatien.Text = dtgv_Khosach.Rows[i].Cells[6].Value.ToString();

        }
        void resettextbox()
        {
            txt_Masach.Clear() ;
            txt_Loaisach.Clear();
            txt_Tensach.Clear();
            txt_Tacgia.Clear();
            txt_Nhaxuatban.Clear();
            txt_Soluong.Clear();
            txt_Giatien.Clear();
            txt_Masach.Focus();
        }
        private void btn_Them_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Masach.Text) || string.IsNullOrEmpty(txt_Loaisach.Text) || string.IsNullOrEmpty(txt_Tensach.Text) || string.IsNullOrEmpty(txt_Tacgia.Text) || string.IsNullOrEmpty(txt_Nhaxuatban.Text) || string.IsNullOrEmpty(txt_Soluong.Text) || string.IsNullOrEmpty(txt_Giatien.Text))
            {
                MessageBox.Show("Không được để trống dữ liệu.Vui lòng nhập dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else
            {

                command = connection.CreateCommand();
                try
                {


                    command.CommandText = "insert into Khosach values('" + txt_Masach.Text + "',N'" + txt_Loaisach.Text + "',N'" + txt_Tensach.Text + "',N'" + txt_Tacgia.Text + "',N'" + txt_Nhaxuatban.Text + "','" + txt_Soluong.Text + "','" + txt_Giatien.Text + "')";
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi nhập sai dữ liệu.Vui lòng nhập lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                loaddatakhosach();
                resettextbox();
            }

        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc chắn muốn xóa không?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                command = connection.CreateCommand();
                command.CommandText = "delete from Khosach where Masach='" + txt_Masach.Text + "'";
                command.ExecuteNonQuery();
                loaddatakhosach();
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "update Khosach set Loaisach= N'" + txt_Loaisach.Text + "',Tensach= N'" + txt_Tensach.Text + "',Tacgia= N'" + txt_Tacgia.Text + "',Nhaxuatban= N'" + txt_Nhaxuatban.Text + "',Soluong= '" + txt_Soluong.Text + "',Giatien= " + txt_Giatien.Text + " where Masach = '" + txt_Masach.Text + "'";
                command.ExecuteNonQuery();
            }
            catch(Exception )
            {
                MessageBox.Show("Vui lòng chọn dữ liệu cần sửa !","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            loaddatakhosach();
        }
        void LoadCBLoaisach()
        {
            var cmd = new SqlCommand("select  DISTINCT Loaisach from Khosach  ", connection);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cb_Loaisachtim.DisplayMember = "Loaisach";
            cb_Loaisachtim.DataSource = dt;
            cb_Loaisachthongke.DisplayMember = "Loaisach";
            cb_Loaisachthongke.DataSource = dt;
            cb_Loaisachban.DisplayMember = "Loaisach";
            cb_Loaisachban.DataSource = dt;
        }
        void LoadCBTacgia()
        {
            var cmd = new SqlCommand("select  DISTINCT Tacgia from Khosach  ", connection);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cb_Tacgiatim.DisplayMember = "Tacgia";
            cb_Tacgiatim.DataSource = dt;
        }
        void LoadCBNhaXuatBan()
        {
            var cmd = new SqlCommand("select  DISTINCT Nhaxuatban from Khosach  ", connection);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cbx_Nhaxuatban.DisplayMember = "Nhaxuatban";
            cbx_Nhaxuatban.DataSource = dt;
        }
        void LoadCBTensach()
        {
            var cmd = new SqlCommand("select DISTINCT Tensach from Khosach where Loaisach = N'" + cb_Loaisachban.Text + "' ", connection);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cb_Tensachmua.DisplayMember = "Tensach";
            cb_Tensachmua.DataSource = dt;
        }
        void Loadgiatien()
        {
            var cmd = new SqlCommand("select Giatien from Khosach where Tensach = N'" + cb_Tensachmua.Text.Trim() + "' and Loaisach = N'" + cb_Loaisachban.Text + "'", connection);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            txt_Giatienban.Text = dt.Rows[0]["Giatien"].ToString();
        }

        private void btn_Timkiem_Click(object sender, EventArgs e)
        {
            if (cb_Tacgia.Checked == true)
            {
                command = connection.CreateCommand();
                command.CommandText = "select * from Khosach where Tacgia = N'" + cb_Tacgiatim.Text.Trim() + "'";
                command.ExecuteNonQuery();
                adapter.SelectCommand = command;
                timkiem.Clear();
                adapter.Fill(timkiem);
                dtgv_Timkiem.DataSource = timkiem;
            }
            else if (cb_Loaisach.Checked == true)
            {
                command = connection.CreateCommand();
                command.CommandText = "select * from Khosach where Loaisach = N'" + cb_Loaisachtim.Text.Trim() + "'";
                command.ExecuteNonQuery();
                adapter.SelectCommand = command;
                timkiem.Clear();
                adapter.Fill(timkiem);
                dtgv_Timkiem.DataSource = timkiem;
            }
            else if (cb_Nhaxuatban.Checked == true)
            {
                command = connection.CreateCommand();
                command.CommandText = "select * from Khosach where Nhaxuatban = N'" + cbx_Nhaxuatban.Text.Trim() + "'";
                command.ExecuteNonQuery();
                adapter.SelectCommand = command;
                timkiem.Clear();
                adapter.Fill(timkiem);
                dtgv_Timkiem.DataSource = timkiem;
            }
            else if (cb_Loaisach.Checked == true && cb_Tacgia.Checked == true)
            {
                command = connection.CreateCommand();
                command.CommandText = "select * from Khosach where Loaisach = N'" + cb_Loaisachtim.Text.Trim() + "'and Tacgia = N'" + cb_Tacgiatim.Text.Trim() + "'";
                command.ExecuteNonQuery();
                adapter.SelectCommand = command;
                timkiem.Clear();
                adapter.Fill(timkiem);
                dtgv_Timkiem.DataSource = timkiem;
            }
            
        }

        private void btn_Mua_Click(object sender, EventArgs e)
        {
            


            var cmd = new SqlCommand("select Soluong from Khosach where Tensach = N'" + cb_Tensachmua.Text.Trim() + "' and Loaisach = N'" + cb_Loaisachban.Text + "'", connection);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            try
            {
                
                int sosachtrongkho = Convert.ToInt32(dt.Rows[0]["Soluong"]);
                int sosachmua = Convert.ToInt32(txt_Soluongban.Text);
                if (sosachtrongkho - sosachmua <= 0)
                {
                    MessageBox.Show("Số lượng sách không đủ.");
                    muasach.Clear();

                }
                else
                {
                    if (txt_Soluongban.TextLength != 0|| sosachtrongkho - sosachmua > 0)
                    {
                        command = connection.CreateCommand();
                        command.CommandText = "insert into Muasach values(N'" + cb_Loaisachban.Text + "',N'" + cb_Tensachmua.Text + "','" + txt_Soluongban.Text + "','" + txt_Giatienban.Text + "','" + dtp_Ngaymuasach.Text + "')";
                        command.ExecuteNonQuery();
                    }


                    command = connection.CreateCommand();
                    command.CommandText = "select * from Muasach  where  Loaisach = N'" + cb_Loaisachban.Text + "' and Tensach = N'" + cb_Tensachmua.Text.Trim() + "' and Soluong = '" + txt_Soluongban.Text + "' and Ngaymua = '" + dtp_Ngaymuasach.Text + "' ";
                    adapter.SelectCommand = command;
                    muasach.Clear();
                    adapter.Fill(muasach);
                    dtgv_Mua.DataSource = muasach;

                    command = connection.CreateCommand();
                    command.CommandText = "update Khosach set Soluong = Soluong - '" + txt_Soluongban.Text + "'  where Tensach = N'" + cb_Tensachmua.Text + "' and Loaisach = N'" + cb_Loaisachban.Text + "'";
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Vui lòng nhập số lượng sách !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                muasach.Clear();
            }
            loaddatakhosach();
        }

        private void btn_Thongke_Click(object sender, EventArgs e)
        {
            if (cb_Ngaythongke.Checked == true)
            {
                command = connection.CreateCommand();
                command.CommandText = "select Loaisach,Tensach,Soluong,Giatien,Ngaymua,Soluong*Giatien as Thanhtien from Muasach where Day(Ngaymua) = '" + dtp_Ngaythongke.Value.Day + "'";
                command.ExecuteNonQuery();
                adapter.SelectCommand = command;
                thongke.Clear();
                adapter.Fill(thongke);
                dtgv_Thongke.DataSource = thongke;
            }
            if (cb_Thongkethang.Checked == true)
            {
                command = connection.CreateCommand();
                command.CommandText = "select Loaisach,Tensach,Soluong,Giatien,Ngaymua,Soluong*Giatien as Thanhtien from Muasach where Month(Ngaymua) = '" + dtp_Thongkethang.Value.Month + "'";
                command.ExecuteNonQuery();
                adapter.SelectCommand = command;
                thongke.Clear();
                adapter.Fill(thongke);
                dtgv_Thongke.DataSource = thongke;
            }

            else if (cb_Thongkeloaisach.Checked == true)
            {
                command = connection.CreateCommand();
                command.CommandText = "select Loaisach,Tensach,Soluong,Giatien,Ngaymua,Soluong*Giatien as Thanhtien from Muasach where Loaisach = N'" + cb_Loaisachthongke.Text.Trim() + "'";
                command.ExecuteNonQuery();
                adapter.SelectCommand = command;
                thongke.Clear();
                adapter.Fill(thongke);
                dtgv_Thongke.DataSource = thongke;
            }
        }

        private void cb_Loaisachban_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCBTensach();
        }

        private void cb_Tensachmua_SelectedIndexChanged(object sender, EventArgs e)
        {
            Loadgiatien();
        }
    }
}
