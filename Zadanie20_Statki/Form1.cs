﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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

        List<Ship> listOfShips = new List<Ship>();


        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {

                BuildingShips4Masted();
                textBox.Text += "One 4-masted Battleship on water. Ready for combat !";
                textBox.Text += Environment.NewLine;
                BuildingShips3Masted();
                BuildingShips3Masted();
                textBox.Text += "Two 3-masted Battleships on water. Ready for combat !" ;
                textBox.Text += Environment.NewLine;
                BuildingShips2Masted();
                BuildingShips2Masted();
                BuildingShips2Masted();
                textBox.Text += "Three 2-masted Battleships on water. Ready for combat !" ;
                textBox.Text += Environment.NewLine;
                BuildingShips1Masted();
                BuildingShips1Masted();
                BuildingShips1Masted();
                BuildingShips1Masted();
                textBox.Text += "Four 1-masted Battleships on water. Ready for combat !" ;
                textBox.Text += Environment.NewLine;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Storm over battlefield!\nRestart application","FATAL ERROR");
                Application.Exit();
            }


            foreach (var item in locations)  // przeniesienie wartości z tablicy do listy
            {
                locationsList.Add(item);
            }

            foreach (Control c in tableLayoutPanel.Controls) // properties Tag przycisku taki sam jak tekst na guziku
            {
                c.Tag = c.Text;
                //c.TabIndex = Convert.ToInt32(c.Text);
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

                                Ship ship = new Ship(xAxis, yAxis, xAxis, Convert.ToSByte(yAxis - 1), xAxis, 
                                    Convert.ToSByte(yAxis - 2), xAxis, Convert.ToSByte(yAxis - 3));

                                listOfShips.Add(ship);

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

                                Ship ship = new Ship(xAxis, yAxis, xAxis, Convert.ToSByte(yAxis + 1), xAxis,
                                    Convert.ToSByte(yAxis + 2), xAxis, Convert.ToSByte(yAxis + 3));

                                listOfShips.Add(ship);

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

                                Ship ship = new Ship(xAxis, yAxis, Convert.ToSByte(xAxis - 1), yAxis, Convert.ToSByte(xAxis - 2), yAxis,
                                    Convert.ToSByte(xAxis - 3), yAxis);

                                listOfShips.Add(ship);

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

                                Ship ship = new Ship(xAxis, yAxis, Convert.ToSByte(xAxis + 1), yAxis, Convert.ToSByte(xAxis + 2), yAxis,
                                    Convert.ToSByte(xAxis + 3), yAxis);

                                listOfShips.Add(ship);

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

                                    Ship ship = new Ship(xAxis, yAxis, xAxis, Convert.ToSByte(yAxis - 1), xAxis,
                                    Convert.ToSByte(yAxis - 2));

                                    listOfShips.Add(ship);

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

                                    Ship ship = new Ship(xAxis, yAxis, xAxis, Convert.ToSByte(yAxis + 1), xAxis,
                                    Convert.ToSByte(yAxis + 2));

                                    listOfShips.Add(ship);

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

                                    Ship ship = new Ship(xAxis, yAxis, Convert.ToSByte(xAxis - 1), yAxis, Convert.ToSByte(xAxis - 2), yAxis);

                                    listOfShips.Add(ship);

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

                                    Ship ship = new Ship(xAxis, yAxis, Convert.ToSByte(xAxis + 1), yAxis, Convert.ToSByte(xAxis + 2), yAxis);
                                    
                                    listOfShips.Add(ship);

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

                                    Ship ship = new Ship(xAxis, yAxis, xAxis, Convert.ToSByte(yAxis - 1));

                                    listOfShips.Add(ship);

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

                                    Ship ship = new Ship(xAxis, yAxis, xAxis, Convert.ToSByte(yAxis + 1));

                                    listOfShips.Add(ship);

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

                                    Ship ship = new Ship(xAxis, yAxis, Convert.ToSByte(xAxis - 1), yAxis);

                                    listOfShips.Add(ship);

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

                                    Ship ship = new Ship(xAxis, yAxis, Convert.ToSByte(xAxis + 1), yAxis);

                                    listOfShips.Add(ship);

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

                    Ship ship = new Ship(xAxis, yAxis);

                    listOfShips.Add(ship);

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

            
            

            int btnIndex = Convert.ToInt32(btn.Tag) - 1;

            if (locationsList[btnIndex] == 0 || locationsList[btnIndex] == 8)
            {
                btn.BackColor = Color.LightBlue;
                btn.Text = string.Empty;
                btn.Enabled = false;
            }
            else
            {
                btn.BackColor = Color.DarkOrange;
                btn.ForeColor = Color.DarkOrange; //  DLACZEGO TO  NIE DZIAŁA ??????????????????
                btn.Text = locationsList[btnIndex].ToString();
                btn.ForeColor = Color.DarkOrange;       //  DLACZEGO TO  NIE DZIAŁA ???????????
                btn.Enabled = false;
                CheckForSunken();

            }

            //CheckForSunken();


        }


        private void CheckForSunken ()
        {

            foreach (Ship ship in listOfShips)
            {
                 
                int index1 = (10 * ship.mast1[0]) + (ship.mast1[1]  );
                int index2 = (10 * ship.mast2[0]) + (ship.mast2[1] );
                int index3 = (10 * ship.mast3[0]) + (ship.mast3[1] );
                int index4 = (10 * ship.mast4[0]) + (ship.mast4[1]);

                if (tableLayoutPanel.Controls[index1].Text == "4"
                    && tableLayoutPanel.Controls[index1].BackColor == Color.DarkOrange
                    && tableLayoutPanel.Controls[index2].BackColor == Color.DarkOrange
                    && tableLayoutPanel.Controls[index3].BackColor == Color.DarkOrange
                    && tableLayoutPanel.Controls[index4].BackColor == Color.DarkOrange)
                {
                    tableLayoutPanel.Controls[index1].BackColor = Color.Red;
                    tableLayoutPanel.Controls[index2].BackColor = Color.Red;
                    tableLayoutPanel.Controls[index3].BackColor = Color.Red;
                    tableLayoutPanel.Controls[index4].BackColor = Color.Red;

                    textBox.Text += "You have just sunk 4-masted Battleship. It was huge dreadnought type battleship. Well done!";
                    textBox.Text += Environment.NewLine;
                    ship.shipActive = false;
                    lbl_4masted.Text = string.Empty; 
                    CheckWholeFleet();

                }
                else if(tableLayoutPanel.Controls[index1].Text == "3"
                    && tableLayoutPanel.Controls[index1].BackColor == Color.DarkOrange
                    && tableLayoutPanel.Controls[index2].BackColor == Color.DarkOrange
                    && tableLayoutPanel.Controls[index3].BackColor == Color.DarkOrange)
                {
                    tableLayoutPanel.Controls[index1].BackColor = Color.Red;
                    tableLayoutPanel.Controls[index2].BackColor = Color.Red;
                    tableLayoutPanel.Controls[index3].BackColor = Color.Red;

                    textBox.Text += "You have just sunk 3-masted Battleship. It was powerful and well armored cruiser. Well done!";
                    textBox.Text += Environment.NewLine;
                    ship.shipActive = false;
                    if (lbl_3masted1.Text != string.Empty)
                    {
                        lbl_3masted1.Text = string.Empty;
                    }

                    else 
                    {
                        lbl_3masted2.Text = string.Empty;
                    }
                    CheckWholeFleet();

                }
                else if (tableLayoutPanel.Controls[index1].Text == "2"
                    && tableLayoutPanel.Controls[index1].BackColor == Color.DarkOrange
                    && tableLayoutPanel.Controls[index2].BackColor == Color.DarkOrange)
                {
                    tableLayoutPanel.Controls[index1].BackColor = Color.Red;
                    tableLayoutPanel.Controls[index2].BackColor = Color.Red;

                    textBox.Text += "You have just sunk 2-masted Battleship. It was quick and dangerous destroyer. Well done!";
                    textBox.Text += Environment.NewLine;
                    ship.shipActive = false;

                    if (lbl_2masted1.Text != string.Empty)
                    {
                        lbl_2masted1.Text = string.Empty;
                    }
                    else if (lbl_2masted1.Text == string.Empty && lbl_2masted2.Text != string.Empty)
                    {
                        lbl_2masted2.Text = string.Empty;
                    }
                    else
                    {
                        lbl_2masted3.Text = string.Empty;
                    }
                    CheckWholeFleet();

                }
                else if (tableLayoutPanel.Controls[index1].Text == "1"
                    && tableLayoutPanel.Controls[index1].BackColor == Color.DarkOrange)
                {
                    tableLayoutPanel.Controls[index1].BackColor = Color.Red;

                    textBox.Text += "You have just sunk 1-masted Battleship. It wasn't easy to find this little torpedo boat. Well done!";
                    textBox.Text += Environment.NewLine;
                    ship.shipActive = false;
                    if (lbl_1masted1.Text != string.Empty)
                    {
                        lbl_1masted1.Text = string.Empty;
                    }
                    else if (lbl_1masted1.Text == string.Empty && lbl_1masted2.Text != string.Empty)
                    {
                        lbl_1masted2.Text = string.Empty;
                    }
                    else if (lbl_1masted1.Text == string.Empty && lbl_1masted2.Text == string.Empty 
                        && lbl_1masted3.Text != string.Empty)
                    {
                        lbl_1masted3.Text = string.Empty;
                    }
                    else
                    {
                        lbl_1masted4.Text = string.Empty;
                    }
                    CheckWholeFleet();

                }

            }

            
        }
     
        private void CheckWholeFleet()
        {
            bool fleetDestroyed = false;
            foreach (Ship ship in listOfShips)
            {
                if (ship.shipActive == false)
                {
                    fleetDestroyed = true;
                }
                else
                {
                    fleetDestroyed = false;
                    break;
                }

                
            }

            if (fleetDestroyed == true)
            {
                textBox.Text += Environment.NewLine;
                textBox.Text += "Good work Captain! You defeated all enemy  Battleships. You sunk whole fleet. It was epic!";
                textBox.Text += Environment.NewLine;
                tableLayoutPanel.Enabled = false;
            }

        }

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

                if (locationsList[btnIndex] == 0 || locationsList[btnIndex] == 8
                    || c.BackColor == Color.DarkOrange || c.BackColor == Color.Red)
                {
                    
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


    public class Ship
    {
        public sbyte[] mast1 = new sbyte[2];
        public sbyte[] mast2 = new sbyte[2];
        public sbyte[] mast3 = new sbyte[2];
        public sbyte[] mast4 = new sbyte[2];
        public bool shipActive = true;

        public Ship(sbyte xMast1, sbyte yMast1)
        {
            mast1[0] = xMast1;
            mast1[1] = yMast1;
        }
        public Ship(sbyte xMast1, sbyte yMast1, sbyte xMast2, sbyte yMast2)
        {
            mast1[0] = xMast1;
            mast1[1] = yMast1;
            mast2[0] = xMast2;
            mast2[1] = yMast2;
        }
        public Ship(sbyte xMast1, sbyte yMast1, sbyte xMast2, sbyte yMast2, sbyte xMast3, sbyte yMast3)
        {
            mast1[0] = xMast1;
            mast1[1] = yMast1;
            mast2[0] = xMast2;
            mast2[1] = yMast2;
            mast3[0] = xMast3;
            mast3[1] = yMast3;
        }

        public Ship(sbyte xMast1, sbyte yMast1, sbyte xMast2, sbyte yMast2,
            sbyte xMast3, sbyte yMast3, sbyte xMast4, sbyte yMast4)
        {
            mast1[0] = xMast1;
            mast1[1] = yMast1;
            mast2[0] = xMast2;
            mast2[1] = yMast2;
            mast3[0] = xMast3;
            mast3[1] = yMast3;
            mast4[0] = xMast4;
            mast4[1] = yMast4;
        }



    }


}
