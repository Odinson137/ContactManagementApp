using Microsoft.AspNetCore.Mvc;
using ContactManagementApp.DTO;
using ContactManagementApp.Interfaces;
using ContactManagementApp.Models;

namespace ContactManagementApp.Controllers;

public class ContactController(IContactRepository repository) : Controller
{
    public async Task<IActionResult> Index()
    {
        return View(await repository.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ContactDto dto)
    {
        var contact = new Contact
        {
            Name = dto.Name,
            MobilePhone = dto.MobilePhone,
            JobTitle = dto.JobTitle,
            BirthDate = dto.BirthDate
        };

        if (!ModelState.IsValid)
            return BadRequest("Неверные данные контакта");

        await repository.AddAsync(contact);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var contact = await repository.GetByIdAsync(id);
        if (contact == null)
            return NotFound();

        var dto = new ContactDto
        {
            Id = contact.Id,
            Name = contact.Name,
            MobilePhone = contact.MobilePhone,
            JobTitle = contact.JobTitle,
            BirthDate = contact.BirthDate
        };

        return Json(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit([FromBody] ContactDto dto)
    {
        var contact = await repository.GetByIdAsync(dto.Id);
        if (contact == null)
            return NotFound();

        contact.Name = dto.Name;
        contact.MobilePhone = dto.MobilePhone;
        contact.JobTitle = dto.JobTitle;
        contact.BirthDate = dto.BirthDate;

        if (!ModelState.IsValid)
            return BadRequest("Неверные данные контакта");

        await repository.UpdateAsync(contact);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var contact = await repository.GetByIdAsync(id);
        if (contact == null)
            return NotFound();

        await repository.DeleteAsync(id);
        return Ok();
    }
}