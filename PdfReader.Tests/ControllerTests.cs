using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PdfReader.Services.Interfaces;
using PdfReader.Web.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PdfReader.Tests
{
    public class ControllerTests
    {
        private readonly PdfReaderController controller;
        private readonly Mock<IWriter> service;

        public ControllerTests()
        {
            this.service = new Mock<IWriter>();
            this.controller = new PdfReaderController(this.service.Object);
        }

        [Fact]
        public void ReturnViewOnUpload()
        {
            IActionResult result = controller.Upload();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void ReturnBadRequestOnGetFirstFiveLines()
        {
            var file = new Mock<Microsoft.AspNetCore.Http.IFormFile>();
            IActionResult result = await controller.GetFirstFiveLines(file.Object);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void ReturnNotFoundOnGetFirstFiveLines()
        {
            var file = new Mock<Microsoft.AspNetCore.Http.IFormFile>();
            IActionResult result = await controller.GetFirstFiveLines(null);

            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
