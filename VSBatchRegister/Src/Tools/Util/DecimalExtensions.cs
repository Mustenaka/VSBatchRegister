using System.Text;

namespace VSBatchRegister.Tools.Util;

public static class DecimalExtensions
{
    private static readonly string[] ChineseNumbers = { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };
    private static readonly string[] ChineseUnits = { "", "拾", "佰", "仟" };
    private static readonly string[] ChineseBigUnits = { "", "万", "亿", "兆" };

    public static string ToChineseCapital(this decimal number)
    {
        if (number == 0)
            return "零元整";

        StringBuilder result = new StringBuilder();
        string[] parts = number.ToString("F2").Split('.');
        string integerPart = parts[0];
        string decimalPart = parts.Length > 1 ? parts[1] : "00";

        // 处理整数部分
        for (int i = 0; i < integerPart.Length; i++)
        {
            int digit = integerPart[integerPart.Length - 1 - i] - '0';
            int unitIndex = i % 4;
            int bigUnitIndex = i / 4;

            if (digit != 0)
            {
                result.Insert(0, ChineseUnits[unitIndex]);
                result.Insert(0, ChineseNumbers[digit]);
            }
            else if (unitIndex == 0 && result.Length > 0 && result[0] != '零')
            {
                result.Insert(0, ChineseBigUnits[bigUnitIndex]);
            }

            if (unitIndex == 0 && bigUnitIndex > 0)
            {
                result.Insert(0, ChineseBigUnits[bigUnitIndex]);
            }
        }

        result.Append("元");

        // 处理小数部分
        if (decimalPart == "00")
        {
            result.Append("整");
        }
        else
        {
            if (decimalPart[0] != '0')
            {
                result.Append(ChineseNumbers[decimalPart[0] - '0']);
                result.Append("角");
            }
            if (decimalPart[1] != '0')
            {
                result.Append(ChineseNumbers[decimalPart[1] - '0']);
                result.Append("分");
            }
        }

        return result.ToString().Replace("零拾", "零").Replace("零佰", "零").Replace("零仟", "零").Replace("零万", "万").Replace("零亿", "亿").Replace("零兆", "兆").Replace("零零", "零").TrimEnd('零');
    }
}