using System.Diagnostics;
using NPOI.SS.UserModel;

namespace VSBatchRegister.Common.Common.Command.Detail;

/// <summary>
/// WriteExcelCommand - 公共命令：保存Sheet成为一个新文件
/// </summary>
public class WriteExcelCommand : ICommand<WriteExcelCommand>
{
    private string? _filePath;              // 保存文件路径
    private string? _sheetName;              // 设置的表格名称
    private ISheet? _sheetFromOther;        // 外部Workbook表
    private ISheet? _sheetFromMyself;       // 自身表格
    private IWorkbook? _workbook;           // 自身工作簿（用于新文件）

    /// <summary>
    /// WriteExcelCommand - 公共命令：保存Sheet成为一个新文件
    /// </summary>
    /// <param name="input">WriteExcelCommandContext上下文</param>
    /// <returns>保存文件地址</returns>
    /// <exception cref="Exception">数据错误</exception>
    public WriteExcelCommand Execute(object? input)
    {
        var context = input as WriteExcelCommandContext ?? throw new Exception("命令数据无法转换为 WriteExcelCommandContext");

        // 获取context信息，及获取外部Sheet列表
        _filePath = context.FilePath;
        _sheetFromOther = context.SheetFromOther;
        _sheetName = context.SheetName;

        // 创建一个工作空间，用于生成新文件
        //_workbook = new XSSFWorkbook();
        //_sheetFromMyself = _workbook.CreateSheet(_sheetName);
        //CellExtend.CopySheet(_sheetFromOther!, _sheetFromMyself);
        //CrossCellExtend.CopySheet(_sheetFromOther!, _sheetFromMyself);

        // 保留原有workbook，并直接创建文件
        Debug.Assert(_sheetFromOther != null, nameof(_sheetFromOther) + " != null");

        _workbook = _sheetFromOther.Workbook;
        _sheetFromMyself = _sheetFromOther;

        // 删除其他的表
        for (var i = _workbook.NumberOfSheets - 1; i >= 0; i--)
        {
            if (_workbook.GetSheetName(i) != _sheetFromOther.SheetName)
            {
                _workbook.RemoveSheetAt(i);
            }
        }

        // 改名
        var sheetIndex = _workbook.GetSheetIndex(_sheetFromOther);
        _workbook.SetSheetName(sheetIndex, _sheetName);

        // 保存文件
        using var fs = new FileStream(_filePath!, FileMode.Create, FileAccess.Write);
        _workbook.Write(fs);

        return this!;
    }

    /// <summary>
    /// WriteExcelCommand 的上下文
    /// </summary>
    public class WriteExcelCommandContext
    {
        /// <summary>
        /// WriteExcelCommand - WriteExcelCommandContext
        /// </summary>
        /// <param name="filePath">保存文件路径</param>
        /// <param name="sheetFromOther">另一个需要保存的表格</param>
        /// <param name="sheetName">本保存的表格名称</param>
        public WriteExcelCommandContext(string? filePath, ISheet? sheetFromOther, string? sheetName)
        {
            FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
            SheetFromOther = sheetFromOther ?? throw new ArgumentNullException(nameof(sheetFromOther));
            SheetName = sheetName ?? throw new ArgumentNullException(nameof(sheetName));
        }

        public string? FilePath { get; set; }
        public ISheet? SheetFromOther { get; set; }
        public string? SheetName { get; set; }
    }
}

