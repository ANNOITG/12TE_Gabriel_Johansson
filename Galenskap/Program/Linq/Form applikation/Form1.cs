using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_applikation
{
    public partial class Form1 : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bandDGV.DataSource = bandBS;
            bandBS.DataSource = from data in db.Bands
                                orderby data.Band_Name
                                select data;
            
        }

        private void bandAddBtn_Click(object sender, EventArgs e)
        {
            Band b = new Band();

            try
            {
                b.Band_Name = bandNameTbx.Text;
                b.Members = int.Parse(label3.Text);
                b.From_Location = label4.Text;
                b.Info = bandInfoTbx.Text;
                b.Startyear = label5.Text;

                db.Bands.InsertOnSubmit(b);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            bandBS.DataSource = from data in db.Bands
                                orderby data.Band_Name
                                select data;
        }
        private void bandRemoveBtn_Click(object sender, EventArgs e)
        {
            if (bandDGV.SelectedRows.Count == 1)
            {
                int selected_id = (int)bandDGV.SelectedRows[0].Cells[0].Value;

                Band b = db.Bands.Single(band => band.Band_ID == selected_id);

                db.Bands.DeleteOnSubmit(b);
                db.SubmitChanges();

                bandBS.DataSource = from data in db.Bands
                                    orderby data.Band_Name
                                    select data;
            }
        }

        int changeState = 0;
        int tempID;

        private void bandChangeBtn_Click(object sender, EventArgs e)
        {
            if (changeState == 0)
            {
                if (bandDGV.SelectedRows.Count == 1)
                {
                    int selected_id = (int)bandDGV.SelectedRows[0].Cells[0].Value;

                    Band b = db.Bands.Single(band => band.Band_ID == selected_id);

                    tempID = b.Band_ID;
                    bandNameTbx.Text = b.Band_Name;
                    bandInfoTbx.Text = b.Info;
                    label3.Text = b.Members.ToString();
                    label5.Text = b.Startyear;

                    changeState = 1;

                }
            }

            else
            {
                try
                {
                    Band b = db.Bands.Single(band => band.Band_ID == tempID);
                    b.Band_Name = bandNameTbx.Text;
                    b.Info = bandInfoTbx.Text;
                    b.Members = int.Parse(label3.Text);
                    b.Startyear = label5.Text;

                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                changeState = 0;

            }
        }
        private void bandSrchBtn_Click(object sender, EventArgs e)
        {
            if (bandSrchTbx.Text.Trim().Length > 0)
            {
                string SrchWord = bandSrchTbx.Text.Trim().ToLower();

                var srchResult = from result in db.Bands
                                 where result.Band_ID.ToString().Contains(SrchWord)
                                 || result.Band_Name.ToLower().Contains(SrchWord)
                                 || result.From_Location.ToLower().Contains(SrchWord)
                                 || result.Info.ToLower().Contains(SrchWord)
                                 || result.Members.ToString().Contains(SrchWord)
                                 || result.Startyear.Contains(SrchWord)
                                 orderby result.Band_Name
                                 select result;

                bandBS.DataSource = srchResult;
            }
            else
            {
                bandBS.DataSource = from data in db.Bands
                                    orderby data.Band_Name
                                    select data;

            }
        }

        private void bandAddBtn_Click_1(object sender, EventArgs e)
        {

        }

    }
}
