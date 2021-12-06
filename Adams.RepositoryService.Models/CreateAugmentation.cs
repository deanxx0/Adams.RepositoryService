using NAVIAIServices.RepositoryService.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Models
{
    public class CreateAugmentation
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public bool Mirror { get; set; }
        [Required]
        public bool Flip { get; set; }
        [Required]
        public bool Rotation90 { get; set; }

        [Required]
        public double Zoom { get; set; }
        [Required]
        public double Shift { get; set; }
        [Required]
        public double Tilt { get; set; }
        [Required]
        public double Rotation { get; set; }
        [Required]
        public BorderModes BorderMode { get; init; }
        [Required]
        public double Contrast { get; set; }
        [Required]
        public double Brightness { get; set; }
        [Required]
        public double Shade { get; set; }
        [Required]
        public double Hue { get; set; }
        [Required]
        public double Saturation { get; set; }
        [Required]
        public double Noise { get; set; }
        [Required]
        public double Smoothing { get; set; }
        [Required]
        public double ColorNoise { get; set; }
        [Required]
        public double PartialFocus { get; set; }
        [Required]
        public double Probability { get; set; }
        [Required]
        public int RandomCount { get; set; }

        public CreateAugmentation()
        {

        }
    }
}
