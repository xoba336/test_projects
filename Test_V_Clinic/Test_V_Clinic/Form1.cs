using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test_V_Clinic.Model;

namespace Test_V_Clinic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'userstoredbDataSet.Animals' table. You can move, or remove it, as needed.
            this.animalsTableAdapter.Fill(this.userstoredbDataSet.Animals);

            /*using (UserstoredbContext db = new UserstoredbContext())
            {
                List<Animals> animals = db.Animals.AsQueryable().ToList();


                foreach (var item in animals)
                {
                    dgrid_animals.Rows.Add(item);
                }
            }*/
                
        }

        private void bt_Add_Click(object sender, EventArgs e)
        {
            AnimalForm af = new AnimalForm();
            af.Action = "Add";
            af.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Refresh grid
            this.animalsTableAdapter.Fill(this.userstoredbDataSet.Animals);
        }

        private void bt_Edit_Click(object sender, EventArgs e)
        {
            if (dgrid_animals.SelectedRows.Count > 0)
            {
                //Animals editAnimal = new Animals();

                int animalId = Convert.ToInt32(dgrid_animals.SelectedRows[0].Cells[0].Value);

                List<Animals> selectedAnimal = null;
                using (UserstoredbContext db = new UserstoredbContext())
                {
                    selectedAnimal = db.Animals.Where(x => x.Id.Equals(animalId)).AsQueryable().ToList();
                }

                AnimalForm af = new AnimalForm();
                af.SelectedAnimal = selectedAnimal[0];
                af.Action = "Update";
                af.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Select some row to edit.");
                return;
            }
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            if (dgrid_animals.SelectedRows.Count > 0)
            {
                int animalId = Convert.ToInt32(dgrid_animals.SelectedRows[0].Cells[0].Value);

                List<Animals> deleteAnimal = null;
                using (UserstoredbContext db = new UserstoredbContext())
                {
                    deleteAnimal = db.Animals.Where(x => x.Id.Equals(animalId)).AsQueryable().ToList();

                    if (deleteAnimal.Count>0)
                    {
                        db.Remove(deleteAnimal[0]);
                        db.SaveChanges();

                    }
                    db.Dispose();
                }
                //Refresh grid
                this.animalsTableAdapter.Fill(this.userstoredbDataSet.Animals);
            }
            else
            {
                MessageBox.Show("Select some row to Delete.");
                return;
            }
        }
    }
}
