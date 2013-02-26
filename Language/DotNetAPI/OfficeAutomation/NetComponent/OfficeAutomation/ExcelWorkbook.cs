using System;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace OfficeAutomation
{
    public class ExcelWorkbook
    {
        private Excel.Application excelApp;
        private Excel.Workbook wb;
        private int _WorksheetIndex = 1;

        private object oNotPassed = System.Reflection.Missing.Value;
        private object oTrue = true;
        private object oFalse = false;

        #region Constructor and destructor

        public ExcelWorkbook()
        {
            try
            {
                excelApp = new Excel.ApplicationClass();
                wb = excelApp.Workbooks.Add(oNotPassed);
            }
            catch
            {
                throw new ApplicationException("Failed to start Excel or create workbook!");
            }
        }

        ~ExcelWorkbook()
        {
            if (excelApp != null)
                Close();
        }

        #endregion

        #region Main workbook and worksheet methods

        public int CreateWorksheet(string name)
        {
            Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets.Add(oNotPassed, (Excel.Worksheet)wb.Worksheets[wb.Worksheets.Count], oNotPassed, oNotPassed);
            ws.Name = name;
            return ws.Index;
        }

        public void Close()
        {
            try
            {
                wb.Close(true, oNotPassed, oNotPassed);
                excelApp.Quit();
            }
            catch
            {
            }
            finally
            {
                releaseObject(wb);
                releaseObject(excelApp);
            }
        }

        public void Save()
        {
            try
            {
                wb.Save();
            }
            catch
            {
                throw new ApplicationException("Failed to save workbook!");
            }
        }

        public void SaveAs(string file)
        {
            try
            {
                wb.SaveAs(file, Excel.XlFileFormat.xlWorkbookDefault, 
                    oNotPassed, oNotPassed, oNotPassed, oNotPassed, 
                    Excel.XlSaveAsAccessMode.xlExclusive, oNotPassed, 
                    oFalse, oNotPassed, oNotPassed, oNotPassed);
            }
            catch
            {
                throw new ApplicationException("Failed to save workbook!");
            }
        }

        #endregion

        #region Workbook properties

        public string Author
        {
            get { return wb.Author; }
            set { wb.Author = value; }
        }

        public string Comments
        {
            get { return wb.Comments; }
            set { wb.Comments = value; }
        }

        public string Keywords
        {
            get { return wb.Keywords; }
            set { wb.Keywords = value; }
        }

        public string Subject
        {
            get { return wb.Subject; }
            set { wb.Subject = value; }
        }

        public string Title
        {
            get { return wb.Title; }
            set { wb.Title = value; }
        }

        #endregion

        #region Cell content and display format

        public void SetData(string range, string text)
        {
            multiCellRange(range).Cells.Value = text;
        }

        public void SetData(string range, double text)
        {
            multiCellRange(range).Cells.Value = text;
        }

        public void SetData(int row, int col, string text)
        {
            singleCell(row, col).Value = text;
        }

        public void SetData(int row, int col, double text)
        {
            singleCell(row, col).Value = text;
        }

        public void SetFormula(string range, string formula)
        {
            string f = formula.Trim();
            if (f.Substring(0,1)!="=")
                f = "=" + f;
            multiCellRange(range).Cells.Formula = f;
        }

        public void SetFormula(int row, int col, string formula)
        {
            singleCell(row, col).Cells.Formula = formula;
        }

        public void SetFormat(string range, string format)
        {
            multiCellRange(range).Cells.NumberFormat = format;
        }

        public void SetFormat(int row, int col, string format)
        {
            singleCell(row, col).Cells.NumberFormat = format;
        }

        #endregion

        #region Alignment

        public void SetHorizontalAlignment(string range, HAlign al)
        {
            multiCellRange(range).HorizontalAlignment = translateHorizontalAlignment(al);
        }

        public void SetHorizontalAlignment(int row, int col, HAlign al)
        {
            singleCell(row, col).HorizontalAlignment = translateHorizontalAlignment(al);
        }

        public void SetVerticalAlignment(string range, VAlign al)
        {
            multiCellRange(range).VerticalAlignment = translateVerticalAlignment(al);
        }

        public void SetVerticalAlignment(int row, int col, VAlign al)
        {
            singleCell(row, col).HorizontalAlignment = translateVerticalAlignment(al);
        }

        #endregion

        #region Renditions

        public void SetBold(string range)
        {
            multiCellRange(range).Cells.Font.Bold = true;
        }

        public void SetBold(int row, int col)
        {
            singleCell(row, col).Cells.Font.Bold = true;
        }

        public void SetItalic(string range)
        {
            multiCellRange(range).Cells.Font.Italic = true;
        }

        public void SetItalic(int row, int col)
        {
            singleCell(row, col).Cells.Font.Italic = true;
        }

        #endregion

        #region Fonts

        public void SetFont(string range, string fontName, int fontSize)
        {
            multiCellRange(range).Cells.Font.Name = (object)fontName;
            multiCellRange(range).Cells.Font.Size = fontSize;
        }

        public void SetFont(int r, int c, string fontName, int fontSize)
        {
            singleCell(r, c).Cells.Font.Name = fontName;
            singleCell(r, c).Cells.Font.Size = fontSize;
        }

        #endregion

        #region Height and Width

        public void SetColumnWidth(int col, int width)
        {
            singleColumn(col).ColumnWidth = width;
        }

        public void SetColumnWidth(string range, int width)
        {
            multiCellRange(range).ColumnWidth = width;
        }

        public void SetRowHeight(int row, int height)
        {
            singleRow(row).RowHeight = height;
        }

        public void SetRowHeight(string range, int height)
        {
            multiCellRange(range).RowHeight = height;
        }

        #endregion

        #region Draw boxes and lines

        public void DrawBox(string range, LineStyle ls, LineWeight lw)
        {
            Excel.Range r = multiCellRange(range);

            //Top edge
            r.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = translateLineStyle(ls);
            r.Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = translateLineWeight(lw);
            r.Borders[Excel.XlBordersIndex.xlEdgeTop].ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic;

            //Bottom edge
            r.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = translateLineStyle(ls);
            r.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = translateLineWeight(lw);
            r.Borders[Excel.XlBordersIndex.xlEdgeBottom].ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic;

            //Left edge
            r.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = translateLineStyle(ls);
            r.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = translateLineWeight(lw);
            r.Borders[Excel.XlBordersIndex.xlEdgeLeft].ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic;

            //Right edge
            r.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = translateLineStyle(ls);
            r.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = translateLineWeight(lw);
            r.Borders[Excel.XlBordersIndex.xlEdgeRight].ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic;
        }

        public void DrawLine(string range, Border bdr, LineStyle ls, LineWeight lw)
        {
            Excel.XlBordersIndex b = translateBorder(bdr);
            Excel.Range r = multiCellRange(range);
            r.Borders[b].LineStyle = translateLineStyle(ls);
            r.Borders[b].Weight = translateLineWeight(lw);
            r.Borders[b].ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic;
        }

        #endregion

        #region Charts

        public void CreateChart(ChartType ct, string dataRange, string sheetName, string chartTitle)
        {
            Excel.Range dr = multiCellRange(dataRange);
            Excel.Chart c = (Excel.Chart)wb.Charts.Add(oNotPassed, wb.Sheets[wb.Sheets.Count], oNotPassed, oNotPassed);
            c.Name = sheetName;
//            c.ChartWizard(dr, translateChartType(ct), oNotPassed, Excel.XlRowCol.xlColumns, 1, 1, oNotPassed, chartTitle, oNotPassed, oNotPassed, oNotPassed);
            c.ChartWizard(dr, translateChartType(ct), oNotPassed, Excel.XlRowCol.xlRows, 1, 1, oNotPassed, chartTitle, oNotPassed, oNotPassed, oNotPassed);
        }

        #endregion

        #region Worksheet properties

        public int WorksheetCount
        {
            get
            {
                return wb.Worksheets.Count;
            }
        }

        public int Worksheet
        {
            get
            {
                return _WorksheetIndex;
            }
            set
            {
                if (value <= wb.Worksheets.Count)
                {
                    _WorksheetIndex = value;
                    ((Microsoft.Office.Interop.Excel._Worksheet)wb.Worksheets[_WorksheetIndex]).Activate();
                }
                else
                    throw new ApplicationException("Invalid worksheet index!");
            }
        }

        public string WorksheetName
        {
            get
            {
                return ((Excel.Worksheet)wb.Worksheets[_WorksheetIndex]).Name;
            }
            set
            {
                ((Excel.Worksheet)wb.Worksheets[_WorksheetIndex]).Name = value;
            }
        }

        #endregion

        #region Private utility routines

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        private Excel.Worksheet currentWorksheet
        {
            get { return (Excel.Worksheet)wb.Worksheets[_WorksheetIndex]; }
        }

        private Excel.Range singleCell(int row, int col)
        {
            return (Excel.Range)currentWorksheet.Cells[row, col];
        }

        private Excel.Range singleColumn(int c)
        {
            return ((Excel.Range)currentWorksheet.Cells[1, c]).EntireColumn;
        }

        private Excel.Range singleRow(int r)
        {
            return ((Excel.Range)currentWorksheet.Cells[r, 1]).EntireRow;
        }

        private Excel.Range multiCellRange(string range)
        {
            return (Excel.Range)currentWorksheet.Range[range];
        }

        private Excel.XlVAlign translateVerticalAlignment(VAlign va)
        {
            switch(va)
            {
                case VAlign.Top:
                    return Excel.XlVAlign.xlVAlignTop;
                case VAlign.Middle:
                    return Excel.XlVAlign.xlVAlignCenter;
                case VAlign.Bottom:
                    return Excel.XlVAlign.xlVAlignBottom;
            }
            return Excel.XlVAlign.xlVAlignBottom;
        }

        private Excel.XlHAlign translateHorizontalAlignment(HAlign ha)
        {
            switch (ha)
            {
                case HAlign.Left:
                    return Excel.XlHAlign.xlHAlignLeft;
                case HAlign.Center:
                    return Excel.XlHAlign.xlHAlignCenter;
                case HAlign.Right:
                    return Excel.XlHAlign.xlHAlignRight;
            }
            return Excel.XlHAlign.xlHAlignLeft;
        }

        private Excel.XlBordersIndex translateBorder(Border bdr)
        {
            switch (bdr)
            {
                case Border.Top:
                    return Excel.XlBordersIndex.xlEdgeTop;
                case Border.Bottom:
                    return Excel.XlBordersIndex.xlEdgeBottom;
                case Border.Left:
                    return Excel.XlBordersIndex.xlEdgeLeft;
                case Border.Right:
                    return Excel.XlBordersIndex.xlEdgeRight;
                case Border.InsideHorizontal:
                    return Excel.XlBordersIndex.xlInsideHorizontal;
                case Border.InsideVertical:
                    return Excel.XlBordersIndex.xlInsideVertical;
            }
            return Excel.XlBordersIndex.xlEdgeTop;
        }

        private Excel.XlLineStyle translateLineStyle(LineStyle ls)
        {
            switch (ls)
            {
                case LineStyle.Continuous:
                    return Excel.XlLineStyle.xlContinuous;
                case LineStyle.Dash:
                    return Excel.XlLineStyle.xlDash;
                case LineStyle.DashDot:
                    return Excel.XlLineStyle.xlDashDot;
                case LineStyle.DashDotDot:
                    return Excel.XlLineStyle.xlDashDotDot;
                case LineStyle.Dot:
                    return Excel.XlLineStyle.xlDot;
                case LineStyle.Double:
                    return Excel.XlLineStyle.xlDouble;
                case LineStyle.None:
                    return Excel.XlLineStyle.xlLineStyleNone;
                case LineStyle.SlantDashDot:
                    return Excel.XlLineStyle.xlSlantDashDot;
            }
            return Excel.XlLineStyle.xlContinuous;
        }

        private Excel.XlBorderWeight translateLineWeight(LineWeight lw)
        {
            switch (lw)
            {
                case LineWeight.Hairline:
                    return Excel.XlBorderWeight.xlHairline;
                case LineWeight.Thin:
                    return Excel.XlBorderWeight.xlThin;
                case LineWeight.Medium:
                    return Excel.XlBorderWeight.xlMedium;
                case LineWeight.Thick:
                    return Excel.XlBorderWeight.xlThick;
            }
            return Excel.XlBorderWeight.xlThin;
        }

        private Excel.XlChartType translateChartType(ChartType ct)
        {
            switch (ct)
            {
                case ChartType.Column3D:
                    return Excel.XlChartType.xl3DColumn;
                case ChartType.BarClustered3D:
                    return Excel.XlChartType.xl3DBarClustered;
                case ChartType.Pie3D:
                    return Excel.XlChartType.xl3DPie;
            }
            return Excel.XlChartType.xl3DColumn;
        }

        #endregion

    }

    #region Enums exposed to client

    public enum HAlign
    {
        Left,
        Center,
        Right
    }

    public enum VAlign
    {
        Top,
        Middle,
        Bottom
    }

    public enum Border
    {
        Top,
        Bottom,
        Left,
        Right,
        InsideHorizontal,
        InsideVertical
    }

    public enum LineStyle
    {
        Continuous,
        Dash,
        DashDot,
        DashDotDot,
        Dot,
        Double,
        None,
        SlantDashDot
    }

    public enum LineWeight
    {
        Hairline,
        Thin,
        Medium,
        Thick
    }

    public enum ChartType
    {
        Column3D,
        BarClustered3D,
        Pie3D
    }

    #endregion

}
