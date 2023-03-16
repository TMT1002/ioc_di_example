using System;

// Lập trình theo kiểu truyền thống 

namespace InverseOfControl
{
    // class ClassC
    // {
    //     public void ActionC() => Console.WriteLine("Hoat dong cua ClassC");
    // }

    // class ClassB
    // {
    //     // Phụ thuộc của ClassB là ClassC
    //     ClassC c_dependency;

    //     public ClassB(ClassC classc) => c_dependency = classc;
    //     public void ActionB()
    //     {
    //         Console.WriteLine("Hoat dong cua ClassB");
    //         c_dependency.ActionC();
    //     }
    // }

    // class ClassA
    // {
    //     // Phụ thuộc của ClassA là ClassB
    //     ClassB b_dependency;

    //     public ClassA(ClassB classb) => b_dependency = classb;
    //     public void ActionA()
    //     {
    //         Console.WriteLine("Hoat dong cua ClassA");
    //         b_dependency.ActionB();
    //     }
    // }
    // class Program
    // {
    //     public static void Main()
    //     {
    //         ClassC objectC = new ClassC();
    //         ClassB objectB = new ClassB(objectC);
    //         ClassA objectA = new ClassA(objectB);
    //         objectA.ActionA();
    //         // Khởi tạo đối tượng objectC ==> objectB phụ thuộc vào objectC ==> objectA phụ thuộc vào objecyB
    //         // Khi chạy hàm ActionA() thì nó sẽ tham chiếu đến objectB và objectC để chạy
    //     }
    // }


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
    class ClassC1 : IClassC
    {
        public ClassC1() => Console.WriteLine("ClassC1 da duoc tao");
        public void ActionC() => Console.WriteLine("Hoat dong cua ClassC1");
    }
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
            IClassC objectC = new ClassC();
            // IClassC objectC = new ClassC1();
            IClassB objectB = new ClassB(objectC);
            ClassA objectA = new ClassA(objectB);

            objectA.ActionA();
            /* Class A tham chiếu đến classB thông qua interface ==> đối tượng tham chiếu đến có thể thay đổi được
            ví dụ như B1, B2,...
            ==> ví dụ khi thay đổi ClassC ==> ClassC1 thì objectB không có gì thay đổi vì nó tham chiếu đến dependence thông qua Interface
            */
        }
    }
}