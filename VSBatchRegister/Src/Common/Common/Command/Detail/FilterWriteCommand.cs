using NPOI.SS.UserModel;

namespace VSBatchRegister.Common.Common.Command.Detail;

/// <summary>
/// FilterWriteCommand : 为表格所有的过滤内容添加具体内容
/// </summary>
public class FilterWriteCommand : ICommand<FilterWriteCommand>
{
    private string? _fillContext;
    private string? _filterContext;
    private ISheet? _sheet;

    /// <summary>
    /// FilterWriteCommandContext : FilterWriteCommand 上下文
    /// </summary>
    public class FilterWriteCommandContext
    {
        public string? FillContext { get; set; }
        public string? FilterContext { get; set; }
        public ISheet Sheet { get; set; }

        /// <summary>
        /// 填充具体内容
        /// </summary>
        /// <param name="fillContext">项目编号</param>
        /// <param name="sheet">填充表格</param>
        /// <param name="filterContext">过滤参数</param>
        /// <exception cref="ArgumentNullException"></exception>
        public FilterWriteCommandContext(string? fillContext, ISheet sheet, string? filterContext = "项目编号：")
        {
            FillContext = fillContext;
            FilterContext = filterContext;
            Sheet = sheet ?? throw new ArgumentNullException(nameof(sheet));
        }
    }

    public FilterWriteCommand Execute(object? input)
    {
        var context = input as FilterWriteCommandContext ?? throw new System.Exception("命令数据无法转换为 AddProjectSNCommandContext");

        _fillContext = context.FillContext;
        _filterContext = context.FilterContext;
        _sheet = context.Sheet;

        // 数据为空，直接返回
        if (_fillContext == null || _filterContext == null || _sheet == null)
        {
            return this;
        }

        AddFilterToSheet();
        return this;
    }

    /// <summary>
    /// 获取计算结果表格
    /// </summary>
    /// <returns></returns>
    public ISheet? GetSheet()
    {
        return _sheet;
    }

    private void AddFilterToSheet()
    {
        // 便利所有行
        for (var i = 0; i < _sheet!.LastRowNum; i++)
        {
            var row = _sheet.GetRow(i);
            if (row == null)
            {
                continue;
            }

            // 便利所有单元格
            for (var colIndex = 0; colIndex < row.LastCellNum; colIndex++)
            {
                var cell = row.GetCell(colIndex);
                if (cell is not { CellType: CellType.String })
                {
                    continue;
                }

                // 识别具体内容
                var cellValue = cell.StringCellValue;
                if (cellValue.Contains(_filterContext!))
                {
                    cell.SetCellValue(cellValue + _fillContext!);
                }
            }
        }
    }
}