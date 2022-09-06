using GMap.NET;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using YuneecFX01.Properties;
using YuneecFX01.system;

namespace YuneecFX01.tool
{
    public class VersionHelper
    {
        public static string GetInformationalVersion()
        {
            return FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;
        }
        public static DateTime GetBuildTime()
        {
            return GetLinkerTimestampUtc(Assembly.GetEntryAssembly());
        }

        private static DateTime GetLinkerTimestampUtc(Assembly assembly)
        {
            var location = assembly.Location;
            return GetLinkerTimestampUtc(location);
        }

        private static DateTime GetLinkerTimestampUtc(string filePath)
        {
            const int peHeaderOffset = 60;
            const int linkerTimestampOffset = 8;
            var bytes = new byte[2048];

            using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                file.Read(bytes, 0, bytes.Length);
            }

            var headerPos = BitConverter.ToInt32(bytes, peHeaderOffset);
            var secondsSince1970 = BitConverter.ToInt32(bytes, headerPos + linkerTimestampOffset);
            var dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return dt.AddSeconds(secondsSince1970);
        }
    }

    public class TimeHelper
    {
        /// <summary>
        /// 获取毫秒级时间戳
        /// </summary>
        public static long Timestamp => DateTimeOffset.Now.ToUnixTimeMilliseconds();
    }

    public class StrFmt
    {
        public static string strF00(double val)
        {
            return string.Format("{0:0.00}", val);
        }
        public static string strF00000000(double val)
        {
            return string.Format("{0:0.00000000}", val);
        }
    }

    public class tools
    {
        private static SpeechSynthesizer voice = new SpeechSynthesizer();
        private static DateTime dtSpeakVoice = DateTime.Now;//语音播报时的时间戳
        private static Prompt prompt;

        public static string strF00(double val)
        {
            string str = string.Format("{0:0.00}", val);

            return str;
        }

        /// <summary>
        /// 播放语音提示
        /// </summary>
        /// <param name="msg">消息正文</param>
        /// <param name="speed">语音速度</param>
        /// <param name="volume">语音音量</param>
        /// <param name="flag">立即播放</param>
        /// <returns></returns>
        public static bool SpeakVoice(string msg, int speed, int volume, bool flag)
        {
            if (flag || prompt == null || prompt.IsCompleted)
            {
                voice.SpeakAsyncCancelAll();
                voice.Rate = speed;
                voice.Volume = volume;
                //voice.SelectVoice("Microsoft Lili");
                voice.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult, 2, System.Globalization.CultureInfo.CurrentCulture);
                prompt = voice.SpeakAsync(msg);
            }
            return true;
        }

        /// <summary>
        /// 播放语音提示
        /// </summary>
        /// <param name="msg">消息正文</param>
        /// <param name="speed">语音速度</param>
        /// <param name="volume">语音音量</param>
        /// <param name="flag">立即播放</param>
        /// <returns></returns>
        public static void SpeakVoice(string msg, int speed, int volume)
        {
            if (prompt == null || prompt.IsCompleted)
            {
                sysLog.Debug("speak voice: " + msg);
                voice.SpeakAsyncCancelAll();
                voice.Rate = speed;
                voice.Volume = volume;
                //voice.SelectVoice("Microsoft Lili");
                voice.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult, 2, System.Globalization.CultureInfo.CurrentCulture);
                prompt = voice.SpeakAsync(msg);
            }
        }

        /// <summary>
        /// 立即播放语音提示，打断正在播放的语音
        /// </summary>
        /// <param name="msg">消息正文</param>
        /// <param name="speed">语音速度</param>
        /// <param name="volume">语音音量</param>
        /// <param name="flag">立即播放</param>
        /// <returns></returns>
        public static void SpeakVoiceNow(string msg, int speed, int volume)
        {
            sysLog.Debug("speak voice now: " + msg);
            voice.SpeakAsyncCancelAll();
            voice.Rate = speed;
            voice.Volume = volume;
            //voice.SelectVoice("Microsoft Lili");
            voice.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult, 2, System.Globalization.CultureInfo.CurrentCulture);
            prompt = voice.SpeakAsync(msg);
        }

        /// <summary>
        /// 播放语音提示，追加到目前播放的语音消息后面
        /// </summary>
        /// <param name="msg">消息正文</param>
        /// <param name="speed">语音速度</param>
        /// <param name="volume">语音音量</param>
        /// <param name="flag">立即播放</param>
        /// <returns></returns>
        public static void SpeakVoiceAppend(string msg, int speed, int volume)
        {
            sysLog.Debug("speak voice append: " + msg);
            voice.Rate = speed;
            voice.Volume = volume;
            //voice.SelectVoice("Microsoft Lili");
            voice.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult, 2, System.Globalization.CultureInfo.CurrentCulture);
            prompt = voice.SpeakAsync(msg);
        }
    }

    public class MyFileTools
    {
        public static void fileSave(List<TestPoint> taskpoint)
        {
            SaveFileDialog filesave = new SaveFileDialog();
            filesave.InitialDirectory = Application.StartupPath + "\\航迹";
            filesave.OverwritePrompt = false;
            filesave.Title = "保存文件";
            filesave.Filter = "二进制|*.dat|xml文件|*.xml";
            bool flag = filesave.ShowDialog() == DialogResult.OK;
            if (flag)
            {
                string filename = filesave.FileName;
                string filetype = filesave.FileName.Substring(filesave.FileName.Length - 4);
                bool flag2 = filetype == ".dat";
                if (flag2)
                {
                    MyFileTools.assemblesave<TestPoint>(filename, taskpoint);
                }
                else
                {
                    MyFileTools.assemblesave2(filename, taskpoint);
                }
            }
        }
        public static void fileSave(List<TestArea> taskarea)
        {
            SaveFileDialog filesave = new SaveFileDialog();
            filesave.InitialDirectory = Application.StartupPath + "\\航迹";
            filesave.OverwritePrompt = false;
            filesave.Title = "保存文件";
            filesave.Filter = "二进制|*.dat";
            filesave.FileName = DateTime.Now.ToString("yy-MM-dd-HH-mm-ss") + "(作业区域)";
            bool flag = filesave.ShowDialog() == DialogResult.OK;
            if (flag)
            {
                string filename = filesave.FileName;
                MyFileTools.assemblesave<TestArea>(filename, taskarea);
            }
        }

        public static bool fileRead(ref List<TestPoint> taskpoint)
        {
            OpenFileDialog fileopen = new OpenFileDialog();
            fileopen.InitialDirectory = Application.StartupPath + "\\航迹";
            fileopen.Title = "打开文件";
            fileopen.Filter = "文件格式|*.dat;*.xml";
            bool flag = fileopen.ShowDialog() == DialogResult.OK;
            bool result;
            if (flag)
            {
                string filetype = fileopen.FileName.Substring(fileopen.FileName.Length - 4);
                bool flag2 = filetype == ".dat";
                if (flag2)
                {
                    MyFileTools.assembleload<TestPoint>(fileopen.FileName, ref taskpoint);
                }
                else
                {
                    MyFileTools.assembleload2(fileopen.FileName, ref taskpoint);
                }
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public static void fileRead(ref List<TestArea> taskarea)
        {
            OpenFileDialog fileopen = new OpenFileDialog();
            fileopen.InitialDirectory = Application.StartupPath + "\\航迹";
            fileopen.Title = "打开文件";
            fileopen.Filter = "文件格式|*.dat";
            bool flag = fileopen.ShowDialog() == DialogResult.OK;
            if (flag)
            {
                MyFileTools.assembleload<TestArea>(fileopen.FileName, ref taskarea);
            }
        }

        public static void dircreate(string path)
        {
            bool flag = !Directory.Exists(path);
            if (flag)
            {
                Directory.CreateDirectory(path);
            }
        }

        public static void dirOpen(string path)
        {
            try
            {
                Process.Start("explorer.exe", path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开目录失败：" + ex.Message, "操作提示");
            }
        }

        public static void writeByte(byte[] inBytes, string taskName, string filename)
        {
            string path = Application.StartupPath + "\\" + taskName + "\\";
            bool flag = !Directory.Exists(path);
            if (flag)
            {
                Directory.CreateDirectory(path);
            }
            string file = path + filename;
            using (FileStream fs = new FileStream(file, FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(MyFileTools.ByteToString(inBytes));
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }
            }
        }

        public static bool Write(string path, bool append, string FileName, string FileContent)
        {
            return MyFileTools.Write(path, append, FileName, FileContent, Encoding.UTF8);
        }

        public static bool Write(string path, bool append, string FileName, string FileContent, Encoding encode)
        {
            bool flag2 = !Directory.Exists(path);
            if (flag2)
            {
                Directory.CreateDirectory(path);
            }
            StreamWriter TxtWriter = null;
            bool flag = false;
            try
            {
                TxtWriter = new StreamWriter(path + FileName, append, encode);
                TxtWriter.Write(FileContent);
                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                bool flag3 = TxtWriter != null;
                if (flag3)
                {
                    TxtWriter.Close();
                }
            }
            return flag;
        }

        //lijinfeng 
        //从savedata.dat文件中，读取每一行文本数据，解析成结构化数据
        public static string ReadData(string path, bool append, string FileName, Encoding encode)
        {
            string data = null;
            bool flag2 = !Directory.Exists(path);
            if (flag2)
            {
                //目录不存在
                return null;
            }

            StreamReader txtReader = null;
            try
            {
                txtReader = new StreamReader(path + FileName, encode, append);
                data = txtReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                bool flag3 = txtReader != null;
                if (flag3)
                {
                    //txtReader.Close();
                }
            }
            return data;
        }

        public static string ByteToString(byte[] InBytes)
        {
            StringBuilder sbOut = new StringBuilder();
            bool flag = true;
            foreach (byte InByte in InBytes)
            {
                bool flag2 = flag;
                if (flag2)
                {
                    flag = false;
                }
                else
                {
                    sbOut.Append(MyFileTools.splitChar);
                }
                sbOut.Append(string.Format("{0:X2}", InByte));
            }
            return sbOut.ToString();
        }

        public static byte[] StringToByte(string InString)
        {
            string[] ByteStrings = InString.Split(new char[]
            {
                MyFileTools.splitChar
            });
            byte[] ByteOut = new byte[ByteStrings.Length];
            for (int i = 0; i < ByteStrings.Length; i++)
            {
                ByteOut[i] = Convert.ToByte(ByteStrings[i], 16);
            }
            return ByteOut;
        }

        public static double[] StringToDouble(string InString)
        {
            double[] result;
            try
            {
                string[] ByteStrings = InString.Split(new char[]
                {
                    '\r',
                    '\n',
                    ' '
                }, StringSplitOptions.RemoveEmptyEntries);
                double[] ByteOut = new double[ByteStrings.Length];
                for (int i = 0; i < ByteStrings.Length; i++)
                {
                    ByteOut[i] = Convert.ToDouble(ByteStrings[i]);
                }
                result = ByteOut;
            }
            catch
            {
                sysLog.Error("string to double failed \n");
                sysLog.Debug("string to double failed s=" + InString + "\r\n");
                result = null;
            }
            return result;
        }

        public static double[] ReadBytes(string path)
        {
            List<double> rbytes = new List<double>();
            using (StreamReader sr = new StreamReader(path))
            {
                string s;
                do
                {
                    s = sr.ReadLine();
                    bool flag = s != null;
                    if (flag)
                    {
                        double[] readHex = MyFileTools.StringToDouble(s);
                        bool flag2 = readHex != null;
                        if (flag2)
                        {
                            rbytes.AddRange(readHex);
                        }
                    }
                    Thread.Sleep(20);
                }
                while (s != null);
            }
            return rbytes.ToArray();
        }

        public static string Read(string path)
        {
            string FileContent = string.Empty;
            bool flag = File.Exists(path);
            if (flag)
            {
                StreamReader TxtReader = null;
                try
                {
                    TxtReader = new StreamReader(path, Encoding.UTF8);
                    FileContent = TxtReader.ReadToEnd();
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    bool flag2 = TxtReader != null;
                    if (flag2)
                    {
                        TxtReader.Close();
                    }
                }
            }
            return FileContent;
        }

        public static void assemblesave<T>(string path, List<T> sobj)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, sobj);
            fs.Close();
        }

        public static void assemblesave2(string path, List<TestPoint> sobj)
        {
            List<TestPoint> xtmp = new List<TestPoint>(sobj.ToArray());
            XmlDocument doc = new XmlDocument();
            XmlDeclaration xdc = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(xdc);
            XmlElement root = doc.CreateElement("waypointPlan");
            doc.AppendChild(root);
            XmlElement waypoint = doc.CreateElement("waypoints");
            waypoint.SetAttribute("count", (xtmp.Count - 1).ToString());
            root.AppendChild(waypoint);
            for (int i = 0; i < xtmp.Count - 1; i++)
            {
                XmlElement wp = doc.CreateElement("wp" + i.ToString());
                wp.SetAttribute("id", xtmp[i].TIndex.ToString());
                wp.SetAttribute("lng", xtmp[i].TPx.ToString("f13"));
                wp.SetAttribute("lat", xtmp[i].TPy.ToString("f13"));
                wp.SetAttribute("alt", xtmp[i].TSeaHigh.ToString("f2"));
                wp.SetAttribute("turnmode", xtmp[i].Tswervemode.ToString());
                wp.SetAttribute("routemode", xtmp[i].Troutemode.ToString());
                wp.SetAttribute("flyheading", ((double)xtmp[i].Tflyheading).ToString("f6"));
                wp.SetAttribute("cameraPitch", xtmp[i].Tyuntaipitch.ToString("f3"));
                wp.SetAttribute("cameraYaw", xtmp[i].Tyuntaiyaw.ToString("f13"));
                wp.SetAttribute("hoverTime", xtmp[i].Tstoptime.ToString("0."));
                wp.SetAttribute("speed", xtmp[i].TLevelSpeed.ToString("0."));
                wp.SetAttribute("linespeed", xtmp[i].Tlinespeed.ToString());
                wp.SetAttribute("verticalspeed", xtmp[i].Tverticalspeed.ToString());
                waypoint.AppendChild(wp);
            }
            doc.Save(path);
        }

        public static void assembleload<T>(string path, ref List<T> sobj)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            List<T> tmp = bf.Deserialize(fs) as List<T>;
            bool flag = tmp != null;
            if (flag)
            {
                sobj = tmp;
            }
            else
            {
                MessageBox.Show("读取文件出错。", "操作提示");
            }
            fs.Close();
        }

        public static void assembleload2(string path, ref List<TestPoint> sobj)
        {
            List<TestPoint> tmplist = new List<TestPoint>();
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement root = doc.DocumentElement;
            XmlNodeList personNodes = root.GetElementsByTagName("waypoints");
            XmlNodeList personNode = root.SelectSingleNode("waypoints").ChildNodes;
            foreach (object obj in personNode)
            {
                XmlNode node = (XmlNode)obj;
                tmplist.Add(new TestPoint
                {
                    TIndex = Convert.ToUInt16(((XmlElement)node).GetAttribute("id")),
                    TPx = Convert.ToDouble(((XmlElement)node).GetAttribute("lng")),
                    TPy = Convert.ToDouble(((XmlElement)node).GetAttribute("lat")),
                    TSeaHigh = Convert.ToSingle(((XmlElement)node).GetAttribute("alt")),
                    TLevelSpeed = Convert.ToSingle(((XmlElement)node).GetAttribute("speed")),
                    Tyuntaipitch = Convert.ToSingle(((XmlElement)node).GetAttribute("cameraPitch")),
                    Tflyheading = Convert.ToSingle(((XmlElement)node).GetAttribute("cameraYaw")),
                    Tstoptime = Convert.ToByte(((XmlElement)node).GetAttribute("hoverTime"))
                });
            }
            bool flag = tmplist.Count > 0;
            if (flag)
            {
                tmplist.Add(new TestPoint());
                tmplist[tmplist.Count - 1].TIndex = (ushort)((byte)(tmplist.Count - 1));
                sobj = tmplist;
            }
            else
            {
                MessageBox.Show("任务载入：航点个数为0", "操作提示");
            }
        }

        public static DataSet ExcelToDS(string Path)
        {
            string strConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=NO;IMEX=1;'", Path);
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "select * from [sheet1$]";
            OleDbDataAdapter myCommand = new OleDbDataAdapter(strExcel, strConn);
            DataSet ds = new DataSet();
            myCommand.Fill(ds, "table1");
            return ds;
        }

        public static void flyAirportSave(List<List<PointLatLng>> flyairport)
        {
            SaveFileDialog filesave = new SaveFileDialog();
            filesave.InitialDirectory = Application.StartupPath + "\\航迹";
            filesave.OverwritePrompt = false;
            filesave.Title = "保存文件";
            filesave.Filter = "二进制|*.dat|xml文件|*.xml";
            bool flag = filesave.ShowDialog() == DialogResult.OK;
            if (flag)
            {
                string filename = filesave.FileName;
                string filetype = filesave.FileName.Substring(filesave.FileName.Length - 4);
                bool flag2 = filetype == ".dat";
                if (flag2)
                {
                    MyFileTools.assemblesave<List<PointLatLng>>(filename, flyairport);
                }
            }
        }

        public static void flyAirPortLoad(ref List<List<PointLatLng>> flyairport)
        {
            OpenFileDialog fileopen = new OpenFileDialog();
            fileopen.InitialDirectory = Application.StartupPath + "\\航迹";
            fileopen.Title = "打开文件";
            fileopen.Filter = "文件格式|*.dat";
            bool flag = fileopen.ShowDialog() == DialogResult.OK;
            if (flag)
            {
                string filetype = fileopen.FileName.Substring(fileopen.FileName.Length - 4);
                bool flag2 = filetype == ".dat";
                if (flag2)
                {
                    MyFileTools.assembleload<List<PointLatLng>>(fileopen.FileName, ref flyairport);
                }
            }
            TestTools.isAvaliableArea();
        }

        public static void flyAirPortLoad()
        {
            string fileName = Application.StartupPath + "\\航迹\\20200507 01.dat";
            MyFileTools.assembleload<List<PointLatLng>>(fileName, ref sysFunction.isnotflyareas);
            TestTools.isAvaliableArea();
        }

        private static char splitChar = ',';
    }

    public class MyImageTools
    {
        public static Image resizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;
            float nPercentW = (float)size.Width / (float)sourceWidth;
            float nPercentH = (float)size.Height / (float)sourceHeight;
            bool flag = nPercentH < nPercentW;
            float nPercent;
            if (flag)
            {
                nPercent = nPercentH;
            }
            else
            {
                nPercent = nPercentW;
            }
            int destWidth = (int)((float)sourceWidth * nPercent);
            int destHeight = (int)((float)sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage(b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return b;
        }
        public static Image GetRotateImage(Image srcImage, int angle)
        {
            angle %= 360;
            int srcWidth = srcImage.Width;
            int srcHeight = srcImage.Height;
            Rectangle rotateRec = MyImageTools.GetRotateRectangle(srcWidth, srcHeight, (float)angle);
            int rotateWidth = rotateRec.Width;
            int rotateHeight = rotateRec.Height;
            Bitmap destImage = null;
            Graphics graphics = null;
            try
            {
                destImage = new Bitmap(rotateWidth, rotateHeight);
                graphics = Graphics.FromImage(destImage);
                Point centerPoint = new Point(rotateWidth / 2, rotateHeight / 2);
                graphics.TranslateTransform((float)centerPoint.X, (float)centerPoint.Y);
                graphics.RotateTransform((float)angle);
                graphics.TranslateTransform((float)(-(float)centerPoint.X), (float)(-(float)centerPoint.Y));
                Point Offset = new Point((rotateWidth - srcWidth) / 2, (rotateHeight - srcHeight) / 2);
                graphics.DrawImage(srcImage, new Rectangle(Offset.X, Offset.Y, srcWidth, srcHeight));
                graphics.ResetTransform();
                graphics.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                bool flag = graphics != null;
                if (flag)
                {
                    graphics.Dispose();
                }
            }
            return destImage;
        }

        public static Rectangle GetRotateRectangle(int width, int height, float angle)
        {
            double radian = (double)angle * 3.141592653589793 / 180.0;
            double cos = Math.Cos(radian);
            double sin = Math.Sin(radian);
            int newWidth = (int)Math.Max(Math.Abs((double)width * cos - (double)height * sin), Math.Abs((double)width * cos + (double)height * sin));
            int newHeight = (int)Math.Max(Math.Abs((double)width * sin - (double)height * cos), Math.Abs((double)width * sin + (double)height * cos));
            return new Rectangle(0, 0, newWidth, newHeight);
        }

        public static Image GetRotateImage2(Image image, float angle)
        {
            bool flag = image == null;
            if (flag)
            {
                throw new ArgumentNullException("image");
            }
            double oldWidth = (double)image.Width;
            double oldHeight = (double)image.Height;
            double theta = (double)angle * 3.141592653589793 / 180.0;
            double locked_theta;
            for (locked_theta = theta; locked_theta < 0.0; locked_theta += 6.283185307179586)
            {
            }
            bool flag2 = (locked_theta >= 0.0 && locked_theta < 1.5707963267948966) || (locked_theta >= 3.141592653589793 && locked_theta < 4.71238898038469);
            double adjacentTop;
            double oppositeTop;
            double adjacentBottom;
            double oppositeBottom;
            if (flag2)
            {
                adjacentTop = Math.Abs(Math.Cos(locked_theta)) * oldWidth;
                oppositeTop = Math.Abs(Math.Sin(locked_theta)) * oldWidth;
                adjacentBottom = Math.Abs(Math.Cos(locked_theta)) * oldHeight;
                oppositeBottom = Math.Abs(Math.Sin(locked_theta)) * oldHeight;
            }
            else
            {
                adjacentTop = Math.Abs(Math.Sin(locked_theta)) * oldHeight;
                oppositeTop = Math.Abs(Math.Cos(locked_theta)) * oldHeight;
                adjacentBottom = Math.Abs(Math.Sin(locked_theta)) * oldWidth;
                oppositeBottom = Math.Abs(Math.Cos(locked_theta)) * oldWidth;
            }
            double newWidth = adjacentTop + oppositeBottom;
            double newHeight = adjacentBottom + oppositeTop;
            int nWidth = (int)Math.Ceiling(newWidth);
            int nHeight = (int)Math.Ceiling(newHeight);
            Bitmap rotatedBmp = new Bitmap(nWidth, nHeight);
            using (Graphics g = Graphics.FromImage(rotatedBmp))
            {
                bool flag3 = locked_theta >= 0.0 && locked_theta < 1.5707963267948966;
                Point[] points;
                if (flag3)
                {
                    points = new Point[]
                    {
                        new Point((int)oppositeBottom, 0),
                        new Point(nWidth, (int)oppositeTop),
                        new Point(0, (int)adjacentBottom)
                    };
                }
                else
                {
                    bool flag4 = locked_theta >= 1.5707963267948966 && locked_theta < 3.141592653589793;
                    if (flag4)
                    {
                        points = new Point[]
                        {
                            new Point(nWidth, (int)oppositeTop),
                            new Point((int)adjacentTop, nHeight),
                            new Point((int)oppositeBottom, 0)
                        };
                    }
                    else
                    {
                        bool flag5 = locked_theta >= 3.141592653589793 && locked_theta < 4.71238898038469;
                        if (flag5)
                        {
                            points = new Point[]
                            {
                                new Point((int)adjacentTop, nHeight),
                                new Point(0, (int)adjacentBottom),
                                new Point(nWidth, (int)oppositeTop)
                            };
                        }
                        else
                        {
                            points = new Point[]
                            {
                                new Point(0, (int)adjacentBottom),
                                new Point((int)oppositeBottom, 0),
                                new Point((int)adjacentTop, nHeight)
                            };
                        }
                    }
                }
                g.DrawImage(image, points);
            }
            return rotatedBmp;
        }
        public static string path = Application.StartupPath + "\\Image";

        public static Bitmap imagePlane1 = Resources.t5;
        public static Bitmap imagePlane2 = Resources.t21;
        public static Bitmap imagePlane3 = Resources.t22;
        public static Bitmap imagePlane4 = Resources.t23;
        public static Bitmap imagePlane5 = Resources.t24;
    }

    public abstract class instance
    {
        public static bool IsFirst(string appId)
        {
            bool ret = false;
            bool flag = instance.OpenMutex(2031617U, 0, appId) == IntPtr.Zero;
            if (flag)
            {
                instance.CreateMutex(IntPtr.Zero, 0, appId);
                ret = true;
            }
            return ret;
        }
        
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr OpenMutex(uint dwDesiredAccess, int bInheritHandle, string lpName);
        
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr CreateMutex(IntPtr lpMutexAttributes, int bInitialOwner, string lpName);
    }
}
