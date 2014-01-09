using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Windows.Forms;

namespace FORMAPP2
{
    public partial class Form1 : Form
    {
        LTSTDataContext db = new LTSTDataContext();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GalenDGV.DataSource = GalenBS;
            GalenBS.DataSource = from data in db.Galningars
                                 orderby data.Galning_Name
                                 select data;    
        }
        private void GalningAddBtn_Click(object sender, EventArgs e)
        {
            Galningar g = new Galningar();

            try
            {

                g.Galning_Name = GalningNameTbx.Text;
                g.Galenskap = int.Parse(GalenskapNivåTbx.Text);
                g.Born = GalenBornTbx.Text;
                g.From_Location = GalningFromTbx.Text;
                g.Info = GalningInfoTbx.Text;

                db.Galningars.InsertOnSubmit(g);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            GalenBS.DataSource = from data in db.Galningars
                                 orderby data.Galning_Name
                                    select data;
       }
        private void GalningRemoveBtn_Click(object sender, EventArgs e)
        {
            if (GalenDGV.SelectedRows.Count == 1)
            {
                int selected_id = (int)GalenDGV.SelectedRows[0].Cells[0].Value;

                Galningar g = db.Galningars.Single(Galen => Galen.Galning_ID == selected_id);

                db.Galningars.DeleteOnSubmit(g);
                db.SubmitChanges();

                GalenBS.DataSource = from data in db.Galningars
                                     orderby data.Galning_Name
                                     select data;   
            }
        }
        int changeState = 0;
        int tempID;
        private void GalningChangeBtn_Click(object sender, EventArgs e)
        {
            if (changeState == 0)
            {

                if (GalenDGV.SelectedRows.Count == 1)
                {
                    int selected_id = (int)GalenDGV.SelectedRows[0].Cells[0].Value;

                    Galningar g = db.Galningars.Single(Galen => Galen.Galning_ID == selected_id);

                    tempID = g.Galning_ID;
                    GalningNameTbx.Text = g.Galning_Name;
                    GalningInfoTbx.Text = g.Info;
                    GalenskapNivåTbx.Text = g.Galenskap.ToString();
                    GalenBornTbx.Text = g.Born;
                    GalningFromTbx.Text = g.From_Location;

                    changeState = 1;

                }
            }
            else
            {
                try
                {
                    Galningar g = db.Galningars.Single(Galen => Galen.Galning_ID == tempID);
                    g.Galning_Name = GalningNameTbx.Text;
                    g.Galenskap = int.Parse(GalenskapNivåTbx.Text);
                    g.Born = GalenBornTbx.Text;
                    g.From_Location = GalningFromTbx.Text;
                    g.Info = GalningInfoTbx.Text;

                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                changeState = 0;

            }
        }

        private void galningSrchBtn_Click(object sender, EventArgs e)
        {
            if (galningSrchTbx.Text.Trim().Length > 0)
            {
                string srchWord = galningSrchTbx.Text.Trim().ToLower();

                var srchResult = from result in db.Galningars
                                 where result.Galning_ID.ToString().Contains(srchWord)
                                 || result.Galning_Name.ToLower().Contains(srchWord)
                                 || result.From_Location.ToLower().Contains(srchWord)
                                 || result.Info.ToLower().Contains(srchWord)
                                 || result.Born.Contains(srchWord)
                                 || result.Galenskap.ToString().Contains(srchWord)
                                 orderby result.Galning_Name
                                 select result;

                GalenBS.DataSource = srchResult;
            }
            else
            {
                GalenBS.DataSource = from data in db.Galningars 
                                    orderby data.Galning_Name
                                         select data;

            }
        }
        


    
    }
    
}
