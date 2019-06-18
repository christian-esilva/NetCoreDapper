using System.Collections.Generic;
using GameStore.Domain.StoreContext.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public object Get()
        {
            return new { version = "Version 0.0.1" };
        }
    }
}