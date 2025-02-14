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
    ///     ������
    ///
    ///     0. ���ݿ�״̬����
    ///     1. ѡ��Excel�ļ�
    ///     2. �������ݵ����ݿ�
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
        /// ѡ���ļ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ChoseFile_Click(object sender, EventArgs e)
        {
            // ѡ��Ŀ��excel�ļ�
            var excelPath = FileSelector.SelectFile();

            if (excelPath == null)
            {
                MessageBox.Show(@"δѡ���ļ�");
                return;
            }
            
            _viewModel.Temp = _srv.GetAdminUserBySheet(excelPath);

            TableMain.Columns =
            [
                new Column(nameof(AdminUser.SlAccount),"ѧ�ţ������˻�����"),
                new Column(nameof(AdminUser.SlName),"����"),
                new Column(nameof(AdminUser.SlPhone),"�ֻ���"),
            ];

            if (_viewModel is { Temp: not null })
            {
                TableMain.Binding(_viewModel.Temp);
            }
            
            Debug.Info("���ѡ���ļ� | ����");
        }

        /// <summary>
        /// �������ݵ����ݿ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ExportToSQL_Click(object sender, EventArgs e)
        {
            Debug.Info("����������ݵ����ݿ�");

            _viewModel?.SaveChanges();

            MessageBox.Show(@"����ɹ����벻Ҫ�ظ����룩");
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MainForm_Load(object sender, EventArgs e)
        {
            var result = await _viewModel.GetAdminUsers();

            if (_viewModel.IsConnectDb)
            {
                ServerConnectStatus.State = TState.Success;
                ServerConnectStatus.Text = @"���ݿ����ӳɹ�";
            }
            else
            {
                ServerConnectStatus.State = TState.Error;
                ServerConnectStatus.Text = @"���ݿ�����ʧ��";
            }

            TableMain.Columns =
            [
                new Column(nameof(AdminUser.SlAccount),"ѧ�ţ������˻�����"),
                new Column(nameof(AdminUser.SlName),"����"),
                new Column(nameof(AdminUser.SlPhone),"�ֻ���"),
            ];

            if (_viewModel is { AdminUsers: not null })
            {
                TableMain.Binding(_viewModel.AdminUsers);
            }

            Debug.Info("�������ݿ�");
        }
    }
}
