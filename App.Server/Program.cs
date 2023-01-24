using App.Business.Concrete;
using App.DataAccess.Concrete.EFEntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using App.DataAccess.Abstract;
using Newtonsoft.Json;

namespace App.Server
{
    public class Program
    {
        static TcpListener listener = null;
        static BinaryWriter bw = null;
        static BinaryReader br = null;
        public static List<TcpClient> Clients { get; set; }

        static void Main(string[] args)
        {

            Clients = new List<TcpClient>();
            var ip = IPAddress.Parse("10.2.13.15");
            var port = 27001;

            var productService = new ProductService(new EFProductDal());
            var ep = new IPEndPoint(ip, port);
            listener = new TcpListener(ep);
            listener.Start();
          
            Console.WriteLine($"Listening on {listener.LocalEndpoint}");
            while (true)
            {
                var client = listener.AcceptTcpClient();
                Clients.Add(client);
                Console.WriteLine($"{client.Client.RemoteEndPoint}");
                Task.Run(() =>
                {
                    var reader = Task.Run(() =>
                    {
                        //foreach (var item in Clients)
                        //{
                        //    Task.Run(() =>
                        //    {
                        //        var stream = item.GetStream();
                        //        br = new BinaryReader(stream);
                        //        while (true)
                        //        {
                        //            try
                        //            {
                        //                var msg = br.ReadString();
                        //                Console.WriteLine($"CLIENT : {client.Client.RemoteEndPoint} : {msg}");

                        //            }
                        //            catch (Exception ex)
                        //            {
                        //                Console.WriteLine($"{item.Client.RemoteEndPoint}  disconnected");
                        //                Clients.Remove(item);
                        //            }
                        //        }
                        //    }).Wait(50);
                        //}

                        //var stream = client.GetStream();
                        //br = new BinaryReader(stream);
                        //while (true)
                        //{
                        //    try
                        //    {
                        //        var msg = br.ReadString();
                        //        Console.WriteLine($"CLIENT : {client.Client.RemoteEndPoint} : {msg}");
                        //        if(msg ==@"Product/Getlist")
                        //        {
                        //            var products = productService.GetAll();
                        //            var jsonstring = JsonConvert.SerializeObject(products);
                        //            bw.Write(jsonstring);
                        //        }
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        Console.WriteLine(ex.Message);
                        //    }
                        //}
                    });

                    var writer = Task.Run(() =>
                    {
                        //var stream = client.GetStream();
                        //bw= new BinaryWriter(stream);
                        //while (true)
                        //{
                        //    var msg = Console.ReadLine();
                        //    bw.Write(msg);
                        //}

                        //while (true)
                        //{
                        //    var msg = Console.ReadLine();
                        //    foreach (var item in Clients)
                        //    {
                        //        var stream = item.GetStream();
                        //        bw = new BinaryWriter(stream);
                        //        bw.Write(msg);
                        //    }
                        //    foreach (var item in Clients)
                        //    {
                        //        if (item.Connected)
                        //        {
                        //            Console.ForegroundColor = ConsoleColor.Green;
                        //        }
                        //        else
                        //        {
                        //            Console.ForegroundColor = ConsoleColor.Red;
                        //        }
                        //        Console.WriteLine($"item : {item.Client.RemoteEndPoint}");
                        //        Console.ResetColor();
                        //    }
                        //}
                    });
                });
            }
        }
    }

}
