using Adapter_Grupo1.Data;
using Adapter_Grupo1.Adapter;
using Adapter_Grupo1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Adapter_Grupo1.Controllers
{
    public class AdapterController : Controller
    {

        private readonly ApplicationDbContext _context;

        public AdapterController(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public IActionResult Index()
        {
            var motores = _context.Motores.ToList();
            return View(motores);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Motor motor)
        {
            if (ModelState.IsValid)
            {
                _context.Motores.Add(motor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(motor);
        }

        // Método para iniciar un motor
        public ActionResult IniciarMotor(int id)
        {
            var motor = _context.Motores.FirstOrDefault(m => m.Id == id);
            if (motor == null) return NotFound();

            IMotorAdapter motorAdapter;
            if (motor.Tipo == "Electrico")
            {
                motorAdapter = new MotorElectricoAdapter(new MotorElectrico());
            }
            else
            {
                motorAdapter = new MotorCombustionAdapter(new MotorCombustion());
            }

            motorAdapter.Iniciar();
            motor.Estado = "Iniciado";
            _context.SaveChanges();

            return RedirectToAction("Index"); // Vuelve a la lista de motores
        }

        // Método para detener un motor
        public ActionResult DetenerMotor(int id)
        {
            var motor = _context.Motores.FirstOrDefault(m => m.Id == id);
            if (motor == null) return NotFound();

            IMotorAdapter motorAdapter;
            if (motor.Tipo == "Electrico")
            {
                motorAdapter = new MotorElectricoAdapter(new MotorElectrico());
            }
            else
            {
                motorAdapter = new MotorCombustionAdapter(new MotorCombustion());
            }

            motorAdapter.Detener();
            motor.Estado = "Detenido";
            _context.SaveChanges();

            return RedirectToAction("Index"); // Vuelve a la lista de motores
        }

    }
}
