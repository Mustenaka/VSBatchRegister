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
        public MainForm()
        {
            InitializeComponent();
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

            Debug.Info("���ѡ���ļ�");
        }

        /// <summary>
        /// �������ݵ����ݿ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ExportToSQL_Click(object sender, EventArgs e)
        {
            Debug.Info("����������ݵ����ݿ�");
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            Debug.Info("�������ݿ�");
        }
    }
}
