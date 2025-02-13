using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VSBatchRegister.Business.User.Model;

// ReSharper disable once StringLiteralTypo
[Table("sys_loginadmin")]
public class AdminUser : AntdUI.NotifyProperty
{
    private long? _slId;
    private string? _slAccount;
    private string? _slPassword;
    private string? _slPhone;
    private string? _slName;
    private byte[]? _slAvatar;
    private string? _slIntroduction;
    private long? _slDeptId;
    private long? _slRoleId;
    private long? _slPostId;
    private bool? _slIsFirstLogin;
    private bool? _slIsDel;
    private DateTime? _slCreateDate;
    private DateTime? _slUpdateDate;
    private string? _slReserved1;
    private string? _slReserved2;

    [Key]
    [Column("sl_id")]
    [Required]
    [Comment("主键, id")]
    public long? SlId
    {
        get => _slId;
        set
        {
            if (_slId != value)
            {
                _slId = value;
                OnPropertyChanged(nameof(SlId));
            }
        }
    }

    [Column("sl_account", TypeName = "varchar(32)")]
    [Comment("用户名（用于登陆）")]
    public string? SlAccount
    {
        get => _slAccount;
        set
        {
            if (_slAccount != value)
            {
                _slAccount = value;
                OnPropertyChanged(nameof(SlAccount));
            }
        }
    }

    [Column("sl_password", TypeName = "varchar(64)")]
    [Comment("密码")]
    public string? SlPassword
    {
        get => _slPassword;
        set
        {
            if (_slPassword != value)
            {
                _slPassword = value;
                OnPropertyChanged(nameof(SlPassword));
            }
        }
    }

    [Column("sl_phone", TypeName = "varchar(1)")]
    [Comment("手机号|不需要填写")]
    public string? SlPhone
    {
        get => _slPhone;
        set
        {
            if (_slPhone != value)
            {
                _slPhone = value;
                OnPropertyChanged(nameof(SlPhone));
            }
        }
    }

    [Column("sl_name", TypeName = "varchar(64)")]
    [Comment("名字|学生姓名")]
    public string? SlName
    {
        get => _slName;
        set
        {
            if (_slName != value)
            {
                _slName = value;
                OnPropertyChanged(nameof(SlName));
            }
        }
    }

    [Column("sl_avatar")]
    [Comment("头像（base64）")]
    public byte[]? SlAvatar
    {
        get => _slAvatar;
        set
        {
            if (_slAvatar != value)
            {
                _slAvatar = value;
                OnPropertyChanged(nameof(SlAvatar));
            }
        }
    }

    [Column("sl_introduction", TypeName = "varchar(255)")]
    [Comment("权限介绍")]
    public string? SlIntroduction
    {
        get => _slIntroduction;
        set
        {
            if (_slIntroduction != value)
            {
                _slIntroduction = value;
                OnPropertyChanged(nameof(SlIntroduction));
            }
        }
    }

    [Column("sl_deptId")]
    [Comment("部门id")]
    public long? SlDeptId
    {
        get => _slDeptId;
        set
        {
            if (_slDeptId != value)
            {
                _slDeptId = value;
                OnPropertyChanged(nameof(SlDeptId));
            }
        }
    }

    [Column("sl_roleId")]
    [Comment("角色id")]
    public long? SlRoleId
    {
        get => _slRoleId;
        set      
        {
            if (_slRoleId != value)
            {
                _slRoleId = value;
                OnPropertyChanged(nameof(SlRoleId));
            }
        }
    }

    [Column("sl_postId")]
    [Comment("post id")]
    public long? SlPostId
    {
        get => _slPostId;
        set
        {
            if (_slPostId != value)
            {
                _slPostId = value;
                OnPropertyChanged(nameof(SlPostId));
            }
        }
    }

    [Column("sl_isFirstLogin")]
    [Comment("是否初次登陆（存在bug）")]
    public bool? SlIsFirstLogin
    {
        get => _slIsFirstLogin;
        set
        {
            if (_slIsFirstLogin != value)
            {
                _slIsFirstLogin = value;
                OnPropertyChanged(nameof(SlIsFirstLogin));
            }
        }
    }

    [Column("sl_isDel")]
    [Comment("是否被删除，默认0")]
    public bool? SlIsDel
    {
        get => _slIsDel;
        set
        {
            if (_slIsDel != value)
            {
                _slIsDel = value;
                OnPropertyChanged(nameof(SlIsDel));
            }
        }
    }

    [Column("sl_createDate")]
    [Comment("创建日期")]
    public DateTime? SlCreateDate
    {
        get => _slCreateDate;
        set
        {
            if (_slCreateDate != value)
            {
                _slCreateDate = value;
                OnPropertyChanged(nameof(SlCreateDate));
            }
        }
    }

    [Column("sl_updateDate")]
    [Comment("更新日期")]
    public DateTime? SlUpdateDate
    {
        get => _slUpdateDate;
        set
        {
            if (_slUpdateDate != value)
            {
                _slUpdateDate = value;
                OnPropertyChanged(nameof(SlUpdateDate));
            }
        }
    }

    [Column("sl_reserved1", TypeName = "varchar(64)")]
    [Comment("不知道干嘛1")]
    public string? SlReserved1
    {
        get => _slReserved1;
        set
        {
            if (_slReserved1 != value)
            {
                _slReserved1 = value;
                OnPropertyChanged(nameof(SlReserved1));
            }
        }
    }

    [Column("sl_reserved2", TypeName = "varchar(64)")]
    [Comment("不知道干嘛2")]
    public string? SlReserved2
    {
        get => _slReserved2;
        set
        {
            if (_slReserved2 != value)
            {
                _slReserved2 = value;
                OnPropertyChanged(nameof(SlReserved2));
            }
        }
    }
}