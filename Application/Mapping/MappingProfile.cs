﻿using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateStudentDTO, Student>();

            CreateMap<UpdateStudentDTO, Student>();
            CreateMap<FavouriteBookDTO, FavouriteBook>();
        }
    }
}