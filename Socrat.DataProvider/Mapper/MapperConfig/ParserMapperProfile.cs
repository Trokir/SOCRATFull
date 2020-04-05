using AutoMapper;
using HMapper;
using Socrat.Data.Model;

namespace Socrat.DataProvider
{
    public partial class EntityMapperProfile : Profile
    {

     
        void DirectParserMapping()
        {
            CreateMap<CustomerParser, Core.Entities.Parsers.CustomerParser>()
                .ForMember(x => x.Customer, a => a.Ignore())
              // .IncludeAllDerived()
                .ReverseMap();
            CreateMap<ParseFileExtention, Core.Entities.Parsers.ParseFileExtention>()
                .ForMember(x => x.Parsers, a => a.Ignore())
               //  .IncludeAllDerived()
                .ReverseMap();

            CreateMap<Parser, Core.Entities.Parsers.Parser>()
                .ForMember(x => x.CustomerParsers, a => a.Ignore())
               //  .IncludeAllDerived()
                .ReverseMap();
        }
    }
}
