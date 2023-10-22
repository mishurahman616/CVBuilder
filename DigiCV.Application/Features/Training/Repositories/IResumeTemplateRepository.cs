using DigiCV.Domain;
using DigiCV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DigiCV.Application.Features.Training.Repositories
{
    public interface IResumeTemplateRepository : IRepositoryBase<ResumeTemplate, Guid>
    {
        bool IsDuplicateName(string name, Guid? id);
    }
}
