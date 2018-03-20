using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Octokit;

namespace github_api_demo.Controllers
{
    

    public class GithubController : ApiController
    {
    

        [Route("github/search")]
        [HttpGet]
        public async Task<SearchRepositoryResult> search(string term)
        {
            var client = new GitHubClient(new ProductHeaderValue("my-demo-app"));

            var req = new SearchRepositoriesRequest(term);

            var res = await client.Search.SearchRepo(req);

            return res;
        }


    }
}
