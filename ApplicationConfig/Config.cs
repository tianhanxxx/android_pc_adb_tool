/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 2010-11-29
 * Time: 19:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.IO;
using System.Reflection;

namespace ApplicationConfig
{
    /// <summary>
    /// 配置文件类
    /// </summary>
    public class Config
    {
    	private string fileName = string.Empty;
    	private string nameSpace = "configuration";
    	private string tableName = "appSettings";

		private string appPath = null;
		private DataSet ds = null;
		private bool isChanged = false;

		private static Config thisConfig = null;

		/// <summary>
		/// 以默认配置文件名，初始化配置文件类。默认配置文件名为 config.xml
		/// </summary>
		public Config()
			: this("config.xml")
		{
		}

		/// <summary>
		/// 以指定文件名，初始化配置文件类
		/// </summary>
		/// <exception cref="NullReferenceException">FileName 的值为 null 或空字符串</exception>
		public Config(string FileName)
		{
			ds = new DataSet();
			ConfigFile = FileName;
		}

		/// <summary>
		/// 释放资源时，保存配置信息
		/// </summary>
		~Config()
		{
			Save();
		}

		/// <summary>
		/// 默认的配置文件
		/// </summary>
		public static Config DefaultConfig
		{
			get
			{
				if (thisConfig == null)
					thisConfig = new Config();

				return thisConfig;
			}
		}

		/// <summary>
		/// 配置文件名称
		/// </summary>
		/// <exception cref="NullReferenceException">值为 null 或空字符串</exception>
		public string ConfigFile
		{
			get
			{
				return fileName;
			}

			set
			{
				if (value == null || value.Trim().Length < 1)
					throw new NullReferenceException("ConfigFile 不能为 null 或空字符串");

				if (fileName == value)
					return;

				fileName = value;

				try
				{
					appPath = Path.GetDirectoryName(
						Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName
						).TrimEnd('\\') + "\\" + fileName;
				}
				catch (Exception)
				{
					appPath = fileName;
				}

				//保存原数据
				Save();

				//应用新文件
				Refresh();
			}
		}

		/// <summary>
		/// 默认表名
		/// </summary>
		/// <exception cref="NullReferenceException">值为 null 或空字符串</exception>
		public string DefaultTable
		{
			get
			{
				return tableName;
			}

			set
			{
				if (value == null || value.Trim().Length < 1)
					throw new NullReferenceException("DefaultTable 不能为 null 或空字符串");

				if (tableName == value)
					return;

				tableName = value;
			}
		}

        /// <summary>
        /// 索引器
        /// </summary>
        public string this[string table, string attrib]
        {
        	get
        	{
        		return GetConfigInfo(table, attrib);
        	}
        	set
        	{
        		SetConfigInfo(table, attrib, value);
        	}
        }
        
        /// <summary>
        /// 索引器
        /// </summary>
        public string this[string attrib]
        {
        	get
        	{
        		return GetConfigInfo(attrib);
        	}
        	set
        	{
        		SetConfigInfo(attrib, value);
        	}
        }
        
        /// <summary>
        /// 读配置信息
        /// </summary>
        /// <param name="table">段名</param>
        /// <param name="attrib">要获取数据的字段名</param>
        /// <returns>返回的数据</returns>
        public string GetConfigInfo(string table, string attrib)
        {
            string value;

            try
            {
                value = ds.Tables[table, nameSpace].Rows[0][attrib].ToString();
            }
            catch (Exception)
            {
                value = string.Empty;
            }

            return value;
        }
        
        /// <summary>
        /// 读配置信息
        /// </summary>
        /// <param name="attrib">要获取数据的字段名</param>
        /// <returns>返回的数据</returns>
        public string GetConfigInfo(string attrib)
        {
        	return GetConfigInfo(tableName, attrib);
        }

        /// <summary>
        /// 保存配置信息
        /// </summary>
        /// <param name="table">段名</param>
        /// <param name="attrib">要保存的配置字段</param>
        /// <param name="value">要保存的内容</param>
        /// <returns>成功返回true，失败返回false</returns>
        public bool SetConfigInfo(string table, string attrib, string value)
        {
            try
            {
                //添加表
                if(!ds.Tables.Contains(table, nameSpace))
                	ds.Tables.Add(table, nameSpace);
                
                //添加行
                if(ds.Tables[table, nameSpace].Rows.Count < 1)
                {
                	DataRow newRow = ds.Tables[table, nameSpace].NewRow();
                	ds.Tables[table, nameSpace].Rows.Add(newRow);
                }
                
                //添加列
                if(!ds.Tables[table, nameSpace].Columns.Contains(attrib))
                	ds.Tables[table, nameSpace].Columns.Add(attrib);
                
                ds.Tables[table, nameSpace].Rows[0][attrib] = value;

				isChanged = true;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        /// <summary>
        /// 保存配置信息
        /// </summary>
        /// <param name="attrib">要保存的配置字段</param>
        /// <param name="value">要保存的内容</param>
        /// <returns>成功返回true，失败返回false</returns>
        public bool SetConfigInfo(string attrib, string value)
        {
        	return SetConfigInfo(tableName, attrib, value);
        }

		/// <summary>
		/// 删除指定表
		/// </summary>
		/// <param name="table">要删除表的表名</param>
		/// <returns>成功返回true，失败返回false</returns>
		public bool RemoveTable(string table)
		{
			try
			{
				ds.Tables[table, nameSpace].Clear();
				isChanged = true;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
        
        /// <summary>
        /// 重新读取配置文件信息
        /// </summary>
		public void Refresh()
		{
			if (File.Exists(appPath))
			{
				ds.Clear();
				ds.ReadXml(appPath);
			}
			else
				ds = new DataSet("nameSpace");

			isChanged = false;
		}

		/// <summary>
		/// 强制保存配置文件信息
		/// </summary>
		/// <remarks>
		/// 此方法可将当前内存中的配置信息强制写入文件
		/// 若不调用此方法，在 Config 类释放时，配置信息也会写入文件
		/// </remarks>
		public void Save()
		{
			if (ds != null && isChanged)
			{
				ds.WriteXml(appPath);
				isChanged = false;
			}
		}

		/// <summary>
		/// 判断是否有指定表的指定字段
		/// </summary>
		/// <param name="table">指定的表</param>
		/// <param name="attrib">指定的字段</param>
		/// <returns>字段存在返回true，不存在返回false</returns>
		public bool Exists(string table, string attrib)
		{
			try
			{
				//检查表是否存在
				if (!ds.Tables.Contains(table, nameSpace))
					return false;

				//没有数据行
				if (ds.Tables[table, nameSpace].Rows.Count < 1)
					return false;

				//检查是否存在列
				if (!ds.Tables[table, nameSpace].Columns.Contains(attrib))
					return false;

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		
		/// <summary>
		/// 判断是否有指定字段
		/// </summary>
		/// <param name="attrib">指定的字段</param>
		/// <returns>字段存在返回true，不存在返回false</returns>
		public bool Exists(string attrib)
		{
			return Exists(tableName, attrib);
		}
    }
}
