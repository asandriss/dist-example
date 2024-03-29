﻿using System.Threading.Tasks;
using System.Web.Mvc;
using FireOnWheels.Messages;
using FireOnWheels.Web.Hubs;
using Microsoft.AspNet.SignalR;
using NServiceBus;
using Order = FireOnWheels.Web.Models.Order;

namespace FireOnWheels.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEndpointInstance endpoint;
        private readonly IHubContext<OrderHub> orderHub;

        public HomeController(IEndpointInstance endpoint)
        {
            this.endpoint = endpoint;
            //this.orderHub = orderHub;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(Order order)
        {
            var options = new SendOptions();
            options.SetDestination("FireOnWheels.Order");

            //Request is an extension method in the NServiceBus.Callbacks NuGet package
            //You also need to assign a unique id to the endpoint
            var priceResponse = await endpoint.Request<PriceResponse>(new PriceRequest {Weight = order.Weight}, options);
            order.Price = priceResponse.Price;
            return View("Review", order);
        }

        public async Task<ActionResult> Confirm(Order order)
        {
            await endpoint.Send("FireOnWheels.Order", new ProcessOrderCommand
            {
                AddressFrom = order.AddressFrom,
                AddressTo = order.AddressTo,
                Price = order.Price,
                Weight = order.Weight
            }).ConfigureAwait(false);

            return View();
        }
    }
}
