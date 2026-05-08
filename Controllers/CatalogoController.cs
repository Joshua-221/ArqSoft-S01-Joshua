namespace Catalogo.Controllers;

using Microsoft.AspNetCore.Mvc;
using Catalogo.Models;

public class CatalogoController : Controller
{
    // Lista estática en memoria con los 5 ítems iniciales requeridos por la rúbrica
    private static List<Item> _items = new()
    {
        new Item { 
            Id = 1, 
            Titulo = "Devil May Cry", 
            Genero = "Hack and Slash", 
            Ano = 2001, 
            Consola = "PS2", 
            Descripcion = "Acción estilizada protagonizada por el cazador de demonios Dante.",
            ImagenUrl = "https://upload.wikimedia.org/wikipedia/en/a/a2/Devil_May_Cry_cover.jpg"
        },
        new Item { 
            Id = 2, 
            Titulo = "Castlevania: SOTN", 
            Genero = "Metroidvania", 
            Ano = 1997, 
            Consola = "PS1", 
            Descripcion = "Exploración no lineal en el castillo de Drácula con Alucard.",
            ImagenUrl = "https://upload.wikimedia.org/wikipedia/en/7/73/Castlevania_-_Symphony_of_the_Night_Coverart.png"
        },
        new Item { 
            Id = 3, 
            Titulo = "NieR: Automata", 
            Genero = "Action RPG", 
            Ano = 2017, 
            Consola = "PS4", 
            Descripcion = "Combates fluidos y una narrativa profunda sobre la existencia humana.",
            ImagenUrl = "https://upload.wikimedia.org/wikipedia/en/b/b2/NieR_Automata_Cover_Art.jpg"
        },
        new Item { 
            Id = 4, 
            Titulo = "Halo: CE", 
            Genero = "Shooter", 
            Ano = 2001, 
            Consola = "Xbox", 
            Descripcion = "El inicio de la legendaria guerra entre la humanidad y el Covenant.",
            ImagenUrl = "https://upload.wikimedia.org/wikipedia/en/7/75/Halo_CE_Box_Art.jpg"
        },
        new Item { 
            Id = 5, 
            Titulo = "Elden Ring", 
            Genero = "Action RPG", 
            Ano = 2022, 
            Consola = "PC", 
            Descripcion = "Exploración en un vasto mundo abierto lleno de desafíos y jefes épicos.",
            ImagenUrl = "https://upload.wikimedia.org/wikipedia/en/0/0f/Elden_Ring_Box_Art.jpg"
        }
    };

    // Acción para visualizar la lista con soporte para filtrado (Paso 5)
    public IActionResult Index(string? genero)
    {
        // Filtra la lista si se recibe un género, de lo contrario muestra todos
        var listaResultante = string.IsNullOrEmpty(genero) 
            ? _items 
            : _items.Where(i => i.Genero == genero).ToList();

        // Extrae géneros únicos para los botones de la vista[cite: 1]
        ViewBag.Generos = _items.Select(i => i.Genero).Distinct().ToList();
        
        return View(listaResultante);
    }

    // Acción para ver la ficha técnica completa de un ítem (Paso 6)[cite: 1]
    public IActionResult Detalle(int id)
    {
        var item = _items.FirstOrDefault(i => i.Id == id);
        
        if (item == null)
        {
            return NotFound();
        }

        return View(item);
    }

    // Acción GET para mostrar el formulario de agregar (Paso 6)[cite: 1]
    [HttpGet]
    public IActionResult Agregar()
    {
        return View();
    }

    // Acción POST para recibir y guardar el nuevo ítem[cite: 1]
    [HttpPost]
    public IActionResult Agregar(Item nuevoItem)
    {
        // Genera un ID simple basado en la cantidad actual[cite: 1]
        nuevoItem.Id = _items.Count + 1;
        _items.Add(nuevoItem);
        
        return RedirectToAction("Index");
    }
    public IActionResult Privacidad()
{
    return View();
}
}