using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;

namespace EMMS.Common
{
    //页面数据校验类
    public class PageValidate
    {
        private static Regex RegPhone = new Regex("^[0-9]+[-]?[0-9]+[-]?[0-9]$");
        private static Regex RegNumber = new Regex("^[0-9]+$");
        private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");
        private static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");
        private static Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$");
        private static Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");
        private static Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");
        private static Regex RegCHZNS = new Regex("[\u4e00-\u9fa5]+");
        private static Regex RegNumberLetter=new Regex("[a-z0-9A-Z]+");
        private static Regex RegCHNumber=new Regex("^[\u4e00-\u9fa5]]+");

        public PageValidate()
        { }

        #region 匹配中文+数字
        public static bool IsCHNumber(string inputData)
        {
            Match m=RegCHNumber.Match(inputData);
            return m.Success;
        }
        #endregion
        #region 匹配字母+数字
        public static bool IsNumberLetter(string inputData)
        {
            Match m = RegNumberLetter.Match(inputData);
            return m.Success;
        }
        #endregion
        #region 数字字符串检查
        //是否匹配电话号码 
        public static bool IsPhone(string inputData)
        {
            Match m = RegPhone.Match(inputData);
            return m.Success;
        }
        //检查查询字符串的键值，是否是数字，最大长度限制
        //public static string FetchInputDigit();
        //检查是否数字字符串
        public static bool IsNumber(string inputData)
        {
            Match m = RegNumber.Match(inputData);
            return m.Success;
        }
        //是否数字字符串，可带正负号
        public static bool IsNumberSign(string inputData)
        {
            Match m = RegNumberSign.Match(inputData);
            return m.Success;
        }
        //是否是浮点数
        public static bool IsDecimal(string inputData)
        {
            Match m = RegDecimal.Match(inputData);
            return m.Success;
        }
        //是否是浮点数，可带正负号
        public static bool IsDecimalSign(string inputData)
        {
            Match m = RegDecimalSign.Match(inputData);
            return m.Success;
        }
        #endregion

        #region 中文检测
        //检查是否有中文字符
        public static bool IsHashCHZN(string inputData)
        {
            Match m = RegCHZN.Match(inputData);
            return m.Success;
        }
        #endregion
        #region 是否为中文
        //是否是中文
        public static bool IsCHZN(string inputData)
        {
            Match m = RegCHZNS.Match(inputData);
            return m.Success;
        }
        #endregion 
        #region 邮件地址
        //是否是浮点数，可带正负号
        public static bool IsEmail(string inputData)
        {
            Match m = RegEmail.Match(inputData);
            return m.Success;
        }
        #endregion

