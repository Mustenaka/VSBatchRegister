using VSBatchRegister.Business.User.Model;
using VSBatchRegister.Common.Common.Command.Detail;
using static VSBatchRegister.Business.User.Service.FetchUserFromSheet;
using static VSBatchRegister.Common.Common.Command.Detail.ReadExcelCommand;

namespace VSBatchRegister.Business.User.Service;

public class AdminUserSrv
{
    private readonly ReadExcelCommand _readExcelCommand = new ();
    private readonly FetchUserFromSheet _fetchUserCommand = new();

    /// <summary>
    /// 通过Excel文件路径获取管理用户信息
    ///     1. 解析Excel文件，获取Sheet
    ///     2. 读取Sheet中的数据，转换为管理用户信息
    /// </summary>
    /// <param name="excelPath"></param>
    /// <returns></returns>
    public AntdUI.AntList<AdminUser>? GetAdminUserBySheet(string excelPath)
    {
        var sheet = _readExcelCommand?.Execute(new ReadExcelCommandContext(excelPath)).GetSheet();

        var users = _fetchUserCommand?.Execute(new FetchUserFromSheetContext(sheet!)).GetAdminUsers();

        return users;
    }
}