<CODEGEN_FILENAME>frm<Window_name>.dbl</CODEGEN_FILENAME>
;//*****************************************************************************
;//
;// Title:        syn_winform.tpl
;//
;// Description:  This template generates the a Synergy class which implements
;//               a .NET WinForm representing a UI Toolkit input window. The
;//               class requires System.Windows.Forms classes from GENNET.
;//
;// Author:       Steve Ives, Synergex Professional Services Group
;//
;// Copyright:    �Synergex International Inc.  All rights reserved.
;//
;// WARNING:      If you were given this code by a Synergex employee then you
;//               may use and modify it freely to generate code for your
;//               applications. However, you may not under any circumstances
;//               distribute this code, or any modified version of this code,
;//               to any third party without first obtaining written permission
;//               to do so from Synergex. In using this code you accept that it
;//               is provided as is, and without support or warranty. Neither
;//               Synergex or the author accept any responsibility for any
;//               losses or damages of any nature which may arise from the use
;//               of this code. This header information must remain unaltered
;//               in the code at all times. Possession of this code, or any
;//               modified version of this code, indicates your acceptance of
;//               these terms.
;//
;// $Revision: 7 $
;//
;// $Date: 5/07/08 1:45p $
;//
;******************************************************************************
;
; Title:        frm<Window_name>.dbl
<FILE:syn_header.inc>
.include "GENSRC:DotNetWrappers.inc"

.ifdef DBLNET
.define TRUE  1
.define FALSE 0
.endc

namespace <NAMESPACE>

    public class frm<Window_name> extends Form

        ;Set this to true for field level validation to occur
        private const fieldLevelValidation, boolean, false
        ;
        ;----------------------------------------------------------------------
        ;Constructor
        ;
        public method frm<Window_name>
            endparams
        proc
            InitializeComponent()
        endmethod
        ;
        ;----------------------------------------------------------------------
        ; Form design code
        ;
;//
;//=============================================================================
;//Declare object variables for controls
;//
        <FIELD_LOOP>
        <IF TEXTBOX>
        <IF PROMPT>
        private lbl<Field_sqlname>, @System.Windows.Forms.Label
        </IF>
        private txt<Field_sqlname>, @System.Windows.Forms.TextBox
        <IF DRILL>
        private btn<Field_sqlname>, @System.Windows.Forms.Button
        </IF>
        </IF>
        <IF CHECKBOX>
        private chk<Field_sqlname>, @System.Windows.Forms.CheckBox
        </IF>
        <IF COMBOBOX>
        <IF PROMPT>
        private lbl<Field_sqlname>, @System.Windows.Forms.Label
        </IF>
        private cbo<Field_sqlname>, @System.Windows.Forms.ComboBox
        </IF>
        <IF RADIOBUTTONS>
        ;RADIOBUTTONS ARE NOT SUPPORTED YET!
        </IF>
        </FIELD_LOOP>
        <BUTTON_LOOP>
        private btn<BUTTON_NAME>, @System.Windows.Forms.Button
        </BUTTON_LOOP>
        ;
        private method InitializeComponent, void
            endparams
        proc
;//
;//=============================================================================
;//Instantiate controls
;//
            <FIELD_LOOP>
            <IF TEXTBOX>
            <IF PROMPT>
            this.lbl<Field_sqlname> = new System.Windows.Forms.Label()
            </IF>
            this.txt<Field_sqlname> = new System.Windows.Forms.TextBox()
            <IF DRILL>
            this.btn<Field_sqlname> = new System.Windows.Forms.Button()
            </IF>
            </IF>
            <IF CHECKBOX>
            this.chk<Field_sqlname> = new System.Windows.Forms.CheckBox()
            </IF>
            <IF COMBOBOX>
            <IF PROMPT>
            this.lbl<Field_sqlname> = new System.Windows.Forms.Label()
            </IF>
            this.cbo<Field_sqlname> = new System.Windows.Forms.ComboBox()
            </IF>
            <IF RADIOBUTTONS>
            ;RADIOBUTTONS ARE NOT SUPPORTED YET!
            </IF>
            </FIELD_LOOP>
            <BUTTON_LOOP>
            this.btn<BUTTON_NAME> = new System.Windows.Forms.Button()
            </BUTTON_LOOP>
            this.SuspendLayout()
;//
;//=============================================================================
;//Configure controls controls
;//
            <FIELD_LOOP>
