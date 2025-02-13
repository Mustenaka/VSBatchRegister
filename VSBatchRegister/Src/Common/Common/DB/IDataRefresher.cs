namespace VSBatchRegister.Common.Common.DB;

public interface IDataRefresher
{
    Task RefreshDataAsync();
}