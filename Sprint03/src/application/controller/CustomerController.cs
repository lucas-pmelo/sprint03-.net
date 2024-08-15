﻿using Microsoft.AspNetCore.Mvc;
using Sprint03.adapter.input.dto;
using Sprint03.domain.model;

namespace Sprint03.application.controller;

[ApiController]
[Route("api/customer")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerAdapter _customerAdapter;

    public CustomerController(ICustomerAdapter customerAdapter)
    {
        _customerAdapter = customerAdapter;
    }

    [HttpGet("{id}")]
    public IActionResult FindById(string id)
    {
        var customer = _customerAdapter.FindById(id);
        return Ok(customer);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Customer customer)
    {
        _customerAdapter.Create(customer);
        return CreatedAtAction(nameof(FindById), new { id = customer.Id }, customer);
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] Customer customer)
    {
        var updatedCustomer = _customerAdapter.Update(id, customer);
        return Ok(updatedCustomer);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        _customerAdapter.Delete(id);
        return NoContent();
    }
}