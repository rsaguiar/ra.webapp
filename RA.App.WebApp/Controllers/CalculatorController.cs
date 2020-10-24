using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RA.App.Exception;
using RA.App.Mapper;
using RA.App.Service.Interfaces;
using RA.App.ViewModel;
using System.Linq;


namespace RA.App.WebApp.Controllers {
    public class CalculatorController : Controller {
        private readonly ICalculatorService _CalculatorService;
        private readonly IPriceService _PriceService;
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ICalculatorService CalculatorService, IPriceService PriceService, ILogger<CalculatorController> logger) {
            _CalculatorService = CalculatorService;
            _PriceService = PriceService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index() {
            return RedirectToAction("CalculatePlanPrice");
        }

        [HttpGet]
        public IActionResult CalculatePlanPrice() {            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CalculatePlanPrice(CalculatorViewModel viewModel) {
            try {
                if (ModelState.IsValid) {
                    var price = _PriceService.GetCalculatePrice(viewModel.FromDDDCode, viewModel.ToDDDCode);
                    if(price != null)
                        viewModel = _CalculatorService.CalculatePlanPrice(viewModel.ToEntity(), price).ToCalculatorViewModel();

                    _CalculatorService.Create(viewModel.ToEntity());                    
                    viewModel.CalculatorHistorical = _CalculatorService.GetAll().Select(s => s.ToCalculatorViewModel()).OrderBy(o => o.Id).ToList();
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

        private void SendFeedback(bool isError, string message) {
            if (isError)
                TempData["MessageError"] = message;
            else
                TempData["Message"] = message;
        }
    }
}
