using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuneecFX01.system
{
    /// <summary>
    /// 数据库操作类
    /// 目前支持sqlite
    /// </summary>
    public class sysDataBase
    {
        /// <summary>
        /// 数据库连接定义
        /// </summary>
        private SQLiteConnection dbConnection;

        /// <summary>
        /// SQL命令定义
        /// </summary>
        private SQLiteCommand dbCommand;

        /// <summary>
        /// 数据读取定义
        /// </summary>
        private SQLiteDataReader dataReader;

        /// <summary>
        /// 数据库操作错误日志
        /// </summary>
        public string dbErrorMsg;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">连接SQLite库字符串</param>
        public sysDataBase(string connectionString)
        {
            try
            {
                dbConnection = new SQLiteConnection(connectionString);
                dbConnection.Open();
            }
            catch (Exception e)
            {
                sysLog.Error(e, "连接数据库失败");
            }
        }
        /// <summary>
        /// 执行SQL命令
        /// </summary>
        /// <returns>The query.</returns>
        /// <param name="queryString">SQL命令字符串</param>
        public SQLiteDataReader ExecuteQuery(string queryString)
        {
            dbErrorMsg = "";
            try
            {
                dbCommand = dbConnection.CreateCommand();
                dbCommand.CommandText = queryString;
                dataReader = dbCommand.ExecuteReader();
            }
            catch (Exception e)
            {
                sysLog.Error(e, "执行SQL失败");
                dbErrorMsg = e.Message;
            }

            return dataReader;
        }
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void CloseConnection()
        {
            //销毁Commend
            if (dbCommand != null)
            {
                dbCommand.Cancel();
            }
            dbCommand = null;
            //销毁Reader
            if (dataReader != null)
            {
                dataReader.Close();
            }
            dataReader = null;
            //销毁Connection
            if (dbConnection != null)
            {
                dbConnection.Close();
            }
            dbConnection = null;

        }

        /// <summary>
        /// 读取整张数据表
        /// </summary>
        /// <returns>The full table.</returns>
        /// <param name="tableName">数据表名称</param>
        public SQLiteDataReader ReadFullTable(string tableName)
        {
            string queryString = "SELECT * FROM " + tableName;
            return ExecuteQuery(queryString);
        }


        /// <summary>
        /// 向指定数据表中插入数据
        /// </summary>
        /// <returns>The values.</returns>
        /// <param name="tableName">数据表名称</param>
        /// <param name="values">插入的数值</param>
        public SQLiteDataReader InsertValues(string tableName, string[] values)
        {
            //获取数据表中字段数目
            int fieldCount = ReadFullTable(tableName).FieldCount;
            //当插入的数据长度不等于字段数目时引发异常
            if (values.Length != fieldCount)
            {
                throw new SQLiteException("values.Length!=fieldCount");
            }

            string queryString = "INSERT INTO " + tableName + " VALUES (" + "'" + values[0] + "'";
            for (int i = 1; i < values.Length; i++)
            {
                queryString += ", " + "'" + values[i] + "'";
            }
            queryString += " )";
            return ExecuteQuery(queryString);
        }

        /// <summary>
        /// 更新指定数据表内的数据
        /// </summary>
        /// <returns>The values.</returns>
        /// <param name="tableName">数据表名称</param>
        /// <param name="colNames">字段名</param>
        /// <param name="colValues">字段名对应的数据</param>
        /// <param name="key">关键字</param>
        /// <param name="value">关键字对应的值</param>
        /// <param name="operation">运算符：=,<,>,...，默认“=”</param>
        public SQLiteDataReader UpdateValues(string tableName, string[] colNames, string[] colValues, string key, string value, string operation = "=")
        {
            //当字段名称和字段数值不对应时引发异常
            if (colNames.Length != colValues.Length)
            {
                throw new SQLiteException("colNames.Length!=colValues.Length");
            }

            string queryString = "UPDATE " + tableName + " SET " + colNames[0] + "=" + "'" + colValues[0] + "'";
            for (int i = 1; i < colValues.Length; i++)
            {
                queryString += ", " + colNames[i] + "=" + "'" + colValues[i] + "'";
            }
            queryString += " WHERE " + key + operation + "'" + value + "'";
            return ExecuteQuery(queryString);
        }

        /// <summary>
        /// 删除指定数据表内的数据
        /// </summary>
        /// <returns>The values.</returns>
        /// <param name="tableName">数据表名称</param>
        /// <param name="colNames">字段名</param>
        /// <param name="colValues">字段名对应的数据</param>
        public SQLiteDataReader DeleteValuesOR(string tableName, string[] colNames, string[] colValues, string[] operations)
        {
            //当字段名称和字段数值不对应时引发异常
            if (colNames.Length != colValues.Length || operations.Length != colNames.Length || operations.Length != colValues.Length)
            {
                throw new SQLiteException("colNames.Length!=colValues.Length || operations.Length!=colNames.Length || operations.Length!=colValues.Length");
            }

            string queryString = "DELETE FROM " + tableName + " WHERE " + colNames[0] + operations[0] + "'" + colValues[0] + "'";
            for (int i = 1; i < colValues.Length; i++)
            {
                queryString += "OR " + colNames[i] + operations[0] + "'" + colValues[i] + "'";
            }
            return ExecuteQuery(queryString);
        }

        /// <summary>
        /// 删除指定数据表内的数据
        /// </summary>
        /// <returns>The values.</returns>
        /// <param name="tableName">数据表名称</param>
        /// <param name="colNames">字段名</param>
        /// <param name="colValues">字段名对应的数据</param>
        public SQLiteDataReader DeleteValuesAND(string tableName, string[] colNames, string[] colValues, string[] operations)
        {
            //当字段名称和字段数值不对应时引发异常
            if (colNames.Length != colValues.Length || operations.Length != colNames.Length || operations.Length != colValues.Length)
            {
                throw new SQLiteException("colNames.Length!=colValues.Length || operations.Length!=colNames.Length || operations.Length!=colValues.Length");
            }

            string queryString = "DELETE FROM " + tableName + " WHERE " + colNames[0] + operations[0] + "'" + colValues[0] + "'";
            for (int i = 1; i < colValues.Length; i++)
            {
                queryString += " AND " + colNames[i] + operations[i] + "'" + colValues[i] + "'";
            }
            return ExecuteQuery(queryString);
        }


        /// <summary>
        /// 创建数据表
        /// </summary> +
        /// <returns>The table.</returns>
        /// <param name="tableName">数据表名</param>
        /// <param name="colNames">字段名</param>
        /// <param name="colTypes">字段名类型</param>
        public SQLiteDataReader CreateTable(string tableName, string[] colNames, string[] colTypes)
        {
            string queryString = "CREATE TABLE IF NOT EXISTS " + tableName + "( " + colNames[0] + " " + colTypes[0];
            for (int i = 1; i < colNames.Length; i++)
            {
                queryString += ", " + colNames[i] + " " + colTypes[i];
            }
            queryString += "  ) ";
            return ExecuteQuery(queryString);
        }

        /// <summary>
        /// Reads the table.
        /// </summary>
        /// <returns>The table.</returns>
        /// <param name="tableName">Table name.</param>
        /// <param name="items">Items.</param>
        /// <param name="colNames">Col names.</param>
        /// <param name="operations">Operations.</param>
        /// <param name="colValues">Col values.</param>
        public SQLiteDataReader ReadTable(string tableName, string[] items, string[] colNames, string[] operations, string[] colValues)
        {
            string queryString = "SELECT " + items[0];
            for (int i = 1; i < items.Length; i++)
            {
                queryString += ", " + items[i];
            }
            queryString += " FROM " + tableName + " WHERE " + colNames[0] + " " + operations[0] + " " + colValues[0];
            for (int i = 0; i < colNames.Length; i++)
            {
                queryString += " AND " + colNames[i] + " " + operations[i] + " " + colValues[0] + " ";
            }
            return ExecuteQuery(queryString);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        public string[] getUserInfo()
        {
            int i = 0;
            string[] strUserNames = new string[10];

            //读取整张表
            SQLiteDataReader reader = ReadFullTable("table_user");
            while (reader.Read())
            {
                //读取Name
                strUserNames[i] = reader.GetString(reader.GetOrdinal("user_name"));
                i = i +1;
            }
            return strUserNames;
        }

        /// <summary>
        /// 获取机构信息
        /// 机构名称
        /// </summary>
        public string getCompanyInfo()
        {
            int i = 0;
            string strValue = null;            

            //读取整张表
            SQLiteDataReader reader = ReadFullTable("table_company");
            while (reader.Read())
            {
                //读取Name
                strValue = reader.GetString(reader.GetOrdinal("company_name"));
                break;
            }
            return strValue;
        }

        /// <summary>
        /// 设置机构信息
        /// 机构名称
        /// 先删除表里的数据，再插入一条新数据
        /// </summary>
        public void setCompanyInfo(string company_name)
        {
            string queryString = "DELETE FROM " + "table_company";
            ExecuteQuery(queryString);

            queryString = "INSERT INTO " + "table_company" + " VALUES (" + "10, '" + company_name + "')";
            ExecuteQuery(queryString);

            return ;
        }

        /// <summary>
        /// 插入一条新的训练场数据
        /// 训练场名称
        /// 训练场—中心圆lng
        /// 训练场—中心圆lat
        /// 训练场—左圆心lng
        /// 训练场—左圆心lat
        /// 训练场—右圆心lng
        /// 训练场—右圆心lat
        /// 训练场—中心圆半径
        /// 训练场—右圆半径
        /// </summary>
        public string insertGroundInfo(string ground_name, string ground_center_lng, string ground_center_lat, string ground_left_lng, string ground_left_lat, string ground_right_lng, string ground_right_lat, string ground_center_rad, string ground_right_rad)
        {
            string queryString;
            
            queryString = "INSERT INTO " + 
                          "table_ground (ground_name,ground_center_lng,ground_center_lat,ground_left_lng,ground_left_lat,ground_right_lng,ground_right_lat,ground_center_rad,ground_right_rad) " + 
                          " VALUES (" + "'" + ground_name + "'," + "'" + ground_center_lng + "'," + "'" + ground_center_lat + "'," + "'" + ground_left_lng + "'," + "'" + ground_left_lat + "'," + "'" + ground_right_lng + "'," + "'" + ground_right_lat + "'," + "'" + ground_center_rad + "'," + "'" + ground_right_rad + "')";
            ExecuteQuery(queryString);

            return dbErrorMsg;
        }

        /// <summary>
        /// 删除一条训练场数据
        /// 训练场名称
        /// </summary>
        public string deleteGroundInfo(string ground_name)
        {
            string queryString;

            queryString = "DELETE FROM  table_ground WHERE ground_name = " + "'" + ground_name + "'";
            ExecuteQuery(queryString);

            return dbErrorMsg;
        }

        /// <summary>
        /// 更新一条训练场数据
        /// 训练场名称
        /// 训练场—中心圆lng
        /// 训练场—中心圆lat
        /// 训练场—左圆心lng
        /// 训练场—左圆心lat
        /// 训练场—右圆心lng
        /// 训练场—右圆心lat
        /// 训练场—中心圆半径
        /// 训练场—右圆半径
        /// </summary>
        public string updateGroundInfo(string ground_name, string ground_center_lng, string ground_center_lat, string ground_left_lng, string ground_left_lat, string ground_right_lng, string ground_right_lat, string ground_center_rad, string ground_right_rad)
        {
            string queryString;

            queryString = "UPDATE table_ground SET " +
                          "ground_center_lng=" + "'" + ground_center_lng + "'," +
                          "ground_center_lat=" + "'" + ground_center_lat + "'," +
                          "ground_left_lng=" + "'" + ground_left_lng + "'," +
                          "ground_left_lat=" + "'" + ground_left_lat + "'," +
                          "ground_right_lng=" + "'" + ground_right_lng + "'," +
                          "ground_right_lat=" + "'" + ground_right_lat + "'," +
                          "ground_center_rad=" + "'" + ground_center_rad + "'," +
                          "ground_right_rad=" + "'" + ground_right_rad + "'," +
                          "ground_center_lat=" + "'" + ground_center_lat + "' " +
                          "WHERE ground_name = " + "'" + ground_name + "'";
            
            ExecuteQuery(queryString);

            return dbErrorMsg;
        }

        /// <summary>
        /// 查询一条训练场数据
        /// 训练场名称
        /// </summary>
        public string[] queryGroundInfo(string ground_name)
        {
            int i = 0;
            string queryString;
            string[] strRets = new string[9];

            try
            {
                //读取查询记录
                queryString = "SELECT * FROM  table_ground WHERE ground_name =" + "'" + ground_name + "'";
                SQLiteDataReader reader = ExecuteQuery(queryString);
                
                reader.Read();

                //读取ground_name
                strRets[0] = reader.GetString(reader.GetOrdinal("ground_name"));

                //读取ground_center_lng
                strRets[1] = reader.GetDouble(reader.GetOrdinal("ground_center_lng")).ToString();

                //读取ground_center_lat
                strRets[2] = reader.GetDouble(reader.GetOrdinal("ground_center_lat")).ToString();

                //读取ground_left_lng
                strRets[3] = reader.GetDouble(reader.GetOrdinal("ground_left_lng")).ToString();

                //读取ground_left_lat
                strRets[4] = reader.GetDouble(reader.GetOrdinal("ground_left_lat")).ToString();

                //读取ground_right_lng
                strRets[5] = reader.GetDouble(reader.GetOrdinal("ground_right_lng")).ToString();

                //读取ground_right_lat
                strRets[6] = reader.GetDouble(reader.GetOrdinal("ground_right_lat")).ToString();

                //读取ground_center_rad
                strRets[7] = reader.GetInt32(reader.GetOrdinal("ground_center_rad")).ToString();

                //读取ground_right_rad
                strRets[8] = reader.GetInt32(reader.GetOrdinal("ground_right_rad")).ToString();
            }
            catch (Exception e)
            {
                sysLog.Error(e, "查询训练场数据失败");
            }           

            return strRets;
        }

        /// <summary>
        /// 获取训练场名称列表
        /// </summary>
        public string[] getGroundNameList()
        {
            int i = 0;
            string[] strGroundNames = new string[128];

            for(i = 0;i< strGroundNames.Length; i++)
            {
                strGroundNames[i] = "";
            }

            //读取整张表
            i = 0;
            SQLiteDataReader reader = ReadFullTable("table_ground");
            while (reader.Read())
            {
                //读取Name
                strGroundNames[i] = reader.GetString(reader.GetOrdinal("ground_name"));
                i = i + 1;
            }
            return strGroundNames;
        }

        /// <summary>
        /// 获取训练参数
        /// </summary>
        public testParam[] getTestInfo()
        {
            int i = 0;
            testParam[] mTestParam = new testParam[3];
            //读取整张表
            i = 0;

            SQLiteDataReader reader = ReadFullTable("table_test_param");
            while (reader.Read())
            {
                mTestParam[i] = new testParam();

                //训练类型名称
                mTestParam[i].txtTestTypeName = reader.GetString(reader.GetOrdinal("test_type_name"));

                //进入中心-时间
                mTestParam[i].txtTestTimeout = reader.GetDouble(reader.GetOrdinal("txtTestTimeout"));

                //进入中心-起始角度
                mTestParam[i].txtTestStartAngle = reader.GetDouble(reader.GetOrdinal("txtTestStartAngle"));

                //进入中心-起始速度
                mTestParam[i].txtTestStartSpeed = reader.GetDouble(reader.GetOrdinal("txtTestStartSpeed"));

                //进入中心-中心圆偏差范围
                mTestParam[i].txtTestRadOffset = reader.GetDouble(reader.GetOrdinal("txtTestRadOffset"));

                //自旋-垂直偏差
                mTestParam[i].txtRotateVOffset = reader.GetDouble(reader.GetOrdinal("txtRotateVOffset"));

                //自旋-水平偏差
                mTestParam[i].txtRotateHOffset = reader.GetDouble(reader.GetOrdinal("txtRotateHOffset"));

                //自旋-最小高度
                mTestParam[i].txtRotateMinHeight = reader.GetDouble(reader.GetOrdinal("txtRotateMinHeight"));

                //自旋-最大高度
                mTestParam[i].txtRotateMaxHeight = reader.GetDouble(reader.GetOrdinal("txtRotateMaxHeight"));

                //自旋-最小时间
                mTestParam[i].txtRotateMinTime = reader.GetDouble(reader.GetOrdinal("txtRotateMinTime"));

                //自旋-最大时间
                mTestParam[i].txtRotateMaxTime = reader.GetDouble(reader.GetOrdinal("txtRotateMaxTime"));

                //自旋-最小角速度
                mTestParam[i].txtRotateMinAngleSpeed = reader.GetDouble(reader.GetOrdinal("txtRotateMinAngleSpeed"));

                //自旋-最大角速度
                mTestParam[i].txtRotateMaxAngleSpeed = reader.GetDouble(reader.GetOrdinal("txtRotateMaxAngleSpeed"));


                //8字-垂直偏差
                mTestParam[i].txtEightVOffset = reader.GetDouble(reader.GetOrdinal("txtEightVOffset"));

                //8字-水平偏差
                mTestParam[i].txtEightHOffset = reader.GetDouble(reader.GetOrdinal("txtEightHOffset"));

                //8字-最小高度
                mTestParam[i].txtEightMinHeight = reader.GetDouble(reader.GetOrdinal("txtEightMinHeight"));

                //8字-最大高度
                mTestParam[i].txtEightMaxHeight = reader.GetDouble(reader.GetOrdinal("txtEightMaxHeight"));

                //8字-最小速度
                mTestParam[i].txtEightMinSpeed = reader.GetDouble(reader.GetOrdinal("txtEightMinSpeed"));

                //8字-最大速度
                mTestParam[i].txtEightMaxSpeed = reader.GetDouble(reader.GetOrdinal("txtEightMaxSpeed"));

                //8字-最小角速度
                mTestParam[i].txtEightMinAngleSpeed = reader.GetDouble(reader.GetOrdinal("txtEightMinAngleSpeed"));

                //8字-最大角速度
                mTestParam[i].txtEightMaxAngleSpeed = reader.GetDouble(reader.GetOrdinal("txtEightMaxAngleSpeed"));

                //8字-航向偏差
                mTestParam[i].txtEightPhiOffset = reader.GetDouble(reader.GetOrdinal("txtEightPhiOffset"));

                //8字-航向统计
                mTestParam[i].txtEightPhiCount = reader.GetDouble(reader.GetOrdinal("txtEightPhiCount"));

                //8字-时长
                mTestParam[i].txtEightTimeout = reader.GetDouble(reader.GetOrdinal("txtEightTimeout"));


                i = i + 1;
            }
            return mTestParam;
        }

        /// <summary>
        /// 更新训练参数数据
        /// </summary>
        public string updateTestInfo(testParam mTestParam)
        {
            string queryString;

            //0:教员训练参数
            //1:驾驶员训练参数
            //2:机长训练参数
            queryString = "UPDATE table_test_param SET " +
                            "txtTestTimeout=" + "'" + mTestParam.txtTestTimeout + "'," +
                            "txtTestStartAngle=" + "'" + mTestParam.txtTestStartAngle + "'," +
                            "txtTestStartSpeed=" + "'" + mTestParam.txtTestStartSpeed + "'," +
                            "txtTestRadOffset=" + "'" + mTestParam.txtTestRadOffset + "'," +
                            "txtRotateVOffset=" + "'" + mTestParam.txtRotateVOffset + "'," +
                            "txtRotateHOffset=" + "'" + mTestParam.txtRotateHOffset + "'," +
                            "txtRotateMinHeight=" + "'" + mTestParam.txtRotateMinHeight + "'," +
                            "txtRotateMaxHeight=" + "'" + mTestParam.txtRotateMaxHeight + "'," +
                            "txtRotateMinTime=" + "'" + mTestParam.txtRotateMinTime + "'," +
                            "txtRotateMaxTime=" + "'" + mTestParam.txtRotateMaxTime + "'," +
                            "txtRotateMinAngleSpeed=" + "'" + mTestParam.txtRotateMinAngleSpeed + "'," +
                            "txtRotateMaxAngleSpeed=" + "'" + mTestParam.txtRotateMaxAngleSpeed + "'," +
                            "txtEightVOffset=" + "'" + mTestParam.txtEightVOffset + "'," +
                            "txtEightHOffset=" + "'" + mTestParam.txtEightHOffset + "'," +
                            "txtEightMinHeight=" + "'" + mTestParam.txtEightMinHeight + "'," +
                            "txtEightMaxHeight=" + "'" + mTestParam.txtEightMaxHeight + "'," +
                            "txtEightMinSpeed=" + "'" + mTestParam.txtEightMinSpeed + "'," +
                            "txtEightMaxSpeed=" + "'" + mTestParam.txtEightMaxSpeed + "'," +
                            "txtEightMinAngleSpeed=" + "'" + mTestParam.txtEightMinAngleSpeed + "'," +
                            "txtEightMaxAngleSpeed=" + "'" + mTestParam.txtEightMaxAngleSpeed + "'," +
                            "txtEightPhiOffset=" + "'" + mTestParam.txtEightPhiOffset + "'," +
                            "txtEightPhiCount=" + "'" + mTestParam.txtEightPhiCount + "'," +
                            "txtEightTimeout=" + "'" + mTestParam.txtEightTimeout + "' " +
                            "WHERE test_type_name = " + "'" + mTestParam.txtTestTypeName + "'";

            ExecuteQuery(queryString);

            return dbErrorMsg;
        }
    }
}

