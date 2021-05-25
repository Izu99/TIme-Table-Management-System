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
        connect con = new connect();
        MySqlCommand cmd;
        MySqlDataReader reader;
        MySqlDataAdapter adapter;
        DataTable dt;

        public LecturerManagement()
        {
            InitializeComponent();
        }

        private void LecturerManagement_Load(object sender, EventArgs e)
        {
            dgvLecturer.DataSource = null;
            con.connection();
            adapter = new MySqlDataAdapter("Select lecturerID'lecturerID',lecturerName'lecturerName',faculty'faculty',department'department',center'center',building'building',level'level',rank'rank' from lecturer ", con.con);
            dt = new DataTable();
            adapter.Fill(dt);
            dgvLecturer.DataSource = dt;
            con.con.Close();
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
                var generateRank = cmbLevel.Text + "." + txtLecturerID.Text;
                con.datasend("insert into lecturer_table (`lecturerID`,`lecturerName`, `faculty`, `department`, `center`, `building`, `level`, `rank`) Value('" + txtLecturerID.Text + "','" + txtLecturerName.Text + "','" + cmbFaculty.Text + "', '" + cmbDepartment.Text + "', '" + cmbCenter.Text + "','" + cmbBuilding.Text + "','" + cmbLevel.Text + "','" + generateRank + "')");
                txtLecturerID.Text = null;
                txtLecturerName.Text = null;
                cmbFaculty.SelectedItem = null;
                cmbDepartment.SelectedItem = null;
                cmbCenter.SelectedItem = null;
                cmbBuilding.SelectedItem = null;
                cmbLevel.SelectedItem = null;

                MessageBox.Show("Successfully Data Added", "Lecturer Management", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLecturerID.Text = null;
            txtLecturerName.Text = null;
            cmbFaculty.SelectedItem = null;
            cmbDepartment.SelectedItem = null;
            cmbCenter.SelectedItem = null;
            cmbBuilding.SelectedItem = null;
            cmbLevel.SelectedItem = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.dataDelete("delete from  lecturer_table where lecturerID= '" + txtLecturerID.Text + "'");
            txtLecturerID.Text = null;
            txtLecturerName.Text = null;
            cmbFaculty.SelectedItem = null;
            cmbDepartment.SelectedItem = null;
            cmbCenter.SelectedItem = null;
            cmbBuilding.SelectedItem = null;
            cmbLevel.SelectedItem = null;
            MessageBox.Show("Successfully Deleted", "Lecturer Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            con.dataUpdate("update lecturer_table set lecturerID= '" + txtLecturerID.Text + "',lecturerName='" + txtLecturerName.Text + "',faculty='" + cmbFaculty.Text + "',department='" + txtLecturerName.Text + "',center ='" + cmbCenter.Text + "',building='" + cmbBuilding.Text + "',level='" + cmbLevel.Text + "' where lecturerID='" + txtLecturerID.Text + "'");
            txtLecturerID.Text = null;
            txtLecturerName.Text = null;
            cmbFaculty.SelectedItem = null;
            cmbDepartment.SelectedItem = null;
            cmbCenter.SelectedItem = null;
            cmbBuilding.SelectedItem = null;
            cmbLevel.SelectedItem = null;
            MessageBox.Show("Successfully Updated", "Lecturer Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }       

        private void dgvLecturer_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLecturer.Rows[e.RowIndex];
                txtLecturerID.Text = row.Cells[0].Value.ToString();
                txtLecturerName.Text = row.Cells[1].Value.ToString();
                cmbFaculty.Text = row.Cells[2].Value.ToString();
                cmbDepartment.Text = row.Cells[3].Value.ToString();
                cmbCenter.Text = row.Cells[4].Value.ToString();
                cmbBuilding.Text = row.Cells[5].Value.ToString();
                cmbLevel.Text = row.Cells[6].Value.ToString();
            }
        }
        
    }
}
