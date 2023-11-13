using System.Data.Common;
using System.Reflection.Metadata.Ecma335;

namespace six_homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal() { Name = "jour" };
            Console.WriteLine(journal.SizeOfState());
            journal += 5;
            Console.WriteLine(journal.SizeOfState());

        }

        class Emploe
        {
            public string Name { get; set; } = "noname";
            public override bool Equals(object? obj)
            {
                Emploe sec = obj as Emploe;
                if (sec == null) return false;
                return this.Name == sec.Name;
            }
        }
        class Journal
        {
            /*Ранее в одном из практических заданий вы создавали 
класс «Журнал». Добавьте к уже созданному классу информацию о количестве сотрудников. Выполните перегрузку 
+ (для увеличения количества сотрудников на указанную 
величину), — (для уменьшения количества сотрудников 
на указанную величину), == (проверка на равенство количества сотрудников), < и > (проверка на меньше или 
больше количества сотрудников), != и Equals. Используйте 
механизм свойств для полей класса.*/
            /*Задание 5
             Создайте класс «Журнал». Необходимо хранить в 
    полях класса: название журнала, год основания, описание журнала, контактный телефон, контактный e-mail. 
    Реализуйте методы класса для ввода данных, вывода 
    данных, реализуйте доступ к отдельным полям через 
    методы класса */
            public string Name { get; set; } = "безымянный";
            private List<Emploe> state= new List<Emploe>();
            public int SizeOfState()
            {
                return state.Capacity;
            }
            public static Journal operator + ( Journal a, int b)
            {
                a.state.Capacity += b;
                return new Journal { Name = a.Name, state= a.state } ;
            }
            public static Journal operator -(Journal a, int b)
            {
                a.state.Capacity -= b;
                return new Journal { Name = a.Name, state = a.state };
            }
            public static bool operator ==(Journal a, Journal b)
            {
               
                return a.state.Capacity==b.state.Capacity;
            }
            public static bool operator !=(Journal a, Journal b)
            {

                return a.state.Capacity == b.state.Capacity;
            }
            public static bool operator <(Journal a, Journal b)
            {

                return a.state.Capacity < b.state.Capacity;
            }
            public static bool operator >(Journal a, Journal b)
            {

                return a.state.Capacity > b.state.Capacity;
            }

            public override bool Equals(object? obj)
            {
                Journal second = obj as Journal;
                if (second == null) return false;
                int i = 0;
                foreach (Emploe pers in second.state)
                {
                    if (!pers.Equals(this.state[i++])) return false;
                }
                return true;
            }

        }
        class Shop
        {
            /*Ранее в одном из практических заданий вы создавали класс «Магазин». Добавьте к уже созданному классу 
информацию о площади магазина. Выполните перегрузку + (для увеличения площади магазина на указанную 
величину), — (для уменьшения площади магазина на 
указанную величину), == (проверка на равенство площадей магазинов), < и > (проверка на меньше или больше 
площади магазина), != и Equals. Используйте механизм 
свойств для полей класса.*/
            private int _space=0;
            private string _name = "Пятёрочка";
            public static Shop operator +(Shop a, Shop b)  => new Shop() {_name=a._name,_space=a._space+b._space };
            public static Shop operator -(Shop a, Shop b)=> new Shop() { _name = a._name, _space = a._space - b._space };
            public static Shop operator +(Shop a, int b) => new Shop() { _name = a._name, _space = a._space + b };
            public static Shop operator -(Shop a, int b) => new Shop() { _name = a._name, _space = a._space - b };
            public static bool operator ==(Shop a, Shop b)
            {
                if (a._space == b._space) return true;
                return false;
            }
            public static bool operator !=(Shop a, Shop b)
            {
                if (a._space != b._space) return true;
                return false;
            }
            public static bool operator >(Shop a, Shop b)
            {
                if (a._space > b._space) return true;
                return false;
            }
            public static bool operator <(Shop a, Shop b)
            {
                if (a._space < b._space) return true;
                return false;
            }
            public override bool Equals(object? obj)
            {
                Shop second = obj as Shop;
                if (second == null) return false;
                if (second._name != this._name) return false;
                return second._space == this._space;
            }
        }
        class Book
        {
            public string Name { get; set; } = "NoName";
            public string Text { get; set; } = "Empty";
            public override bool Equals(object? obj)
            {
                Book book = obj as Book;
                if (book == null) return false;
                return (book.Name==this.Name&& book.Text==this.Text);
            }
        }
        class BooksToRead
        {
            /*Создайте приложение «Список книг для прочтения». 
Приложение должно позволять добавлять книги в список, удалять книги из списка, проверять есть ли книга в
списке, и т.д.Используйте механизм свойств, перегрузки
операторов, индексаторов.*/
            Dictionary<string,Book> Books= new Dictionary<string,Book>();
            public void AddNewBook(Book book)
            {
                Books.Add(book.Name, book);
            }
            public void RemoveBook(string book)
            {
                Books.Remove(book);
            }
            public bool IsHere(string book)
            {
                return Books.ContainsKey(book);
            }

        }
    }
}