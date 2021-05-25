using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LoginRegister
{
    public partial class LecturerManagement : Form
    {
        MySqlCommand cmd;
        MySqlDataReader reader;
        MySqlDataAdapter adapter;
        DataTable dt;
        DataSet ds;
        connect con = new connect();

        public LecturerManagement()
        {
            InitializeComponent();
        }

        public void LecturerManagement_Load()
        {
            dgvLecturer.DataSource = null;
            con.connection();
            adapter = new MySqlDataAdapter("Select * from lecturer_table ", con.con);
            dt = new DataTable();
            adapter.Fill(dt);
            dgvLecturer.DataSource = dt;
            con.con.Close();
        }

        private void LecturerManagement_Load(object sender, EventArgs e)
        {
            LecturerManagement_Load();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtLecturerID.Text == "" || txtLecturerName.Text == "" || cmbFaculty.Text == "" || cmbDepartment.Text == "" || cmbCenter.Text == "" || cmbBuilding.Text == "" || cmbLevel.Text == "")
            {
                MessageBox.Show("No Data Selected", "Lecturer Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                con.datasend("insert into lecturer_table (`lecturerID`,`lecturerName`, `faculty`, `department`, `center`, `building`, `level`, `rank`) Value('" + txtLecturerID.Text + "','" + txtLecturerName.Text + "','" + cmbFaculty.Text + "', '" + cmbDepartment.Text + "', '" + cmbCenter.Text + "','" + cmbBuilding.Text + "','" + cmbLevel.Text + "','" + cmbLevel.Text + "." + txtLecturerID.Text + "')");
                DataClear();
                MessageBox.Show("Successfully Data Added", "Lecturer Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LecturerManagement_Load();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.dataDelete("delete from  lecturer_table where lecturerID= '" + txtLecturerID.Text + "'");
            DataClear();
            MessageBox.Show("Successfully Deleted", "Lecturer Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LecturerManagement_Load();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var generateRank = cmbLevel.Text + "." + txtLecturerID.Text;
            con.dataUpdate("update lecturer_table set lecturerID= '" + txtLecturerID.Text + "',lecturerName='" + txtLecturerName.Text + "',faculty='" + cmbFaculty.Text + "',department='" + cmbDepartment.Text + "',center ='" + cmbCenter.Text + "',building='" + cmbBuilding.Text + "',level='" + cmbLevel.Text + "',rank='" + generateRank + "' where lecturerID='" + txtLecturerID.Text + "'");
            DataClear();
            MessageBox.Show("Successfully Updated", "Lecturer Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LecturerManagement_Load();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
        private void DataClear()
        {
            txtLecturerID.Text = null;
            txtLecturerName.Text = null;
            cmbFaculty.SelectedItem = null;
            cmbDepartment.SelectedItem = null;
            cmbCenter.SelectedItem = null;
            cmbBuilding.SelectedItem = null;
            cmbLevel.SelectedItem = null;
            LecturerManagement_Load();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            DataClear();
        }

        private void dgvLecturer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLecturer.Rows[e.RowIndex];
                txtLecturerID.Text = row.Cells[1].Value.ToString();
                txtLecturerName.Text = row.Cells[2].Value.ToString();
                cmbFaculty.Text = row.Cells[3].Value.ToString();
                cmbDepartment.Text = row.Cells[4].Value.ToString();
                cmbCenter.Text = row.Cells[5].Value.ToString();
                cmbBuilding.Text = row.Cells[6].Value.ToString();
                cmbLevel.Text = row.Cells[7].Value.ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            con.connection();
            dgvLecturer.DataSource = null;
            adapter = new MySqlDataAdapter("Select * from lecturer_table where lecturerID= '" + txtSearch.Text + "'", con.con);
            dt = new DataTable();
            adapter.Fill(dt);
            dgvLecturer.DataSource = dt;
            cmd = new MySqlCommand("Select * from lecturer_table where lecturerID= '" + txtSearch.Text + "'", con.con);
            reader = cmd.ExecuteReader();   

            if (reader.Read())
            {
                txtLecturerID.Text = reader.GetString("lecturerID");
                txtLecturerName.Text = reader.GetString("lecturerName");
                cmbFaculty.Text = reader.GetString("faculty");
                cmbDepartment.Text = reader.GetString("department");
                cmbCenter.Text = reader.GetString("center");
                cmbBuilding.Text = reader.GetString("building");
                cmbLevel.Text = reader.GetString("level");
            }
            else
            {
                DataClear();
            }
        }
    }
}
