using AutoMapper;
using ProjectManagement.Domain.DTO;
using ProjectManagement.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.Mappers
{
    public class CustomMapper
    {

        private IMapper _mapper;

        public CustomMapper() {
            MapperConfiguration configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Project, ReturnProjectDTO>();
                cfg.CreateMap<StudentProjectAssociation, ReturnStudentProjectAssociationDTO>();
                cfg.CreateMap<Professor, ReturnProfessorDTO>();
                cfg.CreateMap<ReturnProfessorDTO, Professor>();
                cfg.CreateMap<Student, ReturnStudentDTO>();
            });
            this._mapper = configuration.CreateMapper();
        }


        public T2 Map<T1, T2>(T1 entity)
        {
            return _mapper.Map<T2>(entity);
        }
    }
}
