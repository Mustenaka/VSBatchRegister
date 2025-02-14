using NPOI.SS.UserModel;
using VSBatchRegister.Business.User.Model;
using VSBatchRegister.Common.Common.Command;

namespace VSBatchRegister.Business.User.Service;

public class FetchUserFromSheet : ICommand<FetchUserFromSheet>
{
    private ISheet? _sheet;
    private AntdUI.AntList<AdminUser> _adminUsers;


    public class FetchUserFromSheetContext(ISheet sheet)
    {
        public ISheet Sheet { get; set; } = sheet;
    }

    public FetchUserFromSheet Execute(object? input)
    {
        var context = input as FetchUserFromSheetContext ?? throw new System.Exception("命令数据无法转换为 FetchUserFromSheetContext");

        _sheet = context.Sheet;
        _adminUsers = new AntdUI.AntList<AdminUser>();

        LoadModelBySheet();

        return this;
    }

    public void LoadModelBySheet()
    {
        var sheet = _sheet;

        for (int i = 1; i <= sheet.LastRowNum; i++)
        {
            var row = sheet.GetRow(i);
            if (row == null)
            {
                continue;
            }

            var user = new AdminUser();

            user.SlAccount = row.GetCell(1).ToString();
            user.SlPassword = "fcea920f7412b5da7be0cf42b8c93759";
            user.SlName = row.GetCell(2).ToString();
            user.SlPhone = row.GetCell(3).ToString();

            user.SlCreateDate = row.GetCell(0).DateCellValue;

            _adminUsers.Add(user);
        }
    }

    public AntdUI.AntList<AdminUser> GetAdminUsers()
    {
        return _adminUsers;
    }
}