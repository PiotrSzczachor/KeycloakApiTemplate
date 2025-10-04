using Models.Domain;
using Models.DTOs;

namespace Application.Interfaces
{
    public interface IGenerateDocumentsService
    {
        string GenerateCertificateHtml(ParticipantDto participant, EventDto @event);
    }
}
