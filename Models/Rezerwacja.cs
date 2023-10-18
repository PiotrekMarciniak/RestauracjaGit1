using System.Text;

namespace Restauracja.Models
{
    public class Rezerwacja
    {
        public int Id { get; set; } // Identyfikator rezerwacji
        public int StolikId { get; set; } // Identyfikator stolika, który jest rezerwowany
        public DateTime DataRezerwacji { get; set; } // Data rezerwacji
        public string Imie { get; set; } // Imiê osoby rezerwuj¹cej stolik
                                         // Inne w³aœciwoœci, które s¹ zwi¹zane z rezerwacj¹
    }
}
