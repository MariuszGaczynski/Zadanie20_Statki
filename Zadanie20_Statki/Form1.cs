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


        public sbyte[,] locations = new sbyte[10, 10]; // tablica ze współrzędnymi lokacji

        List<sbyte> locationsList = new List<sbyte>();   // lista wartości na kolejnych lokacjach


        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {

                BuildingShips4Masted();
                textBox1.Text += "4-masted Battleship located" + Environment.NewLine;
                BuildingShips3Masted();
                BuildingShips3Masted();
                textBox1.Text += "3-masted Battleships located" + Environment.NewLine; ;
                BuildingShips2Masted();
                BuildingShips2Masted();
                BuildingShips2Masted();
                textBox1.Text += "2-masted Battleships located" + Environment.NewLine; ;
                BuildingShips1Masted();
                BuildingShips1Masted();
                BuildingShips1Masted();
                BuildingShips1Masted();
                textBox1.Text += "1-masted Battleships located" + Environment.NewLine; ;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Restart application");
            }


            foreach (var item in locations)  // przeniesienie wartości z tablicy do listy
            {
                locationsList.Add(item);
            }

            foreach (Control c in tableLayoutPanel.Controls) // properties Tag przycisku taki sam jak tekst na guziku
            {
                c.Tag = c.Text;

            }

            foreach (Control c in tableLayoutPanel.Controls) // zamiana tekstów na guziku na "?" niewiadomą 
            {
                c.Text = "?";

            }

            foreach (Control c in tableLayoutPanel.Controls) 
            {
                c.BackColor = Color.DarkBlue;
                c.ForeColor = Color.Aqua;
            }
        }


        private void BuildingShips4Masted()
        {


            sbyte xAxis = (sbyte)random.Next(0, 10);  // losowanie startowej pozycji 4masztowca
            sbyte yAxis = (sbyte)random.Next(0, 10);

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
                                && locations[xAxis, yAxis - 1] == 0
                                && locations[xAxis, yAxis - 2] == 0
                                && locations[xAxis, yAxis - 3] == 0)
                            {
                                locations[xAxis, yAxis - 1] = 4;
                                locations[xAxis, yAxis - 2] = 4;
                                locations[xAxis, yAxis - 3] = 4;
                                shipCorrectLocation = true;

                                SetZoneAroundShip(Convert.ToSByte(xAxis - 1), yAxis);
                                SetZoneAroundShip(Convert.ToSByte(xAxis + 1), yAxis);
                                SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis - 1));
                                SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis - 1));
                                SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis - 2));
                                SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis - 2));
                                SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis - 3));
                                SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis - 3));

                                SetZoneAroundShip(xAxis, Convert.ToSByte(yAxis + 1));
                                SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis + 1));
                                SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis + 1));

                                SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis - 4));
                                SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis - 4));
                                SetZoneAroundShip(xAxis, Convert.ToSByte(yAxis - 4));


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


                                SetZoneAroundShip(Convert.ToSByte(xAxis - 1), yAxis);
                                SetZoneAroundShip(Convert.ToSByte(xAxis + 1), yAxis);
                                SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis + 1));
                                SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis + 1));
                                SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis + 2));
                                SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis + 2));
                                SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis + 3));
                                SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis + 3));

                                SetZoneAroundShip(xAxis, Convert.ToSByte(yAxis - 1));
                                SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis - 1));
                                SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis - 1));

                                SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis + 4));
                                SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis + 4));
                                SetZoneAroundShip(xAxis, Convert.ToSByte(yAxis + 4));
                               

                            }
                            else
                            {

                            }
                            break;
                        }
                    case 3:
                        {
                            if (xAxis >= 3
                                && locations[xAxis - 1, yAxis] == 0
                                && locations[xAxis - 2, yAxis] == 0
                                && locations[xAxis - 3, yAxis] == 0)
                            {
                                locations[xAxis - 1, yAxis] = 4;
                                locations[xAxis - 2, yAxis] = 4;
                                locations[xAxis - 3, yAxis] = 4;
                                shipCorrectLocation = true;

                                SetZoneAroundShip(xAxis, Convert.ToSByte(yAxis +1));
                                SetZoneAroundShip(xAxis, Convert.ToSByte(yAxis - 1));
                                SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis + 1));
                                SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis - 1));
                                SetZoneAroundShip(Convert.ToSByte(xAxis - 2), Convert.ToSByte(yAxis + 1));
                                SetZoneAroundShip(Convert.ToSByte(xAxis - 2), Convert.ToSByte(yAxis - 1));
                                SetZoneAroundShip(Convert.ToSByte(xAxis - 3), Convert.ToSByte(yAxis + 1));
                                SetZoneAroundShip(Convert.ToSByte(xAxis - 3), Convert.ToSByte(yAxis - 1));

                                SetZoneAroundShip(Convert.ToSByte(xAxis +1), yAxis);
                                SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis - 1));
                                SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis + 1));

                                SetZoneAroundShip(Convert.ToSByte(xAxis - 4), Convert.ToSByte(yAxis - 1));
                                SetZoneAroundShip(Convert.ToSByte(xAxis - 4), Convert.ToSByte(yAxis + 1));
                                SetZoneAroundShip(Convert.ToSByte(xAxis - 4), yAxis );


                            }
                            else
                            {

                            }
                            break;
                        }
                    case 4:
                        {
                            if (xAxis <= 6
                                && locations[xAxis + 1, yAxis] == 0
                                && locations[xAxis + 2, yAxis] == 0
                                && locations[xAxis + 3, yAxis] == 0)
                            {
                                locations[xAxis + 1, yAxis] = 4;
                                locations[xAxis + 2, yAxis] = 4;
                                locations[xAxis + 3, yAxis] = 4;
                                shipCorrectLocation = true;

                                SetZoneAroundShip(xAxis, Convert.ToSByte(yAxis + 1));
                                SetZoneAroundShip(xAxis, Convert.ToSByte(yAxis - 1));
                                SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis + 1));
                                SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis - 1));
                                SetZoneAroundShip(Convert.ToSByte(xAxis + 2), Convert.ToSByte(yAxis + 1));
                                SetZoneAroundShip(Convert.ToSByte(xAxis + 2), Convert.ToSByte(yAxis - 1));
                                SetZoneAroundShip(Convert.ToSByte(xAxis + 3), Convert.ToSByte(yAxis + 1));
                                SetZoneAroundShip(Convert.ToSByte(xAxis + 3), Convert.ToSByte(yAxis - 1));

                                SetZoneAroundShip(Convert.ToSByte(xAxis - 1), yAxis);
                                SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis - 1));
                                SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis + 1));

                                SetZoneAroundShip(Convert.ToSByte(xAxis + 4), Convert.ToSByte(yAxis - 1));
                                SetZoneAroundShip(Convert.ToSByte(xAxis + 4), Convert.ToSByte(yAxis + 1));
                                SetZoneAroundShip(Convert.ToSByte(xAxis + 4) ,yAxis );


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
            sbyte xAxis;
            sbyte yAxis;
            int noMoreThan20Tries = 20;
            bool shipCorrectLocation = false; // czy udało się umieścić cały okręt ?
            do
            {

                do
                {
                    noMoreThan20Tries = 20;
                    xAxis = (sbyte)random.Next(0, 10);  // losowanie startowej pozycji 3masztowca
                    yAxis = (sbyte)random.Next(0, 10);

                    if (locations[xAxis, yAxis] != 0)
                    {
                        locationNotAvailable = true; // już coś tam jest , losowanie od nowa
                    }
                    else
                    {
                        
                        locationNotAvailable = false;
                    }

                } while (locationNotAvailable == true);



                do
                {
                    noMoreThan20Tries--;
                    int randomMethod = random.Next(1, 5);  // loswanie metody umieszczenia "reszty" okrętu


                    switch (randomMethod)
                    {
                        case 1:
                            {
                                if (yAxis >= 2
                                    && locations[xAxis, yAxis - 1] == 0
                                    && locations[xAxis, yAxis - 2] == 0)
                                {
                                    locations[xAxis, yAxis] = 3;       // przypisanie wartości 3masztowca lokalizacji startowej
                                    locations[xAxis, yAxis - 1] = 3;
                                    locations[xAxis, yAxis - 2] = 3;
                                    shipCorrectLocation = true;

                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), yAxis);
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), yAxis);
                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis - 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis - 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis - 2));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis - 2));

                                    SetZoneAroundShip(xAxis, Convert.ToSByte(yAxis + 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis + 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis + 1));

                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis - 3));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis - 3));
                                    SetZoneAroundShip(xAxis, Convert.ToSByte(yAxis - 3));


                                    
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
                                    locations[xAxis, yAxis] = 3;       // przypisanie wartości 3masztowca lokalizacji startowej
                                    locations[xAxis, yAxis + 1] = 3;
                                    locations[xAxis, yAxis + 2] = 3;
                                    shipCorrectLocation = true;

                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), yAxis);
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), yAxis);
                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis + 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis + 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis + 2));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis + 2));

                                    SetZoneAroundShip(xAxis, Convert.ToSByte(yAxis - 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis - 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis - 1));

                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis + 3));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis + 3));
                                    SetZoneAroundShip(xAxis, Convert.ToSByte(yAxis + 3));

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
                                    locations[xAxis, yAxis] = 3;       // przypisanie wartości 3masztowca lokalizacji startowej
                                    locations[xAxis - 1, yAxis] = 3;
                                    locations[xAxis - 2, yAxis] = 3;
                                    shipCorrectLocation = true;

                                    SetZoneAroundShip(xAxis, Convert.ToSByte(yAxis + 1));
                                    SetZoneAroundShip(xAxis, Convert.ToSByte(yAxis - 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis + 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis - 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 2), Convert.ToSByte(yAxis + 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 2), Convert.ToSByte(yAxis - 1));

                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), yAxis);
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis - 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis + 1));

                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 3), Convert.ToSByte(yAxis - 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 3), Convert.ToSByte(yAxis + 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 3), yAxis);

                                }
                                else
                                {

                                }
                                break;
                            }
                        case 4:
                            {
                                if (xAxis <= 7
                                    && locations[xAxis + 1, yAxis] == 0
                                    && locations[xAxis + 2, yAxis] == 0)
                                {
                                    locations[xAxis, yAxis] = 3;       // przypisanie wartości 3masztowca lokalizacji startowej
                                    locations[xAxis + 1, yAxis] = 3;
                                    locations[xAxis + 2, yAxis] = 3;
                                    shipCorrectLocation = true;

                                    SetZoneAroundShip(xAxis, Convert.ToSByte(yAxis + 1));
                                    SetZoneAroundShip(xAxis, Convert.ToSByte(yAxis - 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis + 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis - 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 2), Convert.ToSByte(yAxis + 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 2), Convert.ToSByte(yAxis - 1));

                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), yAxis);
                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis - 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis + 1));

                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 3), Convert.ToSByte(yAxis - 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 3), Convert.ToSByte(yAxis + 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 3), yAxis);

                                }
                                else
                                {

                                }
                                break;
                            }

                    }


                } while (shipCorrectLocation == false && noMoreThan20Tries >0);


            } while (shipCorrectLocation == false);
        }



        private void BuildingShips2Masted()
        {
            bool locationNotAvailable = false; // sprawdzam czy nie wpadłem na już istniejący okręt albo jego okolice
            sbyte xAxis;
            sbyte yAxis;
            int noMoreThan20Tries = 20;
            bool shipCorrectLocation = false; // czy udało się umieścić cały okręt ?

            do
            {


                do
                {
                    noMoreThan20Tries = 20;
                    xAxis = (sbyte)random.Next(0, 10);  // losowanie startowej pozycji 2masztowca
                    yAxis = (sbyte)random.Next(0, 10);

                    if (locations[xAxis, yAxis] != 0)
                    {
                        locationNotAvailable = true; // już coś tam jest , losowanie od nowa
                    }
                    else
                    {
                        
                        locationNotAvailable = false;
                    }

                } while (locationNotAvailable == true);


                do
                {
                    noMoreThan20Tries--;
                    int randomMethod = random.Next(1, 5);  // loswanie metody umieszczenia "reszty" okrętu


                    switch (randomMethod)
                    {
                        case 1:
                            {
                                if (yAxis >= 1
                                    && locations[xAxis, yAxis - 1] == 0)
                                {
                                    locations[xAxis, yAxis] = 2;       // przypisanie wartości 2masztowca lokalizacji startowej
                                    locations[xAxis, yAxis - 1] = 2;
                                    shipCorrectLocation = true;

                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), yAxis);
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), yAxis);
                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis - 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis - 1));

                                    SetZoneAroundShip(xAxis, Convert.ToSByte(yAxis + 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis + 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis + 1));

                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis - 2));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis - 2));
                                    SetZoneAroundShip(xAxis, Convert.ToSByte(yAxis - 2));

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
                                    locations[xAxis, yAxis] = 2;       // przypisanie wartości 2masztowca lokalizacji startowej
                                    locations[xAxis, yAxis + 1] = 2;
                                    shipCorrectLocation = true;

                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), yAxis);
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), yAxis);
                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis + 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis + 1));

                                    SetZoneAroundShip(xAxis, Convert.ToSByte(yAxis - 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis - 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis - 1));

                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis + 2));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis + 2));
                                    SetZoneAroundShip(xAxis, Convert.ToSByte(yAxis + 2));
                          
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
                                    locations[xAxis, yAxis] = 2;       // przypisanie wartości 2masztowca lokalizacji startowej
                                    locations[xAxis - 1, yAxis] = 2;
                                    shipCorrectLocation = true;

                                    SetZoneAroundShip(xAxis, Convert.ToSByte(yAxis + 1));
                                    SetZoneAroundShip(xAxis, Convert.ToSByte(yAxis - 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis + 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis - 1));

                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), yAxis);
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis - 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis + 1));

                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 2), Convert.ToSByte(yAxis - 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 2), Convert.ToSByte(yAxis + 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 2), yAxis);
                                 

                                }
                                else
                                {

                                }
                                break;
                            }
                        case 4:
                            {
                                if (xAxis <= 8
                                    && locations[xAxis + 1, yAxis] == 0)
                                {
                                    locations[xAxis, yAxis] = 2;       // przypisanie wartości 2masztowca lokalizacji startowej
                                    locations[xAxis + 1, yAxis] = 2;
                                    shipCorrectLocation = true;

                                    SetZoneAroundShip(xAxis, Convert.ToSByte(yAxis + 1));
                                    SetZoneAroundShip(xAxis, Convert.ToSByte(yAxis - 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis + 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis - 1));

                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), yAxis);
                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis - 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis + 1));

                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 2), Convert.ToSByte(yAxis - 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 2), Convert.ToSByte(yAxis + 1));
                                    SetZoneAroundShip(Convert.ToSByte(xAxis + 2), yAxis);
                                

                                }
                                else
                                {

                                }
                                break;
                            }

                    }


                } while (shipCorrectLocation == false && noMoreThan20Tries >0);

            } while (shipCorrectLocation == false);
        }

        private void BuildingShips1Masted()
        {
            bool locationNotAvailable = false; // sprawdzam czy nie wpadłem na już istniejący okręt albo jego okolice
            sbyte xAxis;
            sbyte yAxis;
            do
            {
                xAxis = (sbyte)random.Next(0, 10);  // losowanie startowej pozycji 1masztowca
                yAxis = (sbyte)random.Next(0, 10);

                if (locations[xAxis, yAxis] != 0)
                {
                    locationNotAvailable = true; // już coś tam jest , losowanie od nowa
                }
                else
                {
                    locations[xAxis, yAxis] = 1;       // przypisanie wartości 1masztowca lokalizacji startowej


                    SetZoneAroundShip(xAxis, Convert.ToSByte(yAxis + 1));
                    SetZoneAroundShip(xAxis, Convert.ToSByte(yAxis - 1));
                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), yAxis);
                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), yAxis);

                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis + 1));
                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis + 1));
                    SetZoneAroundShip(Convert.ToSByte(xAxis + 1), Convert.ToSByte(yAxis - 1));
                    SetZoneAroundShip(Convert.ToSByte(xAxis - 1), Convert.ToSByte(yAxis - 1));


                    locationNotAvailable = false;
                }

            } while (locationNotAvailable == true);


        }


        Random random = new Random((Int32)DateTime.Now.Ticks);


        private void SetZoneAroundShip(sbyte alterXAxis, sbyte alterYAxis)
        {
            try
            {
                locations[alterXAxis, alterYAxis ] = 8;
            }
            catch (Exception exc)
            {

            }
        }


        public int bombsDroped = 0;
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            bombsDroped++;
            lbl_BombsDroped.Text = bombsDroped.ToString();

            btn.Text = string.Empty;
            btn.Enabled = false;

            int btnIndex = Convert.ToInt32(btn.Tag) - 1;

            if (locationsList[btnIndex] == 0 || locationsList[btnIndex] == 8)
            {
                btn.BackColor = Color.LightBlue;
            }
            else
            {
                btn.BackColor = Color.DarkOrange;
                btn.Text = locationsList[btnIndex].ToString();
                //locationsList[btnIndex] = 0;

                //if (SurroundingsIsEmpty(btnIndex))
                //{
                //    btn.BackColor = Color.DarkRed;
                //}
            }

           


        }


        //private bool SurroundingsIsEmpty(int btnIndex)
        //{
        //    if (CheckLocation(btnIndex + 1) == true
        //        && CheckLocation(btnIndex - 1) == true
        //        && CheckLocation(btnIndex + 10) == true
        //        && CheckLocation(btnIndex - 10) == true
        //        && CheckLocation(btnIndex + 9) == true
        //        && CheckLocation(btnIndex - 9) == true
        //        && CheckLocation(btnIndex + 11) == true
        //        && CheckLocation(btnIndex - 11) == true)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}

        private bool CheckLocation(int btnIndex)
        {
            try
            {
                if (locationsList[btnIndex] == 0 || locationsList[btnIndex] == 8)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch
            {
                return true;
            }
        }
        //  DWIE METODY POMOCNICZE (DO USUNIĘCIA )

        private void btn_Help_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (Control c in tableLayoutPanel.Controls)
            {
                int btnIndex = Convert.ToInt32(c.Tag) - 1;

                if (locationsList[btnIndex] == 0 || locationsList[btnIndex] == 8)
                {
                    //c.BackColor = Color.DarkBlue;
                }
                else
                {
                    c.BackColor = Color.DarkOrange;
                }
            }
        }

        private void btn_Help_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (Control c in tableLayoutPanel.Controls)
            {

                if (c.Text == "?")
                {
                    c.BackColor = Color.DarkBlue;
                }
              
            }
        }
    }
}
