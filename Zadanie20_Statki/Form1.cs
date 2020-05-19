using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie20_Statki
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        List<Control> controls = new List<Control>();

        private void MainForm_Load(object sender, EventArgs e)
        {
            

           foreach (Control c in tableLayoutPanel.Controls)
           {
                controls.Add(c);
                c.Tag = c.Text;
                c.Name = "btn_" + c.Text;
                c.Click += Btn_Click;
                c.Text = "?";
           }
            
            
            ShipLocation(1);



            // TableLayoutControlCollection
            //controls = TableLayoutControlCollection(TableLayoutPanel).ToList();

            //TableLayoutPanel.ControlCollection

            //foreach (Control control in )

            //    foreach (Control c in Form1.TableLayoutPanel.Controls)
            //    {
            //        Trace.WriteLine(c.ToString());
            //    }



            //int index = 1;
            //List<Control> controls = this.Controls.OfType<Button>().Cast<Control>().ToList();
            //controls.Reverse();
            //foreach (var item in controls)
            //{
            //    Button btn = (Button)item;
            //           btn.Tag = String.Format("BUTTON{0}", index); // ustawiam Tag przycisku wg schematu: BUTTONx, gdzie x to numer przycisku
            //           btn.Text = index.ToString();
            //          // btn.Click += Btn_Click;  //podpięcie do klikniecia na przycisk metody 
            //           index++;
            //}
        }

        Random random = new Random((Int32)DateTime.Now.Ticks);

        private void ShipLocation (byte shipSize)
        {
           int tagNumber =  random.Next(1, controls.Count);
            foreach (Control c in controls)
            {
                if (Convert.ToInt32(c.Tag) == tagNumber)
                {
                    c.Tag = "Ship";
                    controls.Remove(c);
                    break;
                }
            }
        }

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    int index = 1;
        //    List<Control> controls = this.Controls.OfType<Button>().Cast<Control>().ToList();
        //    controls.Reverse();
        //    foreach (var item in controls)
        //    {
        //        Button btn = (Button)item;
        //        btn.Tag = String.Format("BUTTON{0}", index); // ustawiam Tag przycisku wg schematu: BUTTONx, gdzie x to numer przycisku
        //        btn.Text = index.ToString();
        //        btn.Click += Btn_Click;  //podpięcie do klikniecia na przycisk metody 
        //        index++;
        //    }
        //}


        //private Button FindShipButtonByTag(int number)
        //{
        //    String pattern = String.Format("BUTTON{0}", number);
        //    var item = this.Controls.Cast<Control>().FirstOrDefault(control => String.Equals(control.Tag, pattern));
        //    return (item == null) ? null : (Button)item;
        //}



        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Tag.ToString() == "Ship")
            {
                btn.BackColor = Color.DarkOrange;
            }
            
            MessageBox.Show(btn.Tag.ToString());

            btn.Enabled = false;
        }



    }
}