;//
;//=============================================================================
;//TextBox code
;//
            <IF TEXTBOX>
            <IF PROMPT>
            ;
            ;lbl<Field_sqlname>
            ;
            this.lbl<Field_sqlname>.AutoSize = true
            this.lbl<Field_sqlname>.Location = new System.Drawing.Point(<PROMPT_PIXEL_COL>,<PROMPT_PIXEL_ROW>)
            this.lbl<Field_sqlname>.Name = "lbl<Field_sqlname>"
            this.lbl<Field_sqlname>.TabIndex = 0
            this.lbl<Field_sqlname>.Text = "<FIELD_PROMPT>"
            </IF>
            ;
            ;txt<Field_sqlname>
            ;
            this.txt<Field_sqlname>.Name = "txt<Field_sqlname>"
            this.txt<Field_sqlname>.Location = new System.Drawing.Point(<FIELD_PIXEL_COL>,<FIELD_PIXEL_ROW>)
            this.txt<Field_sqlname>.Size = new System.Drawing.Size(<FIELD_PIXEL_WIDTH>,20)
            this.txt<Field_sqlname>.TabIndex = <FIELD#LOGICAL>
            this.txt<Field_sqlname>.MaxLength = <FIELD_SIZE>
            <IF DISABLED>
            this.txt<Field_sqlname>.Enabled = false
            </IF>
            <IF READONLY>
            this.txt<Field_sqlname>.ReadOnly = true
            </IF>
            <IF UPPERCASE>
            this.txt<Field_sqlname>.CharacterCasing = CharacterCasing.Upper
            </IF>
            <IF REVERSE>
            this.txt<Field_sqlname>.BackColor = Color.Black
            this.txt<Field_sqlname>.ForeColor = Color.White
            </IF>
            <IF DEFAULT>
            this.txt<Field_sqlname>.Text = "<FIELD_DEFAULT>"
            </IF>
            <IF NOECHO>
            this.txt<Field_sqlname>.PasswordChar = "*"
            </IF>
            addhandler(this.txt<Field_sqlname>.Leave,this.txt<Field_sqlname>_Leave)
            <IF DRILL>
            ;
            ;Btn<Field_sqlname>
            ;
            this.btn<Field_sqlname>.Name = "btn<Field_sqlname>"
            this.btn<Field_sqlname>.Location =  new System.Drawing.Point(<DRILL_PIXEL_COL>,<FIELD_PIXEL_ROW>)
            this.btn<Field_sqlname>.Size = new System.Drawing.Size(24,20)
            this.btn<Field_sqlname>.Text = "..."
            addhandler(this.btn<Field_sqlname>.Click,this.btn<Field_sqlname>_Click)
            </IF>
            </IF>
;//
;//=============================================================================
;//CheckBox code
;//
            <IF CHECKBOX>
            ;
            ;chk<Field_sqlname>
            ;
            this.chk<Field_sqlname>.Name = "chk<Field_sqlname>"
            this.chk<Field_sqlname>.Location = New System.Drawing.Point(<FIELD_PIXEL_COL>,<FIELD_PIXEL_ROW>)
            this.chk<Field_sqlname>.Size = New System.Drawing.Size(<FIELD_PIXEL_WIDTH>, 17)
            this.chk<Field_sqlname>.AutoSize = True
            this.chk<Field_sqlname>.TabIndex = <FIELD#LOGICAL>
            this.chk<Field_sqlname>.UseVisualStyleBackColor = True
            this.chk<Field_sqlname>.Text = "<FIELD_PROMPT>"
            <IF DISABLED>
            this.chk<Field_sqlname>.Enabled = False
            </IF>
            <IF DEFAULT>
            ;//this.chk<Field_sqlname>.Checked = True
            ;//this.chk<Field_sqlname>.CheckState = System.Windows.Forms.CheckState.Checked
            </IF>
            </IF>
;//
;//=============================================================================
;//ComboBox code
;//
            <IF COMBOBOX>
            <IF PROMPT>
            ;
            ;lbl<Field_sqlname>
            ;
            this.lbl<Field_sqlname>.Name = "lbl<Field_sqlname>"
            this.lbl<Field_sqlname>.Location = new System.Drawing.Point(<PROMPT_PIXEL_COL>,<PROMPT_PIXEL_ROW>)
            this.lbl<Field_sqlname>.AutoSize = true
            this.lbl<Field_sqlname>.TabIndex = 0
            this.lbl<Field_sqlname>.Text = "<FIELD_PROMPT>"
            </IF>
            ;
            ;cbo<Field_sqlname>
            ;
            this.cbo<Field_sqlname>.Name = "cbo<Field_sqlname>"
            this.cbo<Field_sqlname>.Location = New System.Drawing.Point(<FIELD_PIXEL_COL>,<FIELD_PIXEL_ROW>)
            this.cbo<Field_sqlname>.Size = New System.Drawing.Size(<FIELD_PIXEL_WIDTH>, 21)
            this.cbo<Field_sqlname>.TabIndex = <FIELD#LOGICAL>
            this.cbo<Field_sqlname>.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            this.cbo<Field_sqlname>.FormattingEnabled = True
            <IF DISABLED>
            this.cbo<Field_sqlname>.Enabled = False
            </IF>
