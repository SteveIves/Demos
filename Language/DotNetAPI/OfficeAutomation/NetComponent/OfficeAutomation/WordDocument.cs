using System;
using System.Text;
using Word = Microsoft.Office.Interop.Word;

namespace OfficeAutomation
{
    public class WordDocument
    {
        private Word.Application wordApp;
        private Word.Document doc;
        private object oNotPassed = System.Reflection.Missing.Value;
        private object oTrue = true;
        private object oFalse = false;

        int startPos, endPos;

        #region Main document methods

        public WordDocument()
        {
            try
            {
                wordApp = new Word.ApplicationClass();
                doc = wordApp.Documents.Add(oNotPassed, oNotPassed, oNotPassed, oNotPassed);

                FontName = "Calibri";
                FontSize = 11F;
                Bold = false;
                Italic = false;
                Underline = WdUnderline.wdUnderlineNone;
            }
            catch
            {
                throw new ApplicationException("Failed to start Word or create document!");
            }
        }

        ~WordDocument()
        {
            if (wordApp != null)
                Close();
        }

        public void SaveAs(string file)
        {
            try
            {
                doc.SaveAs(file, oNotPassed, oNotPassed, oNotPassed, oNotPassed, oNotPassed, oNotPassed, oNotPassed, oNotPassed, oNotPassed, oNotPassed, oNotPassed, oNotPassed, oNotPassed, oNotPassed, oNotPassed);
            }
            catch
            {
                throw new ApplicationException("Failed to save document!");
            }
        }

        public void Save()
        {
            try
            {
                doc.Save();
            }
            catch
            {
                throw new ApplicationException("Failed to save document!");
            }
        }

        public void Close()
        {
            try
            {
                ((Microsoft.Office.Interop.Word._Document)doc).Close(oFalse, oNotPassed, oNotPassed);
                ((Microsoft.Office.Interop.Word._Application)wordApp).Quit();
            }
            catch
            {
            }
            finally
            {
                releaseObject(doc);
                releaseObject(wordApp);
            }
        }

        #endregion

        #region Sentences and paragraphs

        public void AddText(string text)
        {
            //Find current end of document position
            Word.Range r = doc.Range(oNotPassed, oNotPassed);
            startPos = r.Characters.Count - 1;

            //Insert the new text
            r.InsertAfter(text);

            //Find the new end of the text
            endPos = r.End;

            //Apply the specified renditions

            r = doc.Range(startPos, endPos);
            r.Font.Name = FontName;
            r.Font.Size = FontSize;
            r.Font.Bold = boolToInt(Bold);
            r.Font.Italic = boolToInt(Italic);
            r.Font.Underline = _Underline;
        }

        public void NewParagraph()
        {
            //Find current end of document position
            Word.Range r = doc.Range(oNotPassed, oNotPassed);
            //Add the new paragraph
            r.Paragraphs.Add(oNotPassed);
        }

        #endregion

        #region Current font

        public string FontName { get; set; }
        public float FontSize { get; set; }
        public bool Bold { get; set; }
        public bool Italic { get; set; }

        private Word.WdUnderline _Underline;
        public WdUnderline Underline
        {
            get { return (WdUnderline)_Underline; }
            set { _Underline = (Word.WdUnderline)value; }
        }
        
        #endregion

        #region Headings

        public void AddHeading1(string text)
        {
            //Find current end of document position
            Word.Range r = doc.Range(oNotPassed, oNotPassed);
            //Insert the new text
            r.InsertAfter(text);
            doc.Paragraphs[doc.Paragraphs.Count].set_Style(Word.WdBuiltinStyle.wdStyleHeading1);
            r.Paragraphs.Add(oNotPassed);
        }

        public void AddHeading2(string text)
        {
            //Find current end of document position
            Word.Range r = doc.Range(oNotPassed, oNotPassed);
            //Insert the new text
            r.Paragraphs.Add(oNotPassed);
            startPos = r.Characters.Count - 1;
            r.InsertAfter(text);
            endPos = r.End;
            r = doc.Range(startPos, endPos);
            r.set_Style(Word.WdBuiltinStyle.wdStyleHeading2);
            r.Paragraphs.Add(oNotPassed);
        }

        public void AddHeading3(string text)
        {
            //Find current end of document position
            Word.Range r = doc.Range(oNotPassed, oNotPassed);
            //Insert the new text
            r.InsertAfter(text);
            doc.Paragraphs[doc.Paragraphs.Count].set_Style(Word.WdBuiltinStyle.wdStyleHeading3);
            r.Paragraphs.Add(oNotPassed);
        }

        #endregion

        #region Tables

        public int AddTable(int rows, int cols)
        {
            Word.Range r = doc.Range(doc.Characters.Count-1, doc.Characters.Count-1);
            doc.Tables.Add(r, rows, cols, oNotPassed, oNotPassed);
            r.Paragraphs.Add(oNotPassed);
            return doc.Tables.Count;
        }

        public void TableAutoFormat(int table, WdTableFormat format)
        {
            doc.Tables[table].AutoFormat((Word.WdTableFormat)format, oNotPassed, oNotPassed, oNotPassed, oNotPassed, oNotPassed, oNotPassed, oNotPassed, oNotPassed, oTrue);
            doc.Tables[table].AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent);
        }

