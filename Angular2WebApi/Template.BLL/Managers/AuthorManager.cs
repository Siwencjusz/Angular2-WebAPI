﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commons.DTOs;
using Commons.DTOs.BaseDto;
using Commons.Entities;
using Commons.Entities.BaseEntity;
using Commons.Interfaces.Repository.baseRepository;
using Template.BLL.Managers.BaseManager;

namespace Template.BLL.Managers
{
    public class AuthorManager<AuthorDto> : BaseManager<AuthorDto> where AuthorDto : BaseDto
    {
        public AuthorManager(IBaseRepository<BaseEntity, BaseDto> repository) : base(repository)
        {
        }
    }
}
