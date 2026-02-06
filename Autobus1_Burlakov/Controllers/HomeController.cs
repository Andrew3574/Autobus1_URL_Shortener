using System.Diagnostics;
using System.Text.Json;
using Autobus1_Burlakov.Data.Repositories;
using Autobus1_Burlakov.Models;
using Autobus1_Burlakov.Models.DTOs;
using Autobus1_Burlakov.Utilities.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Autobus1_Burlakov.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUrlDataRepository _repository;
        private readonly IUrlProcessor _processor;
        private readonly HttpContext _context;
        private int _attemptCounter;
        private string? _shortUrl;

        public HomeController(ILogger<HomeController> logger,
            IUrlProcessor processor,
            IUrlDataRepository repository,
            IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _processor = processor;
            _repository = repository;
            _context = httpContextAccessor.HttpContext!;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] UrlsDataDto dto)
        {
            if (!ModelState.IsValid) return View(dto);
            while(_attemptCounter < 3)
            {
                _shortUrl = ShortenUrl(dto.FullUrl!);
                if (!ifShortUrlExists(_shortUrl))
                {
                    await _repository.Create(CreateUrlDataObject(dto.FullUrl!,_shortUrl,dto.PassageCounter));
                    dto.ShortUrl = $"{_context.Request.Scheme}://{_context.Request.Host}/{_shortUrl}";                    
                    return View(dto);
                }
                _attemptCounter++;
            }
            TempData["Error"] = "Error occured. Try again";
            return View(dto);

        }

        [HttpGet]
        public async Task<IActionResult> UrlManagementPage()
        {
            return View(await _repository.GetByBatch(0));
        }

        [HttpGet]
        public async Task<JsonResult> GetUrlDataBatch(int page)
        {
            var batch = await _repository.GetByBatch(page);
            return Json(batch);
        }

        private Urlsdatum CreateUrlDataObject(string fullUrl,string shortUrl,int passageCounter)
        {
            return new Urlsdatum { FullUrl = fullUrl, ShortUrl = shortUrl, PassageCounter = passageCounter };
        }

        [HttpGet]
        public async Task<IActionResult> UrlUpdatePage(int id)
        {
            var urlDatum = await _repository.GetById(id);
            return View(urlDatum);
        }

        [HttpPost]
        public async Task<IActionResult> UrlUpdate([FromForm]Urlsdatum urlsdatum)
        {
            if (!ModelState.IsValid) return View(urlsdatum);
            await _repository.Update(urlsdatum);
            return RedirectToAction("UrlManagementPage");
        }

        [HttpPost]
        public async Task<IActionResult> UrlDelete(int id)
        {
            await _repository.Delete(id);
            return RedirectToAction("UrlManagementPage");
        }

        private  bool ifShortUrlExists(string shortUrl)
        {
            return _repository.ifShortUrlExists(shortUrl);
        }

        private string ShortenUrl(string fullUrl)
        {
            return _processor.ShortenUrl(fullUrl);
        }
    }
}
