using Models.Domain;
using Models.DTOs;

namespace Application.Interfaces
{
    public interface IGenerateDocumentsService
    {
        string GenerateCertificateHtml(ParticipantDto participant, EventDto @event);
        string GenerateReportHtml(List<ParticipantDto> participant, List<EventDto> @events);
        byte[] GenerateCertificatePdf(string html);
    }
}
