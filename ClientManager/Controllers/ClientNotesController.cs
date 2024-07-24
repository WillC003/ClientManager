using Microsoft.AspNetCore.Mvc;
using ClientManager.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClientManager.Models;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Identity.Client;
using System;
using static Azure.Core.HttpHeader;

namespace ClientManager.Controllers
{
    public class ClientNotesController : Controller
    {
        private readonly ClientContext _context;

        public ClientNotesController(ClientContext context)
        {
            _context = context;
        }

        
        public IActionResult Index(int Id)
        {
            var clientNotes = _context.ClientNotes
            .Where(n => n.ClientID == Id)
            .ToList();

            if (clientNotes == null)
            {
                return NotFound();
            }

            var client = _context.Client.Find(Id);

            if (client == null)
            {
                return NotFound();
            }

            var viewModel = new ClientNotesViewModel
            {
                Client = client,
                Notes = clientNotes
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]


        public IActionResult Create(ClientNotesDto ClientNotesDto, int Id) 
        {
            if (!ModelState.IsValid)
            {
                return View(ClientNotesDto);
            }

            var client = _context.Client.Find(Id);

            ClientNotes note = new ClientNotes()
            {

                Note_Content = ClientNotesDto.Note_Content,
                ClientID = client.Id,
                Updated_By = ClientNotesDto.Updated_By,
                Created_By = ClientNotesDto.Created_By,
                Created_Date = DateOnly.FromDateTime(DateTime.Now),
                Updated_Date = DateOnly.FromDateTime(DateTime.Now),
                Is_Deleted = false

            };

            _context.ClientNotes.Add(note);
            _context.SaveChanges();

            return RedirectToAction("Index(cleint.Id)", "ClientNotes");

        }

    }
}
