﻿using Adams.RespositoryService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NAVIAIServices.RepositoryService;
using NAVIAIServices.RepositoryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Server.Controllers
{
    [ApiController]
    [Route("")]
    [Authorize(Policy = PolicyNames.MemberOrAdmin)]
    public class ProjectController : ControllerBase
    {
        IRepositoryService _repositoryService;
        private readonly AppDbContext _appDbContext;
        private string _projectDbRoot;

        public ProjectController(AppDbContext appDbContext, IRepositoryService repositoryService, IConfiguration configuration)
        {
            _projectDbRoot = configuration.GetValue<string>("ProjectDbRoot");
            _appDbContext = appDbContext;
            _repositoryService = repositoryService;
        }

        [HttpGet("projects")]
        public ActionResult GetAllProject()
        {
            var projectInfos = _appDbContext.ProjectInfos.AsQueryable().ToList();
            var projects = projectInfos.Select(x => _repositoryService.GetProjectService(x.DbPath, DBType.LiteDB).Entity).Where(x => x != null).ToList();
            return Ok(projects);
        }

        [HttpGet("projects/{id}")]
        public ActionResult<Project> GetProject(string id)
        {
            var dbpath = _appDbContext.ProjectInfos.Where(x => x.EntityId == id)
                                                    .FirstOrDefault()
                                                    .DbPath;

            var project = _repositoryService.GetProjectService(dbpath, DBType.LiteDB);
            var entity = project.Entity;
            return entity;
        }

        [HttpPost("projects")]
        public ActionResult CreateProject([FromBody] CreateProject createProject)
        {
            var entity = new Project(
                createProject.AIType,
                createProject.Name,
                createProject.Description
                );

            var dbpath = System.IO.Path.Combine(_projectDbRoot, entity.Id + ".db");
            var projectInfo = new ProjectInfo(entity.Id, dbpath);
            _appDbContext.ProjectInfos.Add(projectInfo);
            _appDbContext.SaveChanges();

            var project = _repositoryService.CreateProjectService(dbpath, DBType.LiteDB, entity);
            return Ok(project.Entity);
        }
    }
}
