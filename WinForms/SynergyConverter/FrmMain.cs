using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ICSharpCode.NRefactory.Visitors;
using System.CodeDom;
using System.CodeDom.Compiler;

namespace SynergyConverter
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            this.Text = FrmAboutBox.AssemblyTitle;

            cboFontSize.SelectedIndex = 2;
            txtCsCode.Focus();
        }

        private void txtCsCode_TextChanged(object sender, EventArgs e)
        {
            txtSynergyCode.Clear();
            configureUI(sender, e);
        }

        //Main menu

        private void mainMenuItem(object sender, EventArgs e)
        {
            ToolStripMenuItem tool = (ToolStripMenuItem)sender;

            switch (tool.Name)
            {
                case "mnuFileTranslate":
                    translateCsCode();
                    break;
                case "mnuFileSaveAs":
                    doSave(false);
                    break;
                case "mnuFileSaveAsTemplate":
                    doSave(true);
                    break;
                case "mnuFileExit":
                    this.Close();
                    break;
                case "mnuEditCut":
                    if (txtCsCode.Focused)
                        txtCsCode.Cut();
                    break;
                case "mnuEditCopy":
                    if (txtCsCode.Focused)
                        txtCsCode.Copy();
                    else
                        txtSynergyCode.Copy();
                    break;
                case "mnuEditPaste":
                    pasteCsCode();
                    break;
                case "mnuEditSelectAll":
                    if (txtCsCode.Focused)
                        txtCsCode.SelectAll();
                    else
                        txtSynergyCode.SelectAll();
                    break;
                case "mnuEditClear":
                    txtCsCode.Text = "";
                    break;
                case "mnuToolsOptions":
                    FrmOptions opt = new FrmOptions();
                    opt.ShowDialog(this);
                    break;
                case "mnuHelpAbout":
                    FrmAboutBox dlg = new FrmAboutBox();
                    dlg.ShowDialog(this);
                    break;
            }
        }

        //Toolbar buttons

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "btnCut":
                    if (txtCsCode.Focused)
                        txtCsCode.Cut();
                    break;
                case "btnCopy":
                    if (txtCsCode.Focused)
                        txtCsCode.Copy();
                    else
                        txtSynergyCode.Copy();
                    break;
                case "btnPaste":
                    pasteCsCode();
                    break;
                case "btnSelectAll":
                    if (txtCsCode.Focused)
                        txtCsCode.SelectAll();
                    else
                        txtSynergyCode.SelectAll();
                    break;
                case "btnTranslate":
                    translateCsCode();
                    break;
                case "btnSaveAs":
                    doSave(false);
                    break;
                case "btnSaveAsTemplate":
                    doSave(true);
                    break;
            }

        }

        //C# text box context menu

        private void mnuCs_Opening(object sender, CancelEventArgs e)
        {
            mnuCsCut.Enabled = ((txtCsCode.Text.Length > 0) && (txtCsCode.SelectionLength > 0));
            mnuCsCopy.Enabled = ((txtCsCode.Text.Length > 0) && (txtCsCode.SelectionLength>0));
            mnuCsSelectAll.Enabled = (txtCsCode.Text.Length > 0);
            mnuCsClear.Enabled = (txtCsCode.Text.Length > 0);
            mnuCsTranslate.Enabled = (txtCsCode.Text.Length > 0);
        }

        private void mnuCs_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "mnuCsCut":
                    txtCsCode.Cut();
                    break;
                case "mnuCsCopy":
                    txtCsCode.Copy();
                    break;
                case "mnuCsPaste":
                    pasteCsCode();
                    break;
                case "mnuCsSelectAll":
                    txtCsCode.SelectAll();
                    break;
                case "mnuCsClear":
                    txtCsCode.Clear();
                    break;
                case "mnuCsTranslate":
                    translateCsCode();
                    break;
            }

            configureUI(sender, e);
        }

        //Synergy text box context menu

        private void mnuSynergy_Opening(object sender, CancelEventArgs e)
        {
            mnuSynergyCopyAll.Enabled = (txtSynergyCode.Text.Length>0);
            mnuSynergyCopySelection.Enabled = ((txtSynergyCode.Text.Length > 0) && (txtSynergyCode.SelectionLength>0));
            mnuSynergyClear.Enabled = (txtSynergyCode.Text.Length > 0);
        }

        private void mnuSynergy_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "mnuSynergyCopyAll":
                    txtSynergyCode.SelectAll();
                    txtSynergyCode.Copy();
                    txtSynergyCode.DeselectAll();
                    break;
                case "mnuSynergyCopySelection":
                    txtSynergyCode.Copy();
                    break;
                case "mnuSynergyClear":
                    txtSynergyCode.Clear();
                    break;
            }
            configureUI(sender, e);
        }

        private void translateCsCode()
        {
            if (txtCsCode.Text.Length > 0)
            {
                var ast = ICSharpCode.NRefactory.ParserFactory.CreateParser(ICSharpCode.NRefactory.SupportedLanguage.CSharp, new StringReader(txtCsCode.Text));
                ast.Parse();
                var cdv = new CodeDomVisitor();
                ast.CompilationUnit.AcceptVisitor(cdv, null);


                if (cdv.codeCompileUnit != null)
                {
                    SynergyVSI.Generators.DBLCode.SynergyCodeGenerator scg = new SynergyVSI.Generators.DBLCode.SynergyCodeGenerator();
                    StringBuilder sb = new StringBuilder();
                    scg.GenerateCodeFromCompileUnit(cdv.codeCompileUnit, new System.IO.StringWriter(sb), new CodeGeneratorOptions());
                    txtSynergyCode.Text = sb.ToString();
                }

                if (Properties.Settings.Default.AutoCopyToClipboard)
                {
                    txtSynergyCode.SelectAll();
                    txtSynergyCode.Copy();
                    txtSynergyCode.DeselectAll();
                }

                txtSynergyCode.SelectionStart = 0;
                txtSynergyCode.ScrollToCaret();
                txtSynergyCode.Focus();


            }
            else
                MessageBox.Show("No C# code to translate", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pasteCsCode()
        {
            txtCsCode.Paste();
            txtCsCode.SelectionStart = 0;
            txtCsCode.ScrollToCaret();
        }

        private void txtCsCode_MouseUp(object sender, MouseEventArgs e)
        {
            configureUI(sender,e);
        }

        private void txtSynergyCode_MouseUp(object sender, MouseEventArgs e)
        {
            configureUI(sender, e);
        }

        private void configureUI(object sender, EventArgs e)
        {
            mnuFileTranslate.Enabled = (txtCsCode.Text.Length > 0);
            
            mnuFileSaveAs.Enabled = (txtSynergyCode.Text.Length > 0);
            btnSaveAs.Enabled = (txtSynergyCode.Text.Length > 0);

            mnuFileSaveAsTemplate.Enabled = (txtSynergyCode.Text.Length > 0);
            btnSaveAsTemplate.Enabled = (txtSynergyCode.Text.Length > 0);

            mnuEditCut.Enabled = ((txtCsCode.Focused) && (txtCsCode.SelectionLength > 0));
            mnuEditCopy.Enabled = ((txtCsCode.Focused && (txtCsCode.SelectionLength > 0) || (txtSynergyCode.Focused && (txtSynergyCode.SelectionLength > 0))));
            mnuEditPaste.Enabled = txtCsCode.Focused;
            mnuEditSelectAll.Enabled = ((txtCsCode.Focused && (txtCsCode.Text.Length > 0)) || (txtSynergyCode.Focused && (txtSynergyCode.Text.Length > 0)));

            mnuEditClear.Enabled = (txtCsCode.Text.Length>0);

            if (txtCsCode.Focused)
            {   
                btnCut.Enabled = (txtCsCode.SelectionLength > 0);
                btnCopy.Enabled = (txtCsCode.SelectionLength > 0);
                btnPaste.Enabled = true;
                btnSelectAll.Enabled = (txtCsCode.Text.Length > 0);
                btnTranslate.Enabled = (txtCsCode.Text.Length > 0);
            }
            else if (txtSynergyCode.Focused)
            {
                btnCut.Enabled = false;
                btnCopy.Enabled = (txtSynergyCode.SelectionLength > 0);
                btnPaste.Enabled = false;
                btnSelectAll.Enabled = (txtSynergyCode.SelectionLength > 0);
                btnTranslate.Enabled = (txtCsCode.Text.Length > 0);
            }
            else
            {
                btnCut.Enabled = false;
                btnCopy.Enabled = false;
                btnPaste.Enabled = false;
                btnSelectAll.Enabled = false;
                btnTranslate.Enabled = false;
            }
        }

        private void cboFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Font newFont = new Font("Courier New", 10);

            switch (cboFontSize.SelectedItem.ToString())
            {
                case "6 point":
                    newFont = new Font("Courier New", 6);
                    break;
                case "8 point":
                    newFont = new Font("Courier New", 8);
                    break;
                case "12 point":
                    newFont = new Font("Courier New", 12);
                    break;
                case "14 point":
                    newFont = new Font("Courier New", 14);
                    break;
            }
            txtCsCode.Font = newFont;
            txtSynergyCode.Font = newFont;
        }

        private void doSave(bool doTemplate)
        {
            if (doTemplate)
            {
                saveFileDialog1.DefaultExt = ".tpl";
                saveFileDialog1.FilterIndex = 3;
            }
            else
            {
                saveFileDialog1.DefaultExt = ".dbc";
                saveFileDialog1.FilterIndex = 1;
            }
            
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                StreamWriter sw = System.IO.File.CreateText(saveFileDialog1.FileName);
                sw.Write(txtSynergyCode.Text);
                sw.Close();
            }
        }

    }
}
