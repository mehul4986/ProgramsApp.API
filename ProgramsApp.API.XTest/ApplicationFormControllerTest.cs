using Microsoft.Extensions.Logging;
using Moq;
using ProgramsApp.API.Controllers;
using ProgramsApp.API.Models;
using ProgramsApp.API.Repositories;
using ProgramsApp.API.Repositories.Interfaces;
using ProgramsApp.API.Services;
using ProgramsApp.API.Services.Interfaces;
namespace ProgramsApp.API.XTest
{
    public class ApplicationFormControllerTest
    {
        ApplicationFormController _controller;
        IApplicationFormService _service;
        ISubmitAppService _appService;
        IApplicationFormRepository _repository;
        ISubmitAppRepository _appRepository;
        Mock<ILogger<ApplicationFormController>> _logger;

        public ApplicationFormControllerTest()
        {
            _repository = new ApplicationFormRepository();
            _appRepository = new SubmitAppRepository();
            _service = new ApplicationFormService(_repository);
            _appService = new SubmitAppService(_appRepository);
            _logger = new Mock<ILogger<ApplicationFormController>>();

            _controller = new ApplicationFormController(_logger.Object, _service, _appService);
        }

        [Fact]
        public async void GetApplicationFormByIdTEST()
        {
            //Arrange
            string validAppFormId = "11";

            //Act                        
            var response = await _controller.GetApplicationForm(validAppFormId);
            var result = response.Result as ApplicationForm;

            //Assert
            Assert.Equal("11", result.id);
        }

        [Fact]
        public async void CreateApplicationFormTEST()
        {
            //Arrange
            ApplicationFormDTO appForm = new ApplicationFormDTO();
            appForm.id = "11";
            appForm.programTitle = "Test Title";
            appForm.programDescription = "Test Description";
            appForm.Questionfields = null;
            appForm.AdditionalQuestionfield = null;

            //Act                        
            var response = await _controller.CreateApplicationForm(appForm);
            var result = response.Result as ApplicationForm;

            //Assert
            Assert.Equal("11", result.id);
        }

        [Fact]
        public async void SubmitApplicationFormTEST()
        {
            //Arrange
            List<Questionfield> lstAppQDTO = new();
            ApplicationFormDTO appForm = new ApplicationFormDTO();
            appForm.id = "11";
            appForm.programTitle = "Test Title";
            appForm.programDescription = "Test Description";
            var appQDTO = new Questionfield
            {
                fieldId = "Q1",
                fieldTitle = "TEST Title",
                fieldType = "text",
                fieldValue = "TEST",
                Options = null,
                required = true,
                @internal = false,
                hide = false
            };
            lstAppQDTO.Add(appQDTO);
            appForm.Questionfields = lstAppQDTO;

            appForm.AdditionalQuestionfield = null;

            //Act                        
            var response = await _controller.SubmitApplicationForm(appForm);

            //Assert
            Assert.Equal(true, response.Result);
        }

        [Fact]
        public async void UpdateApplicationFormTEST()
        {
            //Arrange
            List<Questionfield> lstAppQDTO = new();
            ApplicationFormDTO appForm = new ApplicationFormDTO();
            appForm.id = "11";
            var appQDTO = new Questionfield
            {
                fieldId = "Q1",
                fieldTitle = "TEST Title",
                fieldType = "text",
                fieldValue = null,
                Options = null,
                required = true,
                @internal = false,
                hide = false
            };
            lstAppQDTO.Add(appQDTO);
            appForm.Questionfields = lstAppQDTO;

            appForm.AdditionalQuestionfield = null;

            //Act                        
            var response = await _controller.UpdateApplicationForm(appForm);
            var result = response.Result as ApplicationForm;

            //Assert
            Assert.Equal("TEST Title", result.Questionfields[0].fieldTitle);
        }
    }
}
