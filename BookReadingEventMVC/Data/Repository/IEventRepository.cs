using BookReadingEventMVC.Models.ViewModels;
using System.Collections.Generic;

namespace BookReadingEventMVC.Data.Repository
{
    public interface IEventRepository
    {
        void CreateEvent(EventViewModel eventDTO);
        void DeleteEvent(int id);
        EventViewModel EditEvent(int? id);
        List<EventViewModel> EventsInvited(int id);
        List<CommentViewModel> GetAllComments();
        EventViewModel GetDetails(int id);
        List<EventViewModel> GetEvent();
        List<EventViewModel> MyEvents(int? id);
        void SaveComment(CommentViewModel commentDTO);
        void SaveEvent(EventViewModel eventDTO);
    }
}