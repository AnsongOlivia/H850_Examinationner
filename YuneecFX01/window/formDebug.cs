using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YuneecFX01.map.GMap;
using YuneecFX01.system;
using YuneecFX01.tool;

namespace YuneecFX01.window
{
    public partial class formDebug : Form
    {
        private Window.formMain formMain;
        private GMapControl gMapControl;
        private System.Timers.Timer timer = new System.Timers.Timer();

        private string[] sData;
        private int sDataIndex;

        public formDebug()
        {
            InitializeComponent();
            timer.Interval = 30;
            timer.AutoReset = true;
            timer.Elapsed += timer_Elapsed;
        }

        private void formDebug_Load(object sender, EventArgs e)
        {
            formMain = (Window.formMain)this.Owner;
            Type type = formMain.GetType();
            FieldInfo gMapControl1PropertyInfo = type.GetField("gMapControl", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
            this.gMapControl = (GMapControl)gMapControl1PropertyInfo.GetValue(formMain);

            this.btnPlayOrPause.Enabled = false;
            this.num_MokeSpeed.Value = (int)timer.Interval;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.gMapControl.Refresh();
        }

        private void btnLoadHistory_Click(object sender, EventArgs e)
        {
            if (btnLoadHistory.Text == "加载")
            {
                DialogResult dialogResult = this.openFileDialog.ShowDialog();
                if (dialogResult.Equals(DialogResult.OK))
                {
                    this.tbHistoryPath.Text = this.openFileDialog.FileName;
                }
            }
            else
            {
                timer.Enabled = false;
                btnPlayOrPause.Text = "开始";
                btnLoadHistory.Text = "加载";
                this.tbHistoryPath.Enabled = true;
                sDataIndex = 0;
            }
        }

        private void tbHistoryPath_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(this.tbHistoryPath.Text))
            {
                this.loadFlyData(this.tbHistoryPath.Text);
                this.btnPlayOrPause.Enabled = true;
                sysLog.Debug($"history file load success {this.tbHistoryPath.Text}");
            }
            else
            {
                this.btnPlayOrPause.Enabled = false;
            }
        }

        private void btnPlayOrPause_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Enabled = false;
                btnPlayOrPause.Text = "继续";
            }
            else
            {
                timer.Enabled = true;
                this.tbHistoryPath.Enabled = false;
                btnPlayOrPause.Text = "暂停";
                btnLoadHistory.Text = "停止";
            }
        }

        private void loadFlyData(string path)
        {
            sData = File.ReadAllLines(path);
            this.trackBar.Maximum = sData.Length;
            system.sysFunction.mFlyData.Clear();
        }

        private void trackBar_MouseCaptureChanged(object sender, EventArgs e)
        {
        }

        private void invoke(Control control, Delegate method)
        {
            if (control == null || control.Disposing || control.IsDisposed)
            {
                timer.Enabled = false;
                return;
            }
            try
            {
                control.BeginInvoke(method);
            }
            catch (ObjectDisposedException) { }
            catch (InvalidOperationException) { }
            catch (Exception ex)
            {
                sysLog.Error(ex, "飞行数据处理异常");
            }
        }

        /// <summary>
        /// 模拟数据读取
        /// 读取//history//history_data.txt文件中的数据，一行一行读
        /// 文本数据解析成全局飞行数据
        /// 实时绘制无人机飞行轨迹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            sDataIndex = sDataIndex + 1;
            if (sDataIndex >= sData.Length)
            {
                sDataIndex = 0;
            }
            invoke(this.trackBar, new MethodInvoker(delegate { this.trackBar.Value = sDataIndex; }));
            invoke(this.num_MokeIndex, new MethodInvoker(delegate { this.num_MokeIndex.Value = sDataIndex; }));

            updateMockData(sDataIndex);
        }

        private void updateMockData(int sDataIndex)
        {
            string data = sData[sDataIndex];
            if (data.Length > 10)
            {
                try
                {
                    string[] info1 = data.Split(' ');
                    string[] info2 = data.Split(' ');
                    Array.Copy(info1, 1, info2, 0, 60);
                    system.sysDataModel.decodePlaneData2(info2);
                    sysDataModel.gGpsLastTime = DateTime.Now;
                    sysDataModel.gLastMavlinkTime = DateTime.Now;
                }
                catch (Exception ex)
                {
                    sysLog.Error(ex, "模拟数据读取失败");
                    return;
                }
            }
        }

        private void num_MokeSpeed_ValueChanged(object sender, EventArgs e)
        {
            timer.Interval = Convert.ToInt32(((NumericUpDown)sender).Value);
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            sDataIndex = this.trackBar.Value;
            this.num_MokeIndex.Value = sDataIndex;
            updateMockData(sDataIndex);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.textBox3.Text = system.sysDataModel.PitchSpeed.ToString();
            this.textBox2.Text = system.sysDataModel.YawSpeed.ToString();
            this.textBox1.Text = system.sysDataModel.RollSpeed.ToString();
            this.textBox6.Text = system.sysDataModel.Ax.ToString();
            this.textBox5.Text = system.sysDataModel.Ay.ToString();
            this.textBox4.Text = system.sysDataModel.Az.ToString();
            this.textBox9.Text = system.sysDataModel.Xmag.ToString();
            this.textBox8.Text = system.sysDataModel.Ymag.ToString();
            this.textBox7.Text = system.sysDataModel.Zmag.ToString();
            this.textBox12.Text = system.sysDataModel.Xmag.ToString();
            this.textBox11.Text = system.sysDataModel.Ymag.ToString();
            this.textBox10.Text = system.sysDataModel.Zmag.ToString();
            this.textBox12.Text = system.sysDataModel.YawAngle.ToString();
            this.textBox11.Text = system.sysDataModel.PitchAngle.ToString();
            this.textBox10.Text = system.sysDataModel.RollAngle.ToString();
            this.textBox15.Text = system.sysDataModel.Latitude.ToString();
            this.textBox14.Text = system.sysDataModel.Longtitude.ToString();
            this.textBox13.Text = system.sysDataModel.Gpsh.ToString();
            this.textBox18.Text = system.sysDataModel.Vx.ToString();
            this.textBox17.Text = system.sysDataModel.Vy.ToString();
            this.textBox16.Text = system.sysDataModel.Vz.ToString();
        }


        GMapOverlayGround ground = null;
        private void button1_Click(object sender, EventArgs e)
        {
            if (ground == null)
            {
                ground = new GMapOverlayGround("ground", gMapControl.Position);
                gMapControl.Overlays.Add(ground);
            }

            ground.CentePoint = gMapControl.Position;
            CustomLatLng left = Calculate.getAngleLatLng(new CustomLatLng(ground.CentePoint.Lng, ground.CentePoint.Lat), 6, 90);
            CustomLatLng right = Calculate.getAngleLatLng(new CustomLatLng(ground.CentePoint.Lng, ground.CentePoint.Lat), 6, 90 + 180);
            ground.LeftPoint = new PointLatLng(left.m_lat, left.m_lng);
            ground.RightPoint = new PointLatLng(right.m_lat, right.m_lng);
            ground.CenterRadius = 1.5f;
            ground.EightRadius = 6;
            ground.EightOffset = 2;
            ground.UpdateCircleStyle();
        }
    }
}
