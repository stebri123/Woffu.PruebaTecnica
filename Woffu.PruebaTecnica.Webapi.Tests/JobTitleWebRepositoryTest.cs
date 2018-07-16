using System;
using Xunit;

using Woffu.PruebaTecnica.Webapi.Repositories; 

namespace Woffu.PruebaTecnica.Webapi.Tests
{
    public class JobTitleWebRepositoryTest
    {
        [Fact]
        public void JobTitles_Is_Not_Null()
        {
            var jobTitleRepository = new JobTitleWebRepository();

            var jobTitles = jobTitleRepository.GetAll().Result;

            Assert.NotNull(jobTitles);
        }

        [Fact]
        public void JobTitles_List_Is_Not_Empty()
        {
            var jobTitleRepository = new JobTitleWebRepository();

            var jobTitles = jobTitleRepository.GetAll().Result;

            Assert.NotEmpty(jobTitles);
        }

       
    }
}
