using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fp_web_aula_1.TagHelpers
{
    public class Email:TagHelper
    {
        private string emailDomain = "fiap.com.br";
        public string MailTo { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";

            var endereco = $"{MailTo}@{emailDomain}";

            output.Attributes.SetAttribute("href", $"mailto:{endereco}");
            output.Attributes.SetAttribute("class", "classedecss");
            output.Content.SetContent(endereco);
        }

    }
}
