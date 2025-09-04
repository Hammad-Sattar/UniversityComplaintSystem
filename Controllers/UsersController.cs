using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityComplaintSystem.Models.Dtos;
using UniversityComplaintSystem.Models;
using UniversityComplaintSystem.Repository;

namespace ComplaintSystem.Controllers
    {
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
        {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
            {
            _userRepository = userRepository;
            _mapper = mapper;
            }

        // GET all users
        [HttpGet]
        public async Task<IActionResult> GetAll()
            {
            var users = await _userRepository.GetAllAsync();
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(userDtos);
            }

        // GET user by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
            {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return NotFound();

            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
            }

        // POST create user
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto dto)
            {
            var user = _mapper.Map<User>(dto);
            var created = await _userRepository.AddAsync(user);

            var userDto = _mapper.Map<UserDto>(created);
            return CreatedAtAction(nameof(GetById), new { id = created.UserId }, userDto);
            }

        // PUT update user
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateUserDto dto)
            {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null) return NotFound();

            _mapper.Map(dto, existingUser); // updates existingUser with dto values
            var updated = await _userRepository.UpdateAsync(existingUser);

            var userDto = _mapper.Map<UserDto>(updated);
            return Ok(userDto);
            }

        // DELETE user
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            {
            var deleted = await _userRepository.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
            }
        }
    }
