namespace WindowsLiveSearch
{
    partial class frmSearchSample
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.SearchPage = new System.Windows.Forms.TabPage();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnNearMe = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SettingsPage = new System.Windows.Forms.TabPage();
            this.label18 = new System.Windows.Forms.Label();
            this.cbxWebFileType = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.optFileTypeYP_Only = new System.Windows.Forms.RadioButton();
            this.optFileTypeWP_Only = new System.Windows.Forms.RadioButton();
            this.optFileTypeAny = new System.Windows.Forms.RadioButton();
            this.txtNewsSearchTagFilters = new System.Windows.Forms.TextBox();
            this.txtWebSearchTagFilters = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.optRelevanceSort = new System.Windows.Forms.RadioButton();
            this.optDistanceSort = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optSafeSearchModerate = new System.Windows.Forms.RadioButton();
            this.optSafeSearchStrict = new System.Windows.Forms.RadioButton();
            this.optSafeSearchOff = new System.Windows.Forms.RadioButton();
            this.chkDisableHostCollapsing = new System.Windows.Forms.CheckBox();
            this.chkDisableSpellCorrectForSpecialWords = new System.Windows.Forms.CheckBox();
            this.txtRadius = new System.Windows.Forms.TextBox();
            this.txtLatitude = new System.Windows.Forms.TextBox();
            this.txtLongitude = new System.Windows.Forms.TextBox();
            this.chkQueryWordMarking = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbxCultureInfo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOffset = new System.Windows.Forms.TextBox();
            this.txtNumResults = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.SearchPage.SuspendLayout();
            this.SettingsPage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.SearchPage);
            this.tabControl1.Controls.Add(this.SettingsPage);
            this.tabControl1.Location = new System.Drawing.Point(-1, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(680, 735);
            this.tabControl1.TabIndex = 0;
            // 
            // SearchPage
            // 
            this.SearchPage.Controls.Add(this.txtQuery);
            this.SearchPage.Controls.Add(this.btnNearMe);
            this.SearchPage.Controls.Add(this.btnSearch);
            this.SearchPage.Controls.Add(this.webBrowser1);
            this.SearchPage.Location = new System.Drawing.Point(4, 22);
            this.SearchPage.Name = "SearchPage";
            this.SearchPage.Padding = new System.Windows.Forms.Padding(3);
            this.SearchPage.Size = new System.Drawing.Size(672, 709);
            this.SearchPage.TabIndex = 0;
            this.SearchPage.Text = "Search";
            this.SearchPage.UseVisualStyleBackColor = true;
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(10, 24);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(480, 20);
            this.txtQuery.TabIndex = 3;
            // 
            // btnNearMe
            // 
            this.btnNearMe.Location = new System.Drawing.Point(589, 23);
            this.btnNearMe.Name = "btnNearMe";
            this.btnNearMe.Size = new System.Drawing.Size(75, 23);
            this.btnNearMe.TabIndex = 2;
            this.btnNearMe.Text = "Near Me";
            this.btnNearMe.UseVisualStyleBackColor = true;
            this.btnNearMe.Click += new System.EventHandler(this.btnNearMe_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(502, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(10, 65);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(655, 636);
            this.webBrowser1.TabIndex = 0;
            // 
            // SettingsPage
            // 
            this.SettingsPage.Controls.Add(this.label18);
            this.SettingsPage.Controls.Add(this.cbxWebFileType);
            this.SettingsPage.Controls.Add(this.groupBox3);
            this.SettingsPage.Controls.Add(this.txtNewsSearchTagFilters);
            this.SettingsPage.Controls.Add(this.txtWebSearchTagFilters);
            this.SettingsPage.Controls.Add(this.label12);
            this.SettingsPage.Controls.Add(this.label17);
            this.SettingsPage.Controls.Add(this.label13);
            this.SettingsPage.Controls.Add(this.groupBox2);
            this.SettingsPage.Controls.Add(this.groupBox1);
            this.SettingsPage.Controls.Add(this.chkDisableHostCollapsing);
            this.SettingsPage.Controls.Add(this.chkDisableSpellCorrectForSpecialWords);
            this.SettingsPage.Controls.Add(this.txtRadius);
            this.SettingsPage.Controls.Add(this.txtLatitude);
            this.SettingsPage.Controls.Add(this.txtLongitude);
            this.SettingsPage.Controls.Add(this.chkQueryWordMarking);
            this.SettingsPage.Controls.Add(this.label11);
            this.SettingsPage.Controls.Add(this.cbxCultureInfo);
            this.SettingsPage.Controls.Add(this.label10);
            this.SettingsPage.Controls.Add(this.label9);
            this.SettingsPage.Controls.Add(this.label16);
            this.SettingsPage.Controls.Add(this.label15);
            this.SettingsPage.Controls.Add(this.label14);
            this.SettingsPage.Controls.Add(this.label8);
            this.SettingsPage.Controls.Add(this.txtOffset);
            this.SettingsPage.Controls.Add(this.txtNumResults);
            this.SettingsPage.Controls.Add(this.label7);
            this.SettingsPage.Controls.Add(this.label6);
            this.SettingsPage.Controls.Add(this.label5);
            this.SettingsPage.Controls.Add(this.label4);
            this.SettingsPage.Controls.Add(this.label3);
            this.SettingsPage.Controls.Add(this.label2);
            this.SettingsPage.Controls.Add(this.label1);
            this.SettingsPage.Location = new System.Drawing.Point(4, 22);
            this.SettingsPage.Name = "SettingsPage";
            this.SettingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsPage.Size = new System.Drawing.Size(672, 709);
            this.SettingsPage.TabIndex = 1;
            this.SettingsPage.Text = "Settings";
            this.SettingsPage.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(39, 604);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(510, 16);
            this.label18.TabIndex = 35;
            this.label18.Text = "Return Listings of this Type (PhoneBook SourceType - US Markets Only):";
            // 
            // cbxWebFileType
            // 
            this.cbxWebFileType.FormattingEnabled = true;
            this.cbxWebFileType.Items.AddRange(new object[] {
            "No File Type Preference",
            "Microsoft Word Document Files (.DOC Extension)",
            "Autodesk .DWF Files (.DWF Extension)",
            "HTML Files (.HTM Extension)",
            "HTML Files (.HTML Extension)",
            "Adobe Acrobat Portable Document Format Files (.PDF Extension)",
            "Microsoft PowerPoint Files (.PPT Extension)",
            "Adobe PostScript Files (.PS Extension)",
            "Microsoft Rich Text Format Files (.RTF or .DOC Extension)",
            "Generic Text Files (.TEXT Extension)",
            "Generic Text Files (.TXT Extension)",
            "Microsoft Excel Workbook Files (.XLS Extension)"});
            this.cbxWebFileType.Location = new System.Drawing.Point(144, 565);
            this.cbxWebFileType.Name = "cbxWebFileType";
            this.cbxWebFileType.Size = new System.Drawing.Size(421, 21);
            this.cbxWebFileType.TabIndex = 34;
            this.cbxWebFileType.Text = "No File Type Preference";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.optFileTypeYP_Only);
            this.groupBox3.Controls.Add(this.optFileTypeWP_Only);
            this.groupBox3.Controls.Add(this.optFileTypeAny);
            this.groupBox3.Location = new System.Drawing.Point(251, 622);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(315, 71);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            // 
            // optFileTypeYP_Only
            // 
            this.optFileTypeYP_Only.AutoSize = true;
            this.optFileTypeYP_Only.Location = new System.Drawing.Point(30, 46);
            this.optFileTypeYP_Only.Name = "optFileTypeYP_Only";
            this.optFileTypeYP_Only.Size = new System.Drawing.Size(214, 17);
            this.optFileTypeYP_Only.TabIndex = 2;
            this.optFileTypeYP_Only.Text = "Yellow Pages (Commercial) Listings Only";
            this.optFileTypeYP_Only.UseVisualStyleBackColor = true;
            // 
            // optFileTypeWP_Only
            // 
            this.optFileTypeWP_Only.AutoSize = true;
            this.optFileTypeWP_Only.Location = new System.Drawing.Point(30, 29);
            this.optFileTypeWP_Only.Name = "optFileTypeWP_Only";
            this.optFileTypeWP_Only.Size = new System.Drawing.Size(209, 17);
            this.optFileTypeWP_Only.TabIndex = 1;
            this.optFileTypeWP_Only.Text = "White Pages (Residential) Listings Only";
            this.optFileTypeWP_Only.UseVisualStyleBackColor = true;
            // 
            // optFileTypeAny
            // 
            this.optFileTypeAny.AutoSize = true;
            this.optFileTypeAny.Checked = true;
            this.optFileTypeAny.Location = new System.Drawing.Point(30, 11);
            this.optFileTypeAny.Name = "optFileTypeAny";
            this.optFileTypeAny.Size = new System.Drawing.Size(133, 17);
            this.optFileTypeAny.TabIndex = 0;
            this.optFileTypeAny.TabStop = true;
            this.optFileTypeAny.Text = "All PhoneBook Listings";
            this.optFileTypeAny.UseVisualStyleBackColor = true;
            // 
            // txtNewsSearchTagFilters
            // 
            this.txtNewsSearchTagFilters.Location = new System.Drawing.Point(209, 511);
            this.txtNewsSearchTagFilters.Name = "txtNewsSearchTagFilters";
            this.txtNewsSearchTagFilters.Size = new System.Drawing.Size(357, 20);
            this.txtNewsSearchTagFilters.TabIndex = 32;
            // 
            // txtWebSearchTagFilters
            // 
            this.txtWebSearchTagFilters.Location = new System.Drawing.Point(209, 489);
            this.txtWebSearchTagFilters.Name = "txtWebSearchTagFilters";
            this.txtWebSearchTagFilters.Size = new System.Drawing.Size(357, 20);
            this.txtWebSearchTagFilters.TabIndex = 31;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(39, 444);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(351, 16);
            this.label12.TabIndex = 30;
            this.label12.Text = "Set SearchTagFilter(s) for Web and News Results";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(39, 540);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(315, 16);
            this.label17.TabIndex = 30;
            this.label17.Text = "Return Files of this Type (Web SourceType):";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(41, 372);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(202, 16);
            this.label13.TabIndex = 30;
            this.label13.Text = "Sort PhoneBook Results By:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.optRelevanceSort);
            this.groupBox2.Controls.Add(this.optDistanceSort);
            this.groupBox2.Location = new System.Drawing.Point(251, 379);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(314, 56);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            // 
            // optRelevanceSort
            // 
            this.optRelevanceSort.AutoSize = true;
            this.optRelevanceSort.Location = new System.Drawing.Point(30, 30);
            this.optRelevanceSort.Name = "optRelevanceSort";
            this.optRelevanceSort.Size = new System.Drawing.Size(77, 17);
            this.optRelevanceSort.TabIndex = 1;
            this.optRelevanceSort.Text = "Relevance";
            this.optRelevanceSort.UseVisualStyleBackColor = true;
            // 
            // optDistanceSort
            // 
            this.optDistanceSort.AutoSize = true;
            this.optDistanceSort.Checked = true;
            this.optDistanceSort.Location = new System.Drawing.Point(30, 13);
            this.optDistanceSort.Name = "optDistanceSort";
            this.optDistanceSort.Size = new System.Drawing.Size(110, 17);
            this.optDistanceSort.TabIndex = 0;
            this.optDistanceSort.TabStop = true;
            this.optDistanceSort.Text = "Distance (Default)";
            this.optDistanceSort.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optSafeSearchModerate);
            this.groupBox1.Controls.Add(this.optSafeSearchStrict);
            this.groupBox1.Controls.Add(this.optSafeSearchOff);
            this.groupBox1.Location = new System.Drawing.Point(251, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 71);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // optSafeSearchModerate
            // 
            this.optSafeSearchModerate.AutoSize = true;
            this.optSafeSearchModerate.Checked = true;
            this.optSafeSearchModerate.Location = new System.Drawing.Point(30, 31);
            this.optSafeSearchModerate.Name = "optSafeSearchModerate";
            this.optSafeSearchModerate.Size = new System.Drawing.Size(234, 17);
            this.optSafeSearchModerate.TabIndex = 8;
            this.optSafeSearchModerate.TabStop = true;
            this.optSafeSearchModerate.Text = "Moderate - Filter sexually explicit images only";
            this.optSafeSearchModerate.UseVisualStyleBackColor = true;
            // 
            // optSafeSearchStrict
            // 
            this.optSafeSearchStrict.AutoSize = true;
            this.optSafeSearchStrict.Location = new System.Drawing.Point(30, 13);
            this.optSafeSearchStrict.Name = "optSafeSearchStrict";
            this.optSafeSearchStrict.Size = new System.Drawing.Size(260, 17);
            this.optSafeSearchStrict.TabIndex = 7;
            this.optSafeSearchStrict.Text = "Strict - Filter sexually explicit text and image results";
            this.optSafeSearchStrict.UseVisualStyleBackColor = true;
            // 
            // optSafeSearchOff
            // 
            this.optSafeSearchOff.AutoSize = true;
            this.optSafeSearchOff.Location = new System.Drawing.Point(30, 49);
            this.optSafeSearchOff.Name = "optSafeSearchOff";
            this.optSafeSearchOff.Size = new System.Drawing.Size(170, 17);
            this.optSafeSearchOff.TabIndex = 9;
            this.optSafeSearchOff.Text = "Off - Do not filter search results";
            this.optSafeSearchOff.UseVisualStyleBackColor = true;
            // 
            // chkDisableHostCollapsing
            // 
            this.chkDisableHostCollapsing.AutoSize = true;
            this.chkDisableHostCollapsing.Location = new System.Drawing.Point(179, 347);
            this.chkDisableHostCollapsing.Name = "chkDisableHostCollapsing";
            this.chkDisableHostCollapsing.Size = new System.Drawing.Size(217, 17);
            this.chkDisableHostCollapsing.TabIndex = 22;
            this.chkDisableHostCollapsing.Text = "Check this box to disable host collapsing";
            this.chkDisableHostCollapsing.UseVisualStyleBackColor = true;
            // 
            // chkDisableSpellCorrectForSpecialWords
            // 
            this.chkDisableSpellCorrectForSpecialWords.AutoSize = true;
            this.chkDisableSpellCorrectForSpecialWords.Location = new System.Drawing.Point(179, 330);
            this.chkDisableSpellCorrectForSpecialWords.Name = "chkDisableSpellCorrectForSpecialWords";
            this.chkDisableSpellCorrectForSpecialWords.Size = new System.Drawing.Size(309, 17);
            this.chkDisableSpellCorrectForSpecialWords.TabIndex = 21;
            this.chkDisableSpellCorrectForSpecialWords.Text = "Check this box to disable spell correction for query operators";
            this.chkDisableSpellCorrectForSpecialWords.UseVisualStyleBackColor = true;
            // 
            // txtRadius
            // 
            this.txtRadius.Location = new System.Drawing.Point(466, 274);
            this.txtRadius.Name = "txtRadius";
            this.txtRadius.Size = new System.Drawing.Size(100, 20);
            this.txtRadius.TabIndex = 20;
            this.txtRadius.Text = "5.0";
            // 
            // txtLatitude
            // 
            this.txtLatitude.Location = new System.Drawing.Point(466, 252);
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.Size = new System.Drawing.Size(100, 20);
            this.txtLatitude.TabIndex = 19;
            this.txtLatitude.Text = "47.422433";
            // 
            // txtLongitude
            // 
            this.txtLongitude.Location = new System.Drawing.Point(466, 230);
            this.txtLongitude.Name = "txtLongitude";
            this.txtLongitude.Size = new System.Drawing.Size(100, 20);
            this.txtLongitude.TabIndex = 18;
            this.txtLongitude.Text = "-122.305833";
            // 
            // chkQueryWordMarking
            // 
            this.chkQueryWordMarking.AutoSize = true;
            this.chkQueryWordMarking.Checked = true;
            this.chkQueryWordMarking.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkQueryWordMarking.Location = new System.Drawing.Point(179, 313);
            this.chkQueryWordMarking.Name = "chkQueryWordMarking";
            this.chkQueryWordMarking.Size = new System.Drawing.Size(314, 17);
            this.chkQueryWordMarking.TabIndex = 17;
            this.chkQueryWordMarking.Text = "Check this box to enable query word marking (hit highlighting)";
            this.chkQueryWordMarking.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(109, 188);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(293, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Specify the Language and Country/Region for search results";
            // 
            // cbxCultureInfo
            // 
            this.cbxCultureInfo.FormattingEnabled = true;
            this.cbxCultureInfo.Items.AddRange(new object[] {
            "da-DK",
            "de-AT",
            "de-CH",
            "de-DE",
            "en-AU",
            "en-CA",
            "en-GB",
            "en-ID",
            "en-IE",
            "en-IN",
            "en-MY",
            "en-NZ",
            "en-PH",
            "en-SG",
            "en-US",
            "en-XA",
            "en-ZA",
            "es-AR",
            "es-ES",
            "es-MX",
            "es-US",
            "es-XL",
            "fi-FI",
            "fr-BE",
            "fr-CA",
            "fr-CH",
            "fr-FR",
            "it-IT",
            "ja-JP",
            "ko-KR",
            "nb-NO",
            "nl-BE",
            "nl-NL",
            "pt-BR",
            "sv-SE",
            "tr-TR",
            "zh-CN",
            "zh-HK",
            "zh-TW"});
            this.cbxCultureInfo.Location = new System.Drawing.Point(445, 184);
            this.cbxCultureInfo.Name = "cbxCultureInfo";
            this.cbxCultureInfo.Size = new System.Drawing.Size(121, 21);
            this.cbxCultureInfo.TabIndex = 15;
            this.cbxCultureInfo.Text = "en-US";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(109, 278);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(198, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Specify the Radius of the search in miles";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(109, 256);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(180, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Specify the Latitude of your Location";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(141, 515);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "News:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(141, 493);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 13);
            this.label15.TabIndex = 12;
            this.label15.Text = "Web:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(109, 466);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(433, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "Type your SearchTag Name(s) in the appropriate text box, below, separated by semi" +
                "colons";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(109, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(189, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Specify the Longitude of your Location";
            // 
            // txtOffset
            // 
            this.txtOffset.Location = new System.Drawing.Point(466, 52);
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.Size = new System.Drawing.Size(100, 20);
            this.txtOffset.TabIndex = 11;
            this.txtOffset.Text = "0";
            // 
            // txtNumResults
            // 
            this.txtNumResults.Location = new System.Drawing.Point(466, 29);
            this.txtNumResults.Name = "txtNumResults";
            this.txtNumResults.Size = new System.Drawing.Size(100, 20);
            this.txtNumResults.TabIndex = 10;
            this.txtNumResults.Text = "5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(109, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(286, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Specify the starting point for results (Offset Value - 0 to 999)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(109, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(272, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Specify the number of results per page to return (1 to 50)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(41, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "SearchFlags";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "CultureInfo Setting";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Location Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "SafeSearch Options";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Results Per Page and Offset";
            // 
            // frmSearchSample
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(680, 734);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmSearchSample";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Live Search API Version 1.1 Sample Application";
            this.tabControl1.ResumeLayout(false);
            this.SearchPage.ResumeLayout(false);
            this.SearchPage.PerformLayout();
            this.SettingsPage.ResumeLayout(false);
            this.SettingsPage.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage SearchPage;
        private System.Windows.Forms.TabPage SettingsPage;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btnNearMe;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton optSafeSearchStrict;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkQueryWordMarking;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbxCultureInfo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtOffset;
        private System.Windows.Forms.TextBox txtNumResults;
        private System.Windows.Forms.RadioButton optSafeSearchOff;
        private System.Windows.Forms.RadioButton optSafeSearchModerate;
        private System.Windows.Forms.TextBox txtRadius;
        private System.Windows.Forms.TextBox txtLatitude;
        private System.Windows.Forms.TextBox txtLongitude;
        private System.Windows.Forms.CheckBox chkDisableSpellCorrectForSpecialWords;
        private System.Windows.Forms.CheckBox chkDisableHostCollapsing;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton optRelevanceSort;
        private System.Windows.Forms.RadioButton optDistanceSort;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtNewsSearchTagFilters;
        private System.Windows.Forms.TextBox txtWebSearchTagFilters;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton optFileTypeYP_Only;
        private System.Windows.Forms.RadioButton optFileTypeWP_Only;
        private System.Windows.Forms.RadioButton optFileTypeAny;
        private System.Windows.Forms.ComboBox cbxWebFileType;
        private System.Windows.Forms.Label label18;
    }
}