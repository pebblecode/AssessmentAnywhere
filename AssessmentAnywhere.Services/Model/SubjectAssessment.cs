﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentAnywhere.Services.Model
{
    public class SubjectAssessment
    {
        public string Subject{ get; set; }

        public List<Guid> AssessmentIds { get; set; }
    }
}