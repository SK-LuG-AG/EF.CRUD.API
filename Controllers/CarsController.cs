using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private static List<Cars> cars = new List<Cars>
            {
                new Cars {
                    Id=1,
                    Name="Cayenne",
                    Hersteller="Porsche",
                    Herkunftsland="Deutschland",
                    Baujahr=2004
                },
                new Cars {
                    Id=2,
                    Name="Spider",
                    Hersteller="Ferrari",
                    Herkunftsland="Italien",
                    Baujahr=2001
                }

            };

        public Datenkontext Datenkontext { get; }

        public CarsController(Datenkontext datenkontext)
        {
            Datenkontext = datenkontext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cars>>> Get()
        {          
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cars>> Get(int id)
        {
            var car = cars.Find(c=>c.Id==id);
            if (car == null)
                return BadRequest("Auto gibts nicht!!");
            return Ok(car);
        }

        [HttpPut]
        public async Task<ActionResult<List<Cars>>> UpdateCar(Cars request)
        {
            var car = cars.Find(c => c.Id == request.Id);
            if (car == null)
                return BadRequest("Auto gibts nicht!!");

            car.Name= request.Name;
            car.Hersteller= request.Hersteller;
            car.Herkunftsland= request.Herkunftsland;
            car.Baujahr = request.Baujahr;  

            return Ok(cars);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Cars>>> Delete(int id)
        {
            var car = cars.Find(c => c.Id == id);
            if (car == null)
                return BadRequest("Auto gibts nicht!!");

            cars.Remove(car);
            return Ok(cars);
        }

        [HttpPost]
        public async Task<ActionResult<List<Cars>>> AddCar(Cars car)
        {
            cars.Add(car);
            return Ok(cars);
        }

    }
}
