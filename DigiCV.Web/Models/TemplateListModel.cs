using DigiCV.Application.Features.Training.Services;
using DigiCV.Domain.Entities;

namespace DigiCV.Web.Models
{
    public class TemplateListModel
    {
        private readonly ITemplateService _templateService;
        public Guid? ResumeId { get; set; }
        public Guid? SelectedTemplateId { get; set; }
        public TemplateListModel()
        {

        }
        public TemplateListModel(ITemplateService templateService)
        {
            _templateService= templateService;
        }

        public IList<ResumeTemplate> GetPopularTemplates()
        {
            return _templateService.GetTemplates();
        }

    }
}
