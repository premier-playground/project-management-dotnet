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
    public class ProjectMapper
    {

        private MapperConfiguration configuration { get; set; }

        public ProjectMapper() {
            this.configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Project, ProjectDTO>();
                cfg.CreateMap<ProjectDTO, Project>();
            });
        }


        public ProjectDTO MapToProjectDTO(Project project)
        {
            return configuration.CreateMapper().Map<ProjectDTO>(project);
        }


        public Project MapFromProjectDTO(ProjectDTO projectDTO)
        {
            return configuration.CreateMapper().Map<Project>(projectDTO);
        }
    }
}
