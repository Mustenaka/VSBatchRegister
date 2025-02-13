using NPOI.SS.UserModel;

namespace VSBatchRegister.Common.Common.Command.Detail;

/// <summary>
/// ReadExcelCommand - 公共命令：从Excel文件中读取Sheet
/// </summary>
public class ReadExcelCommand : ICommand<ReadExcelCommand>
{
    private string? fileString;
    private ExcelInteractive? _excelOpt;
    private ISheet? _sheet;

    /// <summary>
    /// ReadExcelCommandContext - 上下文类，用于传递文件路径
    /// </summary>
    public class ReadExcelCommandContext
    {
        public string FilePath { get; set; }

        /// <summary>
        /// 初始化文件路径
        /// </summary>
        /// <param name="filePath"></param>
        public ReadExcelCommandContext(string filePath)
        {
            this.FilePath = filePath;
        }
    }

    /// <summary>
    /// 执行命令，从Excel文件中读取Sheet
    /// </summary>
    /// <param name="input">命令输入参数，必须是ReadExcelCommandContext类型</param>
    /// <returns>返回读取的ISheet对象</returns>
    /// <exception cref="System.Exception">当输入参数无法转换为ReadExcelCommandContext时抛出异常</exception>
    public ReadExcelCommand Execute(object? input)
    {
        var context = input as ReadExcelCommandContext ?? throw new System.Exception("命令数据无法转换为 ReadExcelCommandContext");

        fileString = context.FilePath;
        _excelOpt = new ExcelInteractive(fileString);
        _sheet = _excelOpt.Read();

        return this;
    }

    /// <summary>
    /// 获取读取的Sheet对象
    /// </summary>
    /// <returns>返回ISheet对象</returns>
    /// <exception cref="System.Exception">当Sheet对象为null时抛出异常</exception>
    public ISheet GetSheet()
    {
        if (_sheet == null)
        {
            throw new System.Exception("Sheet is null");
        }

        return _sheet;
    }
}