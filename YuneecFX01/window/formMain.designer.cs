using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace YuneecFX01.Window
{
    partial class formMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.menuIconList = new System.Windows.Forms.ImageList(this.components);
            this.btnUserName = new Sunny.UI.UISymbolButton();
            this.btnExit = new Sunny.UI.UISymbolButton();
            this.gMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.labVol = new System.Windows.Forms.Label();
            this.labACVoltage = new System.Windows.Forms.Label();
            this.labHeight = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.uiProgressIndicator1 = new Sunny.UI.UIProgressIndicator();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.labCurrentLat = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labCurrentLng = new System.Windows.Forms.Label();
            this.uiPanel7 = new Sunny.UI.UIPanel();
            this.txtSystemStatus = new Sunny.UI.UIPanel();
            this.btnGpsStar = new Sunny.UI.UIButton();
            this.gMapControlPanel = new System.Windows.Forms.Panel();
            this.btnMapZoomDn = new Sunny.UI.UISymbolButton();
            this.btnMapZoomUp = new Sunny.UI.UISymbolButton();
            this.btnPositioningAircraft = new Sunny.UI.UISymbolButton();
            this.btnRotate = new Sunny.UI.UIButton();
            this.headingIndicatorInstrumentControl1 = new AviationInstrumentControls.HeadingIndicatorInstrumentControl();
            this.attitudeIndicatorInstrumentControl1 = new AviationInstrumentControls.AttitudeIndicatorInstrumentControl();
            this.labGroundName = new Sunny.UI.UIPanel();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPageTestGround = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.uiLabel61 = new Sunny.UI.UILabel();
            this.btnDeleteGround = new Sunny.UI.UIButton();
            this.btnEditGround = new Sunny.UI.UIButton();
            this.btnAddGround = new Sunny.UI.UIButton();
            this.listGround = new Sunny.UI.UIListBox();
            this.btnCompanyName = new Sunny.UI.UIButton();
            this.uiLabel60 = new Sunny.UI.UILabel();
            this.txtCompanyName = new Sunny.UI.UITextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCenterAngle = new Sunny.UI.UITextBox();
            this.txtCenterLat = new Sunny.UI.UITextBox();
            this.btnGroundCancel = new Sunny.UI.UIButton();
            this.btnGroundSave = new Sunny.UI.UIButton();
            this.txtGroundName = new Sunny.UI.UITextBox();
            this.uiLabel64 = new Sunny.UI.UILabel();
            this.btnOneEightDraw = new Sunny.UI.UIButton();
            this.uiLabel62 = new Sunny.UI.UILabel();
            this.uiLabel63 = new Sunny.UI.UILabel();
            this.txtCenterLng = new Sunny.UI.UITextBox();
            this.btnCenterEnter = new Sunny.UI.UIButton();
            this.uiLabel45 = new Sunny.UI.UILabel();
            this.btnEightClear = new Sunny.UI.UIButton();
            this.uiLabel44 = new Sunny.UI.UILabel();
            this.btnEightEnter = new Sunny.UI.UIButton();
            this.uiLabel47 = new Sunny.UI.UILabel();
            this.txtLeftLat = new Sunny.UI.UITextBox();
            this.txtRightLat = new Sunny.UI.UITextBox();
            this.uiLabel46 = new Sunny.UI.UILabel();
            this.txtLeftLng = new Sunny.UI.UITextBox();
            this.uiLabel56 = new Sunny.UI.UILabel();
            this.uiLabel49 = new Sunny.UI.UILabel();
            this.txtRightLng = new Sunny.UI.UITextBox();
            this.uiLabel48 = new Sunny.UI.UILabel();
            this.uiLabel57 = new Sunny.UI.UILabel();
            this.txtCenterRad = new Sunny.UI.UITextBox();
            this.uiLabel58 = new Sunny.UI.UILabel();
            this.uiLabel55 = new Sunny.UI.UILabel();
            this.uiLabel59 = new Sunny.UI.UILabel();
            this.uiLabel54 = new Sunny.UI.UILabel();
            this.txtRightRad = new Sunny.UI.UITextBox();
            this.uiLabel53 = new Sunny.UI.UILabel();
            this.uiLabel50 = new Sunny.UI.UILabel();
            this.uiLabel52 = new Sunny.UI.UILabel();
            this.uiLabel51 = new Sunny.UI.UILabel();
            this.tabPageTestOne = new System.Windows.Forms.TabPage();
            this.uiTestItemEight = new Sunny.UI.UIRadioButton();
            this.uiTestItemRotate = new Sunny.UI.UIRadioButton();
            this.uiTitlePanel1 = new Sunny.UI.UITitlePanel();
            this.listTextResult = new System.Windows.Forms.ListBox();
            this.txtSpeed = new Sunny.UI.UITextBox();
            this.uiTextBox3 = new Sunny.UI.UITextBox();
            this.labTimeLength = new Sunny.UI.UITextBox();
            this.labFlyHeight = new Sunny.UI.UITextBox();
            this.labSpeed = new Sunny.UI.UITextBox();
            this.txtAngleSpeed = new Sunny.UI.UITextBox();
            this.labPhiOffset = new Sunny.UI.UITextBox();
            this.uiLabel80 = new Sunny.UI.UILabel();
            this.labAngleSpeed = new Sunny.UI.UITextBox();
            this.txtFlyHeight = new Sunny.UI.UITextBox();
            this.labHOffset = new Sunny.UI.UITextBox();
            this.uiLabel79 = new Sunny.UI.UILabel();
            this.labVOffset = new Sunny.UI.UITextBox();
            this.uiLabel75 = new Sunny.UI.UILabel();
            this.txtDistance = new Sunny.UI.UITextBox();
            this.uiLabel74 = new Sunny.UI.UILabel();
            this.uiLabel68 = new Sunny.UI.UILabel();
            this.uiLabel69 = new Sunny.UI.UILabel();
            this.uiLabel87 = new Sunny.UI.UILabel();
            this.listTestProject2 = new Sunny.UI.UIComboBox();
            this.uiLabel86 = new Sunny.UI.UILabel();
            this.listTestType2 = new Sunny.UI.UIComboBox();
            this.uiLabel85 = new Sunny.UI.UILabel();
            this.txtTimeLength = new Sunny.UI.UILabel();
            this.uiLabel84 = new Sunny.UI.UILabel();
            this.uiLabel83 = new Sunny.UI.UILabel();
            this.uiLabel81 = new Sunny.UI.UILabel();
            this.uiLabel70 = new Sunny.UI.UILabel();
            this.txtPhiOffset = new Sunny.UI.UITextBox();
            this.uiLabel71 = new Sunny.UI.UILabel();
            this.uiLabel72 = new Sunny.UI.UILabel();
            this.uiLabel73 = new Sunny.UI.UILabel();
            this.txtVOffset = new Sunny.UI.UITextBox();
            this.txtHOffset = new Sunny.UI.UITextBox();
            this.uiLabel76 = new Sunny.UI.UILabel();
            this.uiLabel77 = new Sunny.UI.UILabel();
            this.uiLabel78 = new Sunny.UI.UILabel();
            this.btnTestStop = new Sunny.UI.UIButton();
            this.btnTestStart = new Sunny.UI.UIButton();
            this.uiLine7 = new Sunny.UI.UILine();
            this.uiLine6 = new Sunny.UI.UILine();
            this.tabPageTestParam = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.uiLine4 = new Sunny.UI.UILine();
            this.uiLine3 = new Sunny.UI.UILine();
            this.txtTestStartSpeed = new Sunny.UI.UITextBox();
            this.uiLabel65 = new Sunny.UI.UILabel();
            this.uiLabel66 = new Sunny.UI.UILabel();
            this.comRotateStartMode = new Sunny.UI.UIComboBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.txtRotateVOffset = new Sunny.UI.UITextBox();
            this.txtRotateHOffset = new Sunny.UI.UITextBox();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.uiLabel13 = new Sunny.UI.UILabel();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.uiLabel12 = new Sunny.UI.UILabel();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uiLabel11 = new Sunny.UI.UILabel();
            this.txtRotateMinHeight = new Sunny.UI.UITextBox();
            this.uiLabel17 = new Sunny.UI.UILabel();
            this.uiLabel10 = new Sunny.UI.UILabel();
            this.uiLabel16 = new Sunny.UI.UILabel();
            this.txtRotateMaxHeight = new Sunny.UI.UITextBox();
            this.txtRotateMinAngleSpeed = new Sunny.UI.UITextBox();
            this.txtRotateMaxTime = new Sunny.UI.UITextBox();
            this.uiLabel15 = new Sunny.UI.UILabel();
            this.uiLabel14 = new Sunny.UI.UILabel();
            this.txtRotateMaxAngleSpeed = new Sunny.UI.UITextBox();
            this.txtRotateMinTime = new Sunny.UI.UITextBox();
            this.uiLabel18 = new Sunny.UI.UILabel();
            this.txtTestTimeout = new Sunny.UI.UITextBox();
            this.uiLabel21 = new Sunny.UI.UILabel();
            this.uiLabel20 = new Sunny.UI.UILabel();
            this.txtTestStartAngle = new Sunny.UI.UITextBox();
            this.uiLabel23 = new Sunny.UI.UILabel();
            this.uiLabel22 = new Sunny.UI.UILabel();
            this.txtTestRadOffset = new Sunny.UI.UITextBox();
            this.uiLabel19 = new Sunny.UI.UILabel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnCancel = new Sunny.UI.UIButton();
            this.txtEightMaxAngleSpeed = new Sunny.UI.UITextBox();
            this.uiLabel40 = new Sunny.UI.UILabel();
            this.uiLabel41 = new Sunny.UI.UILabel();
            this.btnTestDataEdit = new Sunny.UI.UIButton();
            this.txtEightVOffset = new Sunny.UI.UITextBox();
            this.btnTestDataSave = new Sunny.UI.UIButton();
            this.txtEightMaxSpeed = new Sunny.UI.UITextBox();
            this.uiLabel39 = new Sunny.UI.UILabel();
            this.uiLabel38 = new Sunny.UI.UILabel();
            this.txtEightTimeout = new Sunny.UI.UITextBox();
            this.uiLabel37 = new Sunny.UI.UILabel();
            this.uiLabel42 = new Sunny.UI.UILabel();
            this.uiLabel36 = new Sunny.UI.UILabel();
            this.uiLabel43 = new Sunny.UI.UILabel();
            this.txtEightHOffset = new Sunny.UI.UITextBox();
            this.uiLabel35 = new Sunny.UI.UILabel();
            this.uiLabel34 = new Sunny.UI.UILabel();
            this.txtEightPhiCount = new Sunny.UI.UITextBox();
            this.uiLabel33 = new Sunny.UI.UILabel();
            this.lable31 = new Sunny.UI.UILabel();
            this.uiLabel32 = new Sunny.UI.UILabel();
            this.txtEightMinSpeed = new Sunny.UI.UITextBox();
            this.uiLabel31 = new Sunny.UI.UILabel();
            this.txtEightPhiOffset = new Sunny.UI.UITextBox();
            this.uiLabel30 = new Sunny.UI.UILabel();
            this.uiLabel24 = new Sunny.UI.UILabel();
            this.uiLabel29 = new Sunny.UI.UILabel();
            this.uiLabel25 = new Sunny.UI.UILabel();
            this.txtEightMinHeight = new Sunny.UI.UITextBox();
            this.txtEightMinAngleSpeed = new Sunny.UI.UITextBox();
            this.uiLabel28 = new Sunny.UI.UILabel();
            this.txtEightMaxHeight = new Sunny.UI.UITextBox();
            this.uiLabel27 = new Sunny.UI.UILabel();
            this.uiLabel26 = new Sunny.UI.UILabel();
            this.listTestType = new Sunny.UI.UIListBox();
            this.uiLine2 = new Sunny.UI.UILine();
            this.uiLine1 = new Sunny.UI.UILine();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.uiLine10 = new Sunny.UI.UILine();
            this.labBuildTime = new Sunny.UI.UILabel();
            this.labBuildVersion = new Sunny.UI.UILabel();
            this.uiLabel88 = new Sunny.UI.UILabel();
            this.uiLabel82 = new Sunny.UI.UILabel();
            this.btnDeleteCurrentMap = new Sunny.UI.UIButton();
            this.btnDeleteAllMap = new Sunny.UI.UIButton();
            this.uiLabel67 = new Sunny.UI.UILabel();
            this.cbMapProviders = new Sunny.UI.UIComboBox();
            this.btnHeightCheck = new Sunny.UI.UIButton();
            this.btnDiChiCheck = new Sunny.UI.UIButton();
            this.uiLine9 = new Sunny.UI.UILine();
            this.uiLine8 = new Sunny.UI.UILine();
            this.uiLine5 = new Sunny.UI.UILine();
            this.uiTextBox2 = new Sunny.UI.UITextBox();
            this.btnReConnect = new Sunny.UI.UISymbolButton();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbYawAngleAccum = new Sunny.UI.UICheckBox();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.gMapControlPanel.SuspendLayout();
            this.materialTabControl1.SuspendLayout();
            this.tabPageTestGround.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPageTestOne.SuspendLayout();
            this.uiTitlePanel1.SuspendLayout();
            this.tabPageTestParam.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuIconList
            // 
            this.menuIconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("menuIconList.ImageStream")));
            this.menuIconList.TransparentColor = System.Drawing.Color.Transparent;
            this.menuIconList.Images.SetKeyName(0, "location.png");
            this.menuIconList.Images.SetKeyName(1, "paperplane.png");
            this.menuIconList.Images.SetKeyName(2, "params.png");
            this.menuIconList.Images.SetKeyName(3, "settings.png");
            // 
            // btnUserName
            // 
            this.btnUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserName.BackColor = System.Drawing.Color.Transparent;
            this.btnUserName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserName.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUserName.Image = ((System.Drawing.Image)(resources.GetObject("btnUserName.Image")));
            this.btnUserName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserName.ImageInterval = 10;
            this.btnUserName.Location = new System.Drawing.Point(920, 6);
            this.btnUserName.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.btnUserName.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnUserName.Name = "btnUserName";
            this.btnUserName.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.btnUserName.Radius = 10;
            this.btnUserName.Size = new System.Drawing.Size(191, 28);
            this.btnUserName.Style = Sunny.UI.UIStyle.Custom;
            this.btnUserName.TabIndex = 8;
            this.btnUserName.Text = "2022-08-25 17:09:34";
            this.btnUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUserName.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUserName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(1199, 6);
            this.btnExit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnExit.Radius = 10;
            this.btnExit.Size = new System.Drawing.Size(74, 28);
            this.btnExit.Style = Sunny.UI.UIStyle.Custom;
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "退出";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // gMapControl
            // 
            this.gMapControl.Bearing = 0F;
            this.gMapControl.CanDragMap = true;
            this.gMapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl.GrayScaleMode = false;
            this.gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl.LevelsKeepInMemory = 5;
            this.gMapControl.Location = new System.Drawing.Point(0, 0);
            this.gMapControl.Margin = new System.Windows.Forms.Padding(0);
            this.gMapControl.MarkersEnabled = true;
            this.gMapControl.MaxZoom = 22;
            this.gMapControl.MinZoom = 1;
            this.gMapControl.MouseWheelZoomEnabled = true;
            this.gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.gMapControl.Name = "gMapControl";
            this.gMapControl.NegativeMode = false;
            this.gMapControl.PolygonsEnabled = true;
            this.gMapControl.RetryLoadTile = 0;
            this.gMapControl.RoutesEnabled = true;
            this.gMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl.ShowTileGridLines = false;
            this.gMapControl.Size = new System.Drawing.Size(957, 716);
            this.gMapControl.TabIndex = 20;
            this.gMapControl.Zoom = 0D;
            // 
            // labVol
            // 
            this.labVol.BackColor = System.Drawing.Color.Transparent;
            this.labVol.Font = new System.Drawing.Font("黑体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labVol.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labVol.Location = new System.Drawing.Point(392, 6);
            this.labVol.Name = "labVol";
            this.labVol.Size = new System.Drawing.Size(48, 20);
            this.labVol.TabIndex = 91;
            this.labVol.Text = "15.2V";
            this.labVol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labACVoltage
            // 
            this.labACVoltage.BackColor = System.Drawing.Color.Transparent;
            this.labACVoltage.Font = new System.Drawing.Font("黑体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labACVoltage.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labACVoltage.Location = new System.Drawing.Point(348, 6);
            this.labACVoltage.Margin = new System.Windows.Forms.Padding(0);
            this.labACVoltage.Name = "labACVoltage";
            this.labACVoltage.Size = new System.Drawing.Size(41, 20);
            this.labACVoltage.TabIndex = 114;
            this.labACVoltage.Text = "100%";
            this.labACVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labHeight
            // 
            this.labHeight.BackColor = System.Drawing.Color.Transparent;
            this.labHeight.Font = new System.Drawing.Font("黑体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labHeight.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labHeight.Location = new System.Drawing.Point(487, 6);
            this.labHeight.Name = "labHeight";
            this.labHeight.Size = new System.Drawing.Size(47, 20);
            this.labHeight.TabIndex = 109;
            this.labHeight.Text = "100m";
            this.labHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(446, 7);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 19);
            this.label20.TabIndex = 108;
            this.label20.Text = "高度";
            // 
            // uiProgressIndicator1
            // 
            this.uiProgressIndicator1.BackColor = System.Drawing.Color.Transparent;
            this.uiProgressIndicator1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiProgressIndicator1.ForeColor = System.Drawing.Color.White;
            this.uiProgressIndicator1.Location = new System.Drawing.Point(172, 5);
            this.uiProgressIndicator1.Margin = new System.Windows.Forms.Padding(3, 1, 1, 3);
            this.uiProgressIndicator1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiProgressIndicator1.Name = "uiProgressIndicator1";
            this.uiProgressIndicator1.Size = new System.Drawing.Size(29, 32);
            this.uiProgressIndicator1.Style = Sunny.UI.UIStyle.Custom;
            this.uiProgressIndicator1.TabIndex = 87;
            this.uiProgressIndicator1.Text = "uiProgressIndicator1";
            this.uiProgressIndicator1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 200;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.gMapControlPanel);
            this.panel1.Controls.Add(this.materialTabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 748);
            this.panel1.TabIndex = 89;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.labHeight);
            this.panel6.Controls.Add(this.label14);
            this.panel6.Controls.Add(this.labCurrentLat);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.labCurrentLng);
            this.panel6.Controls.Add(this.uiPanel7);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.label20);
            this.panel6.Controls.Add(this.txtSystemStatus);
            this.panel6.Controls.Add(this.labACVoltage);
            this.panel6.Controls.Add(this.labVol);
            this.panel6.Controls.Add(this.btnGpsStar);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(323, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(957, 32);
            this.panel6.TabIndex = 212;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Gray;
            this.label14.Location = new System.Drawing.Point(322, 4);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(1, 25);
            this.label14.TabIndex = 199;
            // 
            // labCurrentLat
            // 
            this.labCurrentLat.BackColor = System.Drawing.Color.Transparent;
            this.labCurrentLat.Font = new System.Drawing.Font("黑体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labCurrentLat.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labCurrentLat.Location = new System.Drawing.Point(581, 7);
            this.labCurrentLat.Name = "labCurrentLat";
            this.labCurrentLat.Size = new System.Drawing.Size(123, 19);
            this.labCurrentLat.TabIndex = 113;
            this.labCurrentLat.Text = "000.00000000";
            this.labCurrentLat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("黑体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(179)))));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(328, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 20);
            this.label1.TabIndex = 198;
            // 
            // labCurrentLng
            // 
            this.labCurrentLng.BackColor = System.Drawing.Color.Transparent;
            this.labCurrentLng.Font = new System.Drawing.Font("黑体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labCurrentLng.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labCurrentLng.Location = new System.Drawing.Point(710, 7);
            this.labCurrentLng.Name = "labCurrentLng";
            this.labCurrentLng.Size = new System.Drawing.Size(123, 19);
            this.labCurrentLng.TabIndex = 112;
            this.labCurrentLng.Text = "000.00000000";
            this.labCurrentLng.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiPanel7
            // 
            this.uiPanel7.BackColor = System.Drawing.Color.Transparent;
            this.uiPanel7.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel7.Location = new System.Drawing.Point(4, 4);
            this.uiPanel7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 5);
            this.uiPanel7.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel7.Name = "uiPanel7";
            this.uiPanel7.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.uiPanel7.Radius = 18;
            this.uiPanel7.Size = new System.Drawing.Size(112, 24);
            this.uiPanel7.Style = Sunny.UI.UIStyle.Custom;
            this.uiPanel7.TabIndex = 23;
            this.uiPanel7.Text = "训练未开始";
            this.uiPanel7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel7.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtSystemStatus
            // 
            this.txtSystemStatus.BackColor = System.Drawing.Color.Transparent;
            this.txtSystemStatus.FillColor = System.Drawing.Color.Yellow;
            this.txtSystemStatus.FillColor2 = System.Drawing.Color.Transparent;
            this.txtSystemStatus.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSystemStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSystemStatus.Location = new System.Drawing.Point(124, 4);
            this.txtSystemStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 5);
            this.txtSystemStatus.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtSystemStatus.Name = "txtSystemStatus";
            this.txtSystemStatus.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.txtSystemStatus.Radius = 18;
            this.txtSystemStatus.RectColor = System.Drawing.Color.Transparent;
            this.txtSystemStatus.Size = new System.Drawing.Size(106, 24);
            this.txtSystemStatus.Style = Sunny.UI.UIStyle.Custom;
            this.txtSystemStatus.TabIndex = 22;
            this.txtSystemStatus.Text = "系统正常";
            this.txtSystemStatus.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtSystemStatus.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnGpsStar
            // 
            this.btnGpsStar.BackColor = System.Drawing.Color.Transparent;
            this.btnGpsStar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGpsStar.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.btnGpsStar.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.btnGpsStar.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.btnGpsStar.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.btnGpsStar.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGpsStar.ForeDisableColor = System.Drawing.Color.White;
            this.btnGpsStar.Location = new System.Drawing.Point(237, 4);
            this.btnGpsStar.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnGpsStar.Name = "btnGpsStar";
            this.btnGpsStar.Radius = 18;
            this.btnGpsStar.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.btnGpsStar.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.btnGpsStar.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.btnGpsStar.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.btnGpsStar.ShowTips = true;
            this.btnGpsStar.Size = new System.Drawing.Size(76, 24);
            this.btnGpsStar.Style = Sunny.UI.UIStyle.Custom;
            this.btnGpsStar.StyleCustomMode = true;
            this.btnGpsStar.TabIndex = 115;
            this.btnGpsStar.Text = "GPS";
            this.btnGpsStar.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGpsStar.TipsForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGpsStar.TipsText = "16";
            this.btnGpsStar.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // gMapControlPanel
            // 
            this.gMapControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMapControlPanel.Controls.Add(this.btnMapZoomDn);
            this.gMapControlPanel.Controls.Add(this.btnMapZoomUp);
            this.gMapControlPanel.Controls.Add(this.btnPositioningAircraft);
            this.gMapControlPanel.Controls.Add(this.btnRotate);
            this.gMapControlPanel.Controls.Add(this.headingIndicatorInstrumentControl1);
            this.gMapControlPanel.Controls.Add(this.attitudeIndicatorInstrumentControl1);
            this.gMapControlPanel.Controls.Add(this.labGroundName);
            this.gMapControlPanel.Controls.Add(this.gMapControl);
            this.gMapControlPanel.Location = new System.Drawing.Point(323, 32);
            this.gMapControlPanel.Margin = new System.Windows.Forms.Padding(0);
            this.gMapControlPanel.Name = "gMapControlPanel";
            this.gMapControlPanel.Size = new System.Drawing.Size(957, 716);
            this.gMapControlPanel.TabIndex = 201;
            // 
            // btnMapZoomDn
            // 
            this.btnMapZoomDn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMapZoomDn.BackColor = System.Drawing.Color.Transparent;
            this.btnMapZoomDn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMapZoomDn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMapZoomDn.Location = new System.Drawing.Point(924, 646);
            this.btnMapZoomDn.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnMapZoomDn.Name = "btnMapZoomDn";
            this.btnMapZoomDn.Radius = 10;
            this.btnMapZoomDn.Size = new System.Drawing.Size(30, 30);
            this.btnMapZoomDn.Symbol = 61456;
            this.btnMapZoomDn.TabIndex = 211;
            this.btnMapZoomDn.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMapZoomDn.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnMapZoomDn.Click += new System.EventHandler(this.btnMapZoomDn_Click);
            // 
            // btnMapZoomUp
            // 
            this.btnMapZoomUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMapZoomUp.BackColor = System.Drawing.Color.Transparent;
            this.btnMapZoomUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMapZoomUp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMapZoomUp.Location = new System.Drawing.Point(924, 610);
            this.btnMapZoomUp.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnMapZoomUp.Name = "btnMapZoomUp";
            this.btnMapZoomUp.Radius = 10;
            this.btnMapZoomUp.Size = new System.Drawing.Size(30, 30);
            this.btnMapZoomUp.Symbol = 61454;
            this.btnMapZoomUp.TabIndex = 210;
            this.btnMapZoomUp.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMapZoomUp.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnMapZoomUp.Click += new System.EventHandler(this.btnMapZoomUp_Click);
            // 
            // btnPositioningAircraft
            // 
            this.btnPositioningAircraft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPositioningAircraft.BackColor = System.Drawing.Color.Transparent;
            this.btnPositioningAircraft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPositioningAircraft.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPositioningAircraft.Location = new System.Drawing.Point(924, 574);
            this.btnPositioningAircraft.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnPositioningAircraft.Name = "btnPositioningAircraft";
            this.btnPositioningAircraft.Radius = 10;
            this.btnPositioningAircraft.Size = new System.Drawing.Size(30, 30);
            this.btnPositioningAircraft.Symbol = 61531;
            this.btnPositioningAircraft.SymbolOffset = new System.Drawing.Point(0, 2);
            this.btnPositioningAircraft.TabIndex = 209;
            this.btnPositioningAircraft.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPositioningAircraft.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnPositioningAircraft.Click += new System.EventHandler(this.btnPositioningAircraft_Click);
            // 
            // btnRotate
            // 
            this.btnRotate.BackColor = System.Drawing.Color.Transparent;
            this.btnRotate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRotate.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRotate.Location = new System.Drawing.Point(225, 10);
            this.btnRotate.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Radius = 10;
            this.btnRotate.Size = new System.Drawing.Size(74, 28);
            this.btnRotate.Style = Sunny.UI.UIStyle.Custom;
            this.btnRotate.TabIndex = 114;
            this.btnRotate.Text = "飞行视角";
            this.btnRotate.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRotate.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnRotate.Click += new System.EventHandler(this.btnRotate_Click);
            // 
            // headingIndicatorInstrumentControl1
            // 
            this.headingIndicatorInstrumentControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.headingIndicatorInstrumentControl1.BackColor = System.Drawing.Color.Transparent;
            this.headingIndicatorInstrumentControl1.Location = new System.Drawing.Point(854, 3);
            this.headingIndicatorInstrumentControl1.Name = "headingIndicatorInstrumentControl1";
            this.headingIndicatorInstrumentControl1.Size = new System.Drawing.Size(100, 100);
            this.headingIndicatorInstrumentControl1.TabIndex = 205;
            // 
            // attitudeIndicatorInstrumentControl1
            // 
            this.attitudeIndicatorInstrumentControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.attitudeIndicatorInstrumentControl1.BackColor = System.Drawing.Color.Transparent;
            this.attitudeIndicatorInstrumentControl1.Location = new System.Drawing.Point(748, 3);
            this.attitudeIndicatorInstrumentControl1.Name = "attitudeIndicatorInstrumentControl1";
            this.attitudeIndicatorInstrumentControl1.Size = new System.Drawing.Size(100, 100);
            this.attitudeIndicatorInstrumentControl1.TabIndex = 204;
            // 
            // labGroundName
            // 
            this.labGroundName.BackColor = System.Drawing.Color.Transparent;
            this.labGroundName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labGroundName.Location = new System.Drawing.Point(12, 10);
            this.labGroundName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labGroundName.MinimumSize = new System.Drawing.Size(1, 1);
            this.labGroundName.Name = "labGroundName";
            this.labGroundName.Radius = 10;
            this.labGroundName.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.labGroundName.Size = new System.Drawing.Size(206, 28);
            this.labGroundName.Style = Sunny.UI.UIStyle.Custom;
            this.labGroundName.TabIndex = 201;
            this.labGroundName.Text = "昊翔无人机-训练场-A";
            this.labGroundName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.labGroundName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPageTestGround);
            this.materialTabControl1.Controls.Add(this.tabPageTestOne);
            this.materialTabControl1.Controls.Add(this.tabPageTestParam);
            this.materialTabControl1.Controls.Add(this.tabPage6);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.materialTabControl1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.materialTabControl1.ImageList = this.menuIconList;
            this.materialTabControl1.Location = new System.Drawing.Point(0, 0);
            this.materialTabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.Padding = new System.Drawing.Point(0, 0);
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(323, 748);
            this.materialTabControl1.TabIndex = 18;
            // 
            // tabPageTestGround
            // 
            this.tabPageTestGround.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabPageTestGround.Controls.Add(this.panel3);
            this.tabPageTestGround.Controls.Add(this.panel2);
            this.tabPageTestGround.ImageKey = "location.png";
            this.tabPageTestGround.Location = new System.Drawing.Point(4, 58);
            this.tabPageTestGround.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.tabPageTestGround.Name = "tabPageTestGround";
            this.tabPageTestGround.Size = new System.Drawing.Size(315, 686);
            this.tabPageTestGround.TabIndex = 0;
            this.tabPageTestGround.Text = "训练场地管理";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.uiLabel61);
            this.panel3.Controls.Add(this.btnDeleteGround);
            this.panel3.Controls.Add(this.btnEditGround);
            this.panel3.Controls.Add(this.btnAddGround);
            this.panel3.Controls.Add(this.listGround);
            this.panel3.Controls.Add(this.btnCompanyName);
            this.panel3.Controls.Add(this.uiLabel60);
            this.panel3.Controls.Add(this.txtCompanyName);
            this.panel3.Location = new System.Drawing.Point(0, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(309, 284);
            this.panel3.TabIndex = 90;
            // 
            // uiLabel61
            // 
            this.uiLabel61.AutoSize = true;
            this.uiLabel61.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel61.ForeColor = System.Drawing.Color.Black;
            this.uiLabel61.Location = new System.Drawing.Point(13, 40);
            this.uiLabel61.Name = "uiLabel61";
            this.uiLabel61.Size = new System.Drawing.Size(74, 19);
            this.uiLabel61.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel61.TabIndex = 130;
            this.uiLabel61.Text = "训练场列表";
            this.uiLabel61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel61.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnDeleteGround
            // 
            this.btnDeleteGround.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteGround.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDeleteGround.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btnDeleteGround.Location = new System.Drawing.Point(218, 250);
            this.btnDeleteGround.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnDeleteGround.Name = "btnDeleteGround";
            this.btnDeleteGround.Radius = 10;
            this.btnDeleteGround.RectSelectedColor = System.Drawing.Color.Empty;
            this.btnDeleteGround.Size = new System.Drawing.Size(87, 29);
            this.btnDeleteGround.Style = Sunny.UI.UIStyle.Custom;
            this.btnDeleteGround.StyleCustomMode = true;
            this.btnDeleteGround.TabIndex = 129;
            this.btnDeleteGround.Text = "删 除";
            this.btnDeleteGround.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDeleteGround.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnDeleteGround.Click += new System.EventHandler(this.btnDeleteGround_Click);
            // 
            // btnEditGround
            // 
            this.btnEditGround.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditGround.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEditGround.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btnEditGround.Location = new System.Drawing.Point(119, 250);
            this.btnEditGround.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnEditGround.Name = "btnEditGround";
            this.btnEditGround.Radius = 10;
            this.btnEditGround.RectSelectedColor = System.Drawing.Color.Empty;
            this.btnEditGround.Size = new System.Drawing.Size(87, 29);
            this.btnEditGround.Style = Sunny.UI.UIStyle.Custom;
            this.btnEditGround.StyleCustomMode = true;
            this.btnEditGround.TabIndex = 128;
            this.btnEditGround.Text = "修 改";
            this.btnEditGround.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEditGround.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnEditGround.Click += new System.EventHandler(this.btnEditGround_Click);
            // 
            // btnAddGround
            // 
            this.btnAddGround.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddGround.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddGround.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btnAddGround.Location = new System.Drawing.Point(18, 250);
            this.btnAddGround.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnAddGround.Name = "btnAddGround";
            this.btnAddGround.Radius = 10;
            this.btnAddGround.RectSelectedColor = System.Drawing.Color.Empty;
            this.btnAddGround.Size = new System.Drawing.Size(87, 29);
            this.btnAddGround.Style = Sunny.UI.UIStyle.Custom;
            this.btnAddGround.StyleCustomMode = true;
            this.btnAddGround.TabIndex = 127;
            this.btnAddGround.Text = "添 加";
            this.btnAddGround.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddGround.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnAddGround.Click += new System.EventHandler(this.btnAddGround_Click);
            // 
            // listGround
            // 
            this.listGround.FillColor = System.Drawing.Color.White;
            this.listGround.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.listGround.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listGround.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.listGround.Items.AddRange(new object[] {
            "昊翔无人机-训练场-A",
            "昊翔无人机-训练场-B",
            "昊翔无人机-训练场-C",
            "昊翔无人机-训练场-D",
            "昊翔无人机-训练场-E",
            "昊翔无人机-训练场-F",
            "昊翔无人机-训练场-G",
            "昊翔无人机-训练场-H",
            "昊翔无人机-训练场-I",
            "昊翔无人机-训练场-J",
            "昊翔无人机-训练场-K"});
            this.listGround.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.listGround.Location = new System.Drawing.Point(16, 62);
            this.listGround.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listGround.MinimumSize = new System.Drawing.Size(1, 1);
            this.listGround.Name = "listGround";
            this.listGround.Padding = new System.Windows.Forms.Padding(2);
            this.listGround.ShowText = false;
            this.listGround.Size = new System.Drawing.Size(292, 180);
            this.listGround.Style = Sunny.UI.UIStyle.Custom;
            this.listGround.TabIndex = 126;
            this.listGround.Text = "listGround";
            this.listGround.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.listGround.SelectedIndexChanged += new System.EventHandler(this.listGround_SelectedIndexChanged);
            // 
            // btnCompanyName
            // 
            this.btnCompanyName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompanyName.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCompanyName.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btnCompanyName.Location = new System.Drawing.Point(237, 12);
            this.btnCompanyName.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCompanyName.Name = "btnCompanyName";
            this.btnCompanyName.Radius = 10;
            this.btnCompanyName.RectSelectedColor = System.Drawing.Color.Empty;
            this.btnCompanyName.Size = new System.Drawing.Size(51, 23);
            this.btnCompanyName.Style = Sunny.UI.UIStyle.Custom;
            this.btnCompanyName.StyleCustomMode = true;
            this.btnCompanyName.TabIndex = 124;
            this.btnCompanyName.Text = "设置";
            this.btnCompanyName.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCompanyName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnCompanyName.Click += new System.EventHandler(this.btnCompanyName_Click);
            // 
            // uiLabel60
            // 
            this.uiLabel60.AutoSize = true;
            this.uiLabel60.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel60.ForeColor = System.Drawing.Color.Black;
            this.uiLabel60.Location = new System.Drawing.Point(13, 15);
            this.uiLabel60.Name = "uiLabel60";
            this.uiLabel60.Size = new System.Drawing.Size(61, 19);
            this.uiLabel60.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel60.TabIndex = 124;
            this.uiLabel60.Text = "机构名称";
            this.uiLabel60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel60.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.ButtonSymbol = 61761;
            this.txtCompanyName.ButtonWidth = 100;
            this.txtCompanyName.CanEmpty = true;
            this.txtCompanyName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCompanyName.DecimalPlaces = 10;
            this.txtCompanyName.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtCompanyName.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCompanyName.Location = new System.Drawing.Point(76, 12);
            this.txtCompanyName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCompanyName.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Padding = new System.Windows.Forms.Padding(5);
            this.txtCompanyName.ShowText = false;
            this.txtCompanyName.Size = new System.Drawing.Size(154, 23);
            this.txtCompanyName.Style = Sunny.UI.UIStyle.Custom;
            this.txtCompanyName.TabIndex = 125;
            this.txtCompanyName.Text = "AOPA 培训机构";
            this.txtCompanyName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtCompanyName.Watermark = "第一次要设置";
            this.txtCompanyName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtCenterAngle);
            this.panel2.Controls.Add(this.txtCenterLat);
            this.panel2.Controls.Add(this.btnGroundCancel);
            this.panel2.Controls.Add(this.btnGroundSave);
            this.panel2.Controls.Add(this.txtGroundName);
            this.panel2.Controls.Add(this.uiLabel64);
            this.panel2.Controls.Add(this.btnOneEightDraw);
            this.panel2.Controls.Add(this.uiLabel62);
            this.panel2.Controls.Add(this.uiLabel63);
            this.panel2.Controls.Add(this.txtCenterLng);
            this.panel2.Controls.Add(this.btnCenterEnter);
            this.panel2.Controls.Add(this.uiLabel45);
            this.panel2.Controls.Add(this.btnEightClear);
            this.panel2.Controls.Add(this.uiLabel44);
            this.panel2.Controls.Add(this.btnEightEnter);
            this.panel2.Controls.Add(this.uiLabel47);
            this.panel2.Controls.Add(this.txtLeftLat);
            this.panel2.Controls.Add(this.txtRightLat);
            this.panel2.Controls.Add(this.uiLabel46);
            this.panel2.Controls.Add(this.txtLeftLng);
            this.panel2.Controls.Add(this.uiLabel56);
            this.panel2.Controls.Add(this.uiLabel49);
            this.panel2.Controls.Add(this.txtRightLng);
            this.panel2.Controls.Add(this.uiLabel48);
            this.panel2.Controls.Add(this.uiLabel57);
            this.panel2.Controls.Add(this.txtCenterRad);
            this.panel2.Controls.Add(this.uiLabel58);
            this.panel2.Controls.Add(this.uiLabel55);
            this.panel2.Controls.Add(this.uiLabel59);
            this.panel2.Controls.Add(this.uiLabel54);
            this.panel2.Controls.Add(this.txtRightRad);
            this.panel2.Controls.Add(this.uiLabel53);
            this.panel2.Controls.Add(this.uiLabel50);
            this.panel2.Controls.Add(this.uiLabel52);
            this.panel2.Controls.Add(this.uiLabel51);
            this.panel2.Location = new System.Drawing.Point(0, 268);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(309, 400);
            this.panel2.TabIndex = 90;
            // 
            // txtCenterAngle
            // 
            this.txtCenterAngle.ButtonSymbol = 61761;
            this.txtCenterAngle.ButtonWidth = 100;
            this.txtCenterAngle.CanEmpty = true;
            this.txtCenterAngle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCenterAngle.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtCenterAngle.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCenterAngle.Location = new System.Drawing.Point(94, 152);
            this.txtCenterAngle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCenterAngle.Maximum = 9D;
            this.txtCenterAngle.Minimum = 0D;
            this.txtCenterAngle.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtCenterAngle.Name = "txtCenterAngle";
            this.txtCenterAngle.Padding = new System.Windows.Forms.Padding(5);
            this.txtCenterAngle.ShowText = false;
            this.txtCenterAngle.Size = new System.Drawing.Size(112, 23);
            this.txtCenterAngle.Style = Sunny.UI.UIStyle.Custom;
            this.txtCenterAngle.TabIndex = 126;
            this.txtCenterAngle.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtCenterAngle.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtCenterAngle.Watermark = "";
            this.txtCenterAngle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtCenterLat
            // 
            this.txtCenterLat.ButtonSymbol = 61761;
            this.txtCenterLat.ButtonWidth = 100;
            this.txtCenterLat.CanEmpty = true;
            this.txtCenterLat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCenterLat.DecimalPlaces = 8;
            this.txtCenterLat.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtCenterLat.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCenterLat.Location = new System.Drawing.Point(94, 92);
            this.txtCenterLat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCenterLat.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtCenterLat.Name = "txtCenterLat";
            this.txtCenterLat.Padding = new System.Windows.Forms.Padding(5);
            this.txtCenterLat.ShowText = false;
            this.txtCenterLat.Size = new System.Drawing.Size(113, 23);
            this.txtCenterLat.Style = Sunny.UI.UIStyle.Custom;
            this.txtCenterLat.TabIndex = 92;
            this.txtCenterLat.Text = "0.00000000";
            this.txtCenterLat.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtCenterLat.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtCenterLat.Watermark = "";
            this.txtCenterLat.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnGroundCancel
            // 
            this.btnGroundCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGroundCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGroundCancel.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGroundCancel.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btnGroundCancel.Location = new System.Drawing.Point(219, 360);
            this.btnGroundCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnGroundCancel.Name = "btnGroundCancel";
            this.btnGroundCancel.Radius = 10;
            this.btnGroundCancel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGroundCancel.RectSelectedColor = System.Drawing.Color.Empty;
            this.btnGroundCancel.Size = new System.Drawing.Size(87, 29);
            this.btnGroundCancel.Style = Sunny.UI.UIStyle.Custom;
            this.btnGroundCancel.StyleCustomMode = true;
            this.btnGroundCancel.TabIndex = 131;
            this.btnGroundCancel.Text = "取 消";
            this.btnGroundCancel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGroundCancel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnGroundCancel.Click += new System.EventHandler(this.btnGroundCancel_Click);
            // 
            // btnGroundSave
            // 
            this.btnGroundSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGroundSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGroundSave.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGroundSave.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btnGroundSave.Location = new System.Drawing.Point(18, 360);
            this.btnGroundSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnGroundSave.Name = "btnGroundSave";
            this.btnGroundSave.Radius = 10;
            this.btnGroundSave.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGroundSave.RectSelectedColor = System.Drawing.Color.Empty;
            this.btnGroundSave.Size = new System.Drawing.Size(87, 29);
            this.btnGroundSave.Style = Sunny.UI.UIStyle.Custom;
            this.btnGroundSave.StyleCustomMode = true;
            this.btnGroundSave.TabIndex = 130;
            this.btnGroundSave.Text = "保 存";
            this.btnGroundSave.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGroundSave.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnGroundSave.Click += new System.EventHandler(this.btnGroundSave_Click);
            // 
            // txtGroundName
            // 
            this.txtGroundName.ButtonSymbol = 61761;
            this.txtGroundName.ButtonWidth = 100;
            this.txtGroundName.CanEmpty = true;
            this.txtGroundName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGroundName.DecimalPlaces = 8;
            this.txtGroundName.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtGroundName.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtGroundName.Location = new System.Drawing.Point(94, 29);
            this.txtGroundName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtGroundName.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtGroundName.Name = "txtGroundName";
            this.txtGroundName.Padding = new System.Windows.Forms.Padding(5);
            this.txtGroundName.ShowText = false;
            this.txtGroundName.Size = new System.Drawing.Size(211, 23);
            this.txtGroundName.Style = Sunny.UI.UIStyle.Custom;
            this.txtGroundName.TabIndex = 129;
            this.txtGroundName.Text = "ABC";
            this.txtGroundName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtGroundName.Watermark = "";
            this.txtGroundName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel64
            // 
            this.uiLabel64.AutoSize = true;
            this.uiLabel64.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel64.ForeColor = System.Drawing.Color.Black;
            this.uiLabel64.Location = new System.Drawing.Point(13, 33);
            this.uiLabel64.Name = "uiLabel64";
            this.uiLabel64.Size = new System.Drawing.Size(74, 19);
            this.uiLabel64.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel64.TabIndex = 128;
            this.uiLabel64.Text = "训练场名称";
            this.uiLabel64.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel64.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnOneEightDraw
            // 
            this.btnOneEightDraw.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOneEightDraw.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOneEightDraw.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btnOneEightDraw.Location = new System.Drawing.Point(217, 234);
            this.btnOneEightDraw.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnOneEightDraw.Name = "btnOneEightDraw";
            this.btnOneEightDraw.Radius = 10;
            this.btnOneEightDraw.RectSelectedColor = System.Drawing.Color.Empty;
            this.btnOneEightDraw.Size = new System.Drawing.Size(87, 29);
            this.btnOneEightDraw.Style = Sunny.UI.UIStyle.Custom;
            this.btnOneEightDraw.StyleCustomMode = true;
            this.btnOneEightDraw.TabIndex = 127;
            this.btnOneEightDraw.Text = "一键生成";
            this.btnOneEightDraw.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOneEightDraw.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnOneEightDraw.Click += new System.EventHandler(this.btnOneEightDraw_Click);
            // 
            // uiLabel62
            // 
            this.uiLabel62.AutoSize = true;
            this.uiLabel62.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel62.Location = new System.Drawing.Point(25, 152);
            this.uiLabel62.Name = "uiLabel62";
            this.uiLabel62.Size = new System.Drawing.Size(61, 19);
            this.uiLabel62.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel62.TabIndex = 124;
            this.uiLabel62.Text = "旋转角度";
            this.uiLabel62.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel62.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel63
            // 
            this.uiLabel63.AutoSize = true;
            this.uiLabel63.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel63.Location = new System.Drawing.Point(204, 152);
            this.uiLabel63.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel63.Name = "uiLabel63";
            this.uiLabel63.Size = new System.Drawing.Size(14, 19);
            this.uiLabel63.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel63.TabIndex = 125;
            this.uiLabel63.Text = "°";
            this.uiLabel63.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel63.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtCenterLng
            // 
            this.txtCenterLng.ButtonSymbol = 61761;
            this.txtCenterLng.ButtonWidth = 100;
            this.txtCenterLng.CanEmpty = true;
            this.txtCenterLng.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCenterLng.DecimalPlaces = 8;
            this.txtCenterLng.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtCenterLng.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCenterLng.Location = new System.Drawing.Point(94, 61);
            this.txtCenterLng.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCenterLng.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtCenterLng.Name = "txtCenterLng";
            this.txtCenterLng.Padding = new System.Windows.Forms.Padding(5);
            this.txtCenterLng.ShowText = false;
            this.txtCenterLng.Size = new System.Drawing.Size(113, 23);
            this.txtCenterLng.Style = Sunny.UI.UIStyle.Custom;
            this.txtCenterLng.TabIndex = 89;
            this.txtCenterLng.Text = "0.00000000";
            this.txtCenterLng.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtCenterLng.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtCenterLng.Watermark = "";
            this.txtCenterLng.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnCenterEnter
            // 
            this.btnCenterEnter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCenterEnter.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCenterEnter.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btnCenterEnter.Location = new System.Drawing.Point(219, 74);
            this.btnCenterEnter.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCenterEnter.Name = "btnCenterEnter";
            this.btnCenterEnter.Radius = 10;
            this.btnCenterEnter.RectSelectedColor = System.Drawing.Color.Empty;
            this.btnCenterEnter.Size = new System.Drawing.Size(87, 29);
            this.btnCenterEnter.Style = Sunny.UI.UIStyle.Custom;
            this.btnCenterEnter.StyleCustomMode = true;
            this.btnCenterEnter.TabIndex = 81;
            this.btnCenterEnter.Text = "采集中心点";
            this.btnCenterEnter.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCenterEnter.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnCenterEnter.Click += new System.EventHandler(this.btnCenterEnter_Click);
            // 
            // uiLabel45
            // 
            this.uiLabel45.AutoSize = true;
            this.uiLabel45.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel45.ForeColor = System.Drawing.Color.Black;
            this.uiLabel45.Location = new System.Drawing.Point(13, 65);
            this.uiLabel45.Name = "uiLabel45";
            this.uiLabel45.Size = new System.Drawing.Size(74, 19);
            this.uiLabel45.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel45.TabIndex = 87;
            this.uiLabel45.Text = "中心点经度";
            this.uiLabel45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel45.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnEightClear
            // 
            this.btnEightClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEightClear.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEightClear.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btnEightClear.Location = new System.Drawing.Point(217, 278);
            this.btnEightClear.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnEightClear.Name = "btnEightClear";
            this.btnEightClear.Radius = 10;
            this.btnEightClear.RectSelectedColor = System.Drawing.Color.Empty;
            this.btnEightClear.Size = new System.Drawing.Size(87, 29);
            this.btnEightClear.Style = Sunny.UI.UIStyle.Custom;
            this.btnEightClear.StyleCustomMode = true;
            this.btnEightClear.TabIndex = 123;
            this.btnEightClear.Text = "清除8字圆";
            this.btnEightClear.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEightClear.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnEightClear.Click += new System.EventHandler(this.btnEightClear_Click);
            // 
            // uiLabel44
            // 
            this.uiLabel44.AutoSize = true;
            this.uiLabel44.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel44.ForeColor = System.Drawing.Color.Black;
            this.uiLabel44.Location = new System.Drawing.Point(204, 65);
            this.uiLabel44.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel44.Name = "uiLabel44";
            this.uiLabel44.Size = new System.Drawing.Size(14, 19);
            this.uiLabel44.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel44.TabIndex = 88;
            this.uiLabel44.Text = "°";
            this.uiLabel44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel44.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnEightEnter
            // 
            this.btnEightEnter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEightEnter.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEightEnter.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btnEightEnter.Location = new System.Drawing.Point(217, 188);
            this.btnEightEnter.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnEightEnter.Name = "btnEightEnter";
            this.btnEightEnter.Radius = 10;
            this.btnEightEnter.RectSelectedColor = System.Drawing.Color.Empty;
            this.btnEightEnter.Size = new System.Drawing.Size(87, 29);
            this.btnEightEnter.Style = Sunny.UI.UIStyle.Custom;
            this.btnEightEnter.StyleCustomMode = true;
            this.btnEightEnter.TabIndex = 122;
            this.btnEightEnter.Text = "采集左圆心";
            this.btnEightEnter.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEightEnter.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnEightEnter.Click += new System.EventHandler(this.btnEightEnter_Click);
            // 
            // uiLabel47
            // 
            this.uiLabel47.AutoSize = true;
            this.uiLabel47.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel47.ForeColor = System.Drawing.Color.Black;
            this.uiLabel47.Location = new System.Drawing.Point(13, 93);
            this.uiLabel47.Name = "uiLabel47";
            this.uiLabel47.Size = new System.Drawing.Size(74, 19);
            this.uiLabel47.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel47.TabIndex = 90;
            this.uiLabel47.Text = "中心点纬度";
            this.uiLabel47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel47.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtLeftLat
            // 
            this.txtLeftLat.ButtonSymbol = 61761;
            this.txtLeftLat.ButtonWidth = 100;
            this.txtLeftLat.CanEmpty = true;
            this.txtLeftLat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLeftLat.DecimalPlaces = 8;
            this.txtLeftLat.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtLeftLat.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLeftLat.Location = new System.Drawing.Point(94, 220);
            this.txtLeftLat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLeftLat.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtLeftLat.Name = "txtLeftLat";
            this.txtLeftLat.Padding = new System.Windows.Forms.Padding(5);
            this.txtLeftLat.ShowText = false;
            this.txtLeftLat.Size = new System.Drawing.Size(113, 23);
            this.txtLeftLat.Style = Sunny.UI.UIStyle.Custom;
            this.txtLeftLat.TabIndex = 96;
            this.txtLeftLat.Text = "0.00000000";
            this.txtLeftLat.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtLeftLat.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtLeftLat.Watermark = "";
            this.txtLeftLat.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtRightLat
            // 
            this.txtRightLat.ButtonSymbol = 61761;
            this.txtRightLat.ButtonWidth = 100;
            this.txtRightLat.CanEmpty = true;
            this.txtRightLat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRightLat.DecimalPlaces = 8;
            this.txtRightLat.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtRightLat.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRightLat.Location = new System.Drawing.Point(94, 288);
            this.txtRightLat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRightLat.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtRightLat.Name = "txtRightLat";
            this.txtRightLat.Padding = new System.Windows.Forms.Padding(5);
            this.txtRightLat.ShowText = false;
            this.txtRightLat.Size = new System.Drawing.Size(113, 23);
            this.txtRightLat.Style = Sunny.UI.UIStyle.Custom;
            this.txtRightLat.TabIndex = 94;
            this.txtRightLat.Text = "0.00000000";
            this.txtRightLat.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtRightLat.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtRightLat.Watermark = "";
            this.txtRightLat.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel46
            // 
            this.uiLabel46.AutoSize = true;
            this.uiLabel46.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel46.ForeColor = System.Drawing.Color.Black;
            this.uiLabel46.Location = new System.Drawing.Point(204, 93);
            this.uiLabel46.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel46.Name = "uiLabel46";
            this.uiLabel46.Size = new System.Drawing.Size(14, 19);
            this.uiLabel46.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel46.TabIndex = 94;
            this.uiLabel46.Text = "°";
            this.uiLabel46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel46.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtLeftLng
            // 
            this.txtLeftLng.ButtonSymbol = 61761;
            this.txtLeftLng.ButtonWidth = 100;
            this.txtLeftLng.CanEmpty = true;
            this.txtLeftLng.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLeftLng.DecimalPlaces = 8;
            this.txtLeftLng.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtLeftLng.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLeftLng.Location = new System.Drawing.Point(94, 185);
            this.txtLeftLng.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLeftLng.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtLeftLng.Name = "txtLeftLng";
            this.txtLeftLng.Padding = new System.Windows.Forms.Padding(5);
            this.txtLeftLng.ShowText = false;
            this.txtLeftLng.Size = new System.Drawing.Size(113, 23);
            this.txtLeftLng.Style = Sunny.UI.UIStyle.Custom;
            this.txtLeftLng.TabIndex = 95;
            this.txtLeftLng.Text = "0.00000000";
            this.txtLeftLng.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtLeftLng.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtLeftLng.Watermark = "";
            this.txtLeftLng.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel56
            // 
            this.uiLabel56.AutoSize = true;
            this.uiLabel56.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel56.ForeColor = System.Drawing.Color.Black;
            this.uiLabel56.Location = new System.Drawing.Point(204, 289);
            this.uiLabel56.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel56.Name = "uiLabel56";
            this.uiLabel56.Size = new System.Drawing.Size(14, 19);
            this.uiLabel56.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel56.TabIndex = 121;
            this.uiLabel56.Text = "°";
            this.uiLabel56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel56.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel49
            // 
            this.uiLabel49.AutoSize = true;
            this.uiLabel49.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel49.Location = new System.Drawing.Point(25, 126);
            this.uiLabel49.Name = "uiLabel49";
            this.uiLabel49.Size = new System.Drawing.Size(61, 19);
            this.uiLabel49.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel49.TabIndex = 104;
            this.uiLabel49.Text = "自旋半径";
            this.uiLabel49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel49.Visible = false;
            this.uiLabel49.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtRightLng
            // 
            this.txtRightLng.ButtonSymbol = 61761;
            this.txtRightLng.ButtonWidth = 100;
            this.txtRightLng.CanEmpty = true;
            this.txtRightLng.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRightLng.DecimalPlaces = 8;
            this.txtRightLng.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtRightLng.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRightLng.Location = new System.Drawing.Point(94, 253);
            this.txtRightLng.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRightLng.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtRightLng.Name = "txtRightLng";
            this.txtRightLng.Padding = new System.Windows.Forms.Padding(5);
            this.txtRightLng.ShowText = false;
            this.txtRightLng.Size = new System.Drawing.Size(113, 23);
            this.txtRightLng.Style = Sunny.UI.UIStyle.Custom;
            this.txtRightLng.TabIndex = 93;
            this.txtRightLng.Text = "0.00000000";
            this.txtRightLng.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtRightLng.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtRightLng.Watermark = "";
            this.txtRightLng.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel48
            // 
            this.uiLabel48.AutoSize = true;
            this.uiLabel48.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel48.Location = new System.Drawing.Point(208, 122);
            this.uiLabel48.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel48.Name = "uiLabel48";
            this.uiLabel48.Size = new System.Drawing.Size(22, 19);
            this.uiLabel48.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel48.TabIndex = 105;
            this.uiLabel48.Text = "米";
            this.uiLabel48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel48.Visible = false;
            this.uiLabel48.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel57
            // 
            this.uiLabel57.AutoSize = true;
            this.uiLabel57.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel57.ForeColor = System.Drawing.Color.Black;
            this.uiLabel57.Location = new System.Drawing.Point(13, 290);
            this.uiLabel57.Name = "uiLabel57";
            this.uiLabel57.Size = new System.Drawing.Size(74, 19);
            this.uiLabel57.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel57.TabIndex = 119;
            this.uiLabel57.Text = "右圆心纬度";
            this.uiLabel57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel57.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtCenterRad
            // 
            this.txtCenterRad.ButtonSymbol = 61761;
            this.txtCenterRad.ButtonWidth = 100;
            this.txtCenterRad.CanEmpty = true;
            this.txtCenterRad.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCenterRad.DoubleValue = 1D;
            this.txtCenterRad.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtCenterRad.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCenterRad.IntValue = 1;
            this.txtCenterRad.Location = new System.Drawing.Point(94, 122);
            this.txtCenterRad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCenterRad.Maximum = 9D;
            this.txtCenterRad.Minimum = 0D;
            this.txtCenterRad.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtCenterRad.Name = "txtCenterRad";
            this.txtCenterRad.Padding = new System.Windows.Forms.Padding(5);
            this.txtCenterRad.ShowText = false;
            this.txtCenterRad.Size = new System.Drawing.Size(112, 23);
            this.txtCenterRad.Style = Sunny.UI.UIStyle.Custom;
            this.txtCenterRad.TabIndex = 106;
            this.txtCenterRad.Text = "1";
            this.txtCenterRad.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtCenterRad.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtCenterRad.Visible = false;
            this.txtCenterRad.Watermark = "";
            this.txtCenterRad.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel58
            // 
            this.uiLabel58.AutoSize = true;
            this.uiLabel58.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel58.ForeColor = System.Drawing.Color.Black;
            this.uiLabel58.Location = new System.Drawing.Point(204, 256);
            this.uiLabel58.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel58.Name = "uiLabel58";
            this.uiLabel58.Size = new System.Drawing.Size(14, 19);
            this.uiLabel58.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel58.TabIndex = 117;
            this.uiLabel58.Text = "°";
            this.uiLabel58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel58.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel55
            // 
            this.uiLabel55.AutoSize = true;
            this.uiLabel55.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel55.ForeColor = System.Drawing.Color.Black;
            this.uiLabel55.Location = new System.Drawing.Point(13, 187);
            this.uiLabel55.Name = "uiLabel55";
            this.uiLabel55.Size = new System.Drawing.Size(74, 19);
            this.uiLabel55.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel55.TabIndex = 107;
            this.uiLabel55.Text = "左圆心经度";
            this.uiLabel55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel55.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel59
            // 
            this.uiLabel59.AutoSize = true;
            this.uiLabel59.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel59.ForeColor = System.Drawing.Color.Black;
            this.uiLabel59.Location = new System.Drawing.Point(13, 255);
            this.uiLabel59.Name = "uiLabel59";
            this.uiLabel59.Size = new System.Drawing.Size(74, 19);
            this.uiLabel59.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel59.TabIndex = 116;
            this.uiLabel59.Text = "右圆心经度";
            this.uiLabel59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel59.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel54
            // 
            this.uiLabel54.AutoSize = true;
            this.uiLabel54.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel54.ForeColor = System.Drawing.Color.Black;
            this.uiLabel54.Location = new System.Drawing.Point(204, 188);
            this.uiLabel54.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel54.Name = "uiLabel54";
            this.uiLabel54.Size = new System.Drawing.Size(14, 19);
            this.uiLabel54.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel54.TabIndex = 108;
            this.uiLabel54.Text = "°";
            this.uiLabel54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel54.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtRightRad
            // 
            this.txtRightRad.ButtonSymbol = 61761;
            this.txtRightRad.ButtonWidth = 100;
            this.txtRightRad.CanEmpty = true;
            this.txtRightRad.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRightRad.DoubleValue = 6D;
            this.txtRightRad.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtRightRad.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRightRad.IntValue = 6;
            this.txtRightRad.Location = new System.Drawing.Point(94, 321);
            this.txtRightRad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRightRad.Maximum = 9D;
            this.txtRightRad.Minimum = 0D;
            this.txtRightRad.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtRightRad.Name = "txtRightRad";
            this.txtRightRad.Padding = new System.Windows.Forms.Padding(5);
            this.txtRightRad.ShowText = false;
            this.txtRightRad.Size = new System.Drawing.Size(112, 23);
            this.txtRightRad.Style = Sunny.UI.UIStyle.Custom;
            this.txtRightRad.TabIndex = 115;
            this.txtRightRad.Text = "6";
            this.txtRightRad.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtRightRad.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtRightRad.Watermark = "";
            this.txtRightRad.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel53
            // 
            this.uiLabel53.AutoSize = true;
            this.uiLabel53.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel53.ForeColor = System.Drawing.Color.Black;
            this.uiLabel53.Location = new System.Drawing.Point(13, 222);
            this.uiLabel53.Name = "uiLabel53";
            this.uiLabel53.Size = new System.Drawing.Size(74, 19);
            this.uiLabel53.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel53.TabIndex = 110;
            this.uiLabel53.Text = "左圆心纬度";
            this.uiLabel53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel53.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel50
            // 
            this.uiLabel50.AutoSize = true;
            this.uiLabel50.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel50.Location = new System.Drawing.Point(204, 323);
            this.uiLabel50.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel50.Name = "uiLabel50";
            this.uiLabel50.Size = new System.Drawing.Size(22, 19);
            this.uiLabel50.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel50.TabIndex = 114;
            this.uiLabel50.Text = "米";
            this.uiLabel50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel50.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel52
            // 
            this.uiLabel52.AutoSize = true;
            this.uiLabel52.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel52.ForeColor = System.Drawing.Color.Black;
            this.uiLabel52.Location = new System.Drawing.Point(204, 221);
            this.uiLabel52.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel52.Name = "uiLabel52";
            this.uiLabel52.Size = new System.Drawing.Size(14, 19);
            this.uiLabel52.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel52.TabIndex = 112;
            this.uiLabel52.Text = "°";
            this.uiLabel52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel52.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel51
            // 
            this.uiLabel51.AutoSize = true;
            this.uiLabel51.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel51.Location = new System.Drawing.Point(31, 323);
            this.uiLabel51.Name = "uiLabel51";
            this.uiLabel51.Size = new System.Drawing.Size(56, 19);
            this.uiLabel51.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel51.TabIndex = 113;
            this.uiLabel51.Text = "8字半径";
            this.uiLabel51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel51.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tabPageTestOne
            // 
            this.tabPageTestOne.Controls.Add(this.uiTestItemEight);
            this.tabPageTestOne.Controls.Add(this.uiTestItemRotate);
            this.tabPageTestOne.Controls.Add(this.uiTitlePanel1);
            this.tabPageTestOne.Controls.Add(this.txtSpeed);
            this.tabPageTestOne.Controls.Add(this.uiTextBox3);
            this.tabPageTestOne.Controls.Add(this.labTimeLength);
            this.tabPageTestOne.Controls.Add(this.labFlyHeight);
            this.tabPageTestOne.Controls.Add(this.labSpeed);
            this.tabPageTestOne.Controls.Add(this.txtAngleSpeed);
            this.tabPageTestOne.Controls.Add(this.labPhiOffset);
            this.tabPageTestOne.Controls.Add(this.uiLabel80);
            this.tabPageTestOne.Controls.Add(this.labAngleSpeed);
            this.tabPageTestOne.Controls.Add(this.txtFlyHeight);
            this.tabPageTestOne.Controls.Add(this.labHOffset);
            this.tabPageTestOne.Controls.Add(this.uiLabel79);
            this.tabPageTestOne.Controls.Add(this.labVOffset);
            this.tabPageTestOne.Controls.Add(this.uiLabel75);
            this.tabPageTestOne.Controls.Add(this.txtDistance);
            this.tabPageTestOne.Controls.Add(this.uiLabel74);
            this.tabPageTestOne.Controls.Add(this.uiLabel68);
            this.tabPageTestOne.Controls.Add(this.uiLabel69);
            this.tabPageTestOne.Controls.Add(this.uiLabel87);
            this.tabPageTestOne.Controls.Add(this.listTestProject2);
            this.tabPageTestOne.Controls.Add(this.uiLabel86);
            this.tabPageTestOne.Controls.Add(this.listTestType2);
            this.tabPageTestOne.Controls.Add(this.uiLabel85);
            this.tabPageTestOne.Controls.Add(this.txtTimeLength);
            this.tabPageTestOne.Controls.Add(this.uiLabel84);
            this.tabPageTestOne.Controls.Add(this.uiLabel83);
            this.tabPageTestOne.Controls.Add(this.uiLabel81);
            this.tabPageTestOne.Controls.Add(this.uiLabel70);
            this.tabPageTestOne.Controls.Add(this.txtPhiOffset);
            this.tabPageTestOne.Controls.Add(this.uiLabel71);
            this.tabPageTestOne.Controls.Add(this.uiLabel72);
            this.tabPageTestOne.Controls.Add(this.uiLabel73);
            this.tabPageTestOne.Controls.Add(this.txtVOffset);
            this.tabPageTestOne.Controls.Add(this.txtHOffset);
            this.tabPageTestOne.Controls.Add(this.uiLabel76);
            this.tabPageTestOne.Controls.Add(this.uiLabel77);
            this.tabPageTestOne.Controls.Add(this.uiLabel78);
            this.tabPageTestOne.Controls.Add(this.btnTestStop);
            this.tabPageTestOne.Controls.Add(this.btnTestStart);
            this.tabPageTestOne.Controls.Add(this.uiLine7);
            this.tabPageTestOne.Controls.Add(this.uiLine6);
            this.tabPageTestOne.ImageKey = "paperplane.png";
            this.tabPageTestOne.Location = new System.Drawing.Point(4, 58);
            this.tabPageTestOne.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageTestOne.Name = "tabPageTestOne";
            this.tabPageTestOne.Size = new System.Drawing.Size(315, 686);
            this.tabPageTestOne.TabIndex = 2;
            this.tabPageTestOne.Text = "单项训练";
            this.tabPageTestOne.UseVisualStyleBackColor = true;
            this.tabPageTestOne.Enter += new System.EventHandler(this.tabPageTestOne_Enter);
            // 
            // uiTestItemEight
            // 
            this.uiTestItemEight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiTestItemEight.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTestItemEight.Location = new System.Drawing.Point(165, 388);
            this.uiTestItemEight.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTestItemEight.Name = "uiTestItemEight";
            this.uiTestItemEight.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiTestItemEight.Size = new System.Drawing.Size(150, 29);
            this.uiTestItemEight.TabIndex = 195;
            this.uiTestItemEight.Text = "八字练习项目";
            this.uiTestItemEight.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiTestItemEight.CheckedChanged += new System.EventHandler(this.uiTestItem_CheckedChanged);
            // 
            // uiTestItemRotate
            // 
            this.uiTestItemRotate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiTestItemRotate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTestItemRotate.Location = new System.Drawing.Point(12, 388);
            this.uiTestItemRotate.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTestItemRotate.Name = "uiTestItemRotate";
            this.uiTestItemRotate.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiTestItemRotate.Size = new System.Drawing.Size(150, 29);
            this.uiTestItemRotate.TabIndex = 195;
            this.uiTestItemRotate.Text = "自旋练习项目";
            this.uiTestItemRotate.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiTestItemRotate.CheckedChanged += new System.EventHandler(this.uiTestItem_CheckedChanged);
            // 
            // uiTitlePanel1
            // 
            this.uiTitlePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiTitlePanel1.AutoScroll = true;
            this.uiTitlePanel1.Controls.Add(this.listTextResult);
            this.uiTitlePanel1.FillColor = System.Drawing.Color.Black;
            this.uiTitlePanel1.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTitlePanel1.Location = new System.Drawing.Point(0, 425);
            this.uiTitlePanel1.Margin = new System.Windows.Forms.Padding(0);
            this.uiTitlePanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel1.Name = "uiTitlePanel1";
            this.uiTitlePanel1.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.uiTitlePanel1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiTitlePanel1.ShowText = false;
            this.uiTitlePanel1.Size = new System.Drawing.Size(315, 261);
            this.uiTitlePanel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTitlePanel1.TabIndex = 194;
            this.uiTitlePanel1.Text = "练习成绩";
            this.uiTitlePanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTitlePanel1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiTitlePanel1.TitleHeight = 30;
            this.uiTitlePanel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // listTextResult
            // 
            this.listTextResult.BackColor = System.Drawing.SystemColors.ControlText;
            this.listTextResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listTextResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listTextResult.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listTextResult.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listTextResult.FormattingEnabled = true;
            this.listTextResult.ItemHeight = 19;
            this.listTextResult.Location = new System.Drawing.Point(0, 35);
            this.listTextResult.Margin = new System.Windows.Forms.Padding(0);
            this.listTextResult.Name = "listTextResult";
            this.listTextResult.Size = new System.Drawing.Size(315, 226);
            this.listTextResult.TabIndex = 89;
            this.listTextResult.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listTextResult_DrawItem);
            // 
            // txtSpeed
            // 
            this.txtSpeed.CanEmpty = true;
            this.txtSpeed.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSpeed.DoubleValue = 0.5D;
            this.txtSpeed.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSpeed.Location = new System.Drawing.Point(81, 319);
            this.txtSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSpeed.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Padding = new System.Windows.Forms.Padding(5);
            this.txtSpeed.ShowText = false;
            this.txtSpeed.Size = new System.Drawing.Size(81, 23);
            this.txtSpeed.Style = Sunny.UI.UIStyle.Custom;
            this.txtSpeed.TabIndex = 167;
            this.txtSpeed.Text = "0.50";
            this.txtSpeed.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtSpeed.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtSpeed.Watermark = "";
            this.txtSpeed.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTextBox3
            // 
            this.uiTextBox3.CanEmpty = true;
            this.uiTextBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox3.Enabled = false;
            this.uiTextBox3.FillColor = System.Drawing.Color.Gainsboro;
            this.uiTextBox3.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox3.Location = new System.Drawing.Point(197, 135);
            this.uiTextBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTextBox3.Name = "uiTextBox3";
            this.uiTextBox3.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox3.Radius = 20;
            this.uiTextBox3.ReadOnly = true;
            this.uiTextBox3.RectColor = System.Drawing.Color.Silver;
            this.uiTextBox3.ShowText = false;
            this.uiTextBox3.Size = new System.Drawing.Size(109, 23);
            this.uiTextBox3.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBox3.TabIndex = 164;
            this.uiTextBox3.Text = "0.00";
            this.uiTextBox3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBox3.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.uiTextBox3.Watermark = "";
            this.uiTextBox3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // labTimeLength
            // 
            this.labTimeLength.CanEmpty = true;
            this.labTimeLength.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.labTimeLength.DoubleValue = 1D;
            this.labTimeLength.Enabled = false;
            this.labTimeLength.FillColor = System.Drawing.Color.Gainsboro;
            this.labTimeLength.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTimeLength.Location = new System.Drawing.Point(197, 354);
            this.labTimeLength.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labTimeLength.MinimumSize = new System.Drawing.Size(1, 1);
            this.labTimeLength.Name = "labTimeLength";
            this.labTimeLength.Padding = new System.Windows.Forms.Padding(5);
            this.labTimeLength.Radius = 20;
            this.labTimeLength.ReadOnly = true;
            this.labTimeLength.RectColor = System.Drawing.Color.Silver;
            this.labTimeLength.ShowText = false;
            this.labTimeLength.Size = new System.Drawing.Size(109, 23);
            this.labTimeLength.Style = Sunny.UI.UIStyle.Custom;
            this.labTimeLength.TabIndex = 164;
            this.labTimeLength.Text = "1.00";
            this.labTimeLength.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.labTimeLength.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.labTimeLength.Watermark = "";
            this.labTimeLength.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // labFlyHeight
            // 
            this.labFlyHeight.CanEmpty = true;
            this.labFlyHeight.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.labFlyHeight.DoubleValue = 1D;
            this.labFlyHeight.Enabled = false;
            this.labFlyHeight.FillColor = System.Drawing.Color.Gainsboro;
            this.labFlyHeight.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labFlyHeight.Location = new System.Drawing.Point(197, 166);
            this.labFlyHeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labFlyHeight.MinimumSize = new System.Drawing.Size(1, 1);
            this.labFlyHeight.Name = "labFlyHeight";
            this.labFlyHeight.Padding = new System.Windows.Forms.Padding(5);
            this.labFlyHeight.Radius = 20;
            this.labFlyHeight.ReadOnly = true;
            this.labFlyHeight.RectColor = System.Drawing.Color.Silver;
            this.labFlyHeight.ShowText = false;
            this.labFlyHeight.Size = new System.Drawing.Size(109, 23);
            this.labFlyHeight.Style = Sunny.UI.UIStyle.Custom;
            this.labFlyHeight.TabIndex = 163;
            this.labFlyHeight.Text = "1.00";
            this.labFlyHeight.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.labFlyHeight.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.labFlyHeight.Watermark = "";
            this.labFlyHeight.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // labSpeed
            // 
            this.labSpeed.CanEmpty = true;
            this.labSpeed.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.labSpeed.DoubleValue = 1D;
            this.labSpeed.Enabled = false;
            this.labSpeed.FillColor = System.Drawing.Color.Gainsboro;
            this.labSpeed.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labSpeed.Location = new System.Drawing.Point(197, 318);
            this.labSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labSpeed.MinimumSize = new System.Drawing.Size(1, 1);
            this.labSpeed.Name = "labSpeed";
            this.labSpeed.Padding = new System.Windows.Forms.Padding(5);
            this.labSpeed.Radius = 20;
            this.labSpeed.ReadOnly = true;
            this.labSpeed.RectColor = System.Drawing.Color.Silver;
            this.labSpeed.ShowText = false;
            this.labSpeed.Size = new System.Drawing.Size(109, 23);
            this.labSpeed.Style = Sunny.UI.UIStyle.Custom;
            this.labSpeed.TabIndex = 164;
            this.labSpeed.Text = "1.00";
            this.labSpeed.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.labSpeed.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.labSpeed.Watermark = "";
            this.labSpeed.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtAngleSpeed
            // 
            this.txtAngleSpeed.CanEmpty = true;
            this.txtAngleSpeed.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAngleSpeed.DoubleValue = 10D;
            this.txtAngleSpeed.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAngleSpeed.Location = new System.Drawing.Point(81, 258);
            this.txtAngleSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAngleSpeed.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtAngleSpeed.Name = "txtAngleSpeed";
            this.txtAngleSpeed.Padding = new System.Windows.Forms.Padding(5);
            this.txtAngleSpeed.ShowText = false;
            this.txtAngleSpeed.Size = new System.Drawing.Size(81, 23);
            this.txtAngleSpeed.Style = Sunny.UI.UIStyle.Custom;
            this.txtAngleSpeed.TabIndex = 171;
            this.txtAngleSpeed.Text = "10.00";
            this.txtAngleSpeed.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtAngleSpeed.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtAngleSpeed.Watermark = "";
            this.txtAngleSpeed.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // labPhiOffset
            // 
            this.labPhiOffset.CanEmpty = true;
            this.labPhiOffset.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.labPhiOffset.DoubleValue = 1D;
            this.labPhiOffset.Enabled = false;
            this.labPhiOffset.FillColor = System.Drawing.Color.Gainsboro;
            this.labPhiOffset.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPhiOffset.Location = new System.Drawing.Point(197, 286);
            this.labPhiOffset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labPhiOffset.MinimumSize = new System.Drawing.Size(1, 1);
            this.labPhiOffset.Name = "labPhiOffset";
            this.labPhiOffset.Padding = new System.Windows.Forms.Padding(5);
            this.labPhiOffset.Radius = 20;
            this.labPhiOffset.ReadOnly = true;
            this.labPhiOffset.RectColor = System.Drawing.Color.Silver;
            this.labPhiOffset.ShowText = false;
            this.labPhiOffset.Size = new System.Drawing.Size(109, 23);
            this.labPhiOffset.Style = Sunny.UI.UIStyle.Custom;
            this.labPhiOffset.TabIndex = 164;
            this.labPhiOffset.Text = "1.00";
            this.labPhiOffset.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.labPhiOffset.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.labPhiOffset.Watermark = "";
            this.labPhiOffset.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel80
            // 
            this.uiLabel80.AutoSize = true;
            this.uiLabel80.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel80.Location = new System.Drawing.Point(164, 261);
            this.uiLabel80.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel80.Name = "uiLabel80";
            this.uiLabel80.Size = new System.Drawing.Size(26, 19);
            this.uiLabel80.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel80.TabIndex = 170;
            this.uiLabel80.Text = "°/s";
            this.uiLabel80.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel80.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // labAngleSpeed
            // 
            this.labAngleSpeed.CanEmpty = true;
            this.labAngleSpeed.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.labAngleSpeed.DoubleValue = 1D;
            this.labAngleSpeed.Enabled = false;
            this.labAngleSpeed.FillColor = System.Drawing.Color.Gainsboro;
            this.labAngleSpeed.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labAngleSpeed.Location = new System.Drawing.Point(197, 256);
            this.labAngleSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labAngleSpeed.MinimumSize = new System.Drawing.Size(1, 1);
            this.labAngleSpeed.Name = "labAngleSpeed";
            this.labAngleSpeed.Padding = new System.Windows.Forms.Padding(5);
            this.labAngleSpeed.Radius = 20;
            this.labAngleSpeed.ReadOnly = true;
            this.labAngleSpeed.RectColor = System.Drawing.Color.Silver;
            this.labAngleSpeed.ShowText = false;
            this.labAngleSpeed.Size = new System.Drawing.Size(109, 23);
            this.labAngleSpeed.Style = Sunny.UI.UIStyle.Custom;
            this.labAngleSpeed.TabIndex = 164;
            this.labAngleSpeed.Text = "1.00";
            this.labAngleSpeed.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.labAngleSpeed.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.labAngleSpeed.Watermark = "";
            this.labAngleSpeed.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtFlyHeight
            // 
            this.txtFlyHeight.CanEmpty = true;
            this.txtFlyHeight.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFlyHeight.DoubleValue = 0.5D;
            this.txtFlyHeight.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFlyHeight.Location = new System.Drawing.Point(81, 168);
            this.txtFlyHeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFlyHeight.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtFlyHeight.Name = "txtFlyHeight";
            this.txtFlyHeight.Padding = new System.Windows.Forms.Padding(5);
            this.txtFlyHeight.ShowText = false;
            this.txtFlyHeight.Size = new System.Drawing.Size(81, 23);
            this.txtFlyHeight.Style = Sunny.UI.UIStyle.Custom;
            this.txtFlyHeight.TabIndex = 166;
            this.txtFlyHeight.Text = "0.50";
            this.txtFlyHeight.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtFlyHeight.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtFlyHeight.Watermark = "";
            this.txtFlyHeight.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // labHOffset
            // 
            this.labHOffset.CanEmpty = true;
            this.labHOffset.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.labHOffset.DoubleValue = 1D;
            this.labHOffset.Enabled = false;
            this.labHOffset.FillColor = System.Drawing.Color.Gainsboro;
            this.labHOffset.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labHOffset.Location = new System.Drawing.Point(197, 225);
            this.labHOffset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labHOffset.MinimumSize = new System.Drawing.Size(1, 1);
            this.labHOffset.Name = "labHOffset";
            this.labHOffset.Padding = new System.Windows.Forms.Padding(5);
            this.labHOffset.Radius = 20;
            this.labHOffset.ReadOnly = true;
            this.labHOffset.RectColor = System.Drawing.Color.Silver;
            this.labHOffset.ShowText = false;
            this.labHOffset.Size = new System.Drawing.Size(109, 23);
            this.labHOffset.Style = Sunny.UI.UIStyle.Custom;
            this.labHOffset.TabIndex = 164;
            this.labHOffset.Text = "1.00";
            this.labHOffset.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.labHOffset.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.labHOffset.Watermark = "";
            this.labHOffset.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel79
            // 
            this.uiLabel79.AutoSize = true;
            this.uiLabel79.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel79.Location = new System.Drawing.Point(2, 260);
            this.uiLabel79.Name = "uiLabel79";
            this.uiLabel79.Size = new System.Drawing.Size(74, 19);
            this.uiLabel79.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel79.TabIndex = 168;
            this.uiLabel79.Text = "飞行角速度";
            this.uiLabel79.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel79.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // labVOffset
            // 
            this.labVOffset.CanEmpty = true;
            this.labVOffset.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.labVOffset.DoubleValue = 1D;
            this.labVOffset.Enabled = false;
            this.labVOffset.FillColor = System.Drawing.Color.Gainsboro;
            this.labVOffset.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labVOffset.Location = new System.Drawing.Point(197, 196);
            this.labVOffset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labVOffset.MinimumSize = new System.Drawing.Size(1, 1);
            this.labVOffset.Name = "labVOffset";
            this.labVOffset.Padding = new System.Windows.Forms.Padding(5);
            this.labVOffset.Radius = 20;
            this.labVOffset.ReadOnly = true;
            this.labVOffset.RectColor = System.Drawing.Color.Silver;
            this.labVOffset.ShowText = false;
            this.labVOffset.Size = new System.Drawing.Size(109, 23);
            this.labVOffset.Style = Sunny.UI.UIStyle.Custom;
            this.labVOffset.TabIndex = 164;
            this.labVOffset.Text = "1.00";
            this.labVOffset.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.labVOffset.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.labVOffset.Watermark = "";
            this.labVOffset.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel75
            // 
            this.uiLabel75.AutoSize = true;
            this.uiLabel75.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel75.ForeColor = System.Drawing.Color.Black;
            this.uiLabel75.Location = new System.Drawing.Point(164, 171);
            this.uiLabel75.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel75.Name = "uiLabel75";
            this.uiLabel75.Size = new System.Drawing.Size(22, 19);
            this.uiLabel75.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel75.TabIndex = 164;
            this.uiLabel75.Text = "米";
            this.uiLabel75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel75.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtDistance
            // 
            this.txtDistance.CanEmpty = true;
            this.txtDistance.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDistance.DoubleValue = 1D;
            this.txtDistance.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDistance.Location = new System.Drawing.Point(82, 137);
            this.txtDistance.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDistance.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Padding = new System.Windows.Forms.Padding(5);
            this.txtDistance.ShowText = false;
            this.txtDistance.Size = new System.Drawing.Size(81, 23);
            this.txtDistance.Style = Sunny.UI.UIStyle.Custom;
            this.txtDistance.TabIndex = 162;
            this.txtDistance.Text = "1.00";
            this.txtDistance.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtDistance.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtDistance.Watermark = "";
            this.txtDistance.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel74
            // 
            this.uiLabel74.AutoSize = true;
            this.uiLabel74.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel74.ForeColor = System.Drawing.Color.Black;
            this.uiLabel74.Location = new System.Drawing.Point(15, 171);
            this.uiLabel74.Name = "uiLabel74";
            this.uiLabel74.Size = new System.Drawing.Size(61, 19);
            this.uiLabel74.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel74.TabIndex = 163;
            this.uiLabel74.Text = "飞行高度";
            this.uiLabel74.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel74.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel68
            // 
            this.uiLabel68.AutoSize = true;
            this.uiLabel68.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel68.ForeColor = System.Drawing.Color.Black;
            this.uiLabel68.Location = new System.Drawing.Point(2, 141);
            this.uiLabel68.Name = "uiLabel68";
            this.uiLabel68.Size = new System.Drawing.Size(74, 19);
            this.uiLabel68.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel68.TabIndex = 192;
            this.uiLabel68.Text = "中心点距离";
            this.uiLabel68.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel68.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel69
            // 
            this.uiLabel69.AutoSize = true;
            this.uiLabel69.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel69.ForeColor = System.Drawing.Color.Black;
            this.uiLabel69.Location = new System.Drawing.Point(164, 141);
            this.uiLabel69.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel69.Name = "uiLabel69";
            this.uiLabel69.Size = new System.Drawing.Size(22, 19);
            this.uiLabel69.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel69.TabIndex = 193;
            this.uiLabel69.Text = "米";
            this.uiLabel69.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel69.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel87
            // 
            this.uiLabel87.AutoSize = true;
            this.uiLabel87.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel87.Location = new System.Drawing.Point(20, 61);
            this.uiLabel87.Name = "uiLabel87";
            this.uiLabel87.Size = new System.Drawing.Size(61, 19);
            this.uiLabel87.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel87.TabIndex = 190;
            this.uiLabel87.Text = "训练项目";
            this.uiLabel87.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel87.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // listTestProject2
            // 
            this.listTestProject2.DataSource = null;
            this.listTestProject2.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.listTestProject2.DropDownWidth = 200;
            this.listTestProject2.FillColor = System.Drawing.Color.White;
            this.listTestProject2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.listTestProject2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listTestProject2.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.listTestProject2.Items.AddRange(new object[] {
            "自由练习",
            "自旋练习",
            "八字练习",
            "模拟考试(全科目)"});
            this.listTestProject2.Location = new System.Drawing.Point(88, 57);
            this.listTestProject2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listTestProject2.MinimumSize = new System.Drawing.Size(63, 0);
            this.listTestProject2.Name = "listTestProject2";
            this.listTestProject2.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.listTestProject2.Size = new System.Drawing.Size(218, 25);
            this.listTestProject2.Style = Sunny.UI.UIStyle.Custom;
            this.listTestProject2.TabIndex = 189;
            this.listTestProject2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.listTestProject2.Watermark = "";
            this.listTestProject2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.listTestProject2.SelectedIndexChanged += new System.EventHandler(this.listTestProject2_SelectedIndexChanged);
            // 
            // uiLabel86
            // 
            this.uiLabel86.AutoSize = true;
            this.uiLabel86.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel86.Location = new System.Drawing.Point(17, 28);
            this.uiLabel86.Name = "uiLabel86";
            this.uiLabel86.Size = new System.Drawing.Size(61, 19);
            this.uiLabel86.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel86.TabIndex = 188;
            this.uiLabel86.Text = "考试类型";
            this.uiLabel86.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel86.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // listTestType2
            // 
            this.listTestType2.DataSource = null;
            this.listTestType2.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.listTestType2.DropDownWidth = 300;
            this.listTestType2.FillColor = System.Drawing.Color.White;
            this.listTestType2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.listTestType2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listTestType2.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.listTestType2.Items.AddRange(new object[] {
            "多旋翼无人机-驾驶员",
            "多旋翼无人机-机长",
            "多旋翼无人机-教员"});
            this.listTestType2.Location = new System.Drawing.Point(88, 22);
            this.listTestType2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listTestType2.MinimumSize = new System.Drawing.Size(63, 0);
            this.listTestType2.Name = "listTestType2";
            this.listTestType2.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.listTestType2.Size = new System.Drawing.Size(218, 25);
            this.listTestType2.Style = Sunny.UI.UIStyle.Custom;
            this.listTestType2.TabIndex = 187;
            this.listTestType2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.listTestType2.Watermark = "";
            this.listTestType2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.listTestType2.SelectedIndexChanged += new System.EventHandler(this.listTestType2_SelectedIndexChanged);
            // 
            // uiLabel85
            // 
            this.uiLabel85.AutoSize = true;
            this.uiLabel85.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel85.ForeColor = System.Drawing.Color.Black;
            this.uiLabel85.Location = new System.Drawing.Point(165, 359);
            this.uiLabel85.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel85.Name = "uiLabel85";
            this.uiLabel85.Size = new System.Drawing.Size(22, 19);
            this.uiLabel85.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel85.TabIndex = 186;
            this.uiLabel85.Text = "秒";
            this.uiLabel85.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel85.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtTimeLength
            // 
            this.txtTimeLength.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTimeLength.ForeColor = System.Drawing.Color.Lime;
            this.txtTimeLength.Location = new System.Drawing.Point(74, 339);
            this.txtTimeLength.Margin = new System.Windows.Forms.Padding(0);
            this.txtTimeLength.Name = "txtTimeLength";
            this.txtTimeLength.Size = new System.Drawing.Size(98, 46);
            this.txtTimeLength.Style = Sunny.UI.UIStyle.Custom;
            this.txtTimeLength.TabIndex = 177;
            this.txtTimeLength.Text = "000";
            this.txtTimeLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtTimeLength.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtTimeLength.Click += new System.EventHandler(this.txtTimeLength_Click);
            // 
            // uiLabel84
            // 
            this.uiLabel84.AutoSize = true;
            this.uiLabel84.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel84.Location = new System.Drawing.Point(16, 359);
            this.uiLabel84.Name = "uiLabel84";
            this.uiLabel84.Size = new System.Drawing.Size(61, 19);
            this.uiLabel84.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel84.TabIndex = 176;
            this.uiLabel84.Text = "训练时长";
            this.uiLabel84.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel84.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel83
            // 
            this.uiLabel83.AutoSize = true;
            this.uiLabel83.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel83.Location = new System.Drawing.Point(140, 342);
            this.uiLabel83.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel83.Name = "uiLabel83";
            this.uiLabel83.Size = new System.Drawing.Size(0, 19);
            this.uiLabel83.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel83.TabIndex = 174;
            this.uiLabel83.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel83.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel81
            // 
            this.uiLabel81.AutoSize = true;
            this.uiLabel81.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel81.ForeColor = System.Drawing.Color.Black;
            this.uiLabel81.Location = new System.Drawing.Point(164, 292);
            this.uiLabel81.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel81.Name = "uiLabel81";
            this.uiLabel81.Size = new System.Drawing.Size(14, 19);
            this.uiLabel81.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel81.TabIndex = 163;
            this.uiLabel81.Text = "°";
            this.uiLabel81.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel81.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel70
            // 
            this.uiLabel70.AutoSize = true;
            this.uiLabel70.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel70.ForeColor = System.Drawing.Color.Black;
            this.uiLabel70.Location = new System.Drawing.Point(15, 202);
            this.uiLabel70.Name = "uiLabel70";
            this.uiLabel70.Size = new System.Drawing.Size(61, 19);
            this.uiLabel70.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel70.TabIndex = 157;
            this.uiLabel70.Text = "垂直偏移";
            this.uiLabel70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel70.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtPhiOffset
            // 
            this.txtPhiOffset.CanEmpty = true;
            this.txtPhiOffset.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhiOffset.DoubleValue = 2D;
            this.txtPhiOffset.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPhiOffset.Location = new System.Drawing.Point(81, 288);
            this.txtPhiOffset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPhiOffset.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtPhiOffset.Name = "txtPhiOffset";
            this.txtPhiOffset.Padding = new System.Windows.Forms.Padding(5);
            this.txtPhiOffset.ShowText = false;
            this.txtPhiOffset.Size = new System.Drawing.Size(81, 23);
            this.txtPhiOffset.Style = Sunny.UI.UIStyle.Custom;
            this.txtPhiOffset.TabIndex = 164;
            this.txtPhiOffset.Text = "2.00";
            this.txtPhiOffset.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtPhiOffset.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtPhiOffset.Watermark = "";
            this.txtPhiOffset.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel71
            // 
            this.uiLabel71.AutoSize = true;
            this.uiLabel71.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel71.ForeColor = System.Drawing.Color.Black;
            this.uiLabel71.Location = new System.Drawing.Point(164, 202);
            this.uiLabel71.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel71.Name = "uiLabel71";
            this.uiLabel71.Size = new System.Drawing.Size(22, 19);
            this.uiLabel71.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel71.TabIndex = 158;
            this.uiLabel71.Text = "米";
            this.uiLabel71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel71.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel72
            // 
            this.uiLabel72.AutoSize = true;
            this.uiLabel72.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel72.ForeColor = System.Drawing.Color.Black;
            this.uiLabel72.Location = new System.Drawing.Point(15, 231);
            this.uiLabel72.Name = "uiLabel72";
            this.uiLabel72.Size = new System.Drawing.Size(61, 19);
            this.uiLabel72.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel72.TabIndex = 159;
            this.uiLabel72.Text = "水平偏移";
            this.uiLabel72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel72.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel73
            // 
            this.uiLabel73.AutoSize = true;
            this.uiLabel73.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel73.ForeColor = System.Drawing.Color.Black;
            this.uiLabel73.Location = new System.Drawing.Point(164, 231);
            this.uiLabel73.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel73.Name = "uiLabel73";
            this.uiLabel73.Size = new System.Drawing.Size(22, 19);
            this.uiLabel73.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel73.TabIndex = 160;
            this.uiLabel73.Text = "米";
            this.uiLabel73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel73.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtVOffset
            // 
            this.txtVOffset.CanEmpty = true;
            this.txtVOffset.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtVOffset.DoubleValue = 1D;
            this.txtVOffset.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVOffset.Location = new System.Drawing.Point(81, 198);
            this.txtVOffset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVOffset.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtVOffset.Name = "txtVOffset";
            this.txtVOffset.Padding = new System.Windows.Forms.Padding(5);
            this.txtVOffset.ShowText = false;
            this.txtVOffset.Size = new System.Drawing.Size(81, 23);
            this.txtVOffset.Style = Sunny.UI.UIStyle.Custom;
            this.txtVOffset.TabIndex = 161;
            this.txtVOffset.Text = "1.00";
            this.txtVOffset.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtVOffset.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtVOffset.Watermark = "";
            this.txtVOffset.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtHOffset
            // 
            this.txtHOffset.CanEmpty = true;
            this.txtHOffset.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHOffset.DoubleValue = 2D;
            this.txtHOffset.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHOffset.Location = new System.Drawing.Point(81, 228);
            this.txtHOffset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHOffset.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtHOffset.Name = "txtHOffset";
            this.txtHOffset.Padding = new System.Windows.Forms.Padding(5);
            this.txtHOffset.ShowText = false;
            this.txtHOffset.Size = new System.Drawing.Size(81, 23);
            this.txtHOffset.Style = Sunny.UI.UIStyle.Custom;
            this.txtHOffset.TabIndex = 162;
            this.txtHOffset.Text = "2.00";
            this.txtHOffset.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtHOffset.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtHOffset.Watermark = "";
            this.txtHOffset.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel76
            // 
            this.uiLabel76.AutoSize = true;
            this.uiLabel76.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel76.Location = new System.Drawing.Point(15, 323);
            this.uiLabel76.Name = "uiLabel76";
            this.uiLabel76.Size = new System.Drawing.Size(61, 19);
            this.uiLabel76.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel76.TabIndex = 167;
            this.uiLabel76.Text = "水平航速";
            this.uiLabel76.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel76.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel77
            // 
            this.uiLabel77.AutoSize = true;
            this.uiLabel77.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel77.ForeColor = System.Drawing.Color.Black;
            this.uiLabel77.Location = new System.Drawing.Point(15, 292);
            this.uiLabel77.Name = "uiLabel77";
            this.uiLabel77.Size = new System.Drawing.Size(61, 19);
            this.uiLabel77.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel77.TabIndex = 165;
            this.uiLabel77.Text = "航向偏移";
            this.uiLabel77.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel77.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel78
            // 
            this.uiLabel78.AutoSize = true;
            this.uiLabel78.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel78.Location = new System.Drawing.Point(164, 323);
            this.uiLabel78.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel78.Name = "uiLabel78";
            this.uiLabel78.Size = new System.Drawing.Size(33, 19);
            this.uiLabel78.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel78.TabIndex = 169;
            this.uiLabel78.Text = "m/s";
            this.uiLabel78.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel78.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnTestStop
            // 
            this.btnTestStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestStop.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTestStop.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btnTestStop.Location = new System.Drawing.Point(207, 90);
            this.btnTestStop.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnTestStop.Name = "btnTestStop";
            this.btnTestStop.Radius = 10;
            this.btnTestStop.RectSelectedColor = System.Drawing.Color.Empty;
            this.btnTestStop.Size = new System.Drawing.Size(99, 24);
            this.btnTestStop.Style = Sunny.UI.UIStyle.Custom;
            this.btnTestStop.StyleCustomMode = true;
            this.btnTestStop.TabIndex = 150;
            this.btnTestStop.Text = "停 止";
            this.btnTestStop.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTestStop.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnTestStop.Click += new System.EventHandler(this.btnTestStop_Click);
            // 
            // btnTestStart
            // 
            this.btnTestStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestStart.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTestStart.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btnTestStart.Location = new System.Drawing.Point(88, 90);
            this.btnTestStart.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnTestStart.Name = "btnTestStart";
            this.btnTestStart.Radius = 10;
            this.btnTestStart.RectSelectedColor = System.Drawing.Color.Empty;
            this.btnTestStart.Size = new System.Drawing.Size(99, 24);
            this.btnTestStart.Style = Sunny.UI.UIStyle.Custom;
            this.btnTestStart.StyleCustomMode = true;
            this.btnTestStart.TabIndex = 148;
            this.btnTestStart.Text = "开 始";
            this.btnTestStart.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTestStart.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnTestStart.Click += new System.EventHandler(this.btnTestStart_Click);
            // 
            // uiLine7
            // 
            this.uiLine7.BackColor = System.Drawing.Color.Transparent;
            this.uiLine7.FillColor = System.Drawing.Color.Transparent;
            this.uiLine7.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine7.ForeColor = System.Drawing.Color.Black;
            this.uiLine7.LineColor = System.Drawing.Color.Gray;
            this.uiLine7.Location = new System.Drawing.Point(6, 119);
            this.uiLine7.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine7.Name = "uiLine7";
            this.uiLine7.Size = new System.Drawing.Size(298, 20);
            this.uiLine7.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine7.TabIndex = 134;
            this.uiLine7.Text = "训练数据";
            this.uiLine7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLine7.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLine6
            // 
            this.uiLine6.BackColor = System.Drawing.Color.Transparent;
            this.uiLine6.FillColor = System.Drawing.Color.Transparent;
            this.uiLine6.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine6.ForeColor = System.Drawing.Color.Black;
            this.uiLine6.LineColor = System.Drawing.Color.Gray;
            this.uiLine6.Location = new System.Drawing.Point(8, 3);
            this.uiLine6.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine6.Name = "uiLine6";
            this.uiLine6.Size = new System.Drawing.Size(298, 20);
            this.uiLine6.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine6.TabIndex = 132;
            this.uiLine6.Text = "考试类型";
            this.uiLine6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLine6.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tabPageTestParam
            // 
            this.tabPageTestParam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabPageTestParam.Controls.Add(this.panel4);
            this.tabPageTestParam.Controls.Add(this.panel5);
            this.tabPageTestParam.Controls.Add(this.listTestType);
            this.tabPageTestParam.Controls.Add(this.uiLine2);
            this.tabPageTestParam.Controls.Add(this.uiLine1);
            this.tabPageTestParam.ImageKey = "params.png";
            this.tabPageTestParam.Location = new System.Drawing.Point(4, 58);
            this.tabPageTestParam.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageTestParam.Name = "tabPageTestParam";
            this.tabPageTestParam.Size = new System.Drawing.Size(315, 686);
            this.tabPageTestParam.TabIndex = 1;
            this.tabPageTestParam.Text = "训练参数设置";
            this.tabPageTestParam.Enter += new System.EventHandler(this.tabPageTestParam_Enter);
            this.tabPageTestParam.Leave += new System.EventHandler(this.tabPageTestParam_Leave);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.uiLine4);
            this.panel4.Controls.Add(this.uiLine3);
            this.panel4.Controls.Add(this.txtTestStartSpeed);
            this.panel4.Controls.Add(this.uiLabel65);
            this.panel4.Controls.Add(this.uiLabel66);
            this.panel4.Controls.Add(this.comRotateStartMode);
            this.panel4.Controls.Add(this.uiLabel1);
            this.panel4.Controls.Add(this.uiLabel3);
            this.panel4.Controls.Add(this.uiLabel5);
            this.panel4.Controls.Add(this.uiLabel4);
            this.panel4.Controls.Add(this.txtRotateVOffset);
            this.panel4.Controls.Add(this.txtRotateHOffset);
            this.panel4.Controls.Add(this.uiLabel9);
            this.panel4.Controls.Add(this.uiLabel8);
            this.panel4.Controls.Add(this.uiLabel13);
            this.panel4.Controls.Add(this.uiLabel7);
            this.panel4.Controls.Add(this.uiLabel12);
            this.panel4.Controls.Add(this.uiLabel6);
            this.panel4.Controls.Add(this.uiLabel11);
            this.panel4.Controls.Add(this.txtRotateMinHeight);
            this.panel4.Controls.Add(this.uiLabel17);
            this.panel4.Controls.Add(this.uiLabel10);
            this.panel4.Controls.Add(this.uiLabel16);
            this.panel4.Controls.Add(this.txtRotateMaxHeight);
            this.panel4.Controls.Add(this.txtRotateMinAngleSpeed);
            this.panel4.Controls.Add(this.txtRotateMaxTime);
            this.panel4.Controls.Add(this.uiLabel15);
            this.panel4.Controls.Add(this.uiLabel14);
            this.panel4.Controls.Add(this.txtRotateMaxAngleSpeed);
            this.panel4.Controls.Add(this.txtRotateMinTime);
            this.panel4.Controls.Add(this.uiLabel18);
            this.panel4.Controls.Add(this.txtTestTimeout);
            this.panel4.Controls.Add(this.uiLabel21);
            this.panel4.Controls.Add(this.uiLabel20);
            this.panel4.Controls.Add(this.txtTestStartAngle);
            this.panel4.Controls.Add(this.uiLabel23);
            this.panel4.Controls.Add(this.uiLabel22);
            this.panel4.Controls.Add(this.txtTestRadOffset);
            this.panel4.Controls.Add(this.uiLabel19);
            this.panel4.Location = new System.Drawing.Point(0, 111);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(317, 291);
            this.panel4.TabIndex = 133;
            // 
            // uiLine4
            // 
            this.uiLine4.BackColor = System.Drawing.Color.Transparent;
            this.uiLine4.FillColor = System.Drawing.Color.Transparent;
            this.uiLine4.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine4.ForeColor = System.Drawing.Color.Black;
            this.uiLine4.LineColor = System.Drawing.Color.Gray;
            this.uiLine4.Location = new System.Drawing.Point(4, 3);
            this.uiLine4.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine4.Name = "uiLine4";
            this.uiLine4.Size = new System.Drawing.Size(298, 20);
            this.uiLine4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine4.TabIndex = 149;
            this.uiLine4.Text = "通用参数";
            this.uiLine4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLine4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLine3
            // 
            this.uiLine3.BackColor = System.Drawing.Color.Transparent;
            this.uiLine3.FillColor = System.Drawing.Color.Transparent;
            this.uiLine3.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine3.ForeColor = System.Drawing.Color.Black;
            this.uiLine3.LineColor = System.Drawing.Color.Gray;
            this.uiLine3.Location = new System.Drawing.Point(4, 98);
            this.uiLine3.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine3.Name = "uiLine3";
            this.uiLine3.Size = new System.Drawing.Size(298, 20);
            this.uiLine3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine3.TabIndex = 148;
            this.uiLine3.Text = "自旋训练参数";
            this.uiLine3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLine3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtTestStartSpeed
            // 
            this.txtTestStartSpeed.ButtonSymbol = 61761;
            this.txtTestStartSpeed.ButtonWidth = 100;
            this.txtTestStartSpeed.CanEmpty = true;
            this.txtTestStartSpeed.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTestStartSpeed.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtTestStartSpeed.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTestStartSpeed.Location = new System.Drawing.Point(232, 58);
            this.txtTestStartSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTestStartSpeed.Maximum = 9D;
            this.txtTestStartSpeed.Minimum = 0D;
            this.txtTestStartSpeed.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtTestStartSpeed.Name = "txtTestStartSpeed";
            this.txtTestStartSpeed.Padding = new System.Windows.Forms.Padding(5);
            this.txtTestStartSpeed.ShowText = false;
            this.txtTestStartSpeed.Size = new System.Drawing.Size(54, 23);
            this.txtTestStartSpeed.Style = Sunny.UI.UIStyle.Custom;
            this.txtTestStartSpeed.TabIndex = 142;
            this.txtTestStartSpeed.Text = "0.00";
            this.txtTestStartSpeed.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtTestStartSpeed.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtTestStartSpeed.Watermark = "水印文字";
            this.txtTestStartSpeed.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel65
            // 
            this.uiLabel65.AutoSize = true;
            this.uiLabel65.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel65.Location = new System.Drawing.Point(167, 61);
            this.uiLabel65.Name = "uiLabel65";
            this.uiLabel65.Size = new System.Drawing.Size(61, 19);
            this.uiLabel65.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel65.TabIndex = 140;
            this.uiLabel65.Text = "启动速度";
            this.uiLabel65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel65.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel66
            // 
            this.uiLabel66.AutoSize = true;
            this.uiLabel66.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel66.Location = new System.Drawing.Point(283, 61);
            this.uiLabel66.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel66.Name = "uiLabel66";
            this.uiLabel66.Size = new System.Drawing.Size(33, 19);
            this.uiLabel66.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel66.TabIndex = 141;
            this.uiLabel66.Text = "m/s";
            this.uiLabel66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel66.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // comRotateStartMode
            // 
            this.comRotateStartMode.DataSource = null;
            this.comRotateStartMode.Enabled = false;
            this.comRotateStartMode.FillColor = System.Drawing.Color.White;
            this.comRotateStartMode.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.comRotateStartMode.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comRotateStartMode.ItemHeight = 20;
            this.comRotateStartMode.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.comRotateStartMode.Items.AddRange(new object[] {
            "进入中心范围启动计时",
            "起飞后启动计时"});
            this.comRotateStartMode.Location = new System.Drawing.Point(8, 254);
            this.comRotateStartMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comRotateStartMode.MinimumSize = new System.Drawing.Size(63, 0);
            this.comRotateStartMode.Name = "comRotateStartMode";
            this.comRotateStartMode.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.comRotateStartMode.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.comRotateStartMode.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom;
            this.comRotateStartMode.Size = new System.Drawing.Size(277, 20);
            this.comRotateStartMode.Style = Sunny.UI.UIStyle.Custom;
            this.comRotateStartMode.SymbolNormal = 61702;
            this.comRotateStartMode.TabIndex = 114;
            this.comRotateStartMode.Text = "进入中心点开始计时";
            this.comRotateStartMode.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.comRotateStartMode.Visible = false;
            this.comRotateStartMode.Watermark = "选择启动模式";
            this.comRotateStartMode.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.Black;
            this.uiLabel1.Location = new System.Drawing.Point(9, 125);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(61, 19);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 81;
            this.uiLabel1.Text = "垂直偏移";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.AutoSize = true;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.ForeColor = System.Drawing.Color.Black;
            this.uiLabel3.Location = new System.Drawing.Point(134, 125);
            this.uiLabel3.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(22, 19);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 82;
            this.uiLabel3.Text = "米";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel5
            // 
            this.uiLabel5.AutoSize = true;
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.ForeColor = System.Drawing.Color.Black;
            this.uiLabel5.Location = new System.Drawing.Point(166, 125);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(61, 19);
            this.uiLabel5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel5.TabIndex = 84;
            this.uiLabel5.Text = "水平偏移";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel4
            // 
            this.uiLabel4.AutoSize = true;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.ForeColor = System.Drawing.Color.Black;
            this.uiLabel4.Location = new System.Drawing.Point(285, 125);
            this.uiLabel4.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(22, 19);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 85;
            this.uiLabel4.Text = "米";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtRotateVOffset
            // 
            this.txtRotateVOffset.ButtonSymbol = 61761;
            this.txtRotateVOffset.ButtonWidth = 100;
            this.txtRotateVOffset.CanEmpty = true;
            this.txtRotateVOffset.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRotateVOffset.DoubleValue = 1D;
            this.txtRotateVOffset.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtRotateVOffset.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRotateVOffset.Location = new System.Drawing.Point(80, 121);
            this.txtRotateVOffset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRotateVOffset.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtRotateVOffset.Name = "txtRotateVOffset";
            this.txtRotateVOffset.Padding = new System.Windows.Forms.Padding(5);
            this.txtRotateVOffset.ShowText = false;
            this.txtRotateVOffset.Size = new System.Drawing.Size(54, 23);
            this.txtRotateVOffset.Style = Sunny.UI.UIStyle.Custom;
            this.txtRotateVOffset.TabIndex = 86;
            this.txtRotateVOffset.Text = "1.00";
            this.txtRotateVOffset.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtRotateVOffset.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtRotateVOffset.Watermark = "";
            this.txtRotateVOffset.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtRotateHOffset
            // 
            this.txtRotateHOffset.ButtonSymbol = 61761;
            this.txtRotateHOffset.ButtonWidth = 100;
            this.txtRotateHOffset.CanEmpty = true;
            this.txtRotateHOffset.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRotateHOffset.DoubleValue = 2D;
            this.txtRotateHOffset.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtRotateHOffset.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRotateHOffset.Location = new System.Drawing.Point(231, 122);
            this.txtRotateHOffset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRotateHOffset.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtRotateHOffset.Name = "txtRotateHOffset";
            this.txtRotateHOffset.Padding = new System.Windows.Forms.Padding(5);
            this.txtRotateHOffset.ShowText = false;
            this.txtRotateHOffset.Size = new System.Drawing.Size(54, 23);
            this.txtRotateHOffset.Style = Sunny.UI.UIStyle.Custom;
            this.txtRotateHOffset.TabIndex = 87;
            this.txtRotateHOffset.Text = "2.00";
            this.txtRotateHOffset.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtRotateHOffset.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtRotateHOffset.Watermark = "";
            this.txtRotateHOffset.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel9
            // 
            this.uiLabel9.AutoSize = true;
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel9.ForeColor = System.Drawing.Color.Black;
            this.uiLabel9.Location = new System.Drawing.Point(9, 158);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(61, 19);
            this.uiLabel9.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel9.TabIndex = 88;
            this.uiLabel9.Text = "最小高度";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel9.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel8
            // 
            this.uiLabel8.AutoSize = true;
            this.uiLabel8.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel8.ForeColor = System.Drawing.Color.Black;
            this.uiLabel8.Location = new System.Drawing.Point(134, 158);
            this.uiLabel8.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(22, 19);
            this.uiLabel8.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel8.TabIndex = 89;
            this.uiLabel8.Text = "米";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel8.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel13
            // 
            this.uiLabel13.AutoSize = true;
            this.uiLabel13.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel13.Location = new System.Drawing.Point(9, 191);
            this.uiLabel13.Name = "uiLabel13";
            this.uiLabel13.Size = new System.Drawing.Size(61, 19);
            this.uiLabel13.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel13.TabIndex = 94;
            this.uiLabel13.Text = "最小时间";
            this.uiLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel13.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel7
            // 
            this.uiLabel7.AutoSize = true;
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel7.ForeColor = System.Drawing.Color.Black;
            this.uiLabel7.Location = new System.Drawing.Point(166, 158);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(61, 19);
            this.uiLabel7.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel7.TabIndex = 90;
            this.uiLabel7.Text = "最大高度";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel7.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel12
            // 
            this.uiLabel12.AutoSize = true;
            this.uiLabel12.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel12.Location = new System.Drawing.Point(134, 191);
            this.uiLabel12.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel12.Name = "uiLabel12";
            this.uiLabel12.Size = new System.Drawing.Size(22, 19);
            this.uiLabel12.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel12.TabIndex = 95;
            this.uiLabel12.Text = "秒";
            this.uiLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel12.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel6
            // 
            this.uiLabel6.AutoSize = true;
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.ForeColor = System.Drawing.Color.Black;
            this.uiLabel6.Location = new System.Drawing.Point(285, 158);
            this.uiLabel6.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(22, 19);
            this.uiLabel6.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel6.TabIndex = 91;
            this.uiLabel6.Text = "米";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel6.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel11
            // 
            this.uiLabel11.AutoSize = true;
            this.uiLabel11.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel11.Location = new System.Drawing.Point(166, 191);
            this.uiLabel11.Name = "uiLabel11";
            this.uiLabel11.Size = new System.Drawing.Size(61, 19);
            this.uiLabel11.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel11.TabIndex = 96;
            this.uiLabel11.Text = "最大时间";
            this.uiLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel11.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtRotateMinHeight
            // 
            this.txtRotateMinHeight.ButtonSymbol = 61761;
            this.txtRotateMinHeight.ButtonWidth = 100;
            this.txtRotateMinHeight.CanEmpty = true;
            this.txtRotateMinHeight.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRotateMinHeight.DoubleValue = 0.5D;
            this.txtRotateMinHeight.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtRotateMinHeight.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRotateMinHeight.Location = new System.Drawing.Point(80, 155);
            this.txtRotateMinHeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRotateMinHeight.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtRotateMinHeight.Name = "txtRotateMinHeight";
            this.txtRotateMinHeight.Padding = new System.Windows.Forms.Padding(5);
            this.txtRotateMinHeight.ShowText = false;
            this.txtRotateMinHeight.Size = new System.Drawing.Size(54, 23);
            this.txtRotateMinHeight.Style = Sunny.UI.UIStyle.Custom;
            this.txtRotateMinHeight.TabIndex = 92;
            this.txtRotateMinHeight.Text = "0.50";
            this.txtRotateMinHeight.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtRotateMinHeight.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtRotateMinHeight.Watermark = "";
            this.txtRotateMinHeight.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel17
            // 
            this.uiLabel17.AutoSize = true;
            this.uiLabel17.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel17.Location = new System.Drawing.Point(3, 224);
            this.uiLabel17.Name = "uiLabel17";
            this.uiLabel17.Size = new System.Drawing.Size(74, 19);
            this.uiLabel17.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel17.TabIndex = 94;
            this.uiLabel17.Text = "最小角速度";
            this.uiLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel17.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel10
            // 
            this.uiLabel10.AutoSize = true;
            this.uiLabel10.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel10.Location = new System.Drawing.Point(285, 191);
            this.uiLabel10.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel10.Name = "uiLabel10";
            this.uiLabel10.Size = new System.Drawing.Size(22, 19);
            this.uiLabel10.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel10.TabIndex = 97;
            this.uiLabel10.Text = "秒";
            this.uiLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel10.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel16
            // 
            this.uiLabel16.AutoSize = true;
            this.uiLabel16.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel16.Location = new System.Drawing.Point(134, 224);
            this.uiLabel16.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel16.Name = "uiLabel16";
            this.uiLabel16.Size = new System.Drawing.Size(26, 19);
            this.uiLabel16.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel16.TabIndex = 95;
            this.uiLabel16.Text = "°/s";
            this.uiLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel16.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtRotateMaxHeight
            // 
            this.txtRotateMaxHeight.ButtonSymbol = 61761;
            this.txtRotateMaxHeight.ButtonWidth = 100;
            this.txtRotateMaxHeight.CanEmpty = true;
            this.txtRotateMaxHeight.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRotateMaxHeight.DoubleValue = 5D;
            this.txtRotateMaxHeight.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtRotateMaxHeight.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRotateMaxHeight.Location = new System.Drawing.Point(231, 155);
            this.txtRotateMaxHeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRotateMaxHeight.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtRotateMaxHeight.Name = "txtRotateMaxHeight";
            this.txtRotateMaxHeight.Padding = new System.Windows.Forms.Padding(5);
            this.txtRotateMaxHeight.ShowText = false;
            this.txtRotateMaxHeight.Size = new System.Drawing.Size(54, 23);
            this.txtRotateMaxHeight.Style = Sunny.UI.UIStyle.Custom;
            this.txtRotateMaxHeight.TabIndex = 93;
            this.txtRotateMaxHeight.Text = "5.00";
            this.txtRotateMaxHeight.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtRotateMaxHeight.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtRotateMaxHeight.Watermark = "";
            this.txtRotateMaxHeight.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtRotateMinAngleSpeed
            // 
            this.txtRotateMinAngleSpeed.ButtonSymbol = 61761;
            this.txtRotateMinAngleSpeed.ButtonWidth = 100;
            this.txtRotateMinAngleSpeed.CanEmpty = true;
            this.txtRotateMinAngleSpeed.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRotateMinAngleSpeed.DoubleValue = 10D;
            this.txtRotateMinAngleSpeed.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtRotateMinAngleSpeed.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRotateMinAngleSpeed.Location = new System.Drawing.Point(80, 221);
            this.txtRotateMinAngleSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRotateMinAngleSpeed.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtRotateMinAngleSpeed.Name = "txtRotateMinAngleSpeed";
            this.txtRotateMinAngleSpeed.Padding = new System.Windows.Forms.Padding(5);
            this.txtRotateMinAngleSpeed.ShowText = false;
            this.txtRotateMinAngleSpeed.Size = new System.Drawing.Size(54, 23);
            this.txtRotateMinAngleSpeed.Style = Sunny.UI.UIStyle.Custom;
            this.txtRotateMinAngleSpeed.TabIndex = 98;
            this.txtRotateMinAngleSpeed.Text = "10.00";
            this.txtRotateMinAngleSpeed.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtRotateMinAngleSpeed.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtRotateMinAngleSpeed.Watermark = "";
            this.txtRotateMinAngleSpeed.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtRotateMaxTime
            // 
            this.txtRotateMaxTime.ButtonSymbol = 61761;
            this.txtRotateMaxTime.ButtonWidth = 100;
            this.txtRotateMaxTime.CanEmpty = true;
            this.txtRotateMaxTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRotateMaxTime.DoubleValue = 30D;
            this.txtRotateMaxTime.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtRotateMaxTime.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRotateMaxTime.IntValue = 30;
            this.txtRotateMaxTime.Location = new System.Drawing.Point(231, 188);
            this.txtRotateMaxTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRotateMaxTime.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtRotateMaxTime.Name = "txtRotateMaxTime";
            this.txtRotateMaxTime.Padding = new System.Windows.Forms.Padding(5);
            this.txtRotateMaxTime.ShowText = false;
            this.txtRotateMaxTime.Size = new System.Drawing.Size(54, 23);
            this.txtRotateMaxTime.Style = Sunny.UI.UIStyle.Custom;
            this.txtRotateMaxTime.TabIndex = 99;
            this.txtRotateMaxTime.Text = "30";
            this.txtRotateMaxTime.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtRotateMaxTime.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtRotateMaxTime.Watermark = "";
            this.txtRotateMaxTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel15
            // 
            this.uiLabel15.AutoSize = true;
            this.uiLabel15.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel15.Location = new System.Drawing.Point(157, 224);
            this.uiLabel15.Name = "uiLabel15";
            this.uiLabel15.Size = new System.Drawing.Size(74, 19);
            this.uiLabel15.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel15.TabIndex = 100;
            this.uiLabel15.Text = "最大角速度";
            this.uiLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel15.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel14
            // 
            this.uiLabel14.AutoSize = true;
            this.uiLabel14.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel14.Location = new System.Drawing.Point(285, 224);
            this.uiLabel14.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel14.Name = "uiLabel14";
            this.uiLabel14.Size = new System.Drawing.Size(26, 19);
            this.uiLabel14.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel14.TabIndex = 101;
            this.uiLabel14.Text = "°/s";
            this.uiLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel14.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtRotateMaxAngleSpeed
            // 
            this.txtRotateMaxAngleSpeed.ButtonSymbol = 61761;
            this.txtRotateMaxAngleSpeed.ButtonWidth = 100;
            this.txtRotateMaxAngleSpeed.CanEmpty = true;
            this.txtRotateMaxAngleSpeed.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRotateMaxAngleSpeed.DoubleValue = 50D;
            this.txtRotateMaxAngleSpeed.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtRotateMaxAngleSpeed.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRotateMaxAngleSpeed.Location = new System.Drawing.Point(231, 221);
            this.txtRotateMaxAngleSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRotateMaxAngleSpeed.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtRotateMaxAngleSpeed.Name = "txtRotateMaxAngleSpeed";
            this.txtRotateMaxAngleSpeed.Padding = new System.Windows.Forms.Padding(5);
            this.txtRotateMaxAngleSpeed.ShowText = false;
            this.txtRotateMaxAngleSpeed.Size = new System.Drawing.Size(54, 23);
            this.txtRotateMaxAngleSpeed.Style = Sunny.UI.UIStyle.Custom;
            this.txtRotateMaxAngleSpeed.TabIndex = 102;
            this.txtRotateMaxAngleSpeed.Text = "50.00";
            this.txtRotateMaxAngleSpeed.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtRotateMaxAngleSpeed.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtRotateMaxAngleSpeed.Watermark = "";
            this.txtRotateMaxAngleSpeed.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtRotateMinTime
            // 
            this.txtRotateMinTime.ButtonSymbol = 61761;
            this.txtRotateMinTime.ButtonWidth = 100;
            this.txtRotateMinTime.CanEmpty = true;
            this.txtRotateMinTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRotateMinTime.DoubleValue = 5D;
            this.txtRotateMinTime.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtRotateMinTime.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRotateMinTime.IntValue = 5;
            this.txtRotateMinTime.Location = new System.Drawing.Point(80, 187);
            this.txtRotateMinTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRotateMinTime.Maximum = 9D;
            this.txtRotateMinTime.Minimum = 0D;
            this.txtRotateMinTime.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtRotateMinTime.Name = "txtRotateMinTime";
            this.txtRotateMinTime.Padding = new System.Windows.Forms.Padding(5);
            this.txtRotateMinTime.ShowText = false;
            this.txtRotateMinTime.Size = new System.Drawing.Size(54, 23);
            this.txtRotateMinTime.Style = Sunny.UI.UIStyle.Custom;
            this.txtRotateMinTime.TabIndex = 103;
            this.txtRotateMinTime.Text = "5";
            this.txtRotateMinTime.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtRotateMinTime.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtRotateMinTime.Watermark = "水印文字";
            this.txtRotateMinTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel18
            // 
            this.uiLabel18.AutoSize = true;
            this.uiLabel18.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel18.Location = new System.Drawing.Point(135, 29);
            this.uiLabel18.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel18.Name = "uiLabel18";
            this.uiLabel18.Size = new System.Drawing.Size(22, 19);
            this.uiLabel18.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel18.TabIndex = 105;
            this.uiLabel18.Text = "秒";
            this.uiLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel18.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtTestTimeout
            // 
            this.txtTestTimeout.ButtonSymbol = 61761;
            this.txtTestTimeout.ButtonWidth = 100;
            this.txtTestTimeout.CanEmpty = true;
            this.txtTestTimeout.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTestTimeout.DoubleValue = 60D;
            this.txtTestTimeout.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtTestTimeout.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTestTimeout.IntValue = 60;
            this.txtTestTimeout.Location = new System.Drawing.Point(81, 25);
            this.txtTestTimeout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTestTimeout.Maximum = 9D;
            this.txtTestTimeout.Minimum = 0D;
            this.txtTestTimeout.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtTestTimeout.Name = "txtTestTimeout";
            this.txtTestTimeout.Padding = new System.Windows.Forms.Padding(5);
            this.txtTestTimeout.ShowText = false;
            this.txtTestTimeout.Size = new System.Drawing.Size(54, 23);
            this.txtTestTimeout.Style = Sunny.UI.UIStyle.Custom;
            this.txtTestTimeout.TabIndex = 106;
            this.txtTestTimeout.Text = "60";
            this.txtTestTimeout.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtTestTimeout.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtTestTimeout.Watermark = "水印文字";
            this.txtTestTimeout.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel21
            // 
            this.uiLabel21.AutoSize = true;
            this.uiLabel21.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel21.Location = new System.Drawing.Point(167, 28);
            this.uiLabel21.Name = "uiLabel21";
            this.uiLabel21.Size = new System.Drawing.Size(61, 19);
            this.uiLabel21.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel21.TabIndex = 107;
            this.uiLabel21.Text = "起始角度";
            this.uiLabel21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel21.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel20
            // 
            this.uiLabel20.AutoSize = true;
            this.uiLabel20.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel20.Location = new System.Drawing.Point(286, 28);
            this.uiLabel20.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel20.Name = "uiLabel20";
            this.uiLabel20.Size = new System.Drawing.Size(14, 19);
            this.uiLabel20.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel20.TabIndex = 108;
            this.uiLabel20.Text = "°";
            this.uiLabel20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel20.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtTestStartAngle
            // 
            this.txtTestStartAngle.ButtonSymbol = 61761;
            this.txtTestStartAngle.ButtonWidth = 100;
            this.txtTestStartAngle.CanEmpty = true;
            this.txtTestStartAngle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTestStartAngle.DoubleValue = 15D;
            this.txtTestStartAngle.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtTestStartAngle.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTestStartAngle.IntValue = 15;
            this.txtTestStartAngle.Location = new System.Drawing.Point(232, 25);
            this.txtTestStartAngle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTestStartAngle.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtTestStartAngle.Name = "txtTestStartAngle";
            this.txtTestStartAngle.Padding = new System.Windows.Forms.Padding(5);
            this.txtTestStartAngle.ShowText = false;
            this.txtTestStartAngle.Size = new System.Drawing.Size(54, 23);
            this.txtTestStartAngle.Style = Sunny.UI.UIStyle.Custom;
            this.txtTestStartAngle.TabIndex = 109;
            this.txtTestStartAngle.Text = "15";
            this.txtTestStartAngle.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtTestStartAngle.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtTestStartAngle.Watermark = "";
            this.txtTestStartAngle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel23
            // 
            this.uiLabel23.AutoSize = true;
            this.uiLabel23.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel23.ForeColor = System.Drawing.Color.Black;
            this.uiLabel23.Location = new System.Drawing.Point(5, 60);
            this.uiLabel23.Name = "uiLabel23";
            this.uiLabel23.Size = new System.Drawing.Size(74, 19);
            this.uiLabel23.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel23.TabIndex = 110;
            this.uiLabel23.Text = "中心点距离";
            this.uiLabel23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel23.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel22
            // 
            this.uiLabel22.AutoSize = true;
            this.uiLabel22.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel22.ForeColor = System.Drawing.Color.Black;
            this.uiLabel22.Location = new System.Drawing.Point(135, 62);
            this.uiLabel22.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel22.Name = "uiLabel22";
            this.uiLabel22.Size = new System.Drawing.Size(22, 19);
            this.uiLabel22.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel22.TabIndex = 111;
            this.uiLabel22.Text = "米";
            this.uiLabel22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel22.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtTestRadOffset
            // 
            this.txtTestRadOffset.ButtonSymbol = 61761;
            this.txtTestRadOffset.ButtonWidth = 100;
            this.txtTestRadOffset.CanEmpty = true;
            this.txtTestRadOffset.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTestRadOffset.DoubleValue = 1D;
            this.txtTestRadOffset.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtTestRadOffset.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTestRadOffset.Location = new System.Drawing.Point(81, 58);
            this.txtTestRadOffset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTestRadOffset.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtTestRadOffset.Name = "txtTestRadOffset";
            this.txtTestRadOffset.Padding = new System.Windows.Forms.Padding(5);
            this.txtTestRadOffset.ShowText = false;
            this.txtTestRadOffset.Size = new System.Drawing.Size(54, 23);
            this.txtTestRadOffset.Style = Sunny.UI.UIStyle.Custom;
            this.txtTestRadOffset.TabIndex = 112;
            this.txtTestRadOffset.Text = "1.00";
            this.txtTestRadOffset.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtTestRadOffset.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtTestRadOffset.Watermark = "";
            this.txtTestRadOffset.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel19
            // 
            this.uiLabel19.AutoSize = true;
            this.uiLabel19.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel19.Location = new System.Drawing.Point(4, 28);
            this.uiLabel19.Name = "uiLabel19";
            this.uiLabel19.Size = new System.Drawing.Size(74, 19);
            this.uiLabel19.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel19.TabIndex = 113;
            this.uiLabel19.Text = "进中心时间";
            this.uiLabel19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel19.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnCancel);
            this.panel5.Controls.Add(this.txtEightMaxAngleSpeed);
            this.panel5.Controls.Add(this.uiLabel40);
            this.panel5.Controls.Add(this.uiLabel41);
            this.panel5.Controls.Add(this.btnTestDataEdit);
            this.panel5.Controls.Add(this.txtEightVOffset);
            this.panel5.Controls.Add(this.btnTestDataSave);
            this.panel5.Controls.Add(this.txtEightMaxSpeed);
            this.panel5.Controls.Add(this.uiLabel39);
            this.panel5.Controls.Add(this.uiLabel38);
            this.panel5.Controls.Add(this.txtEightTimeout);
            this.panel5.Controls.Add(this.uiLabel37);
            this.panel5.Controls.Add(this.uiLabel42);
            this.panel5.Controls.Add(this.uiLabel36);
            this.panel5.Controls.Add(this.uiLabel43);
            this.panel5.Controls.Add(this.txtEightHOffset);
            this.panel5.Controls.Add(this.uiLabel35);
            this.panel5.Controls.Add(this.uiLabel34);
            this.panel5.Controls.Add(this.txtEightPhiCount);
            this.panel5.Controls.Add(this.uiLabel33);
            this.panel5.Controls.Add(this.lable31);
            this.panel5.Controls.Add(this.uiLabel32);
            this.panel5.Controls.Add(this.txtEightMinSpeed);
            this.panel5.Controls.Add(this.uiLabel31);
            this.panel5.Controls.Add(this.txtEightPhiOffset);
            this.panel5.Controls.Add(this.uiLabel30);
            this.panel5.Controls.Add(this.uiLabel24);
            this.panel5.Controls.Add(this.uiLabel29);
            this.panel5.Controls.Add(this.uiLabel25);
            this.panel5.Controls.Add(this.txtEightMinHeight);
            this.panel5.Controls.Add(this.txtEightMinAngleSpeed);
            this.panel5.Controls.Add(this.uiLabel28);
            this.panel5.Controls.Add(this.txtEightMaxHeight);
            this.panel5.Controls.Add(this.uiLabel27);
            this.panel5.Controls.Add(this.uiLabel26);
            this.panel5.Location = new System.Drawing.Point(3, 424);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(313, 240);
            this.panel5.TabIndex = 134;
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btnCancel.Location = new System.Drawing.Point(107, 204);
            this.btnCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Radius = 10;
            this.btnCancel.RectSelectedColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(87, 29);
            this.btnCancel.Style = Sunny.UI.UIStyle.Custom;
            this.btnCancel.StyleCustomMode = true;
            this.btnCancel.TabIndex = 149;
            this.btnCancel.Text = "取 消";
            this.btnCancel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtEightMaxAngleSpeed
            // 
            this.txtEightMaxAngleSpeed.ButtonSymbol = 61761;
            this.txtEightMaxAngleSpeed.ButtonWidth = 100;
            this.txtEightMaxAngleSpeed.CanEmpty = true;
            this.txtEightMaxAngleSpeed.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEightMaxAngleSpeed.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtEightMaxAngleSpeed.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEightMaxAngleSpeed.Location = new System.Drawing.Point(78, 129);
            this.txtEightMaxAngleSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEightMaxAngleSpeed.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtEightMaxAngleSpeed.Name = "txtEightMaxAngleSpeed";
            this.txtEightMaxAngleSpeed.Padding = new System.Windows.Forms.Padding(5);
            this.txtEightMaxAngleSpeed.ShowText = false;
            this.txtEightMaxAngleSpeed.Size = new System.Drawing.Size(54, 23);
            this.txtEightMaxAngleSpeed.Style = Sunny.UI.UIStyle.Custom;
            this.txtEightMaxAngleSpeed.TabIndex = 148;
            this.txtEightMaxAngleSpeed.Text = "0.00";
            this.txtEightMaxAngleSpeed.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtEightMaxAngleSpeed.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtEightMaxAngleSpeed.Visible = false;
            this.txtEightMaxAngleSpeed.Watermark = "";
            this.txtEightMaxAngleSpeed.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel40
            // 
            this.uiLabel40.AutoSize = true;
            this.uiLabel40.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel40.Location = new System.Drawing.Point(1, 132);
            this.uiLabel40.Name = "uiLabel40";
            this.uiLabel40.Size = new System.Drawing.Size(74, 19);
            this.uiLabel40.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel40.TabIndex = 146;
            this.uiLabel40.Text = "最大角速度";
            this.uiLabel40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel40.Visible = false;
            this.uiLabel40.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel41
            // 
            this.uiLabel41.AutoSize = true;
            this.uiLabel41.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel41.Location = new System.Drawing.Point(130, 132);
            this.uiLabel41.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel41.Name = "uiLabel41";
            this.uiLabel41.Size = new System.Drawing.Size(26, 19);
            this.uiLabel41.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel41.TabIndex = 147;
            this.uiLabel41.Text = "°/s";
            this.uiLabel41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel41.Visible = false;
            this.uiLabel41.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnTestDataEdit
            // 
            this.btnTestDataEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestDataEdit.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTestDataEdit.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btnTestDataEdit.Location = new System.Drawing.Point(5, 204);
            this.btnTestDataEdit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnTestDataEdit.Name = "btnTestDataEdit";
            this.btnTestDataEdit.Radius = 10;
            this.btnTestDataEdit.RectSelectedColor = System.Drawing.Color.Empty;
            this.btnTestDataEdit.Size = new System.Drawing.Size(87, 29);
            this.btnTestDataEdit.Style = Sunny.UI.UIStyle.Custom;
            this.btnTestDataEdit.StyleCustomMode = true;
            this.btnTestDataEdit.TabIndex = 147;
            this.btnTestDataEdit.Text = "修改参数";
            this.btnTestDataEdit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTestDataEdit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnTestDataEdit.Click += new System.EventHandler(this.btnTestDataEdit_Click);
            // 
            // txtEightVOffset
            // 
            this.txtEightVOffset.ButtonSymbol = 61761;
            this.txtEightVOffset.ButtonWidth = 100;
            this.txtEightVOffset.CanEmpty = true;
            this.txtEightVOffset.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEightVOffset.DoubleValue = 1D;
            this.txtEightVOffset.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtEightVOffset.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEightVOffset.Location = new System.Drawing.Point(78, 0);
            this.txtEightVOffset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEightVOffset.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtEightVOffset.Name = "txtEightVOffset";
            this.txtEightVOffset.Padding = new System.Windows.Forms.Padding(5);
            this.txtEightVOffset.ShowText = false;
            this.txtEightVOffset.Size = new System.Drawing.Size(54, 23);
            this.txtEightVOffset.Style = Sunny.UI.UIStyle.Custom;
            this.txtEightVOffset.TabIndex = 119;
            this.txtEightVOffset.Text = "1.00";
            this.txtEightVOffset.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtEightVOffset.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtEightVOffset.Watermark = "";
            this.txtEightVOffset.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnTestDataSave
            // 
            this.btnTestDataSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestDataSave.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTestDataSave.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btnTestDataSave.Location = new System.Drawing.Point(209, 204);
            this.btnTestDataSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnTestDataSave.Name = "btnTestDataSave";
            this.btnTestDataSave.Radius = 10;
            this.btnTestDataSave.RectSelectedColor = System.Drawing.Color.Empty;
            this.btnTestDataSave.Size = new System.Drawing.Size(87, 29);
            this.btnTestDataSave.Style = Sunny.UI.UIStyle.Custom;
            this.btnTestDataSave.StyleCustomMode = true;
            this.btnTestDataSave.TabIndex = 146;
            this.btnTestDataSave.Text = "保存参数";
            this.btnTestDataSave.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTestDataSave.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnTestDataSave.Click += new System.EventHandler(this.btnTestDataSave_Click);
            // 
            // txtEightMaxSpeed
            // 
            this.txtEightMaxSpeed.ButtonSymbol = 61761;
            this.txtEightMaxSpeed.ButtonWidth = 100;
            this.txtEightMaxSpeed.CanEmpty = true;
            this.txtEightMaxSpeed.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEightMaxSpeed.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtEightMaxSpeed.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEightMaxSpeed.Location = new System.Drawing.Point(229, 67);
            this.txtEightMaxSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEightMaxSpeed.Maximum = 9D;
            this.txtEightMaxSpeed.Minimum = 0D;
            this.txtEightMaxSpeed.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtEightMaxSpeed.Name = "txtEightMaxSpeed";
            this.txtEightMaxSpeed.Padding = new System.Windows.Forms.Padding(5);
            this.txtEightMaxSpeed.ShowText = false;
            this.txtEightMaxSpeed.Size = new System.Drawing.Size(54, 23);
            this.txtEightMaxSpeed.Style = Sunny.UI.UIStyle.Custom;
            this.txtEightMaxSpeed.TabIndex = 139;
            this.txtEightMaxSpeed.Text = "0.00";
            this.txtEightMaxSpeed.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtEightMaxSpeed.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtEightMaxSpeed.Watermark = "水印文字";
            this.txtEightMaxSpeed.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel39
            // 
            this.uiLabel39.AutoSize = true;
            this.uiLabel39.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel39.ForeColor = System.Drawing.Color.Black;
            this.uiLabel39.Location = new System.Drawing.Point(7, 4);
            this.uiLabel39.Name = "uiLabel39";
            this.uiLabel39.Size = new System.Drawing.Size(61, 19);
            this.uiLabel39.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel39.TabIndex = 115;
            this.uiLabel39.Text = "垂直偏移";
            this.uiLabel39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel39.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel38
            // 
            this.uiLabel38.AutoSize = true;
            this.uiLabel38.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel38.ForeColor = System.Drawing.Color.Black;
            this.uiLabel38.Location = new System.Drawing.Point(131, 4);
            this.uiLabel38.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel38.Name = "uiLabel38";
            this.uiLabel38.Size = new System.Drawing.Size(22, 19);
            this.uiLabel38.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel38.TabIndex = 116;
            this.uiLabel38.Text = "米";
            this.uiLabel38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel38.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtEightTimeout
            // 
            this.txtEightTimeout.ButtonSymbol = 61761;
            this.txtEightTimeout.ButtonWidth = 100;
            this.txtEightTimeout.CanEmpty = true;
            this.txtEightTimeout.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEightTimeout.DoubleValue = 180D;
            this.txtEightTimeout.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtEightTimeout.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEightTimeout.IntValue = 180;
            this.txtEightTimeout.Location = new System.Drawing.Point(229, 163);
            this.txtEightTimeout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEightTimeout.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtEightTimeout.Name = "txtEightTimeout";
            this.txtEightTimeout.Padding = new System.Windows.Forms.Padding(5);
            this.txtEightTimeout.ShowText = false;
            this.txtEightTimeout.Size = new System.Drawing.Size(54, 23);
            this.txtEightTimeout.Style = Sunny.UI.UIStyle.Custom;
            this.txtEightTimeout.TabIndex = 145;
            this.txtEightTimeout.Text = "180";
            this.txtEightTimeout.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtEightTimeout.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtEightTimeout.Watermark = "";
            this.txtEightTimeout.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel37
            // 
            this.uiLabel37.AutoSize = true;
            this.uiLabel37.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel37.ForeColor = System.Drawing.Color.Black;
            this.uiLabel37.Location = new System.Drawing.Point(164, 4);
            this.uiLabel37.Name = "uiLabel37";
            this.uiLabel37.Size = new System.Drawing.Size(61, 19);
            this.uiLabel37.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel37.TabIndex = 117;
            this.uiLabel37.Text = "水平偏移";
            this.uiLabel37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel37.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel42
            // 
            this.uiLabel42.AutoSize = true;
            this.uiLabel42.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel42.Location = new System.Drawing.Point(280, 166);
            this.uiLabel42.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel42.Name = "uiLabel42";
            this.uiLabel42.Size = new System.Drawing.Size(22, 19);
            this.uiLabel42.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel42.TabIndex = 144;
            this.uiLabel42.Text = "秒";
            this.uiLabel42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel42.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel36
            // 
            this.uiLabel36.AutoSize = true;
            this.uiLabel36.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel36.ForeColor = System.Drawing.Color.Black;
            this.uiLabel36.Location = new System.Drawing.Point(283, 4);
            this.uiLabel36.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel36.Name = "uiLabel36";
            this.uiLabel36.Size = new System.Drawing.Size(22, 19);
            this.uiLabel36.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel36.TabIndex = 118;
            this.uiLabel36.Text = "米";
            this.uiLabel36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel36.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel43
            // 
            this.uiLabel43.AutoSize = true;
            this.uiLabel43.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel43.Location = new System.Drawing.Point(164, 166);
            this.uiLabel43.Name = "uiLabel43";
            this.uiLabel43.Size = new System.Drawing.Size(56, 19);
            this.uiLabel43.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel43.TabIndex = 143;
            this.uiLabel43.Text = "8字时间";
            this.uiLabel43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel43.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtEightHOffset
            // 
            this.txtEightHOffset.ButtonSymbol = 61761;
            this.txtEightHOffset.ButtonWidth = 100;
            this.txtEightHOffset.CanEmpty = true;
            this.txtEightHOffset.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEightHOffset.DoubleValue = 2D;
            this.txtEightHOffset.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtEightHOffset.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEightHOffset.Location = new System.Drawing.Point(229, 1);
            this.txtEightHOffset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEightHOffset.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtEightHOffset.Name = "txtEightHOffset";
            this.txtEightHOffset.Padding = new System.Windows.Forms.Padding(5);
            this.txtEightHOffset.ShowText = false;
            this.txtEightHOffset.Size = new System.Drawing.Size(54, 23);
            this.txtEightHOffset.Style = Sunny.UI.UIStyle.Custom;
            this.txtEightHOffset.TabIndex = 120;
            this.txtEightHOffset.Text = "2.00";
            this.txtEightHOffset.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtEightHOffset.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtEightHOffset.Watermark = "";
            this.txtEightHOffset.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel35
            // 
            this.uiLabel35.AutoSize = true;
            this.uiLabel35.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel35.ForeColor = System.Drawing.Color.Black;
            this.uiLabel35.Location = new System.Drawing.Point(7, 37);
            this.uiLabel35.Name = "uiLabel35";
            this.uiLabel35.Size = new System.Drawing.Size(61, 19);
            this.uiLabel35.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel35.TabIndex = 121;
            this.uiLabel35.Text = "最小高度";
            this.uiLabel35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel35.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel34
            // 
            this.uiLabel34.AutoSize = true;
            this.uiLabel34.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel34.ForeColor = System.Drawing.Color.Black;
            this.uiLabel34.Location = new System.Drawing.Point(132, 37);
            this.uiLabel34.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel34.Name = "uiLabel34";
            this.uiLabel34.Size = new System.Drawing.Size(22, 19);
            this.uiLabel34.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel34.TabIndex = 122;
            this.uiLabel34.Text = "米";
            this.uiLabel34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel34.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtEightPhiCount
            // 
            this.txtEightPhiCount.ButtonSymbol = 61761;
            this.txtEightPhiCount.ButtonWidth = 100;
            this.txtEightPhiCount.CanEmpty = true;
            this.txtEightPhiCount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEightPhiCount.DoubleValue = 0.8D;
            this.txtEightPhiCount.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtEightPhiCount.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEightPhiCount.Location = new System.Drawing.Point(229, 133);
            this.txtEightPhiCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEightPhiCount.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtEightPhiCount.Name = "txtEightPhiCount";
            this.txtEightPhiCount.Padding = new System.Windows.Forms.Padding(5);
            this.txtEightPhiCount.ShowText = false;
            this.txtEightPhiCount.Size = new System.Drawing.Size(54, 23);
            this.txtEightPhiCount.Style = Sunny.UI.UIStyle.Custom;
            this.txtEightPhiCount.TabIndex = 140;
            this.txtEightPhiCount.Text = "0.80";
            this.txtEightPhiCount.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtEightPhiCount.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtEightPhiCount.Watermark = "";
            this.txtEightPhiCount.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel33
            // 
            this.uiLabel33.AutoSize = true;
            this.uiLabel33.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel33.Location = new System.Drawing.Point(7, 70);
            this.uiLabel33.Name = "uiLabel33";
            this.uiLabel33.Size = new System.Drawing.Size(61, 19);
            this.uiLabel33.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel33.TabIndex = 128;
            this.uiLabel33.Text = "最小速度";
            this.uiLabel33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel33.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lable31
            // 
            this.lable31.AutoSize = true;
            this.lable31.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lable31.Location = new System.Drawing.Point(164, 133);
            this.lable31.Name = "lable31";
            this.lable31.Size = new System.Drawing.Size(61, 19);
            this.lable31.Style = Sunny.UI.UIStyle.Custom;
            this.lable31.TabIndex = 139;
            this.lable31.Text = "航向统计";
            this.lable31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lable31.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel32
            // 
            this.uiLabel32.AutoSize = true;
            this.uiLabel32.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel32.ForeColor = System.Drawing.Color.Black;
            this.uiLabel32.Location = new System.Drawing.Point(164, 37);
            this.uiLabel32.Name = "uiLabel32";
            this.uiLabel32.Size = new System.Drawing.Size(61, 19);
            this.uiLabel32.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel32.TabIndex = 123;
            this.uiLabel32.Text = "最大高度";
            this.uiLabel32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel32.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtEightMinSpeed
            // 
            this.txtEightMinSpeed.ButtonSymbol = 61761;
            this.txtEightMinSpeed.ButtonWidth = 100;
            this.txtEightMinSpeed.CanEmpty = true;
            this.txtEightMinSpeed.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEightMinSpeed.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtEightMinSpeed.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEightMinSpeed.Location = new System.Drawing.Point(78, 66);
            this.txtEightMinSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEightMinSpeed.Maximum = 9D;
            this.txtEightMinSpeed.Minimum = 0D;
            this.txtEightMinSpeed.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtEightMinSpeed.Name = "txtEightMinSpeed";
            this.txtEightMinSpeed.Padding = new System.Windows.Forms.Padding(5);
            this.txtEightMinSpeed.ShowText = false;
            this.txtEightMinSpeed.Size = new System.Drawing.Size(54, 23);
            this.txtEightMinSpeed.Style = Sunny.UI.UIStyle.Custom;
            this.txtEightMinSpeed.TabIndex = 138;
            this.txtEightMinSpeed.Text = "0.00";
            this.txtEightMinSpeed.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtEightMinSpeed.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtEightMinSpeed.Watermark = "水印文字";
            this.txtEightMinSpeed.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel31
            // 
            this.uiLabel31.AutoSize = true;
            this.uiLabel31.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel31.Location = new System.Drawing.Point(131, 70);
            this.uiLabel31.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel31.Name = "uiLabel31";
            this.uiLabel31.Size = new System.Drawing.Size(33, 19);
            this.uiLabel31.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel31.TabIndex = 130;
            this.uiLabel31.Text = "m/s";
            this.uiLabel31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel31.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtEightPhiOffset
            // 
            this.txtEightPhiOffset.ButtonSymbol = 61761;
            this.txtEightPhiOffset.ButtonWidth = 100;
            this.txtEightPhiOffset.CanEmpty = true;
            this.txtEightPhiOffset.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEightPhiOffset.DoubleValue = 30D;
            this.txtEightPhiOffset.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtEightPhiOffset.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEightPhiOffset.Location = new System.Drawing.Point(229, 100);
            this.txtEightPhiOffset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEightPhiOffset.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtEightPhiOffset.Name = "txtEightPhiOffset";
            this.txtEightPhiOffset.Padding = new System.Windows.Forms.Padding(5);
            this.txtEightPhiOffset.ShowText = false;
            this.txtEightPhiOffset.Size = new System.Drawing.Size(54, 23);
            this.txtEightPhiOffset.Style = Sunny.UI.UIStyle.Custom;
            this.txtEightPhiOffset.TabIndex = 137;
            this.txtEightPhiOffset.Text = "30.00";
            this.txtEightPhiOffset.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtEightPhiOffset.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtEightPhiOffset.Watermark = "";
            this.txtEightPhiOffset.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel30
            // 
            this.uiLabel30.AutoSize = true;
            this.uiLabel30.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel30.ForeColor = System.Drawing.Color.Black;
            this.uiLabel30.Location = new System.Drawing.Point(283, 37);
            this.uiLabel30.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel30.Name = "uiLabel30";
            this.uiLabel30.Size = new System.Drawing.Size(22, 19);
            this.uiLabel30.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel30.TabIndex = 124;
            this.uiLabel30.Text = "米";
            this.uiLabel30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel30.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel24
            // 
            this.uiLabel24.AutoSize = true;
            this.uiLabel24.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel24.Location = new System.Drawing.Point(282, 103);
            this.uiLabel24.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel24.Name = "uiLabel24";
            this.uiLabel24.Size = new System.Drawing.Size(14, 19);
            this.uiLabel24.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel24.TabIndex = 136;
            this.uiLabel24.Text = "°";
            this.uiLabel24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel24.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel29
            // 
            this.uiLabel29.AutoSize = true;
            this.uiLabel29.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel29.Location = new System.Drawing.Point(164, 70);
            this.uiLabel29.Name = "uiLabel29";
            this.uiLabel29.Size = new System.Drawing.Size(61, 19);
            this.uiLabel29.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel29.TabIndex = 131;
            this.uiLabel29.Text = "最大速度";
            this.uiLabel29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel29.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel25
            // 
            this.uiLabel25.AutoSize = true;
            this.uiLabel25.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel25.Location = new System.Drawing.Point(155, 103);
            this.uiLabel25.Name = "uiLabel25";
            this.uiLabel25.Size = new System.Drawing.Size(74, 19);
            this.uiLabel25.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel25.TabIndex = 135;
            this.uiLabel25.Text = "航向角偏移";
            this.uiLabel25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel25.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtEightMinHeight
            // 
            this.txtEightMinHeight.ButtonSymbol = 61761;
            this.txtEightMinHeight.ButtonWidth = 100;
            this.txtEightMinHeight.CanEmpty = true;
            this.txtEightMinHeight.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEightMinHeight.DoubleValue = 0.5D;
            this.txtEightMinHeight.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtEightMinHeight.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEightMinHeight.Location = new System.Drawing.Point(78, 34);
            this.txtEightMinHeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEightMinHeight.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtEightMinHeight.Name = "txtEightMinHeight";
            this.txtEightMinHeight.Padding = new System.Windows.Forms.Padding(5);
            this.txtEightMinHeight.ShowText = false;
            this.txtEightMinHeight.Size = new System.Drawing.Size(54, 23);
            this.txtEightMinHeight.Style = Sunny.UI.UIStyle.Custom;
            this.txtEightMinHeight.TabIndex = 125;
            this.txtEightMinHeight.Text = "0.50";
            this.txtEightMinHeight.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtEightMinHeight.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtEightMinHeight.Watermark = "";
            this.txtEightMinHeight.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtEightMinAngleSpeed
            // 
            this.txtEightMinAngleSpeed.ButtonSymbol = 61761;
            this.txtEightMinAngleSpeed.ButtonWidth = 100;
            this.txtEightMinAngleSpeed.CanEmpty = true;
            this.txtEightMinAngleSpeed.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEightMinAngleSpeed.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtEightMinAngleSpeed.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEightMinAngleSpeed.Location = new System.Drawing.Point(78, 100);
            this.txtEightMinAngleSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEightMinAngleSpeed.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtEightMinAngleSpeed.Name = "txtEightMinAngleSpeed";
            this.txtEightMinAngleSpeed.Padding = new System.Windows.Forms.Padding(5);
            this.txtEightMinAngleSpeed.ShowText = false;
            this.txtEightMinAngleSpeed.Size = new System.Drawing.Size(54, 23);
            this.txtEightMinAngleSpeed.Style = Sunny.UI.UIStyle.Custom;
            this.txtEightMinAngleSpeed.TabIndex = 133;
            this.txtEightMinAngleSpeed.Text = "0.00";
            this.txtEightMinAngleSpeed.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtEightMinAngleSpeed.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtEightMinAngleSpeed.Watermark = "";
            this.txtEightMinAngleSpeed.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel28
            // 
            this.uiLabel28.AutoSize = true;
            this.uiLabel28.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel28.Location = new System.Drawing.Point(1, 103);
            this.uiLabel28.Name = "uiLabel28";
            this.uiLabel28.Size = new System.Drawing.Size(74, 19);
            this.uiLabel28.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel28.TabIndex = 127;
            this.uiLabel28.Text = "最小角速度";
            this.uiLabel28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel28.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtEightMaxHeight
            // 
            this.txtEightMaxHeight.ButtonSymbol = 61761;
            this.txtEightMaxHeight.ButtonWidth = 100;
            this.txtEightMaxHeight.CanEmpty = true;
            this.txtEightMaxHeight.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEightMaxHeight.DoubleValue = 2D;
            this.txtEightMaxHeight.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.txtEightMaxHeight.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEightMaxHeight.Location = new System.Drawing.Point(229, 34);
            this.txtEightMaxHeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEightMaxHeight.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtEightMaxHeight.Name = "txtEightMaxHeight";
            this.txtEightMaxHeight.Padding = new System.Windows.Forms.Padding(5);
            this.txtEightMaxHeight.ShowText = false;
            this.txtEightMaxHeight.Size = new System.Drawing.Size(54, 23);
            this.txtEightMaxHeight.Style = Sunny.UI.UIStyle.Custom;
            this.txtEightMaxHeight.TabIndex = 126;
            this.txtEightMaxHeight.Text = "2.00";
            this.txtEightMaxHeight.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.txtEightMaxHeight.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtEightMaxHeight.Watermark = "";
            this.txtEightMaxHeight.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel27
            // 
            this.uiLabel27.AutoSize = true;
            this.uiLabel27.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel27.Location = new System.Drawing.Point(280, 70);
            this.uiLabel27.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel27.Name = "uiLabel27";
            this.uiLabel27.Size = new System.Drawing.Size(33, 19);
            this.uiLabel27.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel27.TabIndex = 132;
            this.uiLabel27.Text = "m/s";
            this.uiLabel27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel27.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel26
            // 
            this.uiLabel26.AutoSize = true;
            this.uiLabel26.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel26.Location = new System.Drawing.Point(130, 103);
            this.uiLabel26.Margin = new System.Windows.Forms.Padding(0);
            this.uiLabel26.Name = "uiLabel26";
            this.uiLabel26.Size = new System.Drawing.Size(26, 19);
            this.uiLabel26.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel26.TabIndex = 129;
            this.uiLabel26.Text = "°/s";
            this.uiLabel26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel26.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // listTestType
            // 
            this.listTestType.FillColor = System.Drawing.Color.White;
            this.listTestType.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.listTestType.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listTestType.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.listTestType.Items.AddRange(new object[] {
            "多旋翼无人机-驾驶员",
            "多旋翼无人机-机长",
            "多旋翼无人机-教员"});
            this.listTestType.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.listTestType.Location = new System.Drawing.Point(9, 22);
            this.listTestType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listTestType.MinimumSize = new System.Drawing.Size(1, 1);
            this.listTestType.Name = "listTestType";
            this.listTestType.Padding = new System.Windows.Forms.Padding(2);
            this.listTestType.ShowText = false;
            this.listTestType.Size = new System.Drawing.Size(295, 81);
            this.listTestType.Style = Sunny.UI.UIStyle.Custom;
            this.listTestType.TabIndex = 131;
            this.listTestType.Text = "uiListBox1";
            this.listTestType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.listTestType.SelectedIndexChanged += new System.EventHandler(this.listTestType_SelectedIndexChanged);
            // 
            // uiLine2
            // 
            this.uiLine2.BackColor = System.Drawing.Color.Transparent;
            this.uiLine2.FillColor = System.Drawing.Color.Transparent;
            this.uiLine2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine2.ForeColor = System.Drawing.Color.Black;
            this.uiLine2.LineColor = System.Drawing.Color.Gray;
            this.uiLine2.Location = new System.Drawing.Point(4, 399);
            this.uiLine2.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(298, 20);
            this.uiLine2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine2.TabIndex = 79;
            this.uiLine2.Text = "8字训练参数";
            this.uiLine2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLine2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLine1
            // 
            this.uiLine1.BackColor = System.Drawing.Color.Transparent;
            this.uiLine1.FillColor = System.Drawing.Color.Transparent;
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.ForeColor = System.Drawing.Color.Black;
            this.uiLine1.LineColor = System.Drawing.Color.Gray;
            this.uiLine1.Location = new System.Drawing.Point(10, 3);
            this.uiLine1.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(298, 20);
            this.uiLine1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine1.TabIndex = 78;
            this.uiLine1.Text = "考试类型";
            this.uiLine1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLine1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.cbYawAngleAccum);
            this.tabPage6.Controls.Add(this.uiLine10);
            this.tabPage6.Controls.Add(this.labBuildTime);
            this.tabPage6.Controls.Add(this.labBuildVersion);
            this.tabPage6.Controls.Add(this.uiLabel88);
            this.tabPage6.Controls.Add(this.uiLabel82);
            this.tabPage6.Controls.Add(this.btnDeleteCurrentMap);
            this.tabPage6.Controls.Add(this.btnDeleteAllMap);
            this.tabPage6.Controls.Add(this.uiLabel67);
            this.tabPage6.Controls.Add(this.cbMapProviders);
            this.tabPage6.Controls.Add(this.btnHeightCheck);
            this.tabPage6.Controls.Add(this.btnDiChiCheck);
            this.tabPage6.Controls.Add(this.uiLine9);
            this.tabPage6.Controls.Add(this.uiLine8);
            this.tabPage6.Controls.Add(this.uiLine5);
            this.tabPage6.ImageKey = "settings.png";
            this.tabPage6.Location = new System.Drawing.Point(4, 58);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(315, 686);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "系统配置";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // uiLine10
            // 
            this.uiLine10.BackColor = System.Drawing.Color.Transparent;
            this.uiLine10.FillColor = System.Drawing.Color.Transparent;
            this.uiLine10.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine10.ForeColor = System.Drawing.Color.Black;
            this.uiLine10.LineColor = System.Drawing.Color.Gray;
            this.uiLine10.Location = new System.Drawing.Point(6, 12);
            this.uiLine10.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine10.Name = "uiLine10";
            this.uiLine10.Size = new System.Drawing.Size(298, 20);
            this.uiLine10.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine10.TabIndex = 135;
            this.uiLine10.Text = "关于";
            this.uiLine10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLine10.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // labBuildTime
            // 
            this.labBuildTime.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labBuildTime.Location = new System.Drawing.Point(105, 64);
            this.labBuildTime.Name = "labBuildTime";
            this.labBuildTime.Size = new System.Drawing.Size(199, 29);
            this.labBuildTime.TabIndex = 134;
            this.labBuildTime.Text = "2022-09-01T00:00:00";
            this.labBuildTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labBuildTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // labBuildVersion
            // 
            this.labBuildVersion.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labBuildVersion.Location = new System.Drawing.Point(105, 35);
            this.labBuildVersion.Name = "labBuildVersion";
            this.labBuildVersion.Size = new System.Drawing.Size(199, 29);
            this.labBuildVersion.TabIndex = 134;
            this.labBuildVersion.Text = "1.0.0+148.master-b9c17d3.14";
            this.labBuildVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labBuildVersion.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel88
            // 
            this.uiLabel88.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel88.Location = new System.Drawing.Point(6, 64);
            this.uiLabel88.Name = "uiLabel88";
            this.uiLabel88.Size = new System.Drawing.Size(93, 29);
            this.uiLabel88.TabIndex = 133;
            this.uiLabel88.Text = "发布时间：";
            this.uiLabel88.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel88.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel82
            // 
            this.uiLabel82.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel82.Location = new System.Drawing.Point(6, 35);
            this.uiLabel82.Name = "uiLabel82";
            this.uiLabel82.Size = new System.Drawing.Size(93, 29);
            this.uiLabel82.TabIndex = 133;
            this.uiLabel82.Text = "版本信息：";
            this.uiLabel82.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel82.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnDeleteCurrentMap
            // 
            this.btnDeleteCurrentMap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteCurrentMap.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnDeleteCurrentMap.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnDeleteCurrentMap.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(78)))));
            this.btnDeleteCurrentMap.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(70)))), ((int)(((byte)(28)))));
            this.btnDeleteCurrentMap.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(70)))), ((int)(((byte)(28)))));
            this.btnDeleteCurrentMap.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDeleteCurrentMap.Location = new System.Drawing.Point(32, 418);
            this.btnDeleteCurrentMap.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnDeleteCurrentMap.Name = "btnDeleteCurrentMap";
            this.btnDeleteCurrentMap.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnDeleteCurrentMap.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(78)))));
            this.btnDeleteCurrentMap.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(70)))), ((int)(((byte)(28)))));
            this.btnDeleteCurrentMap.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(70)))), ((int)(((byte)(28)))));
            this.btnDeleteCurrentMap.Size = new System.Drawing.Size(98, 35);
            this.btnDeleteCurrentMap.Style = Sunny.UI.UIStyle.LayuiRed;
            this.btnDeleteCurrentMap.TabIndex = 132;
            this.btnDeleteCurrentMap.Text = "清除离线地图";
            this.btnDeleteCurrentMap.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDeleteCurrentMap.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnDeleteCurrentMap.Click += new System.EventHandler(this.btnDeleteCurrentMap_Click);
            // 
            // btnDeleteAllMap
            // 
            this.btnDeleteAllMap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteAllMap.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnDeleteAllMap.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnDeleteAllMap.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(78)))));
            this.btnDeleteAllMap.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(70)))), ((int)(((byte)(28)))));
            this.btnDeleteAllMap.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(70)))), ((int)(((byte)(28)))));
            this.btnDeleteAllMap.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDeleteAllMap.Location = new System.Drawing.Point(177, 418);
            this.btnDeleteAllMap.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnDeleteAllMap.Name = "btnDeleteAllMap";
            this.btnDeleteAllMap.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnDeleteAllMap.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(78)))));
            this.btnDeleteAllMap.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(70)))), ((int)(((byte)(28)))));
            this.btnDeleteAllMap.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(70)))), ((int)(((byte)(28)))));
            this.btnDeleteAllMap.Size = new System.Drawing.Size(98, 35);
            this.btnDeleteAllMap.Style = Sunny.UI.UIStyle.LayuiRed;
            this.btnDeleteAllMap.TabIndex = 132;
            this.btnDeleteAllMap.Text = "清除所有地图";
            this.btnDeleteAllMap.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDeleteAllMap.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnDeleteAllMap.Click += new System.EventHandler(this.btnDeleteAllMap_Click);
            // 
            // uiLabel67
            // 
            this.uiLabel67.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel67.Location = new System.Drawing.Point(32, 282);
            this.uiLabel67.Name = "uiLabel67";
            this.uiLabel67.Size = new System.Drawing.Size(96, 29);
            this.uiLabel67.TabIndex = 131;
            this.uiLabel67.Text = "地图供应商";
            this.uiLabel67.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel67.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cbMapProviders
            // 
            this.cbMapProviders.DataSource = null;
            this.cbMapProviders.FillColor = System.Drawing.Color.White;
            this.cbMapProviders.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbMapProviders.Items.AddRange(new object[] {
            "高德地图"});
            this.cbMapProviders.Location = new System.Drawing.Point(135, 282);
            this.cbMapProviders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMapProviders.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbMapProviders.Name = "cbMapProviders";
            this.cbMapProviders.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbMapProviders.Size = new System.Drawing.Size(140, 29);
            this.cbMapProviders.TabIndex = 130;
            this.cbMapProviders.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbMapProviders.Watermark = "";
            this.cbMapProviders.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbMapProviders.SelectedIndexChanged += new System.EventHandler(this.cbMapProviders_SelectedIndexChanged);
            // 
            // btnHeightCheck
            // 
            this.btnHeightCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHeightCheck.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHeightCheck.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btnHeightCheck.Location = new System.Drawing.Point(177, 161);
            this.btnHeightCheck.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnHeightCheck.Name = "btnHeightCheck";
            this.btnHeightCheck.Radius = 10;
            this.btnHeightCheck.RectSelectedColor = System.Drawing.Color.Empty;
            this.btnHeightCheck.Size = new System.Drawing.Size(98, 33);
            this.btnHeightCheck.Style = Sunny.UI.UIStyle.Custom;
            this.btnHeightCheck.StyleCustomMode = true;
            this.btnHeightCheck.TabIndex = 129;
            this.btnHeightCheck.Text = "高度校准";
            this.btnHeightCheck.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHeightCheck.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnDiChiCheck
            // 
            this.btnDiChiCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDiChiCheck.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDiChiCheck.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btnDiChiCheck.Location = new System.Drawing.Point(32, 161);
            this.btnDiChiCheck.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnDiChiCheck.Name = "btnDiChiCheck";
            this.btnDiChiCheck.Radius = 10;
            this.btnDiChiCheck.RectSelectedColor = System.Drawing.Color.Empty;
            this.btnDiChiCheck.Size = new System.Drawing.Size(98, 33);
            this.btnDiChiCheck.Style = Sunny.UI.UIStyle.Custom;
            this.btnDiChiCheck.StyleCustomMode = true;
            this.btnDiChiCheck.TabIndex = 128;
            this.btnDiChiCheck.Text = "地磁校准";
            this.btnDiChiCheck.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDiChiCheck.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLine9
            // 
            this.uiLine9.BackColor = System.Drawing.Color.Transparent;
            this.uiLine9.FillColor = System.Drawing.Color.Transparent;
            this.uiLine9.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine9.ForeColor = System.Drawing.Color.Black;
            this.uiLine9.LineColor = System.Drawing.Color.Gray;
            this.uiLine9.Location = new System.Drawing.Point(6, 380);
            this.uiLine9.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine9.Name = "uiLine9";
            this.uiLine9.Size = new System.Drawing.Size(298, 20);
            this.uiLine9.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine9.TabIndex = 127;
            this.uiLine9.Text = "缓存设置";
            this.uiLine9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLine9.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLine8
            // 
            this.uiLine8.BackColor = System.Drawing.Color.Transparent;
            this.uiLine8.FillColor = System.Drawing.Color.Transparent;
            this.uiLine8.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine8.ForeColor = System.Drawing.Color.Black;
            this.uiLine8.LineColor = System.Drawing.Color.Gray;
            this.uiLine8.Location = new System.Drawing.Point(6, 254);
            this.uiLine8.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine8.Name = "uiLine8";
            this.uiLine8.Size = new System.Drawing.Size(298, 20);
            this.uiLine8.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine8.TabIndex = 127;
            this.uiLine8.Text = "地图设置";
            this.uiLine8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLine8.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLine5
            // 
            this.uiLine5.BackColor = System.Drawing.Color.Transparent;
            this.uiLine5.FillColor = System.Drawing.Color.Transparent;
            this.uiLine5.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine5.ForeColor = System.Drawing.Color.Black;
            this.uiLine5.LineColor = System.Drawing.Color.Gray;
            this.uiLine5.Location = new System.Drawing.Point(6, 120);
            this.uiLine5.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine5.Name = "uiLine5";
            this.uiLine5.Size = new System.Drawing.Size(298, 20);
            this.uiLine5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine5.TabIndex = 127;
            this.uiLine5.Text = "无人机设置";
            this.uiLine5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLine5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTextBox2
            // 
            this.uiTextBox2.ButtonSymbol = 61761;
            this.uiTextBox2.ButtonWidth = 100;
            this.uiTextBox2.CanEmpty = true;
            this.uiTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox2.DoubleValue = 300D;
            this.uiTextBox2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiTextBox2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox2.IntValue = 300;
            this.uiTextBox2.Location = new System.Drawing.Point(8, 8);
            this.uiTextBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTextBox2.Name = "uiTextBox2";
            this.uiTextBox2.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox2.ShowText = false;
            this.uiTextBox2.Size = new System.Drawing.Size(47, 23);
            this.uiTextBox2.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBox2.TabIndex = 196;
            this.uiTextBox2.Text = "300";
            this.uiTextBox2.TextAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.uiTextBox2.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.uiTextBox2.Watermark = "";
            this.uiTextBox2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnReConnect
            // 
            this.btnReConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReConnect.BackColor = System.Drawing.Color.Transparent;
            this.btnReConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReConnect.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReConnect.Image = ((System.Drawing.Image)(resources.GetObject("btnReConnect.Image")));
            this.btnReConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReConnect.Location = new System.Drawing.Point(1119, 6);
            this.btnReConnect.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnReConnect.Name = "btnReConnect";
            this.btnReConnect.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.btnReConnect.Radius = 10;
            this.btnReConnect.Size = new System.Drawing.Size(74, 28);
            this.btnReConnect.Style = Sunny.UI.UIStyle.Custom;
            this.btnReConnect.TabIndex = 10;
            this.btnReConnect.Text = "重连";
            this.btnReConnect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReConnect.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReConnect.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnReConnect.Click += new System.EventHandler(this.btnReConnect_Click);
            // 
            // uiLabel2
            // 
            this.uiLabel2.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Image = ((System.Drawing.Image)(resources.GetObject("uiLabel2.Image")));
            this.uiLabel2.Location = new System.Drawing.Point(32, 5);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(153, 32);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 4;
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(540, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 19);
            this.label2.TabIndex = 108;
            this.label2.Text = "位置";
            // 
            // cbYawAngleAccum
            // 
            this.cbYawAngleAccum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbYawAngleAccum.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbYawAngleAccum.Location = new System.Drawing.Point(10, 319);
            this.cbYawAngleAccum.MinimumSize = new System.Drawing.Size(1, 1);
            this.cbYawAngleAccum.Name = "cbYawAngleAccum";
            this.cbYawAngleAccum.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.cbYawAngleAccum.Size = new System.Drawing.Size(150, 29);
            this.cbYawAngleAccum.TabIndex = 136;
            this.cbYawAngleAccum.Text = "开启航向统计判定";
            this.cbYawAngleAccum.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 788);
            this.Controls.Add(this.btnUserName);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.uiProgressIndicator1);
            this.Controls.Add(this.btnReConnect);
            this.Controls.Add(this.uiLabel2);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.materialTabControl1;
            this.DrawerUseColors = true;
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 185);
            this.Name = "formMain";
            this.Opacity = 0D;
            this.Padding = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UAV辅助训练系统";
            this.Load += new System.EventHandler(this.formMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.gMapControlPanel.ResumeLayout(false);
            this.materialTabControl1.ResumeLayout(false);
            this.tabPageTestGround.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPageTestOne.ResumeLayout(false);
            this.tabPageTestOne.PerformLayout();
            this.uiTitlePanel1.ResumeLayout(false);
            this.tabPageTestParam.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ImageList menuIconList;
        private Sunny.UI.UISymbolButton btnUserName;
        private Sunny.UI.UISymbolButton btnExit;
        private Sunny.UI.UILabel uiLabel2;
        private GMap.NET.WindowsForms.GMapControl gMapControl;
        private Sunny.UI.UIProgressIndicator uiProgressIndicator1;
        private Sunny.UI.UISymbolButton btnReConnect;
        private Timer timer1;
        private Timer timer2;
        private Timer timer3;
        private Label labVol;
        private Label labHeight;
        private Label label20;
        private Panel panel1;
        private Label labCurrentLat;
        private Label labCurrentLng;
        private Label labACVoltage;
        private Sunny.UI.UIButton btnRotate;
        private Sunny.UI.UITextBox uiTextBox2;
        private MaterialTabControl materialTabControl1;
        private TabPage tabPageTestGround;
        private Panel panel3;
        private Sunny.UI.UILabel uiLabel61;
        private Sunny.UI.UIButton btnDeleteGround;
        private Sunny.UI.UIButton btnEditGround;
        private Sunny.UI.UIButton btnAddGround;
        private Sunny.UI.UIListBox listGround;
        private Sunny.UI.UIButton btnCompanyName;
        private Sunny.UI.UILabel uiLabel60;
        private Sunny.UI.UITextBox txtCompanyName;
        private Panel panel2;
        private Sunny.UI.UIButton btnGroundCancel;
        private Sunny.UI.UIButton btnGroundSave;
        private Sunny.UI.UITextBox txtGroundName;
        private Sunny.UI.UILabel uiLabel64;
        private Sunny.UI.UIButton btnOneEightDraw;
        private Sunny.UI.UILabel uiLabel62;
        private Sunny.UI.UILabel uiLabel63;
        private Sunny.UI.UITextBox txtCenterAngle;
        private Sunny.UI.UITextBox txtCenterLng;
        private Sunny.UI.UIButton btnCenterEnter;
        private Sunny.UI.UILabel uiLabel45;
        private Sunny.UI.UIButton btnEightClear;
        private Sunny.UI.UILabel uiLabel44;
        private Sunny.UI.UIButton btnEightEnter;
        private Sunny.UI.UILabel uiLabel47;
        private Sunny.UI.UITextBox txtLeftLat;
        private Sunny.UI.UITextBox txtRightLat;
        private Sunny.UI.UILabel uiLabel46;
        private Sunny.UI.UITextBox txtLeftLng;
        private Sunny.UI.UITextBox txtCenterLat;
        private Sunny.UI.UILabel uiLabel56;
        private Sunny.UI.UILabel uiLabel49;
        private Sunny.UI.UITextBox txtRightLng;
        private Sunny.UI.UILabel uiLabel48;
        private Sunny.UI.UILabel uiLabel57;
        private Sunny.UI.UITextBox txtCenterRad;
        private Sunny.UI.UILabel uiLabel58;
        private Sunny.UI.UILabel uiLabel55;
        private Sunny.UI.UILabel uiLabel59;
        private Sunny.UI.UILabel uiLabel54;
        private Sunny.UI.UITextBox txtRightRad;
        private Sunny.UI.UILabel uiLabel53;
        private Sunny.UI.UILabel uiLabel50;
        private Sunny.UI.UILabel uiLabel52;
        private Sunny.UI.UILabel uiLabel51;
        private TabPage tabPageTestParam;
        private Panel panel4;
        private Sunny.UI.UILine uiLine4;
        private Sunny.UI.UILine uiLine3;
        private Sunny.UI.UITextBox txtTestStartSpeed;
        private Sunny.UI.UILabel uiLabel65;
        private Sunny.UI.UILabel uiLabel66;
        private Sunny.UI.UIComboBox comRotateStartMode;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox txtRotateVOffset;
        private Sunny.UI.UITextBox txtRotateHOffset;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UILabel uiLabel13;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel uiLabel12;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel uiLabel11;
        private Sunny.UI.UITextBox txtRotateMinHeight;
        private Sunny.UI.UILabel uiLabel17;
        private Sunny.UI.UILabel uiLabel10;
        private Sunny.UI.UILabel uiLabel16;
        private Sunny.UI.UITextBox txtRotateMaxHeight;
        private Sunny.UI.UITextBox txtRotateMinAngleSpeed;
        private Sunny.UI.UITextBox txtRotateMaxTime;
        private Sunny.UI.UILabel uiLabel15;
        private Sunny.UI.UILabel uiLabel14;
        private Sunny.UI.UITextBox txtRotateMaxAngleSpeed;
        private Sunny.UI.UITextBox txtRotateMinTime;
        private Sunny.UI.UILabel uiLabel18;
        private Sunny.UI.UITextBox txtTestTimeout;
        private Sunny.UI.UILabel uiLabel21;
        private Sunny.UI.UILabel uiLabel20;
        private Sunny.UI.UITextBox txtTestStartAngle;
        private Sunny.UI.UILabel uiLabel23;
        private Sunny.UI.UILabel uiLabel22;
        private Sunny.UI.UITextBox txtTestRadOffset;
        private Sunny.UI.UILabel uiLabel19;
        private Panel panel5;
        private Sunny.UI.UIButton btnCancel;
        private Sunny.UI.UITextBox txtEightMaxAngleSpeed;
        private Sunny.UI.UILabel uiLabel40;
        private Sunny.UI.UILabel uiLabel41;
        private Sunny.UI.UIButton btnTestDataEdit;
        private Sunny.UI.UITextBox txtEightVOffset;
        private Sunny.UI.UIButton btnTestDataSave;
        private Sunny.UI.UITextBox txtEightMaxSpeed;
        private Sunny.UI.UILabel uiLabel39;
        private Sunny.UI.UILabel uiLabel38;
        private Sunny.UI.UITextBox txtEightTimeout;
        private Sunny.UI.UILabel uiLabel37;
        private Sunny.UI.UILabel uiLabel42;
        private Sunny.UI.UILabel uiLabel36;
        private Sunny.UI.UILabel uiLabel43;
        private Sunny.UI.UITextBox txtEightHOffset;
        private Sunny.UI.UILabel uiLabel35;
        private Sunny.UI.UILabel uiLabel34;
        private Sunny.UI.UITextBox txtEightPhiCount;
        private Sunny.UI.UILabel uiLabel33;
        private Sunny.UI.UILabel lable31;
        private Sunny.UI.UILabel uiLabel32;
        private Sunny.UI.UITextBox txtEightMinSpeed;
        private Sunny.UI.UILabel uiLabel31;
        private Sunny.UI.UITextBox txtEightPhiOffset;
        private Sunny.UI.UILabel uiLabel30;
        private Sunny.UI.UILabel uiLabel24;
        private Sunny.UI.UILabel uiLabel29;
        private Sunny.UI.UILabel uiLabel25;
        private Sunny.UI.UITextBox txtEightMinHeight;
        private Sunny.UI.UITextBox txtEightMinAngleSpeed;
        private Sunny.UI.UILabel uiLabel28;
        private Sunny.UI.UITextBox txtEightMaxHeight;
        private Sunny.UI.UILabel uiLabel27;
        private Sunny.UI.UILabel uiLabel26;
        private Sunny.UI.UIListBox listTestType;
        private Sunny.UI.UILine uiLine2;
        private Sunny.UI.UILine uiLine1;
        private TabPage tabPageTestOne;
        private Sunny.UI.UITextBox uiTextBox3;
        private Sunny.UI.UITextBox labTimeLength;
        private Sunny.UI.UITextBox labFlyHeight;
        private Sunny.UI.UITextBox labSpeed;
        private Sunny.UI.UITextBox txtAngleSpeed;
        private Sunny.UI.UITextBox labPhiOffset;
        private Sunny.UI.UILabel uiLabel80;
        private Sunny.UI.UITextBox labAngleSpeed;
        private Sunny.UI.UITextBox txtFlyHeight;
        private Sunny.UI.UITextBox labHOffset;
        private Sunny.UI.UILabel uiLabel79;
        private Sunny.UI.UITextBox labVOffset;
        private Sunny.UI.UILabel uiLabel75;
        private Sunny.UI.UITextBox txtDistance;
        private Sunny.UI.UILabel uiLabel74;
        private Sunny.UI.UILabel uiLabel68;
        private Sunny.UI.UILabel uiLabel69;
        private Sunny.UI.UILabel uiLabel87;
        private Sunny.UI.UIComboBox listTestProject2;
        private Sunny.UI.UILabel uiLabel86;
        private Sunny.UI.UIComboBox listTestType2;
        private Sunny.UI.UILabel uiLabel85;
        private Sunny.UI.UILabel txtTimeLength;
        private Sunny.UI.UILabel uiLabel84;
        private Sunny.UI.UITextBox txtSpeed;
        private Sunny.UI.UILabel uiLabel83;
        private Sunny.UI.UILabel uiLabel81;
        private Sunny.UI.UILabel uiLabel70;
        private Sunny.UI.UITextBox txtPhiOffset;
        private Sunny.UI.UILabel uiLabel71;
        private Sunny.UI.UILabel uiLabel72;
        private Sunny.UI.UILabel uiLabel73;
        private Sunny.UI.UITextBox txtVOffset;
        private Sunny.UI.UITextBox txtHOffset;
        private Sunny.UI.UILabel uiLabel76;
        private Sunny.UI.UILabel uiLabel77;
        private Sunny.UI.UILabel uiLabel78;
        private Sunny.UI.UIButton btnTestStop;
        private Sunny.UI.UIButton btnTestStart;
        private Sunny.UI.UILine uiLine7;
        private TabPage tabPage6;
        private Sunny.UI.UIButton btnHeightCheck;
        private Sunny.UI.UIButton btnDiChiCheck;
        private Sunny.UI.UILine uiLine5;
        private Sunny.UI.UILine uiLine6;
        private Sunny.UI.UITitlePanel uiTitlePanel1;
        private ListBox listTextResult;
        private Sunny.UI.UIRadioButton uiTestItemEight;
        private Sunny.UI.UIRadioButton uiTestItemRotate;
        private Panel gMapControlPanel;
        private Sunny.UI.UIPanel labGroundName;
        private AviationInstrumentControls.HeadingIndicatorInstrumentControl headingIndicatorInstrumentControl1;
        private AviationInstrumentControls.AttitudeIndicatorInstrumentControl attitudeIndicatorInstrumentControl1;
        private Sunny.UI.UILine uiLine8;
        private Sunny.UI.UILabel uiLabel67;
        private Sunny.UI.UIComboBox cbMapProviders;
        private Sunny.UI.UIButton btnDeleteCurrentMap;
        private Sunny.UI.UIButton btnDeleteAllMap;
        private Sunny.UI.UILine uiLine9;
        private Sunny.UI.UISymbolButton btnPositioningAircraft;
        private Sunny.UI.UISymbolButton btnMapZoomDn;
        private Sunny.UI.UISymbolButton btnMapZoomUp;
        private Sunny.UI.UILabel labBuildVersion;
        private Sunny.UI.UILabel uiLabel82;
        private Sunny.UI.UILine uiLine10;
        private Sunny.UI.UILabel labBuildTime;
        private Sunny.UI.UILabel uiLabel88;
        private Panel panel6;
        private Label label14;
        private Label label1;
        private Sunny.UI.UIPanel uiPanel7;
        private Sunny.UI.UIPanel txtSystemStatus;
        private Sunny.UI.UIButton btnGpsStar;
        private Label label2;
        private Sunny.UI.UICheckBox cbYawAngleAccum;

        //public Sunny.UI.UISymbolButton UiSymbolButton8 { get => uiSymbolButton8; set => uiSymbolButton8 = value; }
    }
}