;//This really needs to be here, but at this point it is not supported by the Synergy form .NET compiler
            .ifndef DBLNET
            this.cbo<Field_sqlname>.Items.AddRange(cbo<Field_sqlname>_Items(<FIELD_SELECTIONS>))
            .endc
            </IF>
;//
;//=============================================================================
;//RadioButtons code
;//
            <IF RADIOBUTTONS>
            ;
            ;rb<Field_sqlname>
            ;
            ;RADIOBUTTONS ARE NOT SUPPORTED YET!
            </IF>
;//
;//
;//=============================================================================
;//
            </FIELD_LOOP>
            <BUTTON_LOOP>
            ;
            ; btn<BUTTON_NAME>
            ;
            this.btn<BUTTON_NAME>.Name = "btn<BUTTON_NAME>"
            this.btn<BUTTON_NAME>.Location = new System.Drawing.Point(<BUTTON_COLPX>,<BUTTON_ROWPX>)
            this.btn<BUTTON_NAME>.Size = new System.Drawing.Size(<BUTTON_WIDTHPX>,23)
            this.btn<BUTTON_NAME>.Text = "<BUTTON_CAPTION>"
            this.btn<BUTTON_NAME>.TabIndex = (100+<BUTTON_NUMBER>)
            this.btn<BUTTON_NAME>.UseVisualStyleBackColor = true
            addhandler(this.btn<BUTTON_NAME>.Click,this.btn<BUTTON_NAME>_Click)
            </BUTTON_LOOP>
            ;
            ; frm<Window_name>
            ;
            this.Name = "frm<Window_name>"
            this.Text = "<STRUCTURE_DESC> Maintenance"
            this.ClientSize = new System.Drawing.Size(<WINDOW_WIDTHPX>, <WINDOW_HEIGHTPX>)
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            this.ShowInTaskbar = false
            this.MaximizeBox = false
            this.MinimizeBox = false
            <BUTTON_LOOP>
            <IF OKBUTTON>
            this.AcceptButton = (System.Windows.Forms.IButtonControl)this.btn<BUTTON_NAME>
            </IF>
            <IF CANCELBUTTON>
            this.CancelButton = (System.Windows.Forms.IButtonControl)this.btn<BUTTON_NAME>
            </IF>
            </BUTTON_LOOP>

;//
;//=============================================================================
;//Add controls to the form
;//
            <FIELD_LOOP>
            <IF TEXTBOX>
            <IF PROMPT>
            this.Controls.Add((System.Windows.Forms.Control)this.lbl<Field_sqlname>)
            </IF>
            this.Controls.Add((System.Windows.Forms.Control)this.txt<Field_sqlname>)
            <IF DRILL>
            this.Controls.Add((System.Windows.Forms.Control)this.btn<Field_sqlname>)
            </IF>
            </IF>
            <IF CHECKBOX>
            this.Controls.Add((System.Windows.Forms.Control)this.chk<Field_sqlname>)
            </IF>
            <IF COMBOBOX>
            <IF PROMPT>
            this.Controls.Add((System.Windows.Forms.Control)this.lbl<Field_sqlname>)
            </IF>
            this.Controls.Add((System.Windows.Forms.Control)this.cbo<Field_sqlname>)
            </IF>
            <IF RADIOBUTTONS>
            ;RADIOBUTTONS ARE NOT SUPPORTED YET!
            </IF>
            </FIELD_LOOP>
            <BUTTON_LOOP>
            this.Controls.Add((System.Windows.Forms.Control)this.btn<BUTTON_NAME>)
            </BUTTON_LOOP>
            ;
            addhandler(this.Load,this.frm<Window_name>_Load)
            ;
            this.ResumeLayout()
            (void)this.PerformLayout()
            ;
        endmethod
        ;
        ;----------------------------------------------------------------------
        ; Private methods
        ;
        private method validateFields, boolean
            endparams
        proc
            <FIELD_LOOP>
            <IF TEXTBOX>
            if (!validate_txt<Field_sqlname>())
                mreturn false
            </IF>
            </FIELD_LOOP>
            mreturn true
        endmethod
        <FIELD_LOOP>
        <IF COMBOBOX>