        #region 日期格式判断
        public static bool IsDateTime(string str)
        {
            try
            {
                if (!string.IsNullOrEmpty(str))
                {
                    DateTime.Parse(str);
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 其他
        //检查字符串最大长度，返回指定长度的串
        public static string StringCheck(string sqlInput, int maxLength)
        {
            if (sqlInput != null && sqlInput != string.Empty)
            {
                sqlInput = sqlInput.Trim();
                if (sqlInput.Length > maxLength)
                    sqlInput = sqlInput.Substring(0, maxLength);
            }
            return sqlInput;
        }
        //字符串编码
        //public static string 

        //设置Label显示Encode的字符串
        public static void SetLabel(Label lbl, string txtInput)
        {
            lbl.Text = txtInput;
        }
        public static void SetLabel(Label lbl, object inputObj)
        {
            SetLabel(lbl, inputObj.ToString());
        }
        ////字符串清理
        //public static string InputText(string inputString, int maxLength)
        //{
        //    StringBuilder retVal = new StringBuilder();
        //    //检查是否为空
        //    if ((inputString != null) && (inputString != String.Empty))
        //    {
        //        inputString = inputString.Trim();

        //        //检查长度
        //        if (inputString.Length > maxLength)
        //            inputString = inputString.Substring(0, maxLength);

        //        //替换危险字符
        //        for (int i = 0; i < inputString.Length; i++)
        //        {
        //            switch (inputString[i])
        //            {
        //                case '"': retVal.Append("&quot;"); break;
        //                case '<': retVal.Append("&lt;"); break;
        //                case '>': retVal.Append("&gt;"); break;
        //                default:
        //                    retVal.Append(inputString[i]);break;
        //            }
        //        }
        //        retVal.Replace("'", " ");//替换单引号
        //    }
        //    return retVal.ToString();
        //}
        //转换成HTML code
        //public static string Encode(string str)
        //{
        //    str = str.Replace("&", "&amp;");
        //    str = str.Replace("'", "''");
        //    str = str.Replace("\"", "&quot;");
        //    str = str.Replace(" ", "&nbsp;");
        //    str = str.Replace("<", "&lt;");
        //    str = str.Replace(">", "&gt;");
        //    str = str.Replace("\n", "<br>");
        //    return str;
        //}
        //解析html成普通文本
        //public static string Decode(string str)
        //{
        //    str = str.Replace("<br>", "\n");
        //    str = str.Replace("&gt;", ">");
        //    str = str.Replace("&lt;", "<");
        //    str = str.Replace("&nbsp;", " ");
        //    str = str.Replace("&quot;", "\"");
        //    return str;
        //}
        //public static string SqlTextClear(string sqlText)
        //{
        //    if (sqlText == null)
        //        return null;
        //    if (sqlText == "")
        //        return "";

        //    sqlText = sqlText.Replace(",", "");//去除,
        //    sqlText = sqlText.Replace("<", "");//去除<
        //    sqlText = sqlText.Replace(">", "");//去除>
        //    sqlText = sqlText.Replace("--", "");//去除--
        //    sqlText = sqlText.Replace("'", "");//去除'
        //    sqlText = sqlText.Replace("\"", "");//去除"
        //    sqlText = sqlText.Replace("=", "");//去除=
        //    sqlText = sqlText.Replace("%", "");//去除%
        //    sqlText = sqlText.Replace(" ", "");//去除空格
        //    return sqlText;
        //}
        #endregion

        #region 判断是否由特定字符组成
        public static bool isContainSameChar(string strInput)
        {
            string charInput = string.Empty;
            if(!string.IsNullOrEmpty(strInput))
                charInput=strInput.Substring(0,1);
            return isContainSameChar(strInput, charInput, strInput.Length);
        }
        public static bool isContainSameChar(string strInput, string charInput, int lenInput)
        {
            if (string.IsNullOrEmpty(charInput))
                return false;
            else
            {
                Regex RegNumber = new Regex(string.Format("^([{0}])+$,charInput"));
                Match m = RegNumber.Match(strInput);
                return m.Success;
            }
        }
        #endregion

        #region 检查输入的参数是不是某些定义好的特殊字符
        //这个方法目前用于密码输入的安全检查 
        public static bool isContainSpecChar(string strInput)
        {
            string[] list = new string[] { "123456", "654321" };
            bool result = false;//new bool();
            for (int i = 0; i < list.Length; i++)
            {
                if (strInput == list[i])
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        #endregion

        public static string SafeLongFilter(string text, long defaultValue, char split = ',')
        {
            if (text.Trim().Length < 1)
                return defaultValue.ToString(CultureInfo.InvariantCulture);
            //CultureInfo类位于System.Globalization命名空间内。简单的说，当进行数字，日期时间，字符串匹配时，都会进行CultureInfo操作，
            //就是在不同的CultureInfo下，这些操作的结果可能会不一样。
            //InvariantCulture让不管客户端在什么语言环境下，输出的格式都是同一的。
            string[] tmpSplit=text.Split(new[] {split},StringSplitOptions.RemoveEmptyEntries);
            if(tmpSplit.Length<1)
                return defaultValue.ToString(CultureInfo.InvariantCulture);

            long tmp;
            for (int i = 0; i < tmpSplit.Length; i++)
            {
                if (long.TryParse(tmpSplit[i], out tmp))
                    tmpSplit[i] = tmp.ToString(CultureInfo.InvariantCulture);
                else
                    tmpSplit[i] = defaultValue.ToString(CultureInfo.InvariantCulture);
            }
            return string.Join(split.ToString(CultureInfo.InvariantCulture), tmpSplit);
        }
    }

}