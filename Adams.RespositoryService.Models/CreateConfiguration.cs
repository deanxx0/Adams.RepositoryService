using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RespositoryService.Models
{
    public class CreateConfiguration
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int BatchSize { get; set; }
        public string PretrainModelPath { get; set; }
        public int MaxIteration { get; set; }
        public int StepCount { get; set; }
        public double BaseLearningRate { get; set; }
        public double Gamma { get; set; }
        public bool UseCacheMemory { get; set; }
        public int GPUIndex { get; set; }
        public bool SaveBestPosition { get; set; }
        public double SavingPercentage { get; set; }

        public CreateConfiguration()
        {

        }
    }
}
