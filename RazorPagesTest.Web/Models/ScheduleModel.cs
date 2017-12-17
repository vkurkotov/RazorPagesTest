using System;
using System.ComponentModel.DataAnnotations;
using RazorPagesTest.DataLayer.Models;

namespace RazorPagesTest.Web.Models
{
    public class ScheduleModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string PublicSchedule { get; set; }

        [Display(Name = "Public Schedule Size (bytes)")]
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public long PublicScheduleSize { get; set; }

        public string PrivateSchedule { get; set; }

        [Display(Name = "Private Schedule Size (bytes)")]
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public long PrivateScheduleSize { get; set; }

        [Display(Name = "Uploaded (UTC)")]
        [DisplayFormat(DataFormatString = "{0:F}")]
        public DateTime UploadDt { get; set; }

        public static ScheduleModel FromSchedule(Schedule schedule)
        {
            return new ScheduleModel
            {
                Id = schedule.Id,
                Title = schedule.Title,
                PublicSchedule = schedule.PublicSchedule,
                PublicScheduleSize = schedule.PublicScheduleSize,
                PrivateSchedule = schedule.PrivateSchedule,
                PrivateScheduleSize = schedule.PrivateScheduleSize,
                UploadDt = schedule.UploadDt
            };
        }

        public Schedule ToSchedule()
        {
            return new Schedule
            {
                Id = Id,
                Title = Title,
                PublicSchedule =  PublicSchedule,
                PublicScheduleSize = PublicScheduleSize,
                PrivateSchedule = PrivateSchedule,
                PrivateScheduleSize = PrivateScheduleSize,
                UploadDt = UploadDt
            };
        }
    }
}