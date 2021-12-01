﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Models
{
    public class CreateDataset
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Type { get; set; }

        public CreateDataset(string name, string description, string type)
        {
            Name = name;
            Description = description;
            Type = type;
        }
        public CreateDataset()
        {

        }
    }
}