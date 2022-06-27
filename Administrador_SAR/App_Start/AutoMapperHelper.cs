using Administrador_SAR.DBContext;
using Administrador_SAR.Models.Account;
using Administrador_SAR.Models.Evidences;
using Administrador_SAR.Models.Reports;
using Administrador_SAR.Models.UserWorkPlace;
using Administrador_SAR.Models.VisitFlash;
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
            //Report view
            Mapper.CreateMap<Reports, ReportResponseViewModel>()
                .ForMember(dest => dest.Account,
                            opt => opt.MapFrom(src => src.Accounts.FirstName + " " + src.Accounts.LastName))
                .ForMember(dest => dest.Factor,
                            opt => opt.MapFrom(src => src.Factors.Description))
                .ForMember(dest => dest.PositionId,
                            opt => opt.MapFrom(src => src.Accounts.PositionId))
                .ForMember(dest => dest.Position,
                            opt => opt.MapFrom(src => src.Accounts.Position.Description))
                .ForMember(dest => dest.Killer,
                            opt => opt.MapFrom(src => src.Killers.Name))
                .ForMember(dest => dest.Situation,
                            opt => opt.MapFrom(src => src.Situations.Description))
                .ForMember(dest => dest.Status,
                            opt => opt.MapFrom(src => src.StatusReports.Description))
                .ForMember(dest => dest.WorkPlace,
                            opt => opt.MapFrom(src => src.WorkPlaces.Name))
                .ForMember(dest => dest.CountryId,
                            opt => opt.MapFrom(src => src.WorkPlaces.CountryId))
                .ForMember(dest => dest.WorkPlaceId,
                            opt => opt.MapFrom(src => src.WorkPlaces.WorkPlaceId));

            Mapper.CreateMap<Evidences, EvidenceResponseViewModel>();
            //Account Views
            Mapper.CreateMap<Accounts, AccountResponseViewModel>()
                .ForMember(dest => dest.Country,
                            opt => opt.MapFrom(src => src.Countries.Name));
            //WorkPlaces
            Mapper.CreateMap<WorkPlaces, WorkPlaceResponseViewModel>()
                .ForMember(dest => dest.Country,
                            opt => opt.MapFrom(src => src.Countries.Name));
            //Reporte Flash
            Mapper.CreateMap<VisitFlashReports, VisitFlashViewModelResponse>()
                .ForMember(dest => dest.Account,
                            opt => opt.MapFrom(src => src.Accounts.FirstName + " " + src.Accounts.LastName))
                .ForMember(dest => dest.Name,
                            opt => opt.MapFrom(src => src.Name + " " + src.LastName))
                .ForMember(dest => dest.WorkPlace,
                            opt => opt.MapFrom(src => src.WorkPlaces.Name));

            //UserWorkplace
            Mapper.CreateMap<UserWorkPlaces, UserWorkPlaceResponse>()
                .ForMember(dest => dest.UserName,
                            opt => opt.MapFrom(src => src.Accounts.FirstName + " " + src.Accounts.LastName))
                .ForMember(dest => dest.WorkPlace,
                            opt => opt.MapFrom(src => src.WorkPlaces.Name));
        }
    }
}