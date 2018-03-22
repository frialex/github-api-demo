using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Octokit;
using System.Web.Http.Results;
using github_api_demo.Models;

namespace github_api_demo.Controllers
{
    

    public class GithubController : ApiController
    {
        private GitHubClient Client { get; set; }

        public GithubController()
        {
            Client = new GitHubClient(new ProductHeaderValue("my-demo-app"));
        }

        [Route("github/search")]
        [HttpGet]
        public async Task<SearchRepositoryResult> search(string term)
        {

            var req = new SearchRepositoriesRequest(term);

            return await Client.Search.SearchRepo(req);

        }

        [Route("github/filterByRepoCreationDate")]
        [HttpPost]
        public async Task<JsonResult<IEnumerable<SimpleResult>>> filterByRepoCreationDate([FromBody] RepoCreatedDateFilterRequest request)
        {

            var req = new SearchRepositoriesRequest(request.term);


            var resultFromGithub = await Client.Search.SearchRepo(req);

            var resuls = resultFromGithub.Items.Where(i => i.CreatedAt.Date > request.repoCreatedFilterDate)
                        .Select(repo => new SimpleResult { RepoName = repo.Name, CreatedAt = repo.CreatedAt.DateTime });


            return Json<IEnumerable<SimpleResult>>(resuls);

        }



    }



}
