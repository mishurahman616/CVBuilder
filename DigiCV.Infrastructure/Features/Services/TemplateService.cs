using DigiCV.Application;
using DigiCV.Application.Features.Training.Services;
using DigiCV.Domain.Entities;
using DigiCV.Infrastructure.Features.Exceptions;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DigiCV.Infrastructure.Features.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public TemplateService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateTemplate(string name, string imageName, bool isActive)
        {
            if (_unitOfWork.ResumeTemplates.IsDuplicateName(name, null))
                throw new DuplicateNameException("Template name is duplicate");

            ResumeTemplate resumeTemplate = new ResumeTemplate()
            {
               Name = name,
               ImageName= imageName,
               IsActive = isActive
            };

            _unitOfWork.ResumeTemplates.Add(resumeTemplate);
            _unitOfWork.Save();
        }                                                   

        public IList<ResumeTemplate> GetTemplates()
        {
            return _unitOfWork.ResumeTemplates.GetAll();
        }
        public ResumeTemplate GetTemplateById(Guid Id)
        {
            return _unitOfWork.ResumeTemplates.GetById(Id);

        }

    }
}
