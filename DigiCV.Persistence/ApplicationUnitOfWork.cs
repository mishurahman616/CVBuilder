using DigiCV.Application;
using DigiCV.Application.Features.Training.Repositories;
using DigiCV.Persistence.Training.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DigiCV.Persistence
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork 
    {
        public IResumeRepository Resumes { get; private set; }
        public ISkillRepository Skills { get; private set; }
        public IResumeTemplateRepository ResumeTemplates { get; private set; }
        public IEmailRepository Emails { get; private set; }
        public IContactRepository Contacts { get; private set; }

        public ApplicationUnitOfWork(IApplicationDbContext dbContext,
            IResumeRepository resumeRepository,
            ISkillRepository skillRepository,
            IResumeTemplateRepository resumeTemplateRepository,
            IEmailRepository emailRepository,
            IContactRepository contactRepository
            ) : base((DbContext)dbContext)
        {
            Resumes = resumeRepository;
            Skills = skillRepository;
            ResumeTemplates = resumeTemplateRepository;
            Emails = emailRepository;
            Contacts = contactRepository;
        }
    }
}
