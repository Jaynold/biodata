using AutoMapper;
using BioData.Data;
using Newtonsoft.Json.Linq;

namespace BioData.Profiles
{
    public class BiodataProfile : Profile
    {
        public BiodataProfile()
        {
            this.CreateMap<JObject, Language>()
                .ForMember("Title", jData => { jData.MapFrom(jo => jo[0]); });

            this.CreateMap<JObject, Link>()
                           .ForMember("Url", jData => { jData.MapFrom(jo => jo["url"]); })
                           .ForMember("Note", jData => { jData.MapFrom(jo => jo["note"]); });

            this.CreateMap<JObject, Biodata>()
                .ForMember("Id", jData => { jData.MapFrom(jo => jo["biotoolsID"]); })
                .ForMember("Name", jData => { jData.MapFrom(jo => jo["name"]); })
            .ForMember("Description", jData => { jData.MapFrom(jo => jo["description"]); })
            .ForMember("Homepage", jData => { jData.MapFrom(jo => jo["homepage"]); })
            .ForMember("Languages", jData => { jData.MapFrom(jo => jo["language"]); })
            .ForMember("Links", jData => { jData.MapFrom(jo => jo["link"]); });
        }
    }
}