using Grpc.Net.Client;
using GrpcService1;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            var res = client.SayHello(new HelloRequest() { Name = "Fred" });
            Console.WriteLine(res.Message);

        }
    }
}
