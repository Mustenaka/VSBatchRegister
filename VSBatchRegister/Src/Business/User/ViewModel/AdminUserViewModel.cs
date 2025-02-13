using AntdUI;
using Microsoft.EntityFrameworkCore;
using VSBatchRegister.Business.User.Context;
using VSBatchRegister.Business.User.Model;
using VSBatchRegister.Common.ViewModel;

namespace VSBatchRegister.Business.User.ViewModel;

/// <summary>
/// @ViewModel
/// </summary>
public class AdminUserViewModel : BaseViewModel
{
    private readonly AdminUserContextFactory _contextFractory;
    private readonly AdminUserContext _context;
    private AntList<AdminUser>? _adminUsers;

    private bool _isConnectDb;

    /// <summary>
    /// 获取所有的管理用户信息
    /// </summary>
    public AntList<AdminUser>? AdminUsers
    {
        get => _adminUsers;
        set
        {
            _adminUsers = value;
            OnPropertyChanged(nameof(AdminUsers));
        }
    }

    /// <summary>
    /// 获取数据库链接状态
    /// </summary>
    public bool IsConnectDb
    {
        get => _isConnectDb;
        set { /* 不允许外部设置 */ }
    }

    /// <summary>
    /// 获取用户视图信息
    /// </summary>
    public AdminUserViewModel()
    {
        _contextFractory = new AdminUserContextFactory();

        _context = _contextFractory.CreateDbContext();

        _isConnectDb = false;
    }

    /// <summary>
    /// 获取全部用户信息（此时会判断链接状态）
    /// </summary>
    /// <returns></returns>
    public async Task<bool> GetAdminUsers()
    {
        try
        {
            var result = await _context.Detail.ToListAsync();
            AdminUsers = new AntList<AdminUser>(result);
            _isConnectDb = true;
            return true;
        }
        catch (Exception e)
        {
            _isConnectDb = false;
            return false;
        }
    }

    /// <summary>
    /// 获取数据库链接状态
    /// </summary>
    /// <returns></returns>
    public bool GetConnectStatus()
    {
        return _isConnectDb;
    }

    /// <summary>
    /// 保存数据到数据库（异步）
    /// </summary>
    public async void SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// 保存数据到数据库（同步）
    /// </summary>
    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}