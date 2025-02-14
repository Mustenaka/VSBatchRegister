namespace VSBatchRegister.Tools.Util;

public static class AntdExtend
{
    public static AntdUI.AntList<T> ToAntList<T>(this List<T> list)
    {
        var antList = new AntdUI.AntList<T>();
        foreach (var item in list)
        {
            antList.Add(item);
        }

        return antList;
    }
}