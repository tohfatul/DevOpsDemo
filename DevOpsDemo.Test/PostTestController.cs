using DevOpsDemo.Controllers;
using DevOpsDemo.Models;
using DevOpsDemo.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace DevOpsDemo.Test
{
    public class PostTestController
    {
        private PostRepository _repository;

        public PostTestController()
        {
            _repository = new PostRepository();

        }
        [Fact]
        public void Test_Index_View_Result()
        {
            //arrange
            var controller = new HomeController(_repository);

            //act
            var result = controller.Index();

            //assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Test_Index_Return_Result()
        {
            //arrange
            var controller = new HomeController(_repository);

            //act
            var result = controller.Index();

            //assert
            Assert.NotNull(result);
        }


        [Fact]
        public void Test_Index_GetPosts_MatchData()
        {
            //arrange
            var controller = new HomeController(_repository);

            //act
            var result = controller.Index();

            //assert
            var viewResult = Assert.IsType<ViewResult>(result);

            var model =
                Assert.IsAssignableFrom<List<PostViewModel>>(viewResult.ViewData.Model);

            Assert.Equal(3, model.Count);
            Assert.Equal(101, model[0].PostId);
            Assert.Equal("DevOps Demo Title 1", model[0].Title);
        }
    }
}