        public void SetTableCell(int table, int row, int col, string text)
        {
            doc.Tables[table].Cell(row, col).Range.Text = text;
        }

        public void SetTableCell(int table, int row, int col, float text)
        {
            doc.Tables[table].Cell(row, col).Range.Text = text.ToString();
        }

        public void ShadeTableCell(int table, int row, int col)
        {
            doc.Tables[table].Cell(row, col).Shading.Texture = Word.WdTextureIndex.wdTexture20Percent;
        }

        public void ReverseTableRow(int table, int row)
        {
            doc.Tables[table].Rows[row].Shading.Texture = Word.WdTextureIndex.wdTextureSolid;
        }

        public void ReverseTableColumn(int table, int col)
        {
            doc.Tables[table].Columns[col].Shading.Texture = Word.WdTextureIndex.wdTextureSolid;
        }

        #endregion

        #region Page layout

        public WdOrientation Orientation
        {
            get { return (WdOrientation)doc.PageSetup.Orientation; }
            set { doc.PageSetup.Orientation = (Word.WdOrientation)value; }
        }

        public void SetMarginsInches(float top, float botton, float left, float right)
        {
            doc.PageSetup.TopMargin = wordApp.InchesToPoints(top);
            doc.PageSetup.BottomMargin = wordApp.InchesToPoints(botton);
            doc.PageSetup.LeftMargin = wordApp.InchesToPoints(left);
            doc.PageSetup.RightMargin = wordApp.InchesToPoints(right);
        }

        public void SetMarginsCentimeters(float top, float botton, float left, float right)
        {
            doc.PageSetup.TopMargin = wordApp.CentimetersToPoints(top);
            doc.PageSetup.BottomMargin = wordApp.CentimetersToPoints(botton);
            doc.PageSetup.LeftMargin = wordApp.CentimetersToPoints(left);
            doc.PageSetup.RightMargin = wordApp.CentimetersToPoints(right);
        }

        #endregion

        #region Private utility methods

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

        private int boolToInt(bool b)
        {
            if (b)
                return 1;
            else
                return 0;
        }

        #endregion

        #region Enums

        public enum WdUnderline
        {
            wdUnderlineNone = 0,
            wdUnderlineSingle = 1,
            wdUnderlineWords = 2,
            wdUnderlineDouble = 3,
            wdUnderlineDotted = 4,
            wdUnderlineThick = 6,
            wdUnderlineDash = 7,
            wdUnderlineDotDash = 9,
            wdUnderlineDotDotDash = 10,
            wdUnderlineWavy = 11,
            wdUnderlineDottedHeavy = 20,
            wdUnderlineDashHeavy = 23,
            wdUnderlineDotDashHeavy = 25,
            wdUnderlineDotDotDashHeavy = 26,
            wdUnderlineWavyHeavy = 27,
            wdUnderlineDashLong = 39,
            wdUnderlineWavyDouble = 43,
            wdUnderlineDashLongHeavy = 55,
        }

        public enum WdOrientation
        {
            wdOrientPortrait = 0,
            wdOrientLandscape = 1,
        }

        public enum WdTableFormat
        {
            wdTableFormatNone = 0,
            wdTableFormatSimple1 = 1,
            wdTableFormatSimple2 = 2,
            wdTableFormatSimple3 = 3,
            wdTableFormatClassic1 = 4,
            wdTableFormatClassic2 = 5,
            wdTableFormatClassic3 = 6,
            wdTableFormatClassic4 = 7,
            wdTableFormatColorful1 = 8,
            wdTableFormatColorful2 = 9,
            wdTableFormatColorful3 = 10,
            wdTableFormatColumns1 = 11,
            wdTableFormatColumns2 = 12,
            wdTableFormatColumns3 = 13,
            wdTableFormatColumns4 = 14,
            wdTableFormatColumns5 = 15,
            wdTableFormatGrid1 = 16,
            wdTableFormatGrid2 = 17,
            wdTableFormatGrid3 = 18,
            wdTableFormatGrid4 = 19,
            wdTableFormatGrid5 = 20,
            wdTableFormatGrid6 = 21,
            wdTableFormatGrid7 = 22,
            wdTableFormatGrid8 = 23,
            wdTableFormatList1 = 24,
            wdTableFormatList2 = 25,
            wdTableFormatList3 = 26,
            wdTableFormatList4 = 27,
            wdTableFormatList5 = 28,
            wdTableFormatList6 = 29,
            wdTableFormatList7 = 30,
            wdTableFormatList8 = 31,
            wdTableFormat3DEffects1 = 32,
            wdTableFormat3DEffects2 = 33,
            wdTableFormat3DEffects3 = 34,
            wdTableFormatContemporary = 35,
            wdTableFormatElegant = 36,
            wdTableFormatProfessional = 37,
            wdTableFormatSubtle1 = 38,
            wdTableFormatSubtle2 = 39,
            wdTableFormatWeb1 = 40,
            wdTableFormatWeb2 = 41,
            wdTableFormatWeb3 = 42,
        }


        #endregion

    }
}