;//
;//This really needs to be here, but at this point it is not supported by the Synergy form .NET compiler
        .ifndef DBLNET
        ;
        private varargs method cbo<Field_sqlname>_Items, [#]@System.Object
            endparams
            record
                RetData, [#]@System.Object
                idx, int
            endrecord
        proc
            RetData = new System.Object[%numargs]
            for idx from 1 thru %numargs
                RetData[idx] = new string(^arga(idx))
            mreturn RetData
        endmethod
        </IF>
        </FIELD_LOOP>
        .endc
        ;
        <FIELD_LOOP>
        <IF TEXTBOX>
        ;------------------------------
        ;Field validation for <FIELD_PROMPT> (txt<Field_sqlname>)
        ;
        private method validate_txt<Field_sqlname>, boolean
            endparams
        proc
            <IF REQUIRED>
            ;Required field
            if (txt<Field_sqlname>.Text.Length == 0)
            begin
                MessageBox.Show("<FIELD_PROMPT> is a required field.")
                txt<Field_sqlname>.Focus()
                mreturn false
            end
            </IF>
            <IF NUMERIC>
            ;Value must be numeric
            if (txt<Field_sqlname>.Text.Length != 0)
            begin
                try
                begin
                    System.Convert.ToDouble(txt<Field_sqlname>.Text)
                end
                catch (ex,@Exception)
                begin
                    MessageBox.Show("<FIELD_PROMPT> must be numeric.")
                    txt<Field_sqlname>.Clear()
                    txt<Field_sqlname>.Focus()
                    mreturn false
                end
                endtry
            end
            </IF>
            mreturn true
        endmethod
        </IF>
        ;
        </FIELD_LOOP>
        ;----------------------------------------------------------------------
        ; Event handlers
        ;
        ;------------------------------
        ;Form load method
        ;
        private method frm<Window_name>_Load, void
            .ifdef DBLNET
            required in byval sender, @System.Object
            required in byval e,      @System.EventArgs
            .else
            required in sender, @DotNetObject
            required in e,      @DotNetObject
            .endc
            endparams
        proc
            ;TODO: Add form initialization code
        endmethod
        <BUTTON_LOOP>
        ;
        ;------------------------------
        ;The btn<BUTTON_NAME> button was clicked
        ;
        private method btn<BUTTON_NAME>_Click, void
            .ifdef DBLNET
            required in byval sender, @System.Object
            required in byval e,      @System.EventArgs
            .else
            required in sender, @DotNetObject
            required in e,      @DotNetObject
            .endc
            endparams
        proc

            <IF OKBUTTON>
            if (validateFields())
            begin
               ;TODO: Add code to save the data.
               ;Close the form
               this.Close()
            end
            </IF>
            <IF CANCELBUTTON>
            this.Close()
            </IF>
            <IF GENERICBUTTON>
            MessageBox.Show("You clicked the <BUTTON_CAPTION> button")
            </IF>

        endmethod
        </BUTTON_LOOP>
        <FIELD_LOOP>
        <IF TEXTBOX>
        ;
        ;------------------------------
        ;Focus is leaving the <FIELD_PROMPT> field
        ;
        private method txt<Field_sqlname>_Leave, void
            .ifdef DBLNET
            required in byval sender, @System.Object
            required in byval e,      @System.EventArgs
            .else
            required in sender, @DotNetObject
            required in e,      @DotNetObject
            .endc
            endparams
        proc
            ;TODO: IF YOU ARE USING FIELD LEAVE METHOD VALIDATION THEN
            ;UNCOMMENT THIS CODE AND CHANGE btnCancel TO THE NAME OF THE
            ;FORMS CANCEL BUTTON
            ;if (fieldLevelValidation && (!btnCancel.Focused))
            ;    validate_txt<Field_sqlname>()
        endmethod
        </IF>
        </FIELD_LOOP>
        <FIELD_LOOP>
        <IF TEXTBOX>
        <IF DRILL>
        ;
        ;------------------------------
        ;User clicked thr drill button for the <FIELD_PROMPT> field
        ;
        private method btn<Field_sqlname>_Click, void
            .ifdef DBLNET
            required in byval sender, @System.Object
            required in byval e,      @System.EventArgs
            .else
            required in sender, @DotNetObject
            required in e,      @DotNetObject
            .endc
            endparams
        proc
            MessageBox.Show("You clicked on button btn<Field_sqlname>")
        endmethod
        </IF>
        </IF>
        </FIELD_LOOP>

    endclass

endnamespace

