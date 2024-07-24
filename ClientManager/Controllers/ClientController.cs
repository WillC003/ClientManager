using Microsoft.AspNetCore.Mvc;
using ClientManager.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClientManager.Models;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Identity.Client;
using System;

namespace ClientManager.Controllers
{
    public class ClientController : Controller
    {
        private readonly ClientContext _context;

        public ClientController(ClientContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var clients = _context.Client.ToList();
            return View(clients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ClientDto ClientDto)
        {
            if(!ModelState.IsValid)
            {
                return View(ClientDto);
            }

            int newId = ClientDto.Id;
         

            Client client = new Client()
            {
               
                FirstName = ClientDto.FirstName,
                LastName = ClientDto.LastName,
                GymId = ClientDto.GymId,
                UserId = ClientDto.UserId,
                Email = ClientDto.Email,
                PhoneNumber = ClientDto.PhoneNumber,

            };
                
            _context.Client.Add(client);
            _context.SaveChanges();

            return RedirectToAction( "Index", "Client");
        }

        public IActionResult Edit(int Id)
        {
            var client = _context.Client.Find(Id);

            if (client == null) 
            {
                return RedirectToAction("Index", "Client");
            }

            var clientDto = new ClientDto()
            {
                
                FirstName = client.FirstName,
                LastName = client.LastName,
                GymId = client.GymId,
                UserId = client.UserId,
                Email = client.Email,
                PhoneNumber = client.PhoneNumber,


            };

            ViewData["Id"] = client.Id;

            

            return View(clientDto);

        }

        [HttpPost]
        public IActionResult Edit(int id, ClientDto clientDto)
        {
            var client = _context.Client.Find(id);

            if (client == null)
            {
                return RedirectToAction("Index", "Client");
            }

            if (!ModelState.IsValid)
            {
                ViewData["Id"] = client.Id;
                return View(clientDto);
            }

            client.FirstName = clientDto.FirstName;
            client.LastName = clientDto.LastName;
            client.GymId = clientDto.GymId;
            client.UserId = clientDto.UserId;
            client.Email = clientDto.Email;
            client.PhoneNumber = clientDto.PhoneNumber;

            _context.SaveChanges();

            return RedirectToAction("Index", "Client");
        }

        public IActionResult Delete(int Id)
        {
            var client = _context.Client.Find(Id);

            if(client == null)
            {
                return RedirectToAction("Index", "Client");
            }
            _context.Client.Remove(client);
            _context.SaveChanges();

            return RedirectToAction("Index", "Client");
        }

        public IActionResult Detail(int Id)
        {
            var client = _context.Client.Find(Id);

            if (client == null)
            {
                
                return RedirectToAction("Index", "Client");
            }
            var viewModel = new Client
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                GymId = client.GymId,
                UserId = client.UserId,
                Email = client.Email,
                PhoneNumber = client.PhoneNumber,
            };

            ViewData["Id"] = client.Id;
            return View(viewModel);
        }
    }
}
