using AutoMapper;
using HospitalNew.BLL.Dtos;
using HospitalNew.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalNew.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoicesService _invoicesService;
        private readonly IMapper _mapper;

        public InvoicesController(IInvoicesService invoicesService, IMapper mapper)
        {
            _invoicesService = invoicesService;
            _mapper = mapper;
        }
        [Authorize(Roles = "Admin,Accountant")]

        [HttpGet]
        public async Task<IActionResult> GetInvoiceDetails()
        {
            var invoice = await _invoicesService.GetInvoiceDetails();
            var inv = _mapper.Map<IEnumerable<InvoiceDetailsDto>>(invoice);
            return Ok(inv);
        }
        [Authorize(Roles = "Admin,Accountant")]

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceById(int id)
        {
            var invoice = await _invoicesService.GetInvoiceById(id);
            if (invoice == null)
                return NotFound($"No invoice was found with the ID: {id}");
            return Ok(invoice);
        }
        [Authorize(Roles = "Admin,Accountant")]

        [HttpPost]
        public async Task<IActionResult> AddInvoice([FromForm] InvoiceDto dto)
        {
            var result = await _invoicesService.AddInvoice(dto);
            if (result == null)
                return BadRequest("Invalid appointment ID");
            return Ok(dto);
        }
        [Authorize(Roles = "Admin,Accountant")]

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInvoice(int id, [FromForm] InvoiceDto dto)
        {
            var result = await _invoicesService.UpdateInvoice(id, dto);
            if(!result.Success)
                return BadRequest(result.Message);
            return Ok(result);

        }
        [Authorize(Roles = "Admin,Accountant")]

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var result = await _invoicesService.DeleteInvoice(id);
            if (result == null)
                return NotFound($"No invoice was found with the ID: {id}");
            return Ok(result);

        }
    }
}
