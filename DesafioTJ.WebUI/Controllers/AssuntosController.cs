using DesafioTJ.Application.Dtos;
using DesafioTJ.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTJ.WebUI.Controllers;

public class AssuntosController : Controller
{
    private readonly IAssuntoService _assuntoService;
    private readonly IWebHostEnvironment _environment;

    public AssuntosController(IAssuntoService assuntoService, IWebHostEnvironment environment)
    {
        _assuntoService = assuntoService;
        _environment = environment;

    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var products = _assuntoService.ListAll();
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

        var livroDto = await _assuntoService.Read(id);

        if (livroDto == null) return NotFound();

        return View(livroDto);
    }


    [HttpPost]
    public async Task<IActionResult> Create(AssuntoDto assuntoDto)
    {
        if (ModelState.IsValid)
        {
            await _assuntoService.Create(assuntoDto);
            return RedirectToAction(nameof(Index));
        }
        
        return View(assuntoDto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(AssuntoDto assuntoDto)
    {
        if (ModelState.IsValid)
        {
            await _assuntoService.Update(assuntoDto);
            return RedirectToAction(nameof(Index));
        }
        return View(assuntoDto);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        if (id == null)
            return NotFound();

        var livroDto = await _assuntoService.Read(id);

        if (livroDto == null) return NotFound();

        return View(livroDto);
    }

    [HttpPost(), ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _assuntoService.Delete(id);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int id)
    {
        if (id == null) return NotFound();

        var livroDto = await _assuntoService.Read(id);

        if (livroDto == null) return NotFound();
        var wwwroot = _environment.WebRootPath;


        return View(livroDto);
    }
}
