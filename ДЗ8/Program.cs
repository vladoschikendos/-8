using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДЗ8
{
    class Song
    {
        string name;
        string author;
        public Song prev;

        public Song()
        {
            name = "";
            author = "";
            prev = null;
        }

        public Song(string n,string a)
        {
            name = n;
            author = a;
            prev = null;
        }
        public Song(string n,string a,Song p)
        {
            name =n;
            author = a;
            prev = p;
        }
        public void SetName(string n) { name = n;}
        public void SetAuthor(string a) { author = a;}
        public void SetPrev(Song p) { prev = p;}
        public string Title()
        {
            return $"{name} - {author}";
        }
        public void Print()
        {
            Console.WriteLine($"Песня:{name},исполнитедь:{author}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Song mySong = new Song();
            mySong.SetName("Моя песня");
            mySong.SetAuthor("Влад");
            Console.WriteLine("\nmySong создан через new Song():");
            mySong.Print();
            
            Song s1 = new Song("Кукла колдуна", "Король и Шут");

            Song s2 = new Song("Город под подошвой", "Оксимирон", s1);

            Console.WriteLine("\nПесня s1 (конструктор 1):");
            s1.Print();

            Console.WriteLine("\nПесня s2 (конструктор 2, prev = s1):");
            s2.Print();
            Console.WriteLine($"Предыдущая песня: {s2.prev.Title()}");
        }
    }
}
