using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace github_api_demo.Models
{
    public class RepoCreatedDateFilterRequest
    {
        public DateTime repoCreatedFilterDate { get; set; }

        public string term { get; set; }
    }
}