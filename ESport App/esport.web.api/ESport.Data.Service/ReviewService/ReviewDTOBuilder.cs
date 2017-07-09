using ESport.Data.Commons;
using ESport.Data.Entities;

namespace ESport.Data.Service
{
    public class ReviewDTOBuilder : IDTOBuilder<ReviewDTO, Review>
    {
        public ReviewDTO buildDTO(Review entity)
        {
            ReviewDTO dto = new ReviewDTO();
            dto.Description = entity.Description;
            dto.Points = entity.Points;
            dto.UserId = entity.User.UserId;
            return dto;
        }
    }
}
