using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Entities.Enums;
using ProjectManagement.Entities.Models;
using ProjectManagement.Repositories.Contexts;

namespace ProjectManagement.Repositories.Repositories
{
    public class ProjectRepository: IProjectRepository
    {
        private readonly DbContext _context;

        public ProjectRepository(DbContext context)
        {
            this._context = context;
        }

        public Project InsertProject(Project project)
        {
            Project newProject = null;

            using (var localDbContext = new LocalDBContext())
            {
                var professorId = project.Coordinator.Id;
                project.Coordinator = null;
                newProject = localDbContext.Projects.Add(project);
                localDbContext.SaveChanges();

                newProject.Coordinator = localDbContext.Professors.FirstOrDefault(p => p.Id == professorId);
                localDbContext.SaveChanges();
            }

            return newProject;
        }

        public Project UpdateProject(Project project, int projectId)
        {
            Project newProject = null;
            using (var context = new LocalDBContext())
            {
                var retrievedProject = context.Projects.FirstOrDefault(p => p.Id == projectId);
                retrievedProject.Name = project.Name;
                retrievedProject.Description = project.Description;

                Professor coordinator = context.Professors.FirstOrDefault(p => p.Id == project.Coordinator.Id);
                retrievedProject.Coordinator = coordinator;
                context.SaveChanges();
                newProject = retrievedProject;
            }
            return newProject;
        }

        public void DeleteProject(int projectId)
        {
            using (var context = new LocalDBContext())
            {
                var retrievedProject = context.Projects.FirstOrDefault(p => p.Id == projectId);
                if (retrievedProject == null) return;
                context.Projects.Remove(retrievedProject);
                context.SaveChanges();
            }
        }

        public IEnumerable<Project> GetAllProjects()
        {
            List<Project> projects = new List<Project>();
            using (var localDbContext = new LocalDBContext())
            {
                projects = localDbContext.Projects.Include(p => p.Coordinator).ToList();
            }
            return projects;
        }

        public Project GetProjectById(int id)
        {
            Project project = null;
            using (var context = new LocalDBContext())
            {
                project = context.Projects.Include(p => p.Coordinator).FirstOrDefault(p => p.Id == id);
            }
            return project;
        }

        public Project AddStudent(int projectId, string studentId, Level level)
        {
            Project project = null;
            using (var context = new LocalDBContext())
            {
                var retrievedProject = context.Projects.FirstOrDefault(p => p.Id == projectId);
                if (retrievedProject == null) return null;

                var retrievedStudent = context.Students.FirstOrDefault(s => s.Id == studentId);
                if (retrievedStudent == null) return null;

                //var createdStudentProjectAssociation = context.StudentProjectAssociations.Add(new StudentProjectAssociation(level));
                //context.SaveChanges();

                //createdStudentProjectAssociation.Project = retrievedProject;
                //createdStudentProjectAssociation.Student = retrievedStudent;
                //context.SaveChanges();

                //retrievedProject.StudentProjectAssociations.Add(createdStudentProjectAssociation);
                retrievedProject.StudentProjectAssociations.Add(new StudentProjectAssociation(level) { Student = retrievedStudent });
                project = context.Projects
                    .Include(p => p.Coordinator)
                    .Include(p => p.StudentProjectAssociations)
                    .Include(p => p.StudentProjectAssociations.Select(spa => spa.Student))
                    .FirstOrDefault(p => p.Id == retrievedProject.Id);

                context.SaveChanges();
            }

            return project;
        }

        public Project RemoveStudent(int projectId, string studentId)
        {
            Project project = null;
            using (var context = new LocalDBContext())
            {
                var retrievedProject = context.Projects.FirstOrDefault(p => p.Id == projectId);
                if (retrievedProject == null) return null;

                var retrievedStudent = context.Students.FirstOrDefault(s => s.Id == studentId);
                if (retrievedStudent == null) return null;

                var studentProjectAssociation =
                    context.StudentProjectAssociations.FirstOrDefault(spa => 
                        spa.Student.Id == retrievedStudent.Id);
                if (studentProjectAssociation == null) return null;

                context.StudentProjectAssociations.Remove(studentProjectAssociation);
                retrievedProject.StudentProjectAssociations.Remove(studentProjectAssociation);
                project = context.Projects
                    .Include(p => p.Coordinator)
                    .Include(p => p.StudentProjectAssociations)
                    .Include(p => p.StudentProjectAssociations.Select(spa => spa.Student))
                    .FirstOrDefault(p => p.Id == retrievedProject.Id);
                context.SaveChanges();
            }

            return project;
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
