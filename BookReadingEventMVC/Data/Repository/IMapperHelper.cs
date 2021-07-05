using AutoMapper;

namespace BookReadingEventMVC.Data.Repository
{
    public interface IMapperHelper
    {
        IMapper getMapperEvent();
        IMapper getMapperEventView();
        IMapper getMapperComment();
        IMapper getMapperCommentView();
    }
}