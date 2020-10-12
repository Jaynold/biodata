using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BioData.Data;
using Newtonsoft.Json.Linq;

namespace BioData.Profiles
{
    public class BiodataProfile : Profile
    {
        public BiodataProfile()
        {
            this.CreateMap<JObject, Biodata>()
                .ForMember("Id", jData => { jData.MapFrom(jo => jo["biotoolsID"]); })
                .ForMember("Name", jData => { jData.MapFrom(jo => jo["name"]); })
                .ForMember("Owner", jData => { jData.MapFrom(jo => jo["owner"]); })
                .ForMember("Description", jData => { jData.MapFrom(jo => jo["description"]); })
                .ForMember("Homepage", jData => { jData.MapFrom(jo => jo["homepage"]); })
                .ForMember("Languages", jData => { jData.MapFrom(jo => jo["language"].Select(lang => new Language { Name = (string)lang })); })
                .ForMember("ToolTypes", jData => { jData.MapFrom(jo => jo["toolType"].Select(tool => new ToolType { Name = (string)tool })); })
                .ForMember("OperatingSystems", jData => { jData.MapFrom(jo => jo["operatingSystem"].Select(os => new OperatingSystem { Name = (string)os })); })
                .ForMember("Links", jData =>
                {
                    jData.MapFrom(jo => jo["link"]
                    .Select(link => new Link
                    {
                        Url = (string)link["url"],
                        Note = (string)link["note"],
                        LinkTypes = link["type"].Select(type => new LinkType { Name = (string)type }).ToList<LinkType>()
                    }));
                });
        }
    }
}