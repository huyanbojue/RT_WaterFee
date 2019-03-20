using System;
using System.Windows.Forms;

namespace WHC.Framework.BaseUI
{
	/// <summary>
	/// MessageBox 的摘要说明。
	/// </summary>
    public class MessageDxUtil
	{
		/// <summary>
		/// 显示一般的提示信息
		/// </summary>
		/// <param name="message">提示信息</param>
		public static DialogResult ShowTips(string message)
		{
            return DevExpress.XtraEditors.XtraMessageBox.Show(message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// 显示警告信息
		/// </summary>
		/// <param name="message">警告信息</param>
		public static DialogResult ShowWarning(string message)
		{
            return DevExpress.XtraEditors.XtraMessageBox.Show(message, "警告信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		/// <summary>
		/// 显示错误信息
		/// </summary>
		/// <param name="message">错误信息</param>
		public static DialogResult ShowError(string message)
		{
            return DevExpress.XtraEditors.XtraMessageBox.Show(message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		/// <summary>
		/// 显示询问用户信息，并显示错误标志
		/// </summary>
		/// <param name="message">错误信息</param>
		public static DialogResult ShowYesNoAndError(string message)
		{
            return DevExpress.XtraEditors.XtraMessageBox.Show(message, "错误信息", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
		}

		/// <summary>
		/// 显示询问用户信息，并显示提示标志
		/// </summary>
		/// <param name="message">错误信息</param>
		public static DialogResult ShowYesNoAndTips(string message)
		{
            return DevExpress.XtraEditors.XtraMessageBox.Show(message, "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
		}

        /// <summary>
        /// 显示询问用户信息，并显示警告标志
        /// </summary>
        /// <param name="message">警告信息</param>
        public static DialogResult ShowYesNoAndWarning(string message)
        {
            return DevExpress.XtraEditors.XtraMessageBox.Show(message, "警告信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 显示询问用户信息，并显示提示标志
        /// </summary>
        /// <param name="message">错误信息</param>
        public static DialogResult ShowYesNoCancelAndTips(string message)
        {
            return DevExpress.XtraEditors.XtraMessageBox.Show(message, "提示信息", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
        }


        /// <summary>
        /// 询问一个输入字符串
        /// </summary>
        /// <param name="prompt">提示信息</param>
        /// <param name="initValue">初始值</param>
        /// <param name="isPassword">是否密码字符串</param>
        /// <returns>询问到的字符串</returns>
        public static string QueryInputStr(string prompt, string initValue = "", bool isPassword = false)
        {
            QueryInputDialog dlg = new QueryInputDialog();
            dlg.Text = prompt;
            dlg.lblPrompt.Text = prompt.EndsWith(":") || prompt.EndsWith("：") ? prompt : prompt + ":";
            dlg.txtInput.Text = initValue;
            dlg.IsEncryptInput = isPassword;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.txtInput.Text;
            }
            return initValue;
        }
	}
}
