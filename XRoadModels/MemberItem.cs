﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XRoadModels
{
    public class MemberItem
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }
}
