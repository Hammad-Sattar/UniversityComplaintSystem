using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityComplaintSystem.Models.Dtos;
using UniversityComplaintSystem.Models;
using UniversityComplaintSystem.Repository;

[Route("api/[controller]")]
[ApiController]
public class ComplaintActionController : ControllerBase
    {
    private readonly IComplaintActionRepository _repository;
    private readonly IMapper _mapper;

    public ComplaintActionController(IComplaintActionRepository repository, IMapper mapper)
        {
        _repository = repository;
        _mapper = mapper;
        }

    [HttpGet("complaint/{complaintId}")]
    public async Task<ActionResult<IEnumerable<ComplaintActionDto>>> GetByComplaint(int complaintId)
        {
        var actions = await _repository.GetAllByComplaintIdAsync(complaintId);
        var result = _mapper.Map<IEnumerable<ComplaintActionDto>>(actions);
        return Ok(result);
        }

    [HttpGet("{id}")]
    public async Task<ActionResult<ComplaintActionDto>> Get(int id)
        {
        var action = await _repository.GetByIdAsync(id);
        if (action == null) return NotFound();

        return _mapper.Map<ComplaintActionDto>(action);
        }

    [HttpPost]
    public async Task<ActionResult<ComplaintActionDto>> Create(CreateComplaintActionDto dto)
        {
        var entity = _mapper.Map<ComplaintAction>(dto);
        var created = await _repository.AddAsync(entity);
        var result = _mapper.Map<ComplaintActionDto>(created);

        return CreatedAtAction(nameof(Get), new { id = created.ActionId }, result);
        }
    }
