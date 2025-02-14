using System.Reflection;

namespace VSBatchRegister.Tools.Util;

public static class ReflectionHelper
{
    /// <summary>
    /// 过滤掉指定属性，返回与原始对象类型一致的新对象，但排除指定字段。
    /// </summary>
    /// <typeparam name="T">实体对象的类型</typeparam>
    /// <param name="source">实体对象</param>
    /// <param name="excludeProperties">要排除的属性名称</param>
    /// <returns>包含剩余属性的对象</returns>
    public static T FilterProperties<T>(T source, params string[] excludeProperties) where T : new()
    {
        // 创建与原始对象类型一致的新对象
        T result = new T();

        // 获取所有属性
        PropertyInfo[] properties = typeof(T).GetProperties();

        foreach (var property in properties)
        {
            // 如果当前属性不在排除列表中，则赋值
            if (!excludeProperties.Contains(property.Name) && property.CanWrite)
            {
                var value = property.GetValue(source);
                property.SetValue(result, value);
            }
        }

        return result;
    }

    /// <summary>
    /// 批量过滤对象列表的属性。
    /// </summary>
    /// <typeparam name="T">实体对象的类型</typeparam>
    /// <param name="sourceList">实体对象列表</param>
    /// <param name="excludeProperties">要排除的属性名称</param>
    /// <returns>包含剩余属性的对象列表</returns>
    public static IEnumerable<T> FilterPropertiesList<T>(IEnumerable<T> sourceList, params string[] excludeProperties) where T : new()
    {
        return sourceList.Select(source => FilterProperties(source, excludeProperties)).ToList();
    }
}