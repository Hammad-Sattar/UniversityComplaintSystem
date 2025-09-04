using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityComplaintSystem.Models.Dtos;
using UniversityComplaintSystem.Models;
using UniversityComplaintSystem.Repository;

namespace ComplaintSystem.Controllers
    {
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
        {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentsController(IDepartmentRepository departmentRepository, IMapper mapper)
            {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            }

        // GET all departments
        [HttpGet]
        public async Task<IActionResult> GetAll()
            {
            var departments = await _departmentRepository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<DepartmentDto>>(departments);
            return Ok(dtos);
            }

        // GET by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
            {
            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null) return NotFound();

            var dto = _mapper.Map<DepartmentDto>(department);
            return Ok(dto);
            }

        // POST create
        [HttpPost]
        public async Task<IActionResult> Create(CreateDepartmentDto dto)
            {
            var department = _mapper.Map<Department>(dto);
            var created = await _departmentRepository.AddAsync(department);

            var result = _mapper.Map<DepartmentDto>(created);
            return CreatedAtAction(nameof(GetById), new { id = created.DepartmentId }, result);
            }

        // PUT update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateDepartmentDto dto)
            {
            var existing = await _departmentRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(dto, existing); // update with dto values
            var updated = await _departmentRepository.UpdateAsync(existing);

            var result = _mapper.Map<DepartmentDto>(updated);
            return Ok(result);
            }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            {
            var deleted = await _departmentRepository.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
            }
        }
    }
