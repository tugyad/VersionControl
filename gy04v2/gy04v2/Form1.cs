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
            object[,] values = new object[flats.Count, headers.Length];
        }

     		
         
}
}
