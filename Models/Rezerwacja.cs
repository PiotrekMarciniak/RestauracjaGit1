using System.Text;

namespace Restauracja.Models
{
    public class Rezerwacja
    {
        public int Id { get; set; } // Identyfikator rezerwacji
        public int StolikId { get; set; } // Identyfikator stolika, kt�ry jest rezerwowany
        public DateTime DataRezerwacji { get; set; } // Data rezerwacji
        public string Imie { get; set; } // Imi� osoby rezerwuj�cej stolik
                                         // Inne w�a�ciwo�ci, kt�re s� zwi�zane z rezerwacj�
    }
}
