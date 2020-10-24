using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RA.App.Exception;
using RA.App.Mapper;
using RA.App.Service.Interfaces;
using RA.App.ViewModel;
using System.Linq;

namespace RA.App.WebApp.Controllers {
    public class PriceController : Controller {
        private readonly IPriceService _PriceService;
        private readonly ILogger<PriceController> _logger;

        public PriceController(IPriceService PriceService, ILogger<PriceController> logger) {
            _PriceService = PriceService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index() {
            try {
                return View(_PriceService.GetAll().Select(s => s.ToPriceViewModel()).OrderBy(o => o.Id));
            }
            catch (AppException ex) {
                SendFeedback(true, ex.Message);
                return View();
            }
            catch (System.Exception ex) {
                _logger.LogError(ex.Message, ex, ex.InnerException);
                return View();
            }
        }

        [HttpGet]
        public IActionResult Details(int id) {
            try {
                return View(_PriceService.Get(id).ToPriceViewModel());
            }
            catch (AppException ex) {
                SendFeedback(true, ex.Message);
                return View();
            }
            catch (System.Exception ex) {
                _logger.LogError(ex.Message, ex, ex.InnerException);
                return View();
            }
        }

        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PriceViewModel viewModel) {
            try {
                if (ModelState.IsValid) {
                    _PriceService.Create(viewModel.ToEntity());
                    SendFeedback(false, $"Price From: { viewModel.FromDDDCode } To: { viewModel.ToDDDCode } successfully created.");
                    return RedirectToAction(nameof(Index));
                }

                return View(viewModel);
            }
            catch (AppException ex) {
                SendFeedback(true, ex.Message);
                return View();
            }
            catch (System.Exception ex) {
                _logger.LogError(ex.Message, ex, ex.InnerException);
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            try {
                return View(_PriceService.Get(id).ToPriceViewModel());
            }
            catch (AppException ex) {
                SendFeedback(true, ex.Message);
                return View();
            }
            catch (System.Exception ex) {
                _logger.LogError(ex.Message, ex, ex.InnerException);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PriceViewModel viewModel) {
            try {
                if (ModelState.IsValid) {
                    _PriceService.Edit(viewModel.ToEntity());
                    SendFeedback(false, $"Price From: { viewModel.FromDDDCode } To: { viewModel.ToDDDCode } successfully successfully edited.");
                    return RedirectToAction(nameof(Index));
                }

                return View(viewModel);
            }
            catch (AppException ex) {
                SendFeedback(true, ex.Message);
                return View();
            }
            catch (System.Exception ex) {
                _logger.LogError(ex.Message, ex, ex.InnerException);
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id) {
            try {
                return View(_PriceService.Get(id).ToPriceViewModel());
            }
            catch (AppException ex) {
                SendFeedback(true, ex.Message);
                return View();
            }
            catch (System.Exception ex) {
                _logger.LogError(ex.Message, ex, ex.InnerException);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(PriceViewModel viewModel) {
            try {
                _PriceService.Delete(_PriceService.Get(viewModel.Id));
                SendFeedback(false, $"Price From: { viewModel.FromDDDCode } To: { viewModel.ToDDDCode } successfully deleted.");
                return RedirectToAction(nameof(Index));
            }
            catch (AppException ex) {
                SendFeedback(true, ex.Message);
                return View();
            }
            catch (System.Exception ex) {
                _logger.LogError(ex.Message, ex, ex.InnerException);
                return View();
            }
        }

        private void SendFeedback(bool isError, string message) {
            if (isError)
                TempData["MessageError"] = message;
            else
                TempData["Message"] = message;
        }
    }
}
