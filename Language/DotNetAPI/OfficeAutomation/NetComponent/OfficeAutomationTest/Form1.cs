using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OfficeAutomation;

namespace OfficeAutomationTest
{
    public partial class Form1 : Form
    {
        private double[] sales = { 15245.23, 18270, 14187.55, 12153.49, 11200.66, 17899.21, 18487, 19215.23, 17148.87, 20357.24, 21141.49, 16157.68 };
        private double[] cost = { 12455, 13656.99, 11250, 10269.50, 10348.49, 14536.54, 15923.56, 16423.55, 14953.99, 16532.12, 15401.01, 11586.49 };
        private double[] fsales = { 15245.23, 18270, 14187.55 };
        private double[] fcost = { 12455, 13656.99, 11250 };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnCreateSpreadsheet_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            OfficeAutomation.ExcelWorkbook wb = new OfficeAutomation.ExcelWorkbook();

            wb.Title = "This is the title";
	        wb.Subject = "This is the subject";
            wb.Comments = "These are the comments";

	        //====================================================
	        //Sales analysis worksheet
	        //====================================================
	        wb.Worksheet = 1;
	        wb.WorksheetName = "2010 Sales";
	        wb.SetData("A1","2010 Sales");
            wb.SetFont("A1", "Arial", 24);
            wb.SetBold("A1");

            //Row headings
            wb.SetData("A4", "Sales");
            wb.SetData("A5", "Cost Of Sales");
            wb.SetData("A6", "Gross Profit");
            wb.SetBold("A4:A6");
            wb.SetHorizontalAlignment("A4:A6", HAlign.Right);
            wb.SetColumnWidth(1, 20);

            //Column headings
            wb.SetData("B3", "Jan 10");
            wb.SetData("C3", "Feb 10");
            wb.SetData("D3", "Mar 10");
            wb.SetData("E3", "Apr 10");
            wb.SetData("F3", "May 10");
            wb.SetData("G3", "Jun 10");
            wb.SetData("H3", "Jul 10");
            wb.SetData("I3", "Aug 10");
            wb.SetData("J3", "Sep 10");
            wb.SetData("K3", "Oct 10");
            wb.SetData("L3", "Nov 10");
            wb.SetData("M3", "Dec 10");
            wb.SetBold("B3:M3");
            wb.SetHorizontalAlignment("B3:M3", HAlign.Right);
            wb.SetColumnWidth("B:M", 13);

	        //Sales values
            wb.SetData("B4", sales[0]);
            wb.SetData("C4", sales[1]);
            wb.SetData("D4", sales[2]);
            wb.SetData("E4", sales[3]);
            wb.SetData("F4", sales[4]);
            wb.SetData("G4", sales[5]);
            wb.SetData("H4", sales[6]);
            wb.SetData("I4", sales[7]);
            wb.SetData("J4", sales[8]);
            wb.SetData("K4", sales[9]);
            wb.SetData("L4", sales[10]);
            wb.SetData("M4", sales[11]);

	        //Cost of sales values
            wb.SetData("B5", cost[0]);
            wb.SetData("C5", cost[1]);
            wb.SetData("D5", cost[2]);
            wb.SetData("E5", cost[3]);
            wb.SetData("F5", cost[4]);
            wb.SetData("G5", cost[5]);
            wb.SetData("H5", cost[6]);
            wb.SetData("I5", cost[7]);
            wb.SetData("J5", cost[8]);
            wb.SetData("K5", cost[9]);
            wb.SetData("L5", cost[10]);
            wb.SetData("M5", cost[11]);
            wb.SetItalic("B5:M5");

            //Gross profit calculations
            wb.SetFormula("B6", "B4-B5");
            wb.SetFormula("C6", "C4-C5");
            wb.SetFormula("D6", "D4-D5");
            wb.SetFormula("E6", "E4-E5");
            wb.SetFormula("F6", "F4-F5");
            wb.SetFormula("G6", "G4-G5");
            wb.SetFormula("H6", "H4-H5");
            wb.SetFormula("I6", "I4-I5");
            wb.SetFormula("J6", "J4-J5");
            wb.SetFormula("K6", "K4-K5");
            wb.SetFormula("L6", "L4-L5");
            wb.SetFormula("M6", "M4-M5");
            wb.SetBold("B6:M6");
            wb.SetFormat("B4:M6", "$#,##0.00_);[Red]($#,##0.00)");

            //Draw borders around the data
            wb.DrawBox("A4:M6", LineStyle.Continuous, LineWeight.Thick);
            wb.DrawLine("A4:M6", Border.InsideHorizontal, LineStyle.Continuous, LineWeight.Thin);
            wb.DrawLine("A4:M6", Border.InsideVertical, LineStyle.Continuous, LineWeight.Thin);
            wb.DrawLine("A4:A6", Border.Right, LineStyle.Double, LineWeight.Thin);
            wb.DrawLine("A5:M5", Border.Bottom, LineStyle.Double, LineWeight.Thin);

