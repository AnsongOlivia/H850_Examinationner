namespace YuneecFX01.Window
{
    partial class formLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLogin));
            this.mButtonOK = new Sunny.UI.UIButton();
            this.mButtonExit = new Sunny.UI.UIButton();
            this.mComBoxProtocol = new Sunny.UI.UIComboBox();
            this.mComBoxNum = new Sunny.UI.UIComboBox();
            this.mComBoxRate = new Sunny.UI.UIComboBox();
            this.SuspendLayout();
            // 
            // mButtonOK
            // 
            this.mButtonOK.BackColor = System.Drawing.Color.Transparent;
            this.mButtonOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mButtonOK.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(87)))), ((int)(((byte)(0)))));
            this.mButtonOK.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mButtonOK.FillDisableColor = System.Drawing.Color.Transparent;
            this.mButtonOK.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mButtonOK.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mButtonOK.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mButtonOK.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mButtonOK.ForeDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mButtonOK.Location = new System.Drawing.Point(25, 298);
            this.mButtonOK.MinimumSize = new System.Drawing.Size(1, 1);
            this.mButtonOK.Name = "mButtonOK";
            this.mButtonOK.Radius = 10;
            this.mButtonOK.RectColor = System.Drawing.Color.Transparent;
            this.mButtonOK.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mButtonOK.RectHoverColor = System.Drawing.Color.Transparent;
            this.mButtonOK.RectPressColor = System.Drawing.Color.Transparent;
            this.mButtonOK.RectSelectedColor = System.Drawing.Color.Transparent;
            this.mButtonOK.Size = new System.Drawing.Size(210, 37);
            this.mButtonOK.Style = Sunny.UI.UIStyle.Custom;
            this.mButtonOK.TabIndex = 0;
            this.mButtonOK.Text = "确认";
            this.mButtonOK.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mButtonOK.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.mButtonOK.Click += new System.EventHandler(this.mButtonOK_Click);
            // 
            // mButtonExit
            // 
            this.mButtonExit.BackColor = System.Drawing.Color.Transparent;
            this.mButtonExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mButtonExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(90)))), ((int)(((byte)(151)))));
            this.mButtonExit.FillDisableColor = System.Drawing.Color.Transparent;
            this.mButtonExit.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mButtonExit.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mButtonExit.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mButtonExit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mButtonExit.ForeDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mButtonExit.Location = new System.Drawing.Point(25, 345);
            this.mButtonExit.MinimumSize = new System.Drawing.Size(1, 1);
            this.mButtonExit.Name = "mButtonExit";
            this.mButtonExit.Radius = 10;
            this.mButtonExit.RectColor = System.Drawing.Color.Transparent;
            this.mButtonExit.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mButtonExit.RectHoverColor = System.Drawing.Color.Transparent;
            this.mButtonExit.RectPressColor = System.Drawing.Color.Transparent;
            this.mButtonExit.RectSelectedColor = System.Drawing.Color.Transparent;
            this.mButtonExit.Size = new System.Drawing.Size(210, 37);
            this.mButtonExit.Style = Sunny.UI.UIStyle.Custom;
            this.mButtonExit.TabIndex = 1;
            this.mButtonExit.Text = "取消";
            this.mButtonExit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mButtonExit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.mButtonExit.Click += new System.EventHandler(this.mButtonExit_Click);
            // 
            // mComBoxProtocol
            // 
            this.mComBoxProtocol.BackColor = System.Drawing.Color.Transparent;
            this.mComBoxProtocol.DataSource = null;
            this.mComBoxProtocol.FillColor = System.Drawing.Color.White;
            this.mComBoxProtocol.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.mComBoxProtocol.Font = new System.Drawing.Font("新宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mComBoxProtocol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mComBoxProtocol.ItemHoverColor = System.Drawing.Color.Empty;
            this.mComBoxProtocol.Items.AddRange(new object[] {
            "MAVLINK",
            "ROS"});
            this.mComBoxProtocol.ItemSelectBackColor = System.Drawing.Color.Gray;
            this.mComBoxProtocol.Location = new System.Drawing.Point(69, 197);
            this.mComBoxProtocol.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mComBoxProtocol.MinimumSize = new System.Drawing.Size(63, 0);
            this.mComBoxProtocol.Name = "mComBoxProtocol";
            this.mComBoxProtocol.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.mComBoxProtocol.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.mComBoxProtocol.RectColor = System.Drawing.Color.Gray;
            this.mComBoxProtocol.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.mComBoxProtocol.Size = new System.Drawing.Size(166, 21);
            this.mComBoxProtocol.Style = Sunny.UI.UIStyle.Custom;
            this.mComBoxProtocol.TabIndex = 54;
            this.mComBoxProtocol.TextAlignment = System.Drawing.ContentAlignment.BottomLeft;
            this.mComBoxProtocol.Watermark = "请选择通信协议";
            this.mComBoxProtocol.WatermarkColor = System.Drawing.Color.LightGray;
            this.mComBoxProtocol.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // mComBoxNum
            // 
            this.mComBoxNum.BackColor = System.Drawing.Color.Transparent;
            this.mComBoxNum.DataSource = null;
            this.mComBoxNum.FillColor = System.Drawing.Color.White;
            this.mComBoxNum.FillColor2 = System.Drawing.Color.Transparent;
            this.mComBoxNum.Font = new System.Drawing.Font("新宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mComBoxNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mComBoxNum.ItemHoverColor = System.Drawing.Color.Empty;
            this.mComBoxNum.ItemSelectBackColor = System.Drawing.Color.Gray;
            this.mComBoxNum.ItemSelectForeColor = System.Drawing.Color.Transparent;
            this.mComBoxNum.Location = new System.Drawing.Point(69, 242);
            this.mComBoxNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mComBoxNum.MinimumSize = new System.Drawing.Size(63, 0);
            this.mComBoxNum.Name = "mComBoxNum";
            this.mComBoxNum.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.mComBoxNum.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.mComBoxNum.RectColor = System.Drawing.Color.Gray;
            this.mComBoxNum.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.mComBoxNum.Size = new System.Drawing.Size(84, 21);
            this.mComBoxNum.Style = Sunny.UI.UIStyle.Custom;
            this.mComBoxNum.TabIndex = 55;
            this.mComBoxNum.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.mComBoxNum.Watermark = "电台串口";
            this.mComBoxNum.WatermarkColor = System.Drawing.Color.LightGray;
            this.mComBoxNum.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // mComBoxRate
            // 
            this.mComBoxRate.BackColor = System.Drawing.Color.Transparent;
            this.mComBoxRate.DataSource = null;
            this.mComBoxRate.FillColor = System.Drawing.Color.White;
            this.mComBoxRate.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.mComBoxRate.Font = new System.Drawing.Font("新宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mComBoxRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mComBoxRate.ItemHoverColor = System.Drawing.Color.Empty;
            this.mComBoxRate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "43000",
            "56000",
            "57600",
            "115200"});
            this.mComBoxRate.ItemSelectBackColor = System.Drawing.Color.Gray;
            this.mComBoxRate.Location = new System.Drawing.Point(154, 242);
            this.mComBoxRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mComBoxRate.MinimumSize = new System.Drawing.Size(63, 0);
            this.mComBoxRate.Name = "mComBoxRate";
            this.mComBoxRate.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.mComBoxRate.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.mComBoxRate.RectColor = System.Drawing.Color.Gray;
            this.mComBoxRate.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.mComBoxRate.Size = new System.Drawing.Size(81, 21);
            this.mComBoxRate.Style = Sunny.UI.UIStyle.Custom;
            this.mComBoxRate.TabIndex = 56;
            this.mComBoxRate.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.mComBoxRate.Watermark = "波特率";
            this.mComBoxRate.WatermarkColor = System.Drawing.Color.LightGray;
            this.mComBoxRate.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // formLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(258, 458);
            this.Controls.Add(this.mComBoxRate);
            this.Controls.Add(this.mComBoxNum);
            this.Controls.Add(this.mComBoxProtocol);
            this.Controls.Add(this.mButtonExit);
            this.Controls.Add(this.mButtonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.formLogin_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.formLogin_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formLogin_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.formLogin_MouseUp);
            this.Resize += new System.EventHandler(this.formLogin_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton mButtonOK;
        private Sunny.UI.UIButton mButtonExit;
        private Sunny.UI.UIComboBox mComBoxProtocol;
        private Sunny.UI.UIComboBox mComBoxNum;
        private Sunny.UI.UIComboBox mComBoxRate;
    }
}