using DomainEvent;
using DomainEvent.Core;
using DomainEvent.Fx.Bootstrapper;
using System;

namespace DomainEventDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //启动启动器
            Bootstrapper.Run();

            //开始演示
            Console.WriteLine("//开始演示//");

            Console.WriteLine("=====================");

            Console.WriteLine("");
            Console.WriteLine("注册领域事件");
            //可以这样进行注册（推荐）
            //程序根据名称「ProductSnpCrtEvnAgr」读取配置并完成初始化与订阅工作
            DomainEventBus.Register("ProductSnpCrtEvnAgr");

            /*

            //也可以这样进行注册（不推荐，这样就不能用到 DomainEventBus 的配置了）
            //检查 DomainEventBus 内是否存在名称为「ProductSnpCrtEvnAgr」的领域事件聚合封装体
            //如果存在，对其缓存进行刷新
            //如果不存在，则使用给定的领域事件聚合封装体
            DomainEventAggregator eventAggregator = new DomainEventWrapper("ProductSnpCrtEvnAgr", 3600*72);
            DomainEventBus.Register("ProductSnpCrtEvnAgr", eventAggregator);

             */

            //DO SOMETHING

            Console.WriteLine("领域事件数据准备");
            //准备一个领域事件，并对其进行初始化
            var @event = new ProductSnapCreatedEvent { ProductHash = "123" };

            Console.WriteLine("发布领域事件");
            //发布领域事件
            //领域事件总线根据名称「ProductSnpCrtEvnAgr」检查相关的领域事件聚合封装体
            //完成对参数的自校验工作后，发布并执行领域事件或异步执行领域事件
            DomainEventBus.Publish("ProductSnpCrtEvnAgr", @event);

            Console.WriteLine("=====================");
            Console.WriteLine("//演示结束//");

            Console.WriteLine("");

            Console.WriteLine("输入任意东东退出");
            Console.ReadLine();
        }
    }
}