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
        public MainForm()
        {
            InitializeComponent();
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

            Debug.Info("点击选择文件");
        }

        /// <summary>
        /// 导出数据到数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ExportToSQL_Click(object sender, EventArgs e)
        {
            Debug.Info("点击导出数据到数据库");
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            Debug.Info("加载数据库");
        }
    }
}
