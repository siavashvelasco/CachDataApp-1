using Microsoft.VisualBasic;
using System;
var dataDownloader = new SlowDataDownloader<Cash<object, object>>(new Cash<object, object>());


Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));


Console.ReadKey();









//====================    IDataDownloader
public interface IDataDownloader<T>
{

    string DownloadData<Key>(Key resourceId);
}




public class SlowDataDownloader<T> : IDataDownloader<T> where T:ICash<object, object>
      //T = Cash<type>

{
    T _cash;
    public SlowDataDownloader(T cash)
    {
        _cash = cash;
    }

    public string DownloadData<Key>(Key resourceId)
    {
        {
            if (!_cash._cashedData.ContainsKey(resourceId))
            {
                Thread.Sleep(1000);
                var somedata = $"somedata{resourceId}111111";
                _cash.SetCach(resourceId, somedata);
                
                return somedata.ToString();

            }
            return _cash.GetCach(resourceId).ToString();

        }


    }
}
//================= ICashing            ===================================
public interface ICash<Key, Value>
{
    public Dictionary<Key, Value> _cashedData { get; }
    public Value GetCach(Key resourceId);
    public void SetCach(Key resourceId, Value data);

}public class Cash<Key,Value>: ICash<Key, Value>
{
    public Dictionary<Key, Value> _cashedData { get; } = new() { };

    public Value GetCach(Key resourceId)
    {
        return _cashedData[resourceId];
    }

    public void SetCach(Key resourceId, Value data)
    {
        _cashedData[resourceId] = data;
    }
};



