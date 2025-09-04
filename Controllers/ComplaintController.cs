using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityComplaintSystem.Models.Dtos;
using UniversityComplaintSystem.Models;
using UniversityComplaintSystem.Repository;

[Route("api/[controller]")]
[ApiController]
public class ComplaintController : ControllerBase
    {
    private readonly IComplaintRepository _repository;
    private readonly IMapper _mapper;

    public ComplaintController(IComplaintRepository repository, IMapper mapper)
        {
        _repository = repository;
        _mapper = mapper;
        }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        {
        var complaints = await _repository.GetAllAsync();
        var dtos = _mapper.Map<IEnumerable<ComplaintDto>>(complaints);
        return Ok(dtos);
        }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
        {
        var complaint = await _repository.GetByIdAsync(id);
        if (complaint == null) return NotFound();
        return Ok(_mapper.Map<ComplaintDto>(complaint));
        }

    [HttpPost]
    public async Task<IActionResult> Create(ComplaintDto dto)
        {
        var complaint = _mapper.Map<Complaint>(dto);
        await _repository.AddAsync(complaint);
        return Ok(_mapper.Map<ComplaintDto>(complaint));
        }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ComplaintDto dto)
        {
        if (id != dto.ComplaintId) return BadRequest();

        var complaint = _mapper.Map<Complaint>(dto);
        await _repository.UpdateAsync(complaint);
        return NoContent();
        }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
        {
        await _repository.DeleteAsync(id);
        return NoContent();
        }
    }
