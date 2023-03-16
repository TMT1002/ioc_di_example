#nullable disable
using System;
using Microsoft.Extensions.DependencyInjection;
// Lập trình theo kiểu truyền thống 

namespace InverseOfControl
{
    interface IClassB
    {
        public void ActionB();
    }
    interface IClassC
    {
        public void ActionC();
    }
    class ClassC : IClassC
    {
        public ClassC() => Console.WriteLine("ClassC da duoc tao");
        public void ActionC() => Console.WriteLine("Hoat dong cua ClassC");
    }
    // class ClassC1 : IClassC
    // {
    //     public ClassC1() => Console.WriteLine("ClassC1 da duoc tao");
    //     public void ActionC() => Console.WriteLine("Hoat dong cua ClassC1");
    // }
    class ClassB : IClassB
    {
        IClassC c_dependency;
        public ClassB(IClassC classc)
        {
            c_dependency = classc;
            Console.WriteLine("ClassB da duoc tao");
        }
        public void ActionB()
        {
            Console.WriteLine("Hoat dong cua ClassB");
            c_dependency.ActionC();
        }
    }


    class ClassA
    {
        IClassB b_dependency;
        public ClassA(IClassB classb)
        {
            b_dependency = classb;
            Console.WriteLine("ClassA da duoc tao");
        }
        public void ActionA()
        {
            Console.WriteLine("Hoat dong cua ClassA");
            b_dependency.ActionB();
        }
    }
    class Program
    {
        public static void Main()
        {
            var services = new ServiceCollection(); // tao doi tuong services

            // đăng ký các dịch vụ
            services.AddSingleton<ClassA,ClassA>();
            services.AddSingleton<IClassB, ClassB>();
            services.AddSingleton<IClassC, ClassC>();

            var provider = services.BuildServiceProvider();

            ClassA test = provider.GetService<ClassA>();
            test.ActionA();
        }
    }
}