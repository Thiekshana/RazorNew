﻿using Microsoft.AspNetCore.Mvc;
using Razor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor.Interfaces
{
    public interface IProjectRepository
    {
        Task<ActionResult<IEnumerable<Project>>> GetProjectRecords();
        Task<ActionResult<int>> SaveProjectRecords(Project project);
    }
}
