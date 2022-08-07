using AutoMapper;
using App.Models;
using App.ViewModel;

namespace App.Mapping {


    public class MappingProfile : Profile {

        public MappingProfile()
        {
            CreateMap<User,RegisterUserViewModel>()
            .ForMember(des=>des.FirstName,opts=>opts.MapFrom(src=>src.FirstName))
            .ForMember(des=>des.LastName,opts=>opts.MapFrom(src=>src.LastName))
            .ForMember(des=>des.EmailAddress,opts=>opts.MapFrom(src=>src.EmailAddress))
            .ForMember(des=>des.Password,opts=>opts.MapFrom(src=>src.Password))
            .ReverseMap();

            CreateMap<User,LoginViewModel>()
            .ForMember(dest=>dest.Email,opts=>opts.MapFrom(src=>src.EmailAddress))
            .ForMember(dest=>dest.Password,opts=>opts.MapFrom(src=>src.Password))
            .ReverseMap();

            CreateMap<User,SalatyProfileViewModel>()
            .ForMember(dest=>dest.FirstName,opts=>opts.MapFrom(src=>src.FirstName))
            .ForMember(dest=>dest.LastName,opts=>opts.MapFrom(src=>src.LastName))
            .ForMember(dest=>dest.EmailAddress,opts=>opts.MapFrom(src=>src.EmailAddress))
            .ForMember(dest=>dest.Salahs,opts=>opts.MapFrom(src=>src.Salahs))
            .ReverseMap();


            CreateMap<Salah,SalahAddViewModel>()
            .ForMember(dest=>dest.Name,opt=>opt.MapFrom(src=>src.Name))
            .ForMember(dest=>dest.IsPrayed,opt=>opt.MapFrom(src=>src.IsPrayed))
            .ForMember(dest=>dest.Tasbeeh,opt=>opt.MapFrom(src=>src.Tasbeeh))
            .ReverseMap();


        }

    }






}