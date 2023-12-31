﻿using API.Data;
using API.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.WebEncoders.Testing;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")] // /api/users
public class UsersController : ControllerBase
{
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUsers>>> GetUsers()
    {
       var users = await _context.Users.ToListAsync();
       return users;
    }

    [HttpGet("{id}")] // /api/users/2

    public async Task<ActionResult<AppUsers>> GetUser(int id)
    {
        return await _context.Users.FindAsync(id);
    }
}