using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<ExerciseResult> lista = new List<ExerciseResult>();
            string connString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=FacultyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (
            SqlConnection dataConnection = new SqlConnection(connString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT  *  FROM  ExerciseResults";
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    ExerciseResult pom = new ExerciseResult(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetInt32(3));


                    lista.Add(pom);
                }

                foreach (ExerciseResult er in lista)
                    listBoxExerciseResults.Items.Add(er.ToString());
            }
        }
    }
}
