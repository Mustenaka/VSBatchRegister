﻿namespace VSBatchRegister.Common.Common.Model;

/// <summary>
/// Model 数据层基类 - 用于业务数据, 防止复写
/// </summary>
public abstract class BaseModel
{
    public int Id { get; set; }     // ID 信息标识符
}