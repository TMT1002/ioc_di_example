using System;

namespace InverseOfControl2
{
    class Horn
    {
        int level = 0;   // thêm thuộc tính level cho class
        public Horn(int level){   // constructor 
            this.level = level;
        }
        public void Beep() => Console.WriteLine("Bip Bip");
    }
    class Car
    {
        public void Beep()
        {
            Horn horn = new Horn(7);  // ==> phải sử thành Horn(7)
            horn.Beep();
        }
    }
    // viết code kiểu này thì khi muốn thay đổi lớp Horn, rất có thể sẽ phải thay đổi cả lớp Car

    class program
    {
        static void Main()
        {
            Car car = new Car();
            car.Beep();
        }
    }
}