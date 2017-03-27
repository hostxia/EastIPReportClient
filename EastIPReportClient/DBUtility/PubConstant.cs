﻿using System.Configuration;

namespace EastIPReportClient.DBUtility
{

    public class PubConstant
    {
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionStringPC
        {
            get
            {
                string _connectionString = ConfigurationManager.AppSettings["ConnectionStringPC"];
                //string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
                //if (ConStringEncrypt == "true")
                //{
                //    _connectionString = DESEncrypt.Decrypt(_connectionString);
                //}
                return _connectionString;
            }
        }

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionStringIPSP
        {
            get
            {
                string _connectionString = ConfigurationManager.AppSettings["ConnectionStringIPSP"];
                //string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
                //if (ConStringEncrypt == "true")
                //{
                //    _connectionString = DESEncrypt.Decrypt(_connectionString);
                //}
                return _connectionString;
            }
        }

        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            string connectionString = ConfigurationManager.AppSettings[configName];
            //string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
            //if (ConStringEncrypt == "true")
            //{
            //    connectionString = DESEncrypt.Decrypt(connectionString);
            //}
            return connectionString;
        }


    }
}
