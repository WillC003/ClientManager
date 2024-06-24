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

    }
}
