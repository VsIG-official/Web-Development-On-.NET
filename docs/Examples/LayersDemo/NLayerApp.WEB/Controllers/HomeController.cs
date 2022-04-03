using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLayerApp.BLL.Interfaces;
using NLayerApp.BLL.DTO;
using NLayerApp.WEB.Models;
using AutoMapper;
using NLayerApp.BLL.Infrastructure;

namespace NLayerApp.WEB.Controllers
{
    public class HomeController : Controller
    {
        IOrderService orderService;
        public HomeController(IOrderService serv)
        {
            orderService = serv;
        }
        public ActionResult Index()
        {
            Mapper.CreateMap<PhoneDTO, PhoneViewModel>();
            var phones = Mapper.Map<IEnumerable<PhoneDTO>, List<PhoneViewModel>>(orderService.GetPhones());
            return View(phones);
        }

        public ActionResult MakeOrder(int? id)
        {
            try
            {
                Mapper.CreateMap<PhoneDTO, OrderViewModel>()
                    .ForMember("PhoneId", opt => opt.MapFrom(src => src.Id));
                var order = Mapper.Map<PhoneDTO, OrderViewModel>(orderService.GetPhone(id));
                return View(order);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult MakeOrder(OrderViewModel order)
        {
            try
            {
                Mapper.CreateMap<OrderViewModel, OrderDTO>();
                var orderDto = Mapper.Map<OrderViewModel, OrderDTO>(order);
                orderService.MakeOrder(orderDto);
                return Content("<h2>Ваш заказ успешно оформлен</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(order);
        }
        protected override void Dispose(bool disposing)
        {
            orderService.Dispose();
            base.Dispose(disposing);
        }
    }
}