using AntdUI;
using VSBatchRegister.Business.User.Model;
using VSBatchRegister.Business.User.Service;
using VSBatchRegister.Business.User.ViewModel;
using VSBatchRegister.Logger;
using VSBatchRegister.Tools.Files;

namespace VSBatchRegister
{
    /// <summary>
    /// @View
    ///     主窗体
    ///
    ///     0. 数据库状态加载
    ///     1. 选择Excel文件
    ///     2. 导出数据到数据库
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly AdminUserViewModel _viewModel;
        private readonly AdminUserSrv _srv;

        public MainForm()
        {
            InitializeComponent();

            _viewModel = new AdminUserViewModel();
            _srv = new AdminUserSrv();
        }

        /// <summary>
        /// 选择文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ChoseFile_Click(object sender, EventArgs e)
        {
            // 选择目标excel文件
            var excelPath = FileSelector.SelectFile();

            if (excelPath == null)
            {
                MessageBox.Show(@"未选择文件");
                return;
            }
            
            _viewModel.Temp = _srv.GetAdminUserBySheet(excelPath);

            TableMain.Columns =
            [
                new Column(nameof(AdminUser.SlAccount),"学号（用作账户名）"),
                new Column(nameof(AdminUser.SlName),"名称"),
                new Column(nameof(AdminUser.SlPhone),"手机号"),
            ];

            if (_viewModel is { Temp: not null })
            {
                TableMain.Binding(_viewModel.Temp);
            }
            
            Debug.Info("点击选择文件 | 加载");
        }

        /// <summary>
        /// 导出数据到数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ExportToSQL_Click(object sender, EventArgs e)
        {
            Debug.Info("点击导出数据到数据库");

            _viewModel?.SaveChanges();

            MessageBox.Show(@"导入成功（请不要重复导入）");
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MainForm_Load(object sender, EventArgs e)
        {
            var result = await _viewModel.GetAdminUsers();

            if (_viewModel.IsConnectDb)
            {
                ServerConnectStatus.State = TState.Success;
                ServerConnectStatus.Text = @"数据库连接成功";
            }
            else
            {
                ServerConnectStatus.State = TState.Error;
                ServerConnectStatus.Text = @"数据库连接失败";
            }

            TableMain.Columns =
            [
                new Column(nameof(AdminUser.SlAccount),"学号（用作账户名）"),
                new Column(nameof(AdminUser.SlName),"名称"),
                new Column(nameof(AdminUser.SlPhone),"手机号"),
            ];

            if (_viewModel is { AdminUsers: not null })
            {
                TableMain.Binding(_viewModel.AdminUsers);
            }

            Debug.Info("加载数据库");
        }
    }
}
