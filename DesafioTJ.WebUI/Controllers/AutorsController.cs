using DesafioTJ.Application.Dtos;
using DesafioTJ.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTJ.WebUI.Controllers;

public class AutorsController : Controller
{
    private readonly IAutorService _autorService;
    private readonly IWebHostEnvironment _environment;

    public AutorsController(IAutorService autorService, IWebHostEnvironment environment)
    {
        _autorService = autorService;
        _environment = environment;

    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var products = _autorService.ListAll();
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

        var livroDto = await _autorService.Read(id);

        if (livroDto == null) return NotFound();

        return View(livroDto);
    }


    [HttpPost]
    public async Task<IActionResult> Create(AutorDto autorDto)
    {
        if (ModelState.IsValid)
        {
            await _autorService.Create(autorDto);
            return RedirectToAction(nameof(Index));
        }
        
        return View(autorDto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(AutorDto autorDto)
    {
        if (ModelState.IsValid)
        {
            await _autorService.Update(autorDto);
            return RedirectToAction(nameof(Index));
        }
        return View(autorDto);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        if (id == null)
            return NotFound();

        var livroDto = await _autorService.Read(id);

        if (livroDto == null) return NotFound();

        return View(livroDto);
    }

    [HttpPost(), ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _autorService.Delete(id);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int id)
    {
        if (id == null) return NotFound();

        var livroDto = await _autorService.Read(id);

        if (livroDto == null) return NotFound();
        var wwwroot = _environment.WebRootPath;


        return View(livroDto);
    }
}
