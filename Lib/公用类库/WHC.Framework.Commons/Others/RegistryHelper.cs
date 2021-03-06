using System;
using Microsoft.Win32;
using System.Windows.Forms;

namespace WHC.Framework.Commons
{
    /// <summary>
    /// 注册表操作辅助类，通过默认指定注册表的前缀路径，减少调用复杂性。
    /// </summary>
    public sealed class RegistryHelper
    {
        #region 基础操作（读取和保存）
        private static string Software_Key = @"Software\DeepLand\OrderWater";

        /// <summary>
        /// 获取注册表项的值。如果该键不存在，则返回空字符串。
        /// </summary>
        /// <param name="key">注册表键</param>
        /// <returns>指定键返回的值</returns>
        public static string GetValue(string key)
        {
            return GetValue(Software_Key, key);
        }

        /// <summary>
        /// 获取注册表项的值。如果该键不存在，则返回空字符串。
        /// </summary>
        /// <param name="softwareKey">注册表键的前缀路径</param>
        /// <param name="key">注册表键</param>
        /// <returns>指定键返回的值</returns>
        public static string GetValue(string softwareKey, string key)
        {
            return GetValue(softwareKey, key, Registry.CurrentUser);
        }

        /// <summary>
        /// 获取注册表项的值。如果该键不存在，则返回空字符串。
        /// </summary>
        /// <param name="softwareKey">注册表键的前缀路径</param>
        /// <param name="key">注册表键</param>
        /// <param name="rootRegistry">开始的根节点（Registry.CurrentUser或者Registry.LocalMachine等）</param>
        /// <returns>指定键返回的值</returns>
        public static string GetValue(string softwareKey, string key, RegistryKey rootRegistry)
        {
            const string parameter = "key";
            if (null == key)
            {
                throw new ArgumentNullException(parameter);
            }

            string strRet = string.Empty;
            try
            {
                RegistryKey regKey = rootRegistry.OpenSubKey(softwareKey);
                strRet = regKey.GetValue(key).ToString();
            }
            catch
            {
                strRet = "";
            }
            return strRet;
        }

        /// <summary>
        /// 保存键值到注册表
        /// </summary>
        /// <param name="key">注册表键</param>
        /// <param name="value">键的值内容</param>
        /// <returns>如果保存成功返回true，否则为false</returns>
        public static bool SaveValue(string key, string value)
        {
            return SaveValue(Software_Key, key, value);
        }

        /// <summary>
        /// 保存键值到注册表
        /// </summary>
        /// <param name="softwareKey">注册表键的前缀路径</param>
        /// <param name="key">注册表键</param>
        /// <param name="value">键的值内容</param>
        /// <returns>如果保存成功返回true，否则为false</returns>
        public static bool SaveValue(string softwareKey, string key, string value)
        {
            return SaveValue(softwareKey, key, value, Registry.CurrentUser);
        }

        /// <summary>
        /// 保存键值到注册表
        /// </summary>
        /// <param name="softwareKey">注册表键的前缀路径</param>
        /// <param name="key">注册表键</param>
        /// <param name="value">键的值内容</param>
        /// <param name="rootRegistry">开始的根节点（Registry.CurrentUser或者Registry.LocalMachine等）</param>
        /// <returns>如果保存成功返回true，否则为false</returns>
        public static bool SaveValue(string softwareKey, string key, string value, RegistryKey rootRegistry)
        {
            const string parameter1 = "key";
            const string parameter2 = "value";
            if (null == key)
            {
                throw new ArgumentNullException(parameter1);
            }

            if (null == value)
            {
                throw new ArgumentNullException(parameter2);
            }

            RegistryKey reg;
            reg = rootRegistry.OpenSubKey(softwareKey, true);

            if (null == reg)
            {
                reg = rootRegistry.CreateSubKey(softwareKey);
            }
            reg.SetValue(key, value);

            return true;
        } 
        #endregion

        #region 自动启动程序设置

        /// <summary>
        /// 检查是否随系统启动
        /// </summary>
        /// <returns></returns>
        public static bool CheckStartWithWindows()
        {
            RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            if (regkey != null && (string)regkey.GetValue(Application.ProductName, "null", RegistryValueOptions.None) != "null")
            {
                Registry.CurrentUser.Flush();
                return true;
            }

            Registry.CurrentUser.Flush();
            return false;
        }

        /// <summary>
        /// 设置随系统启动
        /// </summary>
        /// <param name="startWin"></param>
        public static void SetStartWithWindows(bool startWin)
        {
            RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            if (regkey != null)
            {
                if (startWin)
                {
                    regkey.SetValue(Application.ProductName, Application.ExecutablePath, RegistryValueKind.String);
                }
                else
                {
                    regkey.DeleteValue(Application.ProductName, false);
                }

                Registry.CurrentUser.Flush();
            }
        }

        #endregion
    }
}