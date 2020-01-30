using System.Collections.Generic;

namespace CleanWebApi.WebApi.ViewModels
{
    public class ErrorViewModel
    {
        public List<string> Errors { get; set; }

        public ErrorViewModel(params string[] errors) =>
            Errors = new List<string>(errors);
    }
}