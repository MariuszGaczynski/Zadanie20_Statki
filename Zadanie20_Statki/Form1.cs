using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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



        public byte[,] locations = new byte[10, 10]; // tablica ze współrzędnymi lokacji

        // List<Control> controls = new List<Control>();

        private void MainForm_Load(object sender, EventArgs e)
        {

            BuildingShips4Masted();
            BuildingShips3Masted();
            BuildingShips3Masted();
            BuildingShips2Masted();
            BuildingShips2Masted();
            BuildingShips2Masted();
            BuildingShips1Masted();
            BuildingShips1Masted();
            BuildingShips1Masted();
            BuildingShips1Masted();

            List<byte> locationsList = new List<byte>();

           

            //foreach (Control c in tableLayoutPanel.Controls)
            //{
            //     controls.Add(c);
            //     c.Tag = c.Text;
            //     c.TabIndex = Convert.ToInt32(c.Text);
            //     c.Name = "btn_" + c.Text;
            //     c.Click += Btn_Click;
            //     c.Text = "?";
            //}


            // ShipLocation(4);


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

        
        private void BuildingShips4Masted()
        {
            

            byte xAxis = (byte)random.Next(0, 10);  // losowanie startowej pozycji 4masztowca
            byte yAxis = (byte)random.Next(0, 10);

            locations[xAxis, yAxis] = 4;       // przypisanie wartości 4masztowca lokalizacji startowej


            bool shipCorrectLocation = false; // czy udało się umieścić cały okręt ?

            do
            {
                int randomMethod = random.Next(1, 5);  // loswanie metody umieszczenia "reszty" okrętu


                switch (randomMethod)
                {
                    case 1:
                        {
                            if (yAxis >= 3 
                                && locations[xAxis, yAxis - 1] ==0 
                                && locations[xAxis, yAxis - 2] == 0 
                                && locations[xAxis, yAxis - 3] == 0)
                            {
                                locations[xAxis, yAxis - 1] = 4;
                                locations[xAxis, yAxis - 2] = 4;
                                locations[xAxis, yAxis - 3] = 4;
                                shipCorrectLocation = true;

                                try
                                {
                                    locations[xAxis - 1, yAxis] = 8;  // zarezerwowane pola po bokach okrętu
                                    locations[xAxis + 1, yAxis] = 8;
                                    locations[xAxis - 1, yAxis - 1] = 8;
                                    locations[xAxis + 1, yAxis - 1] = 8;
                                    locations[xAxis - 1, yAxis - 2] = 8;
                                    locations[xAxis + 1, yAxis - 2] = 8;
                                    locations[xAxis - 1, yAxis - 3] = 8;
                                    locations[xAxis + 1, yAxis - 3] = 8;

                                    locations[xAxis , yAxis+1] = 8;  // zarezerwowane pola na dole
                                    locations[xAxis-1, yAxis + 1] = 8;
                                    locations[xAxis+1, yAxis + 1] = 8;

                                    locations[xAxis - 1, yAxis - 4] = 8; // zarezerwowane pola na górze
                                    locations[xAxis + 1, yAxis - 4] = 8;
                                    locations[xAxis , yAxis - 4] = 8;


                                }
                                catch (Exception exc)
                                {

                                }
                            }
                            else
                            {

                            }
                            break;
                        }
                    case 2:
                        {
                            if (yAxis <= 6
                                && locations[xAxis, yAxis + 1] == 0
                                && locations[xAxis, yAxis + 2] == 0
                                && locations[xAxis, yAxis + 3] == 0)
                            {
                                locations[xAxis, yAxis + 1] = 4;
                                locations[xAxis, yAxis + 2] = 4;
                                locations[xAxis, yAxis + 3] = 4;
                                shipCorrectLocation = true;

                                try
                                {
                                    locations[xAxis - 1, yAxis] = 8;
                                    locations[xAxis + 1, yAxis] = 8;
                                    locations[xAxis - 1, yAxis + 1] = 8;
                                    locations[xAxis + 1, yAxis + 1] = 8;
                                    locations[xAxis - 1, yAxis + 2] = 8;
                                    locations[xAxis + 1, yAxis + 2] = 8;
                                    locations[xAxis + 1, yAxis + 3] = 8;
                                    locations[xAxis - 1, yAxis + 3] = 8;

                                    locations[xAxis, yAxis - 1] = 8;
                                    locations[xAxis - 1, yAxis - 1] = 8;
                                    locations[xAxis + 1, yAxis - 1] = 8;

                                    locations[xAxis + 1, yAxis + 4] = 8;
                                    locations[xAxis, yAxis + 4] = 8;
                                    locations[xAxis - 1, yAxis + 4] = 8;


                                }
                                catch (Exception exc)
                                {

                                }

                            }
                            else
                            {

                            }
                            break;
                        }
                    case 3:
                        {
                            if (xAxis >= 3
                                && locations[xAxis -1, yAxis ] == 0
                                && locations[xAxis -2, yAxis] == 0
                                && locations[xAxis -3, yAxis ] == 0)
                            {
                                locations[xAxis - 1, yAxis] = 4;
                                locations[xAxis - 2, yAxis] = 4;
                                locations[xAxis - 3, yAxis] = 4;
                                shipCorrectLocation = true;


                                try
                                {
                                    locations[xAxis, yAxis +1] = 8;
                                    locations[xAxis, yAxis -1] = 8;
                                    locations[xAxis - 1, yAxis+1] = 8;
                                    locations[xAxis - 1, yAxis - 1] = 8;
                                    locations[xAxis -2, yAxis + 1] = 8;
                                    locations[xAxis -2, yAxis -1] = 8;
                                    locations[xAxis -3, yAxis + 1] = 8;
                                    locations[xAxis -3, yAxis -1] = 8;

                                    locations[xAxis +1, yAxis] = 8;
                                    locations[xAxis + 1, yAxis - 1] = 8;
                                    locations[xAxis + 1, yAxis + 1] = 8;

                                    locations[xAxis - 4, yAxis] = 8;
                                    locations[xAxis - 4, yAxis - 1] = 8;
                                    locations[xAxis - 4, yAxis + 1] = 8;

                                }
                                catch (Exception exc)
                                {

                                }
                            }
                            else
                            {

                            }
                            break;
                        }
                    case 4:
                        {
                            if (yAxis >= 6
                                && locations[xAxis + 1, yAxis] == 0
                                && locations[xAxis + 2, yAxis] == 0
                                && locations[xAxis + 3, yAxis] == 0)
                            {
                                locations[xAxis + 1, yAxis] = 4;
                                locations[xAxis + 2, yAxis] = 4;
                                locations[xAxis + 3, yAxis] = 4;
                                shipCorrectLocation = true;

                                try
                                {
                                    locations[xAxis, yAxis + 1] = 8;
                                    locations[xAxis, yAxis - 1] = 8;
                                    locations[xAxis + 1, yAxis + 1] = 8;
                                    locations[xAxis + 1, yAxis - 1] = 8;
                                    locations[xAxis + 2, yAxis + 1] = 8;
                                    locations[xAxis + 2, yAxis - 1] = 8;
                                    locations[xAxis + 3, yAxis + 1] = 8;
                                    locations[xAxis + 3, yAxis - 1] = 8;

                                    locations[xAxis - 1, yAxis] = 8;
                                    locations[xAxis - 1, yAxis - 1] = 8;
                                    locations[xAxis - 1, yAxis + 1] = 8;

                                    locations[xAxis + 4, yAxis] = 8;
                                    locations[xAxis + 4, yAxis - 1] = 8;
                                    locations[xAxis + 4, yAxis + 1] = 8;

                                }
                                catch (Exception exc)
                                {

                                }

                            }
                            else
                            {

                            }
                            break;
                        }

                }


            } while (shipCorrectLocation == false);

        }



        private void BuildingShips3Masted()
        {
            bool locationNotAvailable = false; // sprawdzam czy nie wpadłem na już istniejący okręt albo jego okolice
            byte xAxis;
            byte yAxis; 
            do
            {
                 xAxis = (byte)random.Next(0, 10);  // losowanie startowej pozycji 3masztowca
                 yAxis = (byte)random.Next(0, 10);

                if (locations[xAxis, yAxis] != 0)
                {
                    locationNotAvailable = true; // już coś tam jest , losowanie od nowa
                }
                else
                {
                    locations[xAxis, yAxis] = 3;       // przypisanie wartości 3masztowca lokalizacji startowej
                    locationNotAvailable = false;
                }

            } while (locationNotAvailable == true);



            bool shipCorrectLocation = false; // czy udało się umieścić cały okręt ?

            do
            {
                int randomMethod = random.Next(1, 5);  // loswanie metody umieszczenia "reszty" okrętu


                switch (randomMethod)
                {
                    case 1:
                        {
                            if (yAxis >= 2
                                && locations[xAxis, yAxis - 1] == 0
                                && locations[xAxis, yAxis - 2] == 0)
                            {
                                locations[xAxis, yAxis - 1] = 3;
                                locations[xAxis, yAxis - 2] = 3;
                                shipCorrectLocation = true;

                                try
                                {
                                    locations[xAxis - 1, yAxis] = 8;  // zarezerwowane pola po bokach okrętu
                                    locations[xAxis + 1, yAxis] = 8;
                                    locations[xAxis - 1, yAxis - 1] = 8;
                                    locations[xAxis + 1, yAxis - 1] = 8;
                                    locations[xAxis - 1, yAxis - 2] = 8;
                                    locations[xAxis + 1, yAxis - 2] = 8;

                                    locations[xAxis, yAxis + 1] = 8;  // zarezerwowane pola na dole
                                    locations[xAxis - 1, yAxis + 1] = 8;
                                    locations[xAxis + 1, yAxis + 1] = 8;

                                    locations[xAxis - 1, yAxis - 3] = 8; // zarezerwowane pola na górze
                                    locations[xAxis + 1, yAxis - 3] = 8;
                                    locations[xAxis, yAxis - 3] = 8;


                                }
                                catch (Exception exc)
                                {

                                }
                            }
                            else
                            {

                            }
                            break;
                        }
                    case 2:
                        {
                            if (yAxis <= 7
                                && locations[xAxis, yAxis + 1] == 0
                                && locations[xAxis, yAxis + 2] == 0)
                            {
                                locations[xAxis, yAxis + 1] = 3;
                                locations[xAxis, yAxis + 2] = 3;
                                shipCorrectLocation = true;

                                try
                                {
                                    locations[xAxis - 1, yAxis] = 8;
                                    locations[xAxis + 1, yAxis] = 8;
                                    locations[xAxis - 1, yAxis + 1] = 8;
                                    locations[xAxis + 1, yAxis + 1] = 8;
                                    locations[xAxis - 1, yAxis + 2] = 8;
                                    locations[xAxis + 1, yAxis + 2] = 8;
                                    

                                    locations[xAxis, yAxis - 1] = 8;
                                    locations[xAxis - 1, yAxis - 1] = 8;
                                    locations[xAxis + 1, yAxis - 1] = 8;

                                    locations[xAxis + 1, yAxis + 3] = 8;
                                    locations[xAxis, yAxis + 3] = 8;
                                    locations[xAxis - 1, yAxis + 3] = 8;


                                }
                                catch (Exception exc)
                                {

                                }
                            }
                            else
                            {

                            }
                            break;
                        }
                    case 3:
                        {
                            if (xAxis >= 2
                                && locations[xAxis - 1, yAxis] == 0
                                && locations[xAxis - 2, yAxis] == 0)
                            {
                                locations[xAxis - 1, yAxis] = 3;
                                locations[xAxis - 2, yAxis] = 3;
                                shipCorrectLocation = true;

                                try
                                {
                                    locations[xAxis, yAxis + 1] = 8;
                                    locations[xAxis, yAxis - 1] = 8;
                                    locations[xAxis - 1, yAxis + 1] = 8;
                                    locations[xAxis - 1, yAxis - 1] = 8;
                                    locations[xAxis - 2, yAxis + 1] = 8;
                                    locations[xAxis - 2, yAxis - 1] = 8;

                                    locations[xAxis + 1, yAxis] = 8;
                                    locations[xAxis + 1, yAxis - 1] = 8;
                                    locations[xAxis + 1, yAxis + 1] = 8;

                                    locations[xAxis - 3, yAxis] = 8;
                                    locations[xAxis - 3, yAxis - 1] = 8;
                                    locations[xAxis - 3, yAxis + 1] = 8;

                                }
                                catch (Exception exc)
                                {

                                }

                            }
                            else
                            {

                            }
                            break;
                        }
                    case 4:
                        {
                            if (yAxis >= 7
                                && locations[xAxis + 1, yAxis] == 0
                                && locations[xAxis + 2, yAxis] == 0)
                            {
                                locations[xAxis + 1, yAxis] = 3;
                                locations[xAxis + 2, yAxis] = 3;
                                shipCorrectLocation = true;

                                try
                                {
                                    locations[xAxis, yAxis + 1] = 8;
                                    locations[xAxis, yAxis - 1] = 8;
                                    locations[xAxis + 1, yAxis + 1] = 8;
                                    locations[xAxis + 1, yAxis - 1] = 8;
                                    locations[xAxis + 2, yAxis + 1] = 8;
                                    locations[xAxis + 2, yAxis - 1] = 8;
                                    
                                    locations[xAxis - 1, yAxis] = 8;
                                    locations[xAxis - 1, yAxis - 1] = 8;
                                    locations[xAxis - 1, yAxis + 1] = 8;

                                    locations[xAxis + 3, yAxis] = 8;
                                    locations[xAxis + 3, yAxis - 1] = 8;
                                    locations[xAxis + 3, yAxis + 1] = 8;

                                }
                                catch (Exception exc)
                                {

                                }

                            }
                            else
                            {

                            }
                            break;
                        }

                }


            } while (shipCorrectLocation == false);

        }




        private void BuildingShips2Masted()
        {
            bool locationNotAvailable = false; // sprawdzam czy nie wpadłem na już istniejący okręt albo jego okolice
            byte xAxis;
            byte yAxis;
            do
            {
                xAxis = (byte)random.Next(0, 10);  // losowanie startowej pozycji 2masztowca
                yAxis = (byte)random.Next(0, 10);

                if (locations[xAxis, yAxis] != 0)
                {
                    locationNotAvailable = true; // już coś tam jest , losowanie od nowa
                }
                else
                {
                    locations[xAxis, yAxis] = 2;       // przypisanie wartości 2masztowca lokalizacji startowej
                    locationNotAvailable = false;
                }

            } while (locationNotAvailable == true);



            bool shipCorrectLocation = false; // czy udało się umieścić cały okręt ?

            do
            {
                int randomMethod = random.Next(1, 5);  // loswanie metody umieszczenia "reszty" okrętu


                switch (randomMethod)
                {
                    case 1:
                        {
                            if (yAxis >= 1
                                && locations[xAxis, yAxis - 1] == 0)
                            {
                                locations[xAxis, yAxis - 1] = 2;
                                shipCorrectLocation = true;

                                try
                                {
                                    locations[xAxis - 1, yAxis] = 8;  // zarezerwowane pola po bokach okrętu
                                    locations[xAxis + 1, yAxis] = 8;
                                    locations[xAxis - 1, yAxis - 1] = 8;
                                    locations[xAxis + 1, yAxis - 1] = 8;
                                   
                                    locations[xAxis, yAxis + 1] = 8;  // zarezerwowane pola na dole
                                    locations[xAxis - 1, yAxis + 1] = 8;
                                    locations[xAxis + 1, yAxis + 1] = 8;

                                    locations[xAxis - 1, yAxis - 2] = 8; // zarezerwowane pola na górze
                                    locations[xAxis + 1, yAxis - 2] = 8;
                                    locations[xAxis, yAxis - 2] = 8;


                                }
                                catch (Exception exc)
                                {

                                }
                            }
                            else
                            {

                            }
                            break;
                        }
                    case 2:
                        {
                            if (yAxis <= 8
                                && locations[xAxis, yAxis + 1] == 0)
                            {
                                locations[xAxis, yAxis + 1] = 2;
                                shipCorrectLocation = true;

                                try
                                {
                                    locations[xAxis - 1, yAxis] = 8;
                                    locations[xAxis + 1, yAxis] = 8;
                                    locations[xAxis - 1, yAxis + 1] = 8;
                                    locations[xAxis + 1, yAxis + 1] = 8;
                               
                                    locations[xAxis, yAxis - 1] = 8;
                                    locations[xAxis - 1, yAxis - 1] = 8;
                                    locations[xAxis + 1, yAxis - 1] = 8;

                                    locations[xAxis + 1, yAxis + 2] = 8;
                                    locations[xAxis, yAxis + 2] = 8;
                                    locations[xAxis - 1, yAxis + 2] = 8;


                                }
                                catch (Exception exc)
                                {

                                }

                            }
                            else
                            {

                            }
                            break;
                        }
                    case 3:
                        {
                            if (xAxis >= 1
                                && locations[xAxis - 1, yAxis] == 0)
                            {
                                locations[xAxis - 1, yAxis] = 2;
                                shipCorrectLocation = true;

                                try
                                {
                                    locations[xAxis, yAxis + 1] = 8;
                                    locations[xAxis, yAxis - 1] = 8;
                                    locations[xAxis - 1, yAxis + 1] = 8;
                                    locations[xAxis - 1, yAxis - 1] = 8;
                                    
                                    locations[xAxis + 1, yAxis] = 8;
                                    locations[xAxis + 1, yAxis - 1] = 8;
                                    locations[xAxis + 1, yAxis + 1] = 8;

                                    locations[xAxis - 2, yAxis] = 8;
                                    locations[xAxis - 2, yAxis - 1] = 8;
                                    locations[xAxis - 2, yAxis + 1] = 8;

                                }
                                catch (Exception exc)
                                {

                                }

                            }
                            else
                            {

                            }
                            break;
                        }
                    case 4:
                        {
                            if (yAxis >= 8
                                && locations[xAxis + 1, yAxis] == 0)
                            {
                                locations[xAxis + 1, yAxis] = 2;
                                shipCorrectLocation = true;

                                try
                                {
                                    locations[xAxis, yAxis + 1] = 8;
                                    locations[xAxis, yAxis - 1] = 8;
                                    locations[xAxis + 1, yAxis + 1] = 8;
                                    locations[xAxis + 1, yAxis - 1] = 8;
                                   
                                    locations[xAxis - 1, yAxis] = 8;
                                    locations[xAxis - 1, yAxis - 1] = 8;
                                    locations[xAxis - 1, yAxis + 1] = 8;

                                    locations[xAxis + 2, yAxis] = 8;
                                    locations[xAxis + 2, yAxis - 1] = 8;
                                    locations[xAxis + 2, yAxis + 1] = 8;

                                }
                                catch (Exception exc)
                                {

                                }

                            }
                            else
                            {

                            }
                            break;
                        }

                }


            } while (shipCorrectLocation == false);

        }

        private void BuildingShips1Masted()
        {
            bool locationNotAvailable = false; // sprawdzam czy nie wpadłem na już istniejący okręt albo jego okolice
            byte xAxis;
            byte yAxis;
            do
            {
                xAxis = (byte)random.Next(0, 10);  // losowanie startowej pozycji 1masztowca
                yAxis = (byte)random.Next(0, 10);

                if (locations[xAxis, yAxis] != 0)
                {
                    locationNotAvailable = true; // już coś tam jest , losowanie od nowa
                }
                else
                {
                    locations[xAxis, yAxis] = 1;       // przypisanie wartości 1masztowca lokalizacji startowej

                    try
                    {
                        locations[xAxis, yAxis + 1] = 8;
                        locations[xAxis, yAxis - 1] = 8;
                        locations[xAxis + 1, yAxis] = 8;
                        locations[xAxis - 1, yAxis] = 8;

                        locations[xAxis+1, yAxis + 1] = 8;
                        locations[xAxis-1, yAxis + 1] = 8;
                        locations[xAxis+1, yAxis - 1] = 8;
                        locations[xAxis-1, yAxis - 1] = 8;


                    }
                    catch (Exception exc)
                    {

                    }

                    locationNotAvailable = false;
                }

            } while (locationNotAvailable == true);


        }

        Random random = new Random((Int32)DateTime.Now.Ticks);

        //private void ShipLocation (byte shipSize)
        //{
          
        //    int tagNumber =  random.Next(1, controls.Count +1);
            

        //    foreach (Control c in controls)
        //    {
        //        if (Convert.ToInt32(c.TabIndex) == tagNumber)
        //        {
        //            c.Tag = "Ship";
                    
        //            break;

        //        }
        //    }

        //    if (shipSize == 4)
        //    {
        //        bool correctShipLocation = false;

        //        while (correctShipLocation == false)
        //        {

        //            int whichMethod = random.Next(1, 2);

        //            switch (whichMethod)
        //            {
        //                case 1:
        //                    if (tableLayoutPanel.Controls[tagNumber-10].Tag.ToString() != "Ship"
        //                        && tableLayoutPanel.Controls[tagNumber - 10].Tag.ToString() != "ShipZone"
        //                        && tagNumber - 10 >0)
        //                    {
        //                        if (tableLayoutPanel.Controls[tagNumber - 20].Tag.ToString() != "Ship"
        //                        && tableLayoutPanel.Controls[tagNumber - 20].Tag.ToString() != "ShipZone"
        //                        && tagNumber - 20 > 0)
        //                        {
        //                            if (tableLayoutPanel.Controls[tagNumber - 30].Tag.ToString() != "Ship"
        //                        && tableLayoutPanel.Controls[tagNumber - 30].Tag.ToString() != "ShipZone"
        //                        && tagNumber - 30 > 0)
        //                            {
        //                                tableLayoutPanel.Controls[tagNumber - 10].Tag = "Ship";
        //                                tableLayoutPanel.Controls[tagNumber - 20].Tag = "Ship";
        //                                tableLayoutPanel.Controls[tagNumber - 30].Tag = "Ship";

        //                                correctShipLocation = true;
        //                                break;
        //                            }
        //                            else
        //                            {

        //                            }
        //                        }
        //                        else
        //                        {

        //                        }
        //                    }
        //                    else
        //                    {

        //                    }
                                
        //                    break;
        //                case 2:
        //                    break;
        //                case 3:
        //                    break;
        //                case 4:
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }
        //    }

        //     void LocationNorth()
        //    {

        //    }
        //}

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



        //private void Btn_Click(object sender, EventArgs e)
        //{
        //    Button btn = (Button)sender;

        //    if (btn.Tag.ToString() == "Ship")
        //    {
        //        btn.BackColor = Color.DarkOrange;
        //    }
            
        //    MessageBox.Show(btn.Tag.ToString());
        //    MessageBox.Show(btn.TabIndex.ToString());
        //   // MessageBox.Show(btn.Tag.ToString());

        //    btn.Enabled = false;
        //}



    }
}
