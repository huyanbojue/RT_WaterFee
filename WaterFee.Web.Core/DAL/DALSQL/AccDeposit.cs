﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using WHC.WaterFeeWeb.Core.IDAL;
using WHC.Framework.Commons;

namespace WHC.WaterFeeWeb.Core.DALSQL
{
    public class AccDeposit : WHC.Framework.ControlUtil.BaseDALSQL<Entity.AccDeposit>, IAccDeposit
    {
        #region 对象实例及构造函数

        public static AccDeposit Instance
        {
            get
            {
                return new AccDeposit();
            }
        }
        public AccDeposit() : base("AccDeposit", "IntCustNO")
        {
        }

        #endregion
 
        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override Entity.AccDeposit DataReaderToEntity(IDataReader dataReader)
        {
            Entity.AccDeposit info = new Entity.AccDeposit();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.IntCustNO = reader.GetInt32("IntCustNO");
            info.MonSum = reader.GetDecimal("MonSum");
            info.DtLastUpd = reader.GetDateTime("DtLastUpd");
            info.DtCreate = reader.GetDateTime("DtCreate");

            return info;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(Entity.AccDeposit obj)
        {
            Entity.AccDeposit info = obj as Entity.AccDeposit;
            Hashtable hash = new Hashtable();

            hash.Add("IntCustNO", info.IntCustNO);
            hash.Add("MonSum", info.MonSum);
            hash.Add("DtLastUpd", info.DtLastUpd);
            hash.Add("DtCreate", info.DtCreate);

            return hash;
        }

        /// <summary>
        /// 获取字段中文别名（用于界面显示）的字典集合
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, string> GetColumnNameAlias()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            #region 添加别名解析
            dict.Add("IntCustNO", "IntCustNO"); 
            dict.Add("MonSum", "MonSum"); 
            dict.Add("DtLastUpd", "DtLastUpd"); 
            dict.Add("DtCreate", "DtCreate"); 
            #endregion

            return dict;
        }

    }
}
