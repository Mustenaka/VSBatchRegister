namespace VSBatchRegister.Tools.Files;

/// <summary>
/// 文件选择器
/// </summary>
public static class FileSelector
{
    /// <summary>
    /// 打开文件选择窗口，选择指定格式的文件
    /// </summary>
    /// <param name="filter">文件过滤器，例如 "Excel 文件 (*.xlsx)|*.xlsx|所有文件 (*.*)|*.*"</param>
    /// <returns>所选文件的路径，如果没有选择文件则返回 null</returns>
    public static string? SelectFile(string filter = "Excel 文件 (*.xlsx)|*.xlsx|所有文件 (*.*)|*.*")
    {
        using var openFileDialog = new OpenFileDialog();

        openFileDialog.Filter = filter;
        openFileDialog.Title = @"请选择一个文件";

        return openFileDialog.ShowDialog() == DialogResult.OK ? openFileDialog.FileName : null;
    }

    /// <summary>
    /// 打开文件夹选择窗口，并在选中的文件夹内创建一个指定名称的子文件夹
    /// </summary>
    /// <param name="folderName">要创建的子文件夹名称</param>
    /// <returns>新创建的子文件夹路径，如果没有选择文件夹或创建失败则返回 null</returns>
    public static string? CreateFolderInSelectedPath(string folderName)
    {
        using var folderBrowserDialog = new FolderBrowserDialog();
        folderBrowserDialog.Description = @"请选择一个文件夹";

        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            string selectedFolderPath = folderBrowserDialog.SelectedPath;
            string newFolderPath = Path.Combine(selectedFolderPath, folderName);

            try
            {
                if (!Directory.Exists(newFolderPath))
                {
                    Directory.CreateDirectory(newFolderPath);
                }
                return newFolderPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"文件夹创建失败: {ex.Message}", @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        return null;
    }

    /// <summary>
    /// 获取一个文件夹路径
    /// </summary>
    /// <returns></returns>
    public static string? GetFolder()
    {
        using (var folderBrowserDialog = new FolderBrowserDialog())
        {
            folderBrowserDialog.Description = @"请选择一个文件夹作为保存";

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string rootPath = folderBrowserDialog.SelectedPath;

                return rootPath;
            }
            else
            {
                return null;
            }
        }
    }

    /// <summary>
    /// 读取图片并转换成Base64
    /// </summary>
    /// <returns></returns>
    public static string SelectImageToBase64()
    {
        // 创建文件选择对话框
        OpenFileDialog openFileDialog = new OpenFileDialog
        {
            Filter = @"Image Files|*.jpg;*.jpeg;*.png",  // 只允许选择jpg或png文件
            Title = @"选择图片"
        };

        // 显示对话框并检查是否选择了文件
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                // 获取文件路径
                var filePath = openFileDialog.FileName;
                 
                // 读取文件内容到字节数组
                var fileBytes = File.ReadAllBytes(filePath);

                // 将字节数组转换为Base64字符串
                var base64String = Convert.ToBase64String(fileBytes);

                // 返回Base64编码字符串
                return base64String;
            }
            catch (Exception ex)
            {
                MessageBox.Show(@$"转换失败: {ex.Message}", @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // 如果没有选择文件，返回null
        return null;
    }
}