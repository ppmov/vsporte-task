using SportEventApi.Services;
using SportEventApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace SportEventApi.Controllers;

public abstract class IdentifiedControllerBase<T> : ControllerBase where T : class, IIdentifiedModel
{
    protected ServiceBase<T> _service;
    
    public IdentifiedControllerBase(ServiceBase<T> service) => _service = service;

    [HttpGet]
    public IEnumerable<T> GetAll() => _service.ReadAll();

    [HttpGet("{id}")]
    public ActionResult<T> Get(Guid id)
    {
        var item = _service.Read(id);

        if (item is not null)
            return item;
        else
            return NotFound();
    }

    [HttpPost]
    public IActionResult Create(T item)
    {
        if (item.Id == Guid.Empty)
            item.Id = Guid.NewGuid();

        _service.Create(item);
        return CreatedAtAction(nameof(Get), new { id = item!.Id }, item);
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, T item)
    {
        if (_service.Read(id) is null)
            return NotFound(); 

        item.Id = id;
        _service.Update(item);  
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var item = _service.Get(id);

        if (item is null)
            return NotFound();

        _service.Delete(item);
        return Ok();
    }
}