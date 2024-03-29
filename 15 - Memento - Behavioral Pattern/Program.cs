﻿using System;

namespace _15___Memento___Behavioral_Pattern
{
    /*
     * Turkish:
     * Davranışsal Desendir.
     * Kısaca Yedekleme ve yedeği yükleme işlemidir.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Yeni bir Nesne !");
            Model bookA = new Model("SampleA");
            Console.WriteLine(bookA);

            Taker taker = new Taker();
            taker.backup = bookA.Recover();

            Console.WriteLine("\nManipüle Ettik.");
            bookA._name = "SampleB";
           Console.WriteLine(bookA);

            Console.WriteLine("\nRestore Ettik !");
            bookA.Restore(taker.backup);
            Console.WriteLine(bookA);
        }
    }

    class Model
    {
        public string _name;
        public DateTime _lastEdit;
        public Model(string Name) => this._name = Name;
        public void Restore(Backup model) => this._name = model.Name;    // Yedek sınıfı olduğuna dikkat et !!
        public Backup Recover() => new Backup(this._name);
        public override string ToString() => "Güncel isim: "+this._name;
        
    }
    class Backup //  Memento
    {
        public string Name { get; set; }
        public DateTime _lastEdited { get; set; }

        public Backup(string Name)
        {
            this.Name = Name;
        }
    }

    class Taker
    {
        public Backup backup { get; set; }
    }

}
