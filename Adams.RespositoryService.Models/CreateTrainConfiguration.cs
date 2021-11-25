using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RespositoryService.Models
{
    public class CreateTrainConfiguration
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Width { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public int BatchSize { get; set; }
        [Required]
        public string PretrainModelPath { get; set; }
        [Required]
        public int MaxIteration { get; set; }
        [Required]
        public int StepCount { get; set; }
        [Required]
        public double BaseLearningRate { get; set; }
        [Required]
        public double Gamma { get; set; }
        [Required]
        public bool UseCacheMemory { get; set; }
        [Required]
        public int GPUIndex { get; set; }
        [Required]
        public bool SaveBestPosition { get; set; }
        [Required]
        public double SavingPercentage { get; set; }

        public CreateTrainConfiguration()
        {

        }
    }
}
