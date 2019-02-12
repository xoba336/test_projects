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

    public partial class AnimalForm : Form
    {
        private string action;
        public string Action
        {
            get { return action; }
            set { action = value; }
        }

        private Animals selectedAnimal;
        public Animals SelectedAnimal
        {
            get { return selectedAnimal; }
            set { selectedAnimal = value; }
        }

        public AnimalForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (action == "Add")
            {
                using (UserstoredbContext db = new UserstoredbContext())
                {
                    Animals newAnimal = new Animals();
                    newAnimal.Name = textBox2.Text;
                    newAnimal.Height = Convert.ToDecimal(textBox3.Text.Replace(".", ","));
                    newAnimal.Weight = Convert.ToDecimal(textBox4.Text.Replace(".", ","));
                    newAnimal.Indoor = checkBox5.Checked;
                    /*try
                    {                     
                        newAnimal.Indoor = Convert.ToBoolean(textBox6.Text);
                    }
                    catch(FormatException ex)
                    {
                        MessageBox.Show("Indor. Please enter: 1 - if true, 0 - if false.");
                        return;
                        //throw new Exception("Indor. Please enter: 1 - if true, 0 - if false.");
                    }
                    finally
                    {
                        db.Dispose();
                    }*/
                    newAnimal.Nickname = textBox6.Text;

                    db.Animals.Add(newAnimal);
                    db.SaveChanges();
                    db.Dispose();
                }
            }

            if (Action == "Update")
            {

                using (UserstoredbContext db = new UserstoredbContext())
                {
                    List<Animals> editAnimal = db.Animals.Where(x => x.Id.Equals(selectedAnimal.Id)).AsQueryable().ToList();

                    if (editAnimal.Count>0)
                    {
                        editAnimal[0].Name = textBox2.Text;
                        editAnimal[0].Height = Convert.ToDecimal(textBox3.Text.Replace(".", ","));
                        editAnimal[0].Weight = Convert.ToDecimal(textBox4.Text.Replace(".", ","));
                        editAnimal[0].Indoor = checkBox5.Checked;
                        editAnimal[0].Nickname = textBox6.Text;
                        db.SaveChanges();
                    }

                    db.Dispose();
                }

            }
            //this.Parent.FindForm().Refresh();
            this.Close();
        }

        private void AnimalForm_Load(object sender, EventArgs e)
        {
            Animals paramAnimal = selectedAnimal;
            if (paramAnimal != null)
            {
                textBox1.Text = paramAnimal.Id.ToString();
                textBox2.Text = paramAnimal.Name;
                textBox3.Text = paramAnimal.Height.ToString();
                textBox4.Text = paramAnimal.Weight.ToString();
                checkBox5.Checked = (bool)paramAnimal.Indoor;
                textBox6.Text = paramAnimal.Nickname;
            }
        }
    }
}