            //====================================================
            //Sales forecast worksheet
            //====================================================

	        wb.Worksheet = 2;
	        wb.WorksheetName = "2011 Projection";
	        wb.SetData("A1","2011 Projection");
            wb.SetFont("A1", "Arial", 24);
            wb.SetBold("A1");

            //Row headings
	        wb.SetData("A4","Sales");
	        wb.SetData("A5","Cost Of Sales");
	        wb.SetData("A6","Gross Profit");
	        wb.SetBold("A4:A6");
	        wb.SetHorizontalAlignment("A4:A6",HAlign.Right);
	        wb.SetColumnWidth(1,20);

            //Column headings
	        wb.SetData("B3","Jan 11");
	        wb.SetData("C3","Feb 11");
	        wb.SetData("D3","Mar 11");
	        wb.SetBold("B3:D3");
	        wb.SetHorizontalAlignment("B3:D3",HAlign.Right);
	        wb.SetColumnWidth("B:D",13);

	        //Forecast sales values
	        wb.SetData("B4",fsales[0]);
	        wb.SetData("C4",fsales[1]);
	        wb.SetData("D4",fsales[2]);

	        //Forecast cost of sales values
	        wb.SetData("B5",fcost[0]);
	        wb.SetData("C5",fcost[1]);
	        wb.SetData("D5",fcost[2]);

            //Forecast gross profit calculations
            wb.SetFormula("B6","B4-B5");
	        wb.SetFormula("C6","C4-C5");
	        wb.SetFormula("D6","D4-D5");
	        wb.SetBold("B6:D6");
	        wb.SetFormat("B4:D6","$#,##0.00_);[Red]($#,##0.00)");

   	        //====================================================
   	        //Create charts
   	        //====================================================

            wb.Worksheet = 1;
            wb.CreateChart(ChartType.Column3D, "A3:M6", "Col Chart", "Sales Analysis for 2010");
            wb.CreateChart(ChartType.BarClustered3D, "A3:M6", "Bar Chart", "Sales Analysis for 2010");
            wb.CreateChart(ChartType.Pie3D, "A3:M6", "Pie Chart", "Sales Analysis for 2010");

   	        //====================================================
   	        //Save the Book using Filename
   	        //====================================================

            wb.Worksheet = 1;
            wb.SaveAs("C:\\MySpreadsheet.xlsx");

            wb.Close();

            Cursor = Cursors.Default;

            MessageBox.Show("Created Excel spreadsheet C:\\MySpreadsheet.xlsx");
        }

        private void btnCreateWordDoc_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            OfficeAutomation.WordDocument doc = new OfficeAutomation.WordDocument();

            doc.SetMarginsInches(.5F, .5F, .5F, .5F);

            doc.AddHeading1("Test Document");
            doc.AddText("My first sentence. ");
            doc.Bold = true;
            doc.AddText("A second sentence, this one should be bold.");
            doc.Bold = false;
            doc.NewParagraph();
            doc.AddText("A third sentence in a new paragraph!");

            doc.AddHeading2("Here's a table...");

            int table=doc.AddTable(4,5);
	        doc.TableAutoFormat(table, WordDocument.WdTableFormat.wdTableFormatGrid8);
	        doc.SetTableCell(table,1,1,"Field Name");
	        doc.SetTableCell(table,1,2,"Prompt");
	        doc.SetTableCell(table,1,3,"Type");
	        doc.SetTableCell(table,1,4,"Size");
	        doc.SetTableCell(table,1,5,"Additional Information");
	        doc.SetTableCell(table,2,1,"QA_INITIALS");
	        doc.SetTableCell(table,2,2,"E-Mail Address");
	        doc.SetTableCell(table,2,3,"Decimal");
	        doc.SetTableCell(table,2,4,"10");
            doc.SetTableCell(table, 2, 5, "Hyper - explode_initials_hyper");

            doc.SaveAs("C:\\MyWordDocument.docx");
            doc.Close();

            Cursor = Cursors.Default;

            MessageBox.Show("Created Word document C:\\MyWordDocument.docx");
        }

        private void btnCreateMap_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            MapPointMap map = new MapPointMap();

            string fromName = "Synergex";
            string fromAddress = "2330 Gold Meadow Way, Gold River, CA, 95670";
            string fromNote = "(916) 635-7300";

            string toName = "Citizen Hotel";
            string toAddress = "926 J Street, Sacramento, CA 95814";
            string toNote = "(916) 447-2700";

            map.AddPushPin(fromAddress, fromName, fromNote, true, true);
            map.AddPushPin(toAddress, toName, toNote, false, true);

            map.SaveAs("C:\\SynergexToCitizenHotel.ptm",GeoSaveFormat.geoFormatMap);
            map.Close();

            Cursor = Cursors.Default;

            MessageBox.Show("Created MapPoint map C:\\SynergexToCitizenHotel.ptm");

        }
    }
}
