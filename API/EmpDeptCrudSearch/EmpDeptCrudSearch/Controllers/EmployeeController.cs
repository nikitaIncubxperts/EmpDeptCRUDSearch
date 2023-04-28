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
    public class EmployeeController : ControllerBase {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper) {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            ResponseApi<List<EmployeeDTO>> _response = new ResponseApi<List<EmployeeDTO>>();
            try {
                List<Employee> EmployeeList = await _employeeService.GetList();
                if (EmployeeList.Count > 0) {
                    List<EmployeeDTO> dtoList = _mapper.Map<List<EmployeeDTO>>(EmployeeList);
                    _response = new ResponseApi<List<EmployeeDTO>>() { msg = "OK", Value = dtoList, status = true };
                } else {
                    _response = new ResponseApi<List<EmployeeDTO>>() { msg = "No Data", status = false };
                }
                return StatusCode(StatusCodes.Status200OK, _response);
            } catch (Exception ex) {
                _response = new ResponseApi<List<EmployeeDTO>> { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeDTO request) {
            ResponseApi<EmployeeDTO> _response = new ResponseApi<EmployeeDTO>();
            try {
                Employee _model = _mapper.Map<Employee>(request);
                Employee _employeeCreated = await _employeeService.Add(_model);
                if (_employeeCreated.EmployeeId != 0) {
                    _response = new ResponseApi<EmployeeDTO> {
                        status = true,
                        msg = "OK",
                        Value = _mapper.Map<EmployeeDTO>(_employeeCreated)
                    };
                } else {
                    _response = new ResponseApi<EmployeeDTO> {
                        msg = "Could not create",
                        status = false
                    };
                }
                return StatusCode(StatusCodes.Status200OK, _response);

            } catch (Exception ex) {
                _response = new ResponseApi<EmployeeDTO> { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(EmployeeDTO request) {
            ResponseApi<EmployeeDTO> _response = new ResponseApi<EmployeeDTO>();
            try {
                Employee _model = _mapper.Map<Employee>(request);
                Employee _employeeEdited = await _employeeService.Update(_model);
                _response = new ResponseApi<EmployeeDTO> {
                    status = true,
                    msg = "OK",
                    Value = _mapper.Map<EmployeeDTO>(_employeeEdited)
                };
                return StatusCode(StatusCodes.Status200OK, _response);
            } catch(Exception ex) {
                _response = new ResponseApi<EmployeeDTO> { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);

            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {
            ResponseApi<bool> _response = new ResponseApi<bool>();
            try {
                Employee _employeeFound = await _employeeService.GetById(id);
                bool employeeDeleted = await _employeeService.Delete(_employeeFound);
                if (employeeDeleted) {
                    _response = new ResponseApi<bool> {
                        status = true, msg = "OK",
                    };
                } else {
                    _response = new ResponseApi<bool> {
                        status = false, msg = "Not Deleted",
                    };
                }
                return StatusCode(StatusCodes.Status200OK, _response);
            } catch(Exception ex) {
                _response = new ResponseApi<bool> { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
            
        }
    }
}
