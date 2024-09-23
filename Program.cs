using Microsoft.VisualBasic;
using System;
var bassCashingClass = new Cash<string>();
var dataDownloader = new SlowDataDownloader();


Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));


Console.ReadKey();









//====================    IDataDownloader
public interface IDataDownloader
{

    string DownloadData(string resourceId);
}




public class SlowDataDownloader : IDataDownloader //T = BassCashingClas<string>

{



    public string DownloadData(string resourceId)
    {
        {

            Thread.Sleep(1000);

            return $"Some data for {resourceId}";
        }


    }
}
//================= ICashing            ===================================
public class Cash<T>
{
    public Dictionary<string, T> _cashedData { get; } = new() { };

    public T GetCach(string resourceId)
    {
        return _cashedData[resourceId];
    }

    public void SetCach(string resourceId, T data)
    {
        _cashedData[resourceId] = data;
    }
};



