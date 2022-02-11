using Administrador_SAR.DBContext;
using Administrador_SAR.Models.Account;
using Administrador_SAR.Models.Reports;
using Administrador_SAR.Models.WorkPlace;
using AutoMapper;

namespace Administrador_SAR.App_Start
{
    public class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            //SOURCE - DESTINATION

            Mapper.CreateMap<CreateWorkPlaceRequestModel, WorkPlaces>();
            Mapper.CreateMap<Reports, ReportResponseViewModel>()
                .ForMember(dest => dest.Account,
                            opt => opt.MapFrom(src => src.Accounts.FirstName + " " + src.Accounts.LastName))
                .ForMember(dest => dest.Factor,
                            opt => opt.MapFrom(src => src.Factors.Description))
                .ForMember(dest => dest.Killer,
                            opt => opt.MapFrom(src => src.Killers.Name))
                .ForMember(dest => dest.Situation,
                            opt => opt.MapFrom(src => src.Situations.Description))
                .ForMember(dest => dest.Status,
                            opt => opt.MapFrom(src => src.StatusReports.Description))
                .ForMember(dest => dest.WorkPlace,
                            opt => opt.MapFrom(src => src.WorkPlaces.Name));
            //Account Views
            Mapper.CreateMap<Accounts, AccountResponseViewModel>()
                .ForMember(dest => dest.Country,
                            opt => opt.MapFrom(src => src.Countries.Name));
            Mapper.CreateMap<WorkPlaces, WorkPlaceResponseViewModel>()
                .ForMember(dest => dest.Country,
                            opt => opt.MapFrom(src => src.Countries.Name));
        }
    }
}