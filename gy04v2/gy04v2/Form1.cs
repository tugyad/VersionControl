﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
namespace gy04v2
{
    public partial class Form1 : Form
    {
        RealEstateEntities context = new RealEstateEntities();
        public List<Flat> Flats;
        Excel.Application xlApp; 
        Excel.Workbook xlWB; 
        Excel.Worksheet xlSheet;

        public Form1()
        {
            InitializeComponent();
            LoadData();

        }
        private void LoadData()
        {
            Flats = context.Flat.ToList();
            
        }
        void CreateExcel()
        {

        
        try
        {
         xlApp = new Excel.Application();
         xlWB = xlApp.Workbooks.Add(Missing.Value);
         xlSheet = xlWB.ActiveSheet;

         CreateTable();

         xlApp.Visible = true;
         xlApp.UserControl = true;
        }
        catch (Exception ex) 
        {
        string errMsg = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
         MessageBox.Show(errMsg, "Error");

        xlWB.Close(false, Type.Missing, Type.Missing);
         xlApp.Quit();
         xlWB = null;
         xlApp = null;
        }
        }
        int counter = 0;
        void CreateTable()
        {
            string[] headers = new string[] {
         "Kód",
         "Eladó",
         "Oldal",
         "Kerület",
        "Lift",
        "Szobák száma",
        "Alapterület (m2)",
        "Ár (mFt)",
        "Négyzetméter ár (Ft/m2)"};

            for (int i = 0; i < headers.Length; i++)
            {
                xlSheet.Cells[1, i + 1] = headers[i];
            }
            object[,] values = new object[Flats.Count, headers.Length];
           
            foreach (Flat flat in Flats)
            {
                values[counter, 0] = flat.Code;
                values[counter, 1] = flat.Vendor;
                values[counter, 2] = flat.Side;
                values[counter, 3] = flat.District;
                values[counter, 4] = flat.Elevator; 
                values[counter, 5] = flat.NumberOfRooms;
                values[counter, 6] = flat.FloorArea;
                values[counter, 7] = flat.Price;

                values[counter, 8] = "";

                counter++;
            }
        }
        private string GetCell(int x, int y)
        {
            string ExcelCoordinate = "";
            int dividend = y;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                ExcelCoordinate = Convert.ToChar(65 + modulo).ToString() + ExcelCoordinate;
                dividend = (int)((dividend - modulo) / 26);
            }
            ExcelCoordinate += x.ToString();

            return ExcelCoordinate;
        }




    }
}
