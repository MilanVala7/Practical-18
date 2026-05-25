using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Practical_18.Models;
using Practical_18.Services.Interfaces;
using Practical_18.ViewModels;

namespace Practical_18.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _service;
        private readonly IMapper _mapper;

        public StudentController(
            IStudentService service,
            IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _service.GetAllAsync();

            var vm = _mapper.Map<List<StudentListVM>>(students);

            return View(vm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentCreateVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var student = _mapper.Map<Student>(vm);

            await _service.CreateAsync(student);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var student = await _service.GetByIdAsync(id);

            var vm = _mapper.Map<StudentEditVM>(student);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentEditVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var student = _mapper.Map<Student>(vm);

            await _service.UpdateAsync(student);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var student = await _service.GetByIdAsync(id);

            var vm = _mapper.Map<StudentDetailsVM>(student);

            return View(vm);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var student = await _service.GetByIdAsync(id);

            var vm = _mapper.Map<StudentDetailsVM>(student);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
