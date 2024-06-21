using Microsoft.AspNetCore.Mvc;
using ProgramsApp.API.Models;
using ProgramsApp.API.Services.Interfaces;

namespace ProgramsApp.API.Controllers
{
    [ApiController]
    public class ApplicationFormController : ControllerBase
    {
        private readonly ILogger<ApplicationFormController> _logger;
        private IApplicationFormService _applicationFormService;
        private ISubmitAppService _submitAppService;

        public ApplicationFormController(ILogger<ApplicationFormController> logger, IApplicationFormService applicationFormService, ISubmitAppService submitAppService)
        {
            _logger = logger;
            _applicationFormService = applicationFormService;
            _submitAppService = submitAppService;
        }

        /// <summary>
        /// This API will create an application form in the cosmos database
        /// </summary>
        /// <param name="applicationFormDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/CreateApp")]
        public async Task<ResponseModel> CreateApplicationForm(ApplicationFormDTO applicationFormDTO)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                _logger.LogInformation("Creating Application Form - Validating Input.");

                if (string.IsNullOrEmpty(applicationFormDTO.id) ||
                    string.IsNullOrEmpty(applicationFormDTO.programTitle) ||
                    string.IsNullOrEmpty(applicationFormDTO.programDescription) ||
                    (applicationFormDTO.Questionfields != null && applicationFormDTO.Questionfields.Count > 0 && (
                    applicationFormDTO.Questionfields.Any(x => string.IsNullOrEmpty(x.fieldId)) ||
                    applicationFormDTO.Questionfields.Any(x => string.IsNullOrEmpty(x.fieldTitle)) ||
                    applicationFormDTO.Questionfields.Any(x => string.IsNullOrEmpty(x.fieldType)))) ||
                    (applicationFormDTO.AdditionalQuestionfield != null && applicationFormDTO.AdditionalQuestionfield.Count > 0 && (
                    applicationFormDTO.AdditionalQuestionfield.Any(x => string.IsNullOrEmpty(x.fieldId)) ||
                    applicationFormDTO.AdditionalQuestionfield.Any(x => string.IsNullOrEmpty(x.fieldTitle)) ||
                    applicationFormDTO.AdditionalQuestionfield.Any(x => string.IsNullOrEmpty(x.fieldType)))))
                {
                    _logger.LogInformation("Creating Application Form - Validation failed.");
                    response.StatusCode = 400;
                    response.Status = "bad request";
                    response.Error = "Request data is invalid";
                }
                else
                {
                    _logger.LogInformation("Creating Application Form.");
                    var isExist = await _applicationFormService.IsApplicationExist(applicationFormDTO.id);
                    if (!isExist)
                    {
                        var createResponse = await _applicationFormService.CreateApplication(applicationFormDTO);
                        _logger.LogInformation("Application Form Created.");
                        response.Result = createResponse;
                    }
                    else
                    {
                        _logger.LogInformation("Creating Application Form failed as id exist.");
                        response.StatusCode = 409;
                        response.Status = "bad request";
                        response.Error = "Duplicate ID present";
                    }

                }
            }
            catch (Exception ex)
            {
                response.StatusCode = 400;
                response.Status = "bad request - " + ex.Message.ToString();
                response.Error = "Error in Creating Application Form. Please try again.";

                _logger.LogError(ex, string.Concat("Error in Creating Application Form.", " ERROR: ", ex.Message));
            }
            return response;
        }

        /// <summary>
        /// This API will update application form in the cosmos database
        /// </summary>
        /// <param name="applicationFormDTO"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/UpdateApp")]
        public async Task<ResponseModel> UpdateApplicationForm(ApplicationFormDTO applicationFormDTO)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                _logger.LogInformation("Updating Application Form - Validating Input.");

                if (string.IsNullOrEmpty(applicationFormDTO.id) ||
                     (applicationFormDTO.Questionfields != null && applicationFormDTO.Questionfields.Count > 0 && (
                     applicationFormDTO.Questionfields.Any(x => string.IsNullOrEmpty(x.fieldId)) ||
                     applicationFormDTO.Questionfields.Any(x => string.IsNullOrEmpty(x.fieldTitle)) ||
                     applicationFormDTO.Questionfields.Any(x => string.IsNullOrEmpty(x.fieldType)))) ||
                     (applicationFormDTO.AdditionalQuestionfield != null && applicationFormDTO.AdditionalQuestionfield.Count > 0 && (
                     applicationFormDTO.AdditionalQuestionfield.Any(x => string.IsNullOrEmpty(x.fieldId)) ||
                     applicationFormDTO.AdditionalQuestionfield.Any(x => string.IsNullOrEmpty(x.fieldTitle)) ||
                     applicationFormDTO.AdditionalQuestionfield.Any(x => string.IsNullOrEmpty(x.fieldType)))))
                {
                    _logger.LogInformation("Updating Application Form - Validation failed.");
                    response.StatusCode = 400;
                    response.Status = "bad request";
                    response.Error = "Request data is invalid";
                }
                else
                {
                    _logger.LogInformation("Updating Application Form.");
                    var createResponse = await _applicationFormService.UpdateApplication(applicationFormDTO);
                    _logger.LogInformation("Application Form Updated.");
                    response.Result = createResponse;
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = 400;
                response.Status = "bad request - " + ex.Message.ToString();
                response.Error = "Error in Updating Application Form. Please try again.";

                _logger.LogError(ex, string.Concat("Error in Updating Application Form.", " ERROR: ", ex.Message));
            }
            return response;
        }

        /// <summary>
        /// This API will get application form from the cosmos database
        /// </summary>
        /// <param name="applicationFormDTO"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetApp")]
        public async Task<ResponseModel> GetApplicationForm(string id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                _logger.LogInformation("Retrieving Application Form - Validating Input.");

                if (string.IsNullOrEmpty(id))
                {
                    _logger.LogInformation("Retrieving Application Form - Validation failed.");
                    response.StatusCode = 400;
                    response.Status = "bad request";
                    response.Error = "Request data is invalid";
                }
                else
                {
                    _logger.LogInformation("Retrieving Application Form.");
                    var createResponse = await _applicationFormService.GetApplicationById(id);
                    _logger.LogInformation("Application Form Retrieved.");
                    response.Result = createResponse;
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = 400;
                response.Status = "bad request - " + ex.Message.ToString();
                response.Error = "Error in Retrieving Application Form. Please try again.";

                _logger.LogError(ex, string.Concat("Error in Retrieving Application Form.", " ERROR: ", ex.Message));
            }
            return response;
        }

        /// <summary>
        /// This API will submit an application form in the cosmos database
        /// </summary>
        /// <param name="applicationFormDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/SubmitApp")]
        public async Task<ResponseModel> SubmitApplicationForm(ApplicationFormDTO applicationFormDTO)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                _logger.LogInformation("Submitting Application Form - Validating Input.");

                if (string.IsNullOrEmpty(applicationFormDTO.id) ||
                     string.IsNullOrEmpty(applicationFormDTO.programTitle) ||
                     string.IsNullOrEmpty(applicationFormDTO.programDescription) ||
                     (applicationFormDTO.Questionfields != null && applicationFormDTO.Questionfields.Count > 0 && (
                     applicationFormDTO.Questionfields.Any(x => string.IsNullOrEmpty(x.fieldId)) ||
                     applicationFormDTO.Questionfields.Any(x => string.IsNullOrEmpty(x.fieldTitle)) ||
                     applicationFormDTO.Questionfields.Any(x => string.IsNullOrEmpty(x.fieldValue)) ||
                     applicationFormDTO.Questionfields.Any(x => string.IsNullOrEmpty(x.fieldType)))) ||
                     (applicationFormDTO.AdditionalQuestionfield != null && applicationFormDTO.AdditionalQuestionfield.Count > 0 && (
                     applicationFormDTO.AdditionalQuestionfield.Any(x => string.IsNullOrEmpty(x.fieldId)) ||
                     applicationFormDTO.AdditionalQuestionfield.Any(x => string.IsNullOrEmpty(x.fieldTitle)) ||
                     applicationFormDTO.AdditionalQuestionfield.Any(x => string.IsNullOrEmpty(x.fieldValue)) ||
                     applicationFormDTO.AdditionalQuestionfield.Any(x => string.IsNullOrEmpty(x.fieldType)))))
                {
                    _logger.LogInformation("Submitting Application Form - Validation failed.");
                    response.StatusCode = 400;
                    response.Status = "bad request";
                    response.Error = "Request data is invalid";
                }
                else
                {
                    _logger.LogInformation("Submitting Application Form.");
                    var isExist = await _submitAppService.IsApplicationExist(applicationFormDTO.id);
                    if (!isExist)
                    {
                        var createResponse = await _submitAppService.SubmitApplication(applicationFormDTO);
                        _logger.LogInformation("Application Form Submitted.");
                        response.Result = createResponse;
                    }
                    else
                    {
                        _logger.LogInformation("Application Form Submission failed as id exist.");
                        response.StatusCode = 409;
                        response.Status = "bad request";
                        response.Error = "Application Form Submission failed as id exist.";
                    }
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = 400;
                response.Status = "bad request - " + ex.Message.ToString();
                response.Error = "Error in Application Form Submission. Please try again.";

                _logger.LogError(ex, string.Concat("Error in Application Form Submission.", " ERROR: ", ex.Message));
            }
            return response;
        }
    }
}
