using DigiCV.Domain.Entities;
using DigiCV.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiCV.Application.Features.Training.Services
{
    public interface ITemplateService
    {
        public IList<ResumeTemplate> GetTemplates();
        void CreateTemplate(string name, string imageName, bool isActive);
        ResumeTemplate GetTemplateById(Guid Id);
    }
}
