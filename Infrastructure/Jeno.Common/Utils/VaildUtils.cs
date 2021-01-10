using Jeno.Common.Features;
using Masuit.Tools;

namespace Jeno.Common.Utils
{
    /// <summary>
    /// 验证工具类
    /// </summary>
    [DI(AutoFacInstanceType = Enum.AutoFacInstanceType.SingleInstance)]
    public class VaildUtils
    {
        public VaildUtils()
        {
        }

        /// <summary>
        /// 检查是否是IP地址
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public bool IsIP(string ip)
        {
            return ip.MatchInetAddress();
        }

        /// <summary>
        /// 检查是否是电子邮件，可在appsetting.json中添加EmailDomainWhiteList和EmailDomainBlockList配置邮箱域名黑白名单，逗号分隔，如"EmailDomainBlockList": "^\\w{1,5}@qq.com,^\\w{1,5}@163.com,^\\w{1,5}@gmail.com,^\\w{1,5}@outlook.com"
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsEmail(string email)
        {
            return email.MatchEmail().isMatch;
        }

        /// <summary>
        /// 检查是否是手机号码
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool IsPhone(string phone)
        {
            return phone.MatchPhoneNumber();
        }

        /// <summary>
        /// 检查是否是url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool IsUrl(string url)
        {
            return url.MatchUrl();
        }

        /// <summary>
        /// 检查是否是身份证
        /// </summary>
        /// <param name="id_card"></param>
        /// <returns></returns>
        public bool IsIdentifyCard(string id_card)
        {
            return id_card.MatchIdentifyCard();
        }

        /// <summary>
        /// 校验中国专利申请号或专利号，是否带校验位，校验位前是否带“.”，都可以校验，待校验的号码前不要带CN、ZL字样的前缀
        /// </summary>
        /// <param name="cNPatentNumber"></param>
        /// <returns></returns>
        public bool IsCNPatentNumber(string cNPatentNumber)
        {
            return cNPatentNumber.MatchCNPatentNumber();
        }
    }
}
