using Microsoft.AspNetCore.Mvc;
using Aula29MVCDB.Models;
namespace Aula29MVCDB.Controllers;
public class ClienteController : Controller
{
    private readonly MvcDBContext _context;

    public ClienteController(MvcDBContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Clientes);
    }

    public IActionResult Show(int id)
    {
        Cliente? cliente =_context.Clientes.Find(id);

        if(cliente == null)
        {
            return NotFound();
        }
        return View(cliente);
    }

    public IActionResult Create()
    {      
        return View();
    }

    public IActionResult CreateResult(int id, string endereco, string cidade, string regiao, string codigoPostal, string pais, string telefone)
    {
        if(_context.Clientes.Find(id) == null)
        {
            _context.Clientes.Add(new Cliente(id, endereco, cidade, regiao, codigoPostal, pais, telefone));
            _context.SaveChanges();
            return RedirectToAction("Create");
        }
        else
        {
           return Content("Já existe um cliente com esse id.");
        }
       
    }

    public IActionResult Delete(int id)
    {
        _context.Clientes.Remove(_context.Clientes.Find(id));
        _context.SaveChanges();
        return View();
    }

    public IActionResult Update(int id)
    {
        Cliente cliente = _context.Clientes.Find(id);
        if(cliente == null)
        {
            return Content("Esse cliente não existe.");
        }
        else
        {
           return View(cliente);
        }
    }

    public IActionResult UpdateResult(int Id, string endereco, string cidade, string regiao, string codigoPostal, string pais, string telefone)
    {
        Cliente cliente = _context.Clientes.Find(Id);

        cliente.Id = Id;
        cliente.Endereco = endereco;
        cliente.Cidade = cidade;
        cliente.Regiao = regiao;
        cliente.CodigoPostal = codigoPostal;
        cliente.Pais = pais;
        cliente.Telefone = telefone;
        _context.SaveChanges();
        return RedirectToAction("Index");
    }   
}
