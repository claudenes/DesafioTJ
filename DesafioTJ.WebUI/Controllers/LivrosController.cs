using DesafioTJ.Application.Dtos;
using DesafioTJ.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTJ.WebUI.Controllers;

public class LivrosController : Controller
{
    private readonly ILivroService _livroService;
    private readonly IWebHostEnvironment _environment;

    public LivrosController(ILivroService livroService, IWebHostEnvironment environment)
    {
        _livroService = livroService;
        _environment = environment;

    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var products = _livroService.ListAll();
        return View(await products);
    }
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        if (id == null)
            return NotFound();

        var livroDto = await _livroService.Read(id);

        if (livroDto == null) return NotFound();

        return View(livroDto);
    }


    [HttpPost]
    public async Task<IActionResult> Create(LivroDto livroDto)
    {
        if (ModelState.IsValid)
        {
            await _livroService.Create(livroDto);
            return RedirectToAction(nameof(Index));
        }
        
        return View(livroDto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(LivroDto livroDto)
    {
        if (ModelState.IsValid)
        {
            await _livroService.Update(livroDto);
            return RedirectToAction(nameof(Index));
        }
        return View(livroDto);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        if (id == null)
            return NotFound();

        var livroDto = await _livroService.Read(id);

        if (livroDto == null) return NotFound();

        return View(livroDto);
    }

    [HttpPost(), ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _livroService.Delete(id);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int id)
    {
        if (id == null) return NotFound();

        var livroDto = await _livroService.Read(id);

        if (livroDto == null) return NotFound();
        var wwwroot = _environment.WebRootPath;


        return View(livroDto);
    }
}
