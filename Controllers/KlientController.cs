using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restauracja.Data;
using Restauracja.Models;

namespace Restauracja.Controllers
{
    public class KlientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KlientController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult ListaStolikow()
        {
            // Pobierz dostępne stoliki z bazy danych
            var dostepneStoliki = _context.StolikiVM.Where(s => s.Dostepnosc == "Dostepne").ToList();

            return View(dostepneStoliki);
        }

        public IActionResult RezerwujStolik(int id)
        {
            // Pobierz stolik o określonym ID
            var stolik = _context.StolikiVM.FirstOrDefault(s => s.Id == id);

            if (stolik == null || stolik.Dostepnosc != "Dostepne")
            {
                return NotFound();
            }
            else
            {
                return View(stolik);
            }
            
        }

        
        [HttpPost]
        public async Task<IActionResult> ZapiszRezerwacje(Rezerwacja rezerwacja)
        {
            if (ModelState.IsValid)
            {
                // Sprawdź dostępność stolika przed zapisaniem rezerwacji
                var stolik = _context.StolikiVM.FirstOrDefault(s => s.Id == rezerwacja.Id);

                if (stolik == null)
                {
                    return NotFound("Nie znaleziono stolika.");
                }

                if (stolik.Dostepnosc != "Dostepne")
                {
                    return NotFound("Stolik jest już zarezerwowany.");
                }

                // Aktualizuj dostępność stolika
                stolik.Dostepnosc = "Zarezerwowany";
                _context.Update(stolik);

                // Dodaj rezerwację do bazy danych
                rezerwacja.Id = 0; 
                _context.Rezerwacje.Add(rezerwacja);
                await _context.SaveChangesAsync();

                return RedirectToAction("ListaStolikow"); // Przekierowanie po zapisaniu rezerwacji
            }

            return View(rezerwacja); // Jeśli dane są niepoprawne, wyświetl formularz ponownie
        }

    }
}
