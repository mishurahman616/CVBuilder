namespace DigiCV.Web.Models.PDF
{
    public interface IPdfGenerationService
    {
        byte[] GeneratePdf(PdfCreateModel createModel);
    }

}
