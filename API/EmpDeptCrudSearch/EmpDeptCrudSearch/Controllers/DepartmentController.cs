using AutoMapper;
using EmpDeptCrudSearch.DTO;
using EmpDeptCrudSearch.Models;
using EmpDeptCrudSearch.Services.Contract;
using EmpDeptCrudSearch.Services.Implementation;
using EmpDeptCrudSearch.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpDeptCrudSearch.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentService departmentService, IMapper mapper) {
            _departmentService = departmentService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get() {
            ResponseApi<List<DepartmentDTO>> _response = new ResponseApi<List<DepartmentDTO>>();
            try {
                List<Department> departmentList = await _departmentService.GetList();
                if (departmentList.Count > 0) {
                    List<DepartmentDTO> dtoList = _mapper.Map<List<DepartmentDTO>>(departmentList);//Not capturing departmentName
                    _response = new ResponseApi<List<DepartmentDTO>>() { msg = "OK", Value = dtoList, status = true };
                } else {
                    _response = new ResponseApi<List<DepartmentDTO>>() { msg = "No Data", status = false };
                }
                return StatusCode(StatusCodes.Status200OK, _response);
            } catch (Exception ex) {
                _response = new ResponseApi<List<DepartmentDTO>> { status = false, msg = ex.Message};
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
