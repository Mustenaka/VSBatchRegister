namespace VSBatchRegister.Tools.Files;

public class FileHelper
{
    /// <summary>
    /// 将文件复制到指定目录，并返回文件名
    /// </summary>
    /// <param name="sourceFilePath">源文件路径</param>
    /// <param name="destinationFolder">目标目录路径</param>
    /// <returns>文件名</returns>
    public static string CopyFileToFolder(string? sourceFilePath, string destinationFolder)
    {
        if (string.IsNullOrEmpty(sourceFilePath))
        {
            return string.Empty;
        }

        // 检查源文件是否存在
        if (!File.Exists(sourceFilePath))
        {
            return string.Empty;
        }

        // 检查目标目录是否存在，不存在则创建
        if (!Directory.Exists(destinationFolder))
        {
            Directory.CreateDirectory(destinationFolder);
        }

        // 获取源文件名称
        var fileName = Path.GetFileName(sourceFilePath);

        // 构造目标文件路径
        var destinationFilePath = Path.Combine(destinationFolder, fileName);

        // 复制文件
        File.Copy(sourceFilePath, destinationFilePath, true);

        // 返回文件名
        return fileName;
    }

    /// <summary>
    /// 获取文件路径所在的文件夹上一层文件夹路径
    /// </summary>
    /// <param name="filePath">文件路径</param>
    /// <returns>上一层文件夹路径</returns>
    public static string GetParentFolder(string filePath)
    {
        // 检查文件路径是否为空或无效
        if (string.IsNullOrEmpty(filePath) || !Path.IsPathRooted(filePath))
        {
            throw new ArgumentException("文件路径无效：" + filePath);
        }

        // 获取文件所在目录
        var currentFolder = Path.GetDirectoryName(filePath);

        if (string.IsNullOrEmpty(currentFolder))
        {
            throw new InvalidOperationException("无法获取文件所在目录：" + filePath);
        }

        // 获取上一层目录
        var parentFolder = Directory.GetParent(currentFolder)?.FullName;

        if (string.IsNullOrEmpty(parentFolder))
        {
            throw new InvalidOperationException("无法获取上一层目录：" + currentFolder);
        }

        return parentFolder;
    }

    /// <summary>
    /// 判断字符串是否包含路径，并提取文件名。
    /// </summary>
    /// <param name="input">输入的字符串</param>
    /// <returns>提取的文件名或原始字符串</returns>
    public static string ExtractFileName(string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input ?? "";
        }

        // 使用 Path 类判断是否为有效路径
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException("输入字符串不能为空！");
        }

        try
        {
            // 获取文件名（如果路径有效）
            var fileName = Path.GetFileName(input);
            if (!string.IsNullOrEmpty(fileName) && fileName != input)
            {
                return fileName;
            }

            // 如果输入本身是文件名，则直接返回
            return input;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("处理路径时出错：" + ex.Message, ex);
        }
    }
}