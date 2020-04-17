using System;

namespace WebUI.ViewModels.AttachmentsModel
{
    public class AttachmentViewModel
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public DateTime DateUploaded { get; set; }
        public string Path { get; set; }
    }
}