using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c.shr.lab5
{
    //Многоадресный и одноадресный делегат;
    delegate void Multicast();
    delegate void Unicast();

    class Program
    {
        //Свойства класса, принимающие изначальные значения;
        private int Test { get; set; } = 1;
        private int Exam { get; set; } = 4;
        private string Finall_Exam { get; set; } = "Program";
        private string Contest { get; set; } = "Presentation";

        //Конструктор с параметрами для переопределения значений если пользователь захочет их изменить;
        public Program(int New_Test, int New_Exam, string New_Finall_Exam, string New_Contest)
        {
            Test = New_Test;
            Exam = New_Exam;
            Finall_Exam = New_Finall_Exam;
            Contest = New_Contest;
        }
        public Program()
        { }

        //Делегат принимает адрес функции, вызываем ее;
        static void Main(string[] args)
        {
            Program program = new Program();
            Unicast one_for_all = program.Input;
            one_for_all();
        }
        //Конструктора класса Inform принимают значения полей и записывают их в свойства;
        public void Input()
        {
            Inform inform = new Inform(Test, Exam);
            Inform inform_1 = new Inform(Finall_Exam, Contest);
            More(inform, inform_1);
        }
        //Inform является дочерним классом от двух интерфейсов - вызываем функции этих интерфейсов при помощи многоадресного делегата;
        static void More(ITest flat, IFinal_Exam street)
        {
            Multicast all_in_one = flat.Write_Test;
            all_in_one += street.Write_Final_Exam;
            all_in_one();
        }
    }
    class Inform : ITest, IFinal_Exam
    {
        private int Test { get; set; }
        private int Exam { get; set; }
        private string Finall_Exam { get; set; }
        private string Contest { get; set; }

        public Inform(int test, int exam)
        {
            Test = test;
            Exam = exam;
        }
        public Inform(string finall_exam, string contest)
        {
            Finall_Exam = finall_exam;
            Contest = contest;
        }
        public Inform()
        { }

        //Функции интерфейсов выводят данные о месте проживания;
        void ITest.Write_Test()
        {
            Console.WriteLine($"\nНомер теста: " + Test);
            Console.WriteLine($"Вариант: " + Exam);
        }
        void IFinal_Exam.Write_Final_Exam()
        {
            Console.WriteLine($"Экзамен: " + Finall_Exam);
            Console.WriteLine($"Конкурс: " + Contest + "\n");
            Console.Write("Хотите изменить данные? Введите 1 - да, другое число - нет: ");

            //Если пользователь хочет изменить данные - вызываем функцию More_1, которая при помощи делегата вызовет функцию Re_Write класса Re_Write;
            if (Convert.ToInt32(Console.ReadLine()) == 1)
            {
                ReWrite write = new ReWrite();
                More_1(write);
            }
            else
            {
                Console.WriteLine("Вы решили не изменять\n");
                Console.ReadLine();
            }
        }
        static void More_1(IReWrite write)
        {
            Unicast one_for_all = write.Re_Write;
            one_for_all();
        }
    }

    interface ITest
    {
        void Write_Test();
    }
    interface IFinal_Exam
    {
        void Write_Final_Exam();
    }

    class ReWrite : IReWrite
    {
        private int New_Test { get; set; }
        private int New_Exam { get; set; }
        private string New_Finall_Exam { get; set; }
        private string New_Contest { get; set; }

        public ReWrite()
        { }

        //Вводим новые данные и при помощи конструктора класса Program записываем их в свойства, вызываем функцию Input класса Program;
        void IReWrite.Re_Write()
        {
            Console.Write("\nВведите новый номер теста: ");
            New_Test = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите вариант: ");
            New_Exam = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите Экзамен: ");
            New_Finall_Exam = Console.ReadLine();
            Console.Write("Введите конкурс: ");
            New_Contest = Console.ReadLine();
            Program program = new Program(New_Test, New_Exam, New_Finall_Exam, New_Contest);
            Unicast one_for_all = program.Input;
            one_for_all();
        }
    }

    interface IReWrite
    {
        void Re_Write();
    }
}
